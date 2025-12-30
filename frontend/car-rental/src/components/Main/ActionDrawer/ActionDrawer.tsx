import { Divider } from "@mui/material";
import { DrawerHeaderWrapper } from "../Drawer/Drawer.styles";
import { ActionDrawerStyled } from "./ActionDrawer.styles";
import { useActionDrawer } from "./ActionDrawerContext";

export const ActionDrawer = () => {
  const {open, node, closeActionDrawer} = useActionDrawer();
  return ( 
    <ActionDrawerStyled 
      variant="temporary" 
      anchor="right"
      onClose={closeActionDrawer}
      open={open}>
      <DrawerHeaderWrapper>
      </DrawerHeaderWrapper>
      <Divider />
      {node}
    </ActionDrawerStyled>
  );
}