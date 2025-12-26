import { Divider, Drawer } from "@mui/material";
import { MainBar } from "../components/MainBar/MainBar";
import { styled } from '@mui/material/styles'; // Zmiana tutaj!


const drawerWidth = 240;

const MainWrapper = styled('div')`
  margin-left: ${drawerWidth}px;
`;

const DrawerHeader = styled('div')(({ theme }) => ({
  display: 'flex',
  alignItems: 'center',
  padding: theme.spacing(0, 1),
  ...theme.mixins.toolbar,
  justifyContent: 'flex-end',
}));

export const Main = () => {

  return ( 
    <>
      <MainBar></MainBar>
      <Drawer 
        variant="permanent" 
        anchor="left"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          '& .MuiDrawer-paper': {
            width: drawerWidth,
            boxSizing: 'border-box',
          },
        }}
        open={true}>
        <DrawerHeader></DrawerHeader>
        <Divider />
        <div>Side Navigation</div>
      </Drawer>
      <MainWrapper>
        Main Page Content 
      </MainWrapper>
    </>
  );
}