import { AppBar, IconButton, Tooltip } from "@mui/material";
import { StyledToolbar } from "./MainBar.styles";
import AddIcon from '@mui/icons-material/Add';
import { useContent } from "../Content/ContentContext";
import { ContentEnum } from "../Content/content.enum";
import { useActionDrawer } from "../ActionDrawer/ActionDrawerContext";
import { ActionDrawerMode } from "../ActionDrawer/enums/ActionDrawerMode";

export const MainBar = () => {
  const { content } = useContent();
  const { openActionDrawer } = useActionDrawer();

  const getContentType = () => {
    switch (content) {
      case ContentEnum.BIKES:
        return 'bike';
      case ContentEnum.STATIONS:
        return 'station';
      default:
        return '';
    }
  };

  return ( 
    <AppBar position="static">
      <StyledToolbar>
        <Tooltip title={`Add new ${getContentType()}`}>
          <IconButton
            onClick={() => openActionDrawer(ActionDrawerMode.EDITING)}
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