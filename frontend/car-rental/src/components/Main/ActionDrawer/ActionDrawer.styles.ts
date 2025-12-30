import { Drawer, styled } from "@mui/material";
import { actionDrawerWidth } from "../../../consts";

export const ActionDrawerStyled = styled(Drawer)(({ theme }) => ({
  width: actionDrawerWidth,
  flexShrink: 0,
  '& .MuiDrawer-paper': {
    width: actionDrawerWidth,
    boxSizing: 'border-box',
    backgroundColor: theme.palette.background.paper,
  },
}));