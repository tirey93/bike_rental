import { AppBar, IconButton, Tooltip } from "@mui/material";
import { StyledToolbar } from "./MainBar.styles";
import AddIcon from '@mui/icons-material/Add';
import { useContent } from "../contexts/ContentContext";
import { ContentEnum } from "../contexts/enums/content.enum";

export const MainBar = () => {
  const { current } = useContent();

  const getContentType = () => {
    switch (current) {
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