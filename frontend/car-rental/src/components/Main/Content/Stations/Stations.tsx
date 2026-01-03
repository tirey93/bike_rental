import { Paper, Table, TableHead, TableRow, TableCell, TableBody, IconButton } from "@mui/material";
import { stationApiUrl } from "../../../../consts";
import { useFetch } from "../../../../hooks/useFetch";
import { Station } from "./dtos/Station";
import { ContainerStyled } from "../Bikes/Bikes.styles";
import UpdateIcon from '@mui/icons-material/Update';
import DeleteIcon from '@mui/icons-material/Delete';
import { useRefresh } from "../../../../contexts/RefreshContext";
import { ContentEnum } from "../content.enum";
import { useActionDrawer } from "../../ActionDrawer/ActionDrawerContext";
import { UpsertStation } from "./UpsertStation/UpsertStation";
import { DeleteStation } from "./DeleteStation/DeleteStation";

export const Stations = () => {
  const { refreshKeys, triggerRefresh } = useRefresh();
  const { data, loading, error } = useFetch<Station[]>(stationApiUrl, refreshKeys[ContentEnum.STATIONS]);
  const { openWith } = useActionDrawer();

  return (
    <>
      {loading && <p>Loading stations...</p>}
      {error && <p>Error: {error}</p>}
      <ContainerStyled component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell align="right">Code</TableCell>
              <TableCell align="right">Location</TableCell>
              <TableCell align="right">Capacity</TableCell>
              <TableCell align="center">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data && data.map((row) => (
              <TableRow
                key={row.id}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell component="th" scope="row">
                  {row.id}
                </TableCell>
                <TableCell align="right">{row.code}</TableCell>
                <TableCell align="right">{row.location}</TableCell>
                <TableCell align="right">{row.capacity}</TableCell>
                <TableCell align="center">
                  <IconButton
                    onClick={ () => openWith({
                      component: DeleteStation,
                      name: 'Delete station',
                      props: {station: row},
                      onSuccess: () => triggerRefresh(ContentEnum.STATIONS)
                    })}>
                    <DeleteIcon />
                  </IconButton>
                  <IconButton
                    onClick={ () => openWith({
                      component: UpsertStation,
                      name: 'Update station',
                      props: {station: row},
                      onSuccess: () => triggerRefresh(ContentEnum.STATIONS)
                    })}>
                    <UpdateIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </ContainerStyled>
    </>
  );
}