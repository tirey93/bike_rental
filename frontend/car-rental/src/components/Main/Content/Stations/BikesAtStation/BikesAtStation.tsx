import { Paper, Table, TableHead, TableRow, TableCell, TableBody, Tooltip, IconButton } from "@mui/material";
import { drawerWidth, stationApiUrl } from "../../../../../consts";
import { useFetch } from "../../../../../hooks/useFetch";
import { ContainerStyled } from "../../Bikes/Bikes.styles";
import { Bike } from "../dtos/Bike";

type Props = {
  stationId: number
}
export const BikesAtStation = ({stationId}: Props) => {
  const { data, loading, error } = useFetch<Bike[]>(`${stationApiUrl}/${stationId}/bikes`);

  return (
    <>
      {loading && <p>Loading bikes...</p>}
      {error && <p>Error: {error}</p>}
      <ContainerStyled sx={{width:`${80}%`}} component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Model</TableCell>
              <TableCell align="right">Color</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data && data.map((row) => (
              <TableRow
                key={row.model}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell component="th" scope="row">
                  {row.model}
                </TableCell>
                <TableCell align="right">{row.color}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </ContainerStyled>
    </>
  );
}