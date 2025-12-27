import { AppBar, IconButton } from "@mui/material";
import { useAuth } from "../../../hooks/useAuth";
import { StyledToolbar } from "./MainBar.styles";
import LogoutIcon from '@mui/icons-material/Logout';

export const MainBar = () => {
  const { user, signOut } = useAuth();

  return ( 
    <AppBar position="static">
      <StyledToolbar>
        Hello {user}!
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
  );
}