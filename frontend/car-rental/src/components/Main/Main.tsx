import { MainBar } from "./MainBar/MainBar";
import { Drawer } from "./Drawer/Drawer";
import { ContentProvider } from "./contexts/ContentContext";
import { Content } from "./Content/Content";



export const Main = () => {
  return ( 
    <>
      <ContentProvider>
        <MainBar></MainBar>
        <Drawer></Drawer>
        <Content></Content>
      </ContentProvider> 
    </>
  );
}