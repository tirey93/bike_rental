import { ThemeProvider } from "styled-components";
import { PropsWithChildren } from "react";
import { theme } from "../assets/theme";


export const AppProviders = ({children}: PropsWithChildren) => {
    return ( 
        <ThemeProvider theme={theme}>
            {children}
        </ThemeProvider>
    );
};