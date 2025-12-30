import { useContent } from "./ContentContext";
import { Bikes } from "./Bikes/Bikes";
import { ContentStyled } from "./Content.styles";
import { Stations } from "./Stations/Stations";

export const Content = () => {
  const { current } = useContent();
  
  return ( 
    <ContentStyled>
      {current === 'Bikes' && <Bikes></Bikes>}
      {current === 'Stations' && <Stations></Stations>}
    </ContentStyled>
  );
}