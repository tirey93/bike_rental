import { Button, InputLabel, MenuItem, Select } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { useState } from "react";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import { BikeModels } from "../../../../../assets/BikeModels";
import dayjs, { Dayjs } from "dayjs";
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { bikeApiUrl, stationApiUrl } from "../../../../../consts";
import { Bike } from "../dtos/Bike";
import { formatDateOnly, SaveBike } from "../dtos/SaveBike";
import { useCreate } from "../../../../../hooks/useCreate";
import AddBoxIcon from '@mui/icons-material/AddBox';
import { AddBikeToStation } from "../dtos/AddBikeToStation";

type Props = {
  bike: Bike;
}

export const AddStationToBike = ({bike}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const [selectedModel, setSelectedModel] = useState<string>(bike?.model ?? '');
  const [selectedColor, setSelectedColor] = useState<string>(bike?.color ?? '');
  const [date, setDate] = useState<Dayjs | null>(dayjs(bike?.lastServiceDate));
  const { create } = useCreate<AddBikeToStation>(stationApiUrl);

  const handleAdd = () => {
      create({
        externalBikeId: bike.externalId
        }, publishSuccess);
    
  }
  return ( 
    <Wrapper>
      <FormControlStyled>
        <InputLabel id="select-model-label">Model</InputLabel>
        <Select
          id="select-model"
          value={selectedModel}
          label="Model"
          onChange={(e) => setSelectedModel(e.target.value)}>
          {BikeModels.map((model) => (
            <MenuItem key={model.id} value={model.name}>
              {model.name}
            </MenuItem>
          ))}
        </Select>
      </FormControlStyled>
      <ConfirmationButtonWrapper>
          <Button
            disabled={selectedModel === '' || selectedColor === '' || date === null}
            onClick={() => handleAdd()}
            variant="contained" startIcon={<AddBoxIcon />}>Add</Button>
      </ConfirmationButtonWrapper>
    </Wrapper>
  );
}