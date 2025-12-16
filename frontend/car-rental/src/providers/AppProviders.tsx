import { Provider } from "react-redux";
import { theme } from "../assets/theme";
import { ThemeProvider } from "styled-components";
import { PropsWithChildren } from "react";


export const AppProviders = ({children}: PropsWithChildren) => {
    return ( 
        <ThemeProvider theme={theme}>
            {children}
        </ThemeProvider>
    );
};