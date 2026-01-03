import { Button } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import SaveIcon from '@mui/icons-material/Save';
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { stationApiUrl } from "../../../../../consts";
import { Station } from "../dtos/Station";
import { useDelete } from "../../../../../hooks/useDelete";
import { DeleteStationConfirmationStyled } from "./DeleteStation.styled";

type Props = {
  station: Station;
}

export const DeleteStation = ({station}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const { remove } = useDelete(stationApiUrl, station.id);

  return (
    <Wrapper>
      <FormControlStyled>
        <DeleteStationConfirmationStyled>
          You are about to delete station {station.code}.<br></br>
          Are you sure you want to continue?
        </DeleteStationConfirmationStyled>
      </FormControlStyled>
      <ConfirmationButtonWrapper $important>
        <Button
          onClick={() => remove(publishSuccess)}
          variant="contained" startIcon={<SaveIcon />}>{'Delete'}</Button>
      </ConfirmationButtonWrapper>
    </Wrapper>
  );
}
