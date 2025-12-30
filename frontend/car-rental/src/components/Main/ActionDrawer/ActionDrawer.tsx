import { Divider } from "@mui/material";
import { DrawerHeaderWrapper } from "../Drawer/Drawer.styles";
import { ActionDrawerStyled } from "./ActionDrawer.styles";
import { useActionDrawer } from "./ActionDrawerContext";
import { useContent } from "../Content/ContentContext";
import { ContentEnum } from "../Content/content.enum";
import { ActionDrawerMode } from "./enums/ActionDrawerMode";

export const ActionDrawer = () => {
  const {open, mode, closeActionDrawer} = useActionDrawer();
  const { content } = useContent();
  return ( 
    <ActionDrawerStyled 
      variant="temporary" 
      anchor="right"
      onClose={closeActionDrawer}
      open={open}>
      <DrawerHeaderWrapper>
      </DrawerHeaderWrapper>
      <Divider />
      {content === ContentEnum.BIKES && (
        <div>
          Bikes form
        </div>
      )}
      {content === ContentEnum.STATIONS && (
        <div>
          Stations form
        </div>
      )}
    </ActionDrawerStyled>
  );
}