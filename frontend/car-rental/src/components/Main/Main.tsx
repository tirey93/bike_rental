import { MainBar } from "./MainBar/MainBar";
import { Drawer } from "./Drawer/Drawer";
import { ContentProvider } from "./Content/ContentContext";
import { Content } from "./Content/Content";
import { ActionDrawerProvider } from "./ActionDrawer/ActionDrawerContext";
import { ActionDrawer } from "./ActionDrawer/ActionDrawer";



export const Main = () => {
  return ( 
    <>
      <ActionDrawerProvider>
        <ContentProvider>
          <MainBar></MainBar>
          <Drawer></Drawer>
          <ActionDrawer></ActionDrawer>
          <Content></Content>
        </ContentProvider> 
      </ActionDrawerProvider>
    </>
  );
}