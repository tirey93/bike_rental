import React, { PropsWithChildren, useCallback, useContext, useState } from 'react';

export interface ErrorContextType {
  error: string | null;
  dispatchError: (message: string) => void
}

const ErrorContext = React.createContext({} as ErrorContextType);

export const ErrorProvider = ({ children }: PropsWithChildren) => {
  const [error, setError] = useState<string | null>(null);

  const dispatchError = useCallback((message: string) => {
    setError(message);
    setTimeout(() => {
      setError('');
    }, 7000);
  }, []);

  return <ErrorContext.Provider value={{ error, dispatchError }}>{children}</ErrorContext.Provider>;
};

export const useError = () => {
  const errorContext = useContext(ErrorContext);

  if (!errorContext) {
    throw Error('useAuth needs to be used inside AuthContext');
  }

  return errorContext;
};