import { AppBar, Box, IconButton, Toolbar } from "@mui/material";
import LogoutIcon from '@mui/icons-material/Logout';
import styled from "styled-components";
import { useAuth } from "../hooks/useAuth";

const StyledToolbar = styled(Toolbar)`
  display: flex;
  justify-content: flex-end;
`;

export const Main = () => {
  const { signOut } = useAuth();
  return ( 
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <StyledToolbar>
            <IconButton
            onClick={signOut}
            size="large"
            edge="end"
            color="inherit"
            aria-label="open drawer"
            sx={{ ml: 2 }}>
            <LogoutIcon />
          </IconButton>
        </StyledToolbar>
      </AppBar>
    </Box>
  );
}