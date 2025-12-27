import { PropsWithChildren } from "react";
import { ErrorProvider } from "../../contexts/ErrorContext.";
import { AuthProvider } from "../../contexts/AuthContext";
import { ThemeProvider, createTheme } from '@mui/material/styles'; // I tutaj!



export const AppProviders = ({children}: PropsWithChildren) => {
  const customTheme = createTheme({
    palette: {
      primary: {
        main: '#1976d2',
        contrastText: 'white',
      },
      background: {
        paper: '#f5f5f5',
      },
    },
  });

  return (
    <ThemeProvider theme={customTheme}>
      <ErrorProvider>
        <AuthProvider>
          {children}
        </AuthProvider>
      </ErrorProvider>
    </ThemeProvider>
  );
};