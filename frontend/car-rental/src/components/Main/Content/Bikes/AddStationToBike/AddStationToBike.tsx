import { Button, InputLabel, MenuItem, Select } from "@mui/material";
import { useActionDrawer } from "../../../ActionDrawer/ActionDrawerContext";
import { useState } from "react";
import { Wrapper } from "../../../../../pages/App/App.styles";
import { FormControlStyled } from "../../../ActionDrawer/styles/FormControlStyled";
import dayjs, { Dayjs } from "dayjs";
import { ConfirmationButtonWrapper } from "../../../ActionDrawer/styles/ConfirmationButtonWrapper";
import { bikeApiUrl, bikeAtStationApiUrl, stationApiUrl } from "../../../../../consts";
import { Bike } from "../dtos/Bike";
import { formatDateOnly, SaveBike } from "../dtos/SaveBike";
import { useCreate } from "../../../../../hooks/useCreate";
import AddBoxIcon from '@mui/icons-material/AddBox';
import { AddBikeToStation } from "../dtos/AddBikeToStation";
import { useFetch } from "../../../../../hooks/useFetch";
import { Station } from "../../Stations/dtos/Station";
import { ContentEnum } from "../../content.enum";
import { useRefresh } from "../../../../../contexts/RefreshContext";

type Props = {
  bike: Bike;
}

export const AddStationToBike = ({bike}: Props) => {
  const { publishSuccess } = useActionDrawer();
  const { create } = useCreate<AddBikeToStation>(bikeAtStationApiUrl);
  const { refreshKeys, triggerRefresh } = useRefresh();
  const { data: stations, loading, error } = useFetch<Station[]>(stationApiUrl, refreshKeys[ContentEnum.STATIONS]);
  const [selectedExternalId, setSelectedExternalId] = useState<string>('');

  const handleAdd = () => {
      create({
        externalBikeId: bike.externalId,
        externalStationId: selectedExternalId
      }, publishSuccess);
    
  }
  return ( 
    <Wrapper>
      {loading && <p>Loading stations...</p>}
      {error && <p>Error: {error}</p>}
      {stations && 
        <FormControlStyled>
          <InputLabel id="select-model-label">Station</InputLabel>
          <Select
            id="select-model"
            value={selectedExternalId}
            label="Station"
            onChange={(e) => setSelectedExternalId(e.target.value)}>
            {stations.map((station) => (
              <MenuItem key={station.id} value={station.externalId}>
                {station.code} - {station.location}
              </MenuItem>
            ))}
          </Select>
        </FormControlStyled>
      }
      <ConfirmationButtonWrapper>
          <Button
            disabled={loading || error != null || !stations}
            onClick={() => handleAdd()}
            variant="contained" startIcon={<AddBoxIcon />}>Add</Button>
      </ConfirmationButtonWrapper>
    </Wrapper>
  );
}