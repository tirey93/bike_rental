import { MainBar } from "./MainBar/MainBar";
import { Drawer } from "./Drawer/Drawer";
import { ContentStyled } from "./Main.styles";



export const Main = () => {

  return ( 
    <>
      <MainBar></MainBar>
      <Drawer></Drawer>      
      <ContentStyled>
        Main Page Content 
      </ContentStyled>
    </>
  );
}