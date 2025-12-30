import { useContent } from "./ContentContext";
import { Bikes } from "./Bikes/Bikes";
import { ContentStyled } from "./Content.styles";
import { Stations } from "./Stations/Stations";

export const Content = () => {
  const { content } = useContent();
  
  return ( 
    <ContentStyled>
      {content === 'Bikes' && <Bikes></Bikes>}
      {content === 'Stations' && <Stations></Stations>}
    </ContentStyled>
  );
}