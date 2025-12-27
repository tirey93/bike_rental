import { MainBar } from "../MainBar/MainBar";
import { styled } from '@mui/material/styles';
import { drawerWidth } from "../../consts";
import { Drawer } from "../Drawer/Drawer";

const MainWrapper = styled('div')`
  margin-left: ${drawerWidth}px;
`;

export const Main = () => {

  return ( 
    <>
      <MainBar></MainBar>
      <Drawer></Drawer>      
      <MainWrapper>
        Main Page Content 
      </MainWrapper>
    </>
  );
}