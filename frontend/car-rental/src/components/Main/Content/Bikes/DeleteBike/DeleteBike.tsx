import { Button } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { bikeApiUrl } from "../../../../../consts";
import { Bike } from "../dtos/Bike";
import { DeleteBikeConfirmationStyled } from "./DeleteBike.styled";
import { useDelete } from "../../../../../hooks/useDelete";
import DeleteIcon from '@mui/icons-material/Delete';

type Props = {
  bike: Bike;
}

export const DeleteBike = ({bike}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const { remove } = useDelete(bikeApiUrl, bike.id); 

  return ( 
    <Wrapper>
      <FormControlStyled>
        <DeleteBikeConfirmationStyled>
          You are about to delete bike {bike.model}.<br></br>
          Are you sure you want to continue?
        </DeleteBikeConfirmationStyled>
      </FormControlStyled>
      <ConfirmationButtonWrapper $important>
          <Button
            onClick={() => remove(publishSuccess)}
            variant="contained" startIcon={<DeleteIcon />}>{'Delete'}</Button>
      </ConfirmationButtonWrapper>
    </Wrapper>
  );
}