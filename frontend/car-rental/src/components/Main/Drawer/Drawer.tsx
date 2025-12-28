import { Divider, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import { DrawerHeaderWrapper, DrawerStyled } from "./Drawer.styles";
import PedalBikeIcon from '@mui/icons-material/PedalBike';
import LocalGasStationIcon from '@mui/icons-material/LocalGasStation';
import { useAuth } from "../../../contexts/AuthContext";
import { useContent } from "../contexts/ContentContext";
import { ContentEnum } from "../contexts/enums/content.enum";

export const Drawer = () => {
  const { user } = useAuth();
  const { change } = useContent();
  
  return ( 
    <DrawerStyled 
      variant="permanent" 
      anchor="left"
      sx={{
        
      }}
      open={true}>
      <DrawerHeaderWrapper>Hello {user}!</DrawerHeaderWrapper>
      <Divider />
      <List>
        <ListItem key={ContentEnum.BIKES} disablePadding>
            <ListItemButton onClick={() => change(ContentEnum.BIKES)}>
              <ListItemIcon>
                <PedalBikeIcon></PedalBikeIcon>
              </ListItemIcon>
              <ListItemText primary={ContentEnum.BIKES} />
            </ListItemButton>
          </ListItem>
          <ListItem key={ContentEnum.STATIONS} disablePadding>
            <ListItemButton onClick={() => change(ContentEnum.STATIONS)}>
              <ListItemIcon>
                <LocalGasStationIcon></LocalGasStationIcon>
              </ListItemIcon>
              <ListItemText primary={ContentEnum.STATIONS} />
            </ListItemButton>
          </ListItem>
      </List>
    </DrawerStyled>
  );
}