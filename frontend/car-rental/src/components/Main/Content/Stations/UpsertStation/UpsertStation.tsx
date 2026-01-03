
import { Button, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { useEffect, useState } from "react";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import SaveIcon from '@mui/icons-material/Save';
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { stationApiUrl } from "../../../../../consts";
import { Station } from "../dtos/Station";
import { useUpdate } from "../../../../../hooks/useUpdate";
import { useCreate } from "../../../../../hooks/useCreate";
import { SaveStation } from "../dtos/SaveStation";
import { StationLocations } from "../../../../../assets/StationLocations";

type Props = {
  station?: Station;
}

export const UpsertStation = ({station}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const [code, setCode] = useState<string>(station?.code ?? '');
  const [selectedLocation, setSelectedLocation] = useState<string>(station?.location ?? '');
  const [capacity, setCapacity] = useState<number | null>(station?.capacity ?? null);
  const { create } = useCreate<SaveStation>(stationApiUrl);
  const { update } = useUpdate<SaveStation>(stationApiUrl, station?.id ?? 0);

  const handleUpsert = () => {
    const payload: SaveStation = { code, location: selectedLocation, capacity };
    if (station) {
      update(payload, publishSuccess);
    } else {
      create(payload, publishSuccess);
    }
  }

  return (
    <Wrapper>
      <FormControlStyled>
        <TextField fullWidth label="Code" value={code} onChange={(e) => setCode(e.target.value)} />
      </FormControlStyled>
      <FormControlStyled>
        <InputLabel id="select-location-label">Location</InputLabel>
        <Select
          id="select-location"
          value={selectedLocation}
          label="Location"
          onChange={(e) => setSelectedLocation(e.target.value)}>
          {StationLocations.map((model) => (
            <MenuItem key={model.id} value={model.name}>
              {model.name}
            </MenuItem>
          ))}
        </Select>
      </FormControlStyled>
      <FormControlStyled>
        <TextField
          fullWidth
          label="Capacity"
          type="number"
          value={capacity ?? ''}
          onChange={(e) => setCapacity(e.target.value === '' ? null : Number(e.target.value))}
        />
      </FormControlStyled>
      <ConfirmationButtonWrapper>
        <Button
          disabled={code === '' || selectedLocation === '' || capacity === null}
          onClick={() => handleUpsert()}
          variant="contained" startIcon={<SaveIcon />}>{station ? 'Update' : 'Save'}</Button>
      </ConfirmationButtonWrapper>
    </Wrapper>
  );
}