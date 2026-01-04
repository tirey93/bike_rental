import { useContent } from "./ContentContext";
import { Bikes } from "./Bikes/Bikes";
import { ContentStyled } from "./Content.styles";
import { Stations } from "./Stations/Stations";
import { ContentEnum } from "./content.enum";
import { useSearchParams } from "react-router-dom";

export const Content = () => {
  const { content } = useContent();
  
  return ( 
    <ContentStyled>
      {content === ContentEnum.BIKES && <Bikes></Bikes>}
      {content === ContentEnum.STATIONS && <Stations></Stations>}
    </ContentStyled>
  );
}