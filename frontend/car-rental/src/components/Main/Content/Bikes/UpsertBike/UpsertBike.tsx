import { Button, InputLabel, MenuItem, Select } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { useEffect, useState } from "react";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import { BikeModels } from "../../../../../assets/BikeModels";
import { BikeColors } from "../../../../../assets/BikeColors";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import dayjs, { Dayjs } from "dayjs";
import SaveIcon from '@mui/icons-material/Save';
import { SaveButtonWrapper } from "../../../ActionDrawer/styles/SaveButtonWrapper";
import { useSave } from "../../../../../hooks/useSave";
import { bikeApiUrl } from "../../../../../consts";
import { Bike } from "../dtos/Bike";
import { formatDateOnly, SaveBike } from "../dtos/SaveBike";
import { useUpdate } from "../../../../../hooks/useUpdate";

type Props = {
  bike?: Bike;
}

export const UpsertBike = ({bike}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const [selectedModel, setSelectedModel] = useState<string>(bike?.model ?? '');
  const [selectedColor, setSelectedColor] = useState<string>(bike?.color ?? '');
  const [date, setDate] = useState<Dayjs | null>(dayjs(bike?.lastServiceDate));
  const { save } = useSave<SaveBike>(bikeApiUrl);
  const { update } = useUpdate<SaveBike>(bikeApiUrl, bike?.id ?? 0);

  const handleUpsert = () => {
    if (bike) {
      update({
          model: selectedModel, 
          color: selectedColor, 
          lastServiceDate: formatDateOnly(date?.toDate())
        }, publishSuccess);
    } else {
      save({
          model: selectedModel, 
          color: selectedColor, 
          lastServiceDate: formatDateOnly(date?.toDate())
        }, publishSuccess);
    }
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
      <FormControlStyled>
        <InputLabel id="select-color-label">Color</InputLabel>
        <Select
          id="select-color"
          value={selectedColor}
          label="Color"
          onChange={(e) => setSelectedColor(e.target.value)}>
          {BikeColors.map((color) => (
            <MenuItem key={color.id} value={color.name}>
              {color.name}
            </MenuItem>
          ))}
        </Select>
      </FormControlStyled>
      <FormControlStyled>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
          <DatePicker
            label="Last service date"
            value={date}
            onChange={(newValue) => setDate(newValue)}/>
        </LocalizationProvider>
      </FormControlStyled>
      <SaveButtonWrapper>
          <Button
            disabled={selectedModel === '' || selectedColor === '' || date === null}
            onClick={() => handleUpsert()}
            variant="contained" startIcon={<SaveIcon />}>{bike ? 'Update' : 'Save'}</Button>
      </SaveButtonWrapper>
    </Wrapper>
  );
}