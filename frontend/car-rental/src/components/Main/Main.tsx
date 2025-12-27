import { MainBar } from "./MainBar/MainBar";
import { Drawer } from "./Drawer/Drawer";
import { Content } from "./Main.styles";



export const Main = () => {

  return ( 
    <>
      <MainBar></MainBar>
      <Drawer></Drawer>
      <Content>
        Main Page Content 
      </Content>
    </>
  );
}