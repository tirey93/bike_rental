import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { useState } from "react";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import { BikeModels } from "../../../../../assets/BikeModels";
import { BikeColors } from "../../../../../assets/BikeColors";

type Props = {
 edit: boolean
}

export const UpsertBike = ({edit}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const [selectedModel, setSelectedModel] = useState<string>('');
  const [selectedColor, setSelectedColor] = useState<string>('');

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
        <DatePicker label="Basic date picker" />
      {/* <button onClick={publishSuccess}>Submit</button> */}
      </Wrapper>
    </div>
  );
}