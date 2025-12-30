import { Divider, IconButton, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Tooltip } from "@mui/material";
import { DrawerHeaderWrapper, DrawerStyled, ListItemButtonStyled } from "./Drawer.styles";
import PedalBikeIcon from '@mui/icons-material/PedalBike';
import LocalGasStationIcon from '@mui/icons-material/LocalGasStation';
import { useAuth } from "../../../contexts/AuthContext";
import { useContent } from "../Content/ContentContext";
import { ContentEnum } from "../Content/content.enum";
import LogoutIcon from '@mui/icons-material/Logout';

export const Drawer = () => {
  const { user, signOut } = useAuth();
  const { content, change } = useContent();
  
  return ( 
    <DrawerStyled 
      variant="permanent" 
      anchor="left"
      open={true}>
      <DrawerHeaderWrapper>
        <Tooltip title="Sign Out">
          <IconButton
            onClick={signOut}
            size="large"
            color="inherit"
            aria-label="open drawer">
            <LogoutIcon />
          </IconButton>
        </Tooltip>
        Hello {user}!
      </DrawerHeaderWrapper>
      <Divider />
      <List>
        <ListItem key={ContentEnum.BIKES} disablePadding>
            <ListItemButtonStyled onClick={() => change(ContentEnum.BIKES)} selected={content === ContentEnum.BIKES}>
              <ListItemIcon>
                <PedalBikeIcon></PedalBikeIcon>
              </ListItemIcon>
              <ListItemText primary={ContentEnum.BIKES} />
            </ListItemButtonStyled>
          </ListItem>
          <ListItem key={ContentEnum.STATIONS} disablePadding>
            <ListItemButtonStyled onClick={() => change(ContentEnum.STATIONS)} selected={content === ContentEnum.STATIONS}>
              <ListItemIcon>
                <LocalGasStationIcon></LocalGasStationIcon>
              </ListItemIcon>
              <ListItemText primary={ContentEnum.STATIONS} />
            </ListItemButtonStyled>
          </ListItem>
      </List>
    </DrawerStyled>
  );
}