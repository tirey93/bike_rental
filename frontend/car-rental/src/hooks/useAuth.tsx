import React, { PropsWithChildren, useContext, useEffect, useState } from 'react';
import axios from 'axios';
import { useError } from './useError.';

const AuthContext = React.createContext({} as AuthContextType);

export interface SignInType {
  login: string;
  password: string;
}
export interface AuthContextType {
  user: string | null;
  signIn: ({login, password}: SignInType) => void;
  signOut: () => void;
}

export const AuthProvider = ({ children }: PropsWithChildren) => {
  const [user, setUser] = useState(null);
  const { dispatchError } = useError();

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      (async () => {
        try {
          const response = await axios.get('/me', {
            headers: {
              authorization: `Bearer ${token}`,
            },
          });
          setUser(response.data);
        } catch (e) {
          console.log(e);
        }
      })();
    }
  }, []);

  const signIn = async ({ login, password }: SignInType) => {
    try {
      const response = await axios.post('/login', {
        login,
        password,
      });
      setUser(response.data);
      localStorage.setItem('token', response.data.token);
    } catch (e) {
      dispatchError('Invalid email or password');
    }
  };

  const signOut = () => {
    setUser(null);
    localStorage.removeItem('token');
  };

  return <AuthContext.Provider value={{ user, signIn, signOut }}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
  const auth = useContext(AuthContext);

  if (!auth) {
    throw Error('useAuth needs to be used inside AuthContext');
  }

  return auth;
};