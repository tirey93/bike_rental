import { Button, TextField } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import { bikeApiUrl, stationApiUrl } from "../../../../../consts";
import { useFetch } from "../../../../../hooks/useFetch";
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { useDelete } from "../../../../../hooks/useDelete";
import { BikeAtStation } from "../dtos/BikeAtStation";
import DeleteIcon from '@mui/icons-material/Delete';

type Props = {
  bikeId: number;
}

export const DisplayStation = ({bikeId}: Props) => {
  const { publishSuccess } = useActionDrawer();  
  
  const { data, loading, error } = useFetch<BikeAtStation>(`${stationApiUrl}/bike/${bikeId}/bikeAtStation`);
  const { remove } = useDelete(`${stationApiUrl}/bike`, data?.stationId!); 

  return ( 
    <>
      {loading && <p>Loading station...</p>}
      {error && <p>Error: {error}</p>}
      {data && 
      <Wrapper>
        <FormControlStyled>
          <TextField fullWidth label="Code" value={data.code} disabled />
        </FormControlStyled>
        <FormControlStyled>
          <TextField fullWidth label="Location" value={data.location} disabled />
        </FormControlStyled>
        <FormControlStyled>
          <TextField
            disabled
            fullWidth
            label="Capacity"
            type="number"
            value={data.capacity}
          />
        </FormControlStyled>
        <ConfirmationButtonWrapper $important>
          <Button
            onClick={() => remove(publishSuccess)}
            variant="contained" startIcon={<DeleteIcon />}>{'Delete'}</Button>
        </ConfirmationButtonWrapper>
      </Wrapper>}
    </>
  );
}