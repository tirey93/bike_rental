import { ThemeProvider } from "styled-components";
import { PropsWithChildren } from "react";
import { theme } from "../assets/theme";
import { ErrorProvider } from "../hooks/useError.";
import { AuthProvider } from "../hooks/useAuth";


export const AppProviders = ({children}: PropsWithChildren) => {
    return ( 
        <ThemeProvider theme={theme}>
          <ErrorProvider>
            <AuthProvider>
              {children}
            </AuthProvider>
          </ErrorProvider>
        </ThemeProvider>
    );
};