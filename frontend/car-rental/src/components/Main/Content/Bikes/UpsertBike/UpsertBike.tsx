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
import { Dayjs } from "dayjs";
import SaveIcon from '@mui/icons-material/Save';
import { SaveButtonWrapper } from "../../../ActionDrawer/styles/SaveButtonWrapper";

type Props = {
 edit: boolean
}

export const UpsertBike = ({edit}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const [selectedModel, setSelectedModel] = useState<string>('');
  const [selectedColor, setSelectedColor] = useState<string>('');
  const [date, setDate] = useState<Dayjs | null>(null);

  const handleUpsert = () => {
    console.log('Bike saved:', {model: selectedModel, color: selectedColor, lastServiceDate: date});
    publishSuccess();
  }
  return ( 
    <div>
      <Wrapper>
        <FormControlStyled>
          <InputLabel id="select-model-label">Model</InputLabel>
          <Select
            id="select-model"
            value={selectedModel}
            label="Model"
            onChange={(e) => setSelectedModel(e.target.value)}>
            {BikeModels.map((model) => (
              <MenuItem key={model.id} value={model.id}>
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
              <MenuItem key={color.id} value={color.id}>
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
              variant="contained" startIcon={<SaveIcon />}>{edit ? 'Update' : 'Save'}</Button>
        </SaveButtonWrapper>
      </Wrapper>
    </div>
  );
}