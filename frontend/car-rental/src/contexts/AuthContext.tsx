import React, { PropsWithChildren, useContext, useEffect, useState } from 'react';

const AuthContext = React.createContext({} as AuthContextType);


export interface AuthContextType {
  user: string | null;
  signIn: (login: string) => void;
  signOut: () => void;
}

export const AuthProvider = ({ children }: PropsWithChildren) => {
  const [user, setUser] = useState<string | null>(null);

  useEffect(() => {
    const user = localStorage.getItem('user');
    if (user) {
      setUser(user);
    }
  }, []);

  const signIn = async (login: string) => {
    localStorage.setItem('user', login);
    setUser(login);
  };

  const signOut = () => {
    setUser(null);
    localStorage.removeItem('user');
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