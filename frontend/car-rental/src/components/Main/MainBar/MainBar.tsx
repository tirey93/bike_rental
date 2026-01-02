import { AppBar, IconButton, Tooltip } from "@mui/material";
import { StyledToolbar } from "./MainBar.styles";
import AddIcon from '@mui/icons-material/Add';
import { useContent } from "../Content/ContentContext";
import { ContentEnum } from "../Content/content.enum";
import { DrawerComponent, useActionDrawer } from "../ActionDrawer/ActionDrawerContext";
import { UpsertBike } from "../Content/Bikes/UpsertBike/UpsertBike";
import { UpsertStation } from "../Content/Stations/UpsertStation/UpsertStation";
import { on } from "events";

export const MainBar = () => {
  const { content } = useContent();
  const { openWith } = useActionDrawer();

  const getDescription = () => {
    switch (content) {
      case ContentEnum.BIKES:
        return 'bike';
      case ContentEnum.STATIONS:
        return 'station';
      default:
        return '';
    }
  };

  const getComponent = (): DrawerComponent => {
    switch (content) {
      case ContentEnum.BIKES:
        return UpsertBike;
      case ContentEnum.STATIONS:
        return UpsertStation;
      default:
        throw Error('No component found for content ' + content);
    }
  }

  return ( 
    <AppBar position="static">
      <StyledToolbar>
        <Tooltip title={`Add new ${getDescription()}`}>
          <IconButton
            onClick={() => openWith({name: `Add new ${getDescription()}`, component: getComponent(), props: {edit: false}, onSuccess: () => { console.log('Drawer closed');}})}
            size="large"
            edge="end"
            color="inherit"
            aria-label="open drawer"
            sx={{ ml: 2 }}>
            <AddIcon />
          </IconButton>          
        </Tooltip>
      </StyledToolbar>
    </AppBar>
  );
}