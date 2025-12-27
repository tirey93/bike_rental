import { Divider, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import { DrawerHeaderWrapper, DrawerStyled } from "./Drawer.styles";
import PedalBikeIcon from '@mui/icons-material/PedalBike';
import { useAuth } from "../../../hooks/useAuth";

export const Drawer = () => {
  const { user } = useAuth();
  
  return ( 
    <div>
      <DrawerStyled 
        variant="permanent" 
        anchor="left"
        sx={{
          
        }}
        open={true}>
        <DrawerHeaderWrapper>Hello {user}!</DrawerHeaderWrapper>
        <Divider />
        <List>
          <ListItem key={'Bikes'} disablePadding>
              <ListItemButton>
                <ListItemIcon>
                  <PedalBikeIcon></PedalBikeIcon>
                </ListItemIcon>
                <ListItemText primary={'Bikes'} />
              </ListItemButton>
            </ListItem>
        </List>
      </DrawerStyled>
    </div>
  );
}