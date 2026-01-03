import {  Paper, Table, TableHead, TableRow, TableCell, TableBody, IconButton } from "@mui/material";
import { bikeApiUrl } from "../../../../consts";
import { useFetch } from "../../../../hooks/useFetch";
import { Bike } from "./dtos/Bike";
import { ContainerStyled } from "./Bikes.styles";
import UpdateIcon from '@mui/icons-material/Update';
import DeleteIcon from '@mui/icons-material/Delete';
import { useRefresh } from "../../../../contexts/RefreshContext";
import { ContentEnum } from "../content.enum";

export const Bikes = () => {
  const { refreshKeys } = useRefresh();
  const { data, loading, error } = useFetch<Bike[]>(bikeApiUrl, refreshKeys[ContentEnum.BIKES]);

  return ( 
    <>
      {loading && <p>Loading bikes...</p>}
      {error && <p>Error: {error}</p>}
      <ContainerStyled component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell align="right">Model</TableCell>
              <TableCell align="right">Color</TableCell>
              <TableCell align="right">Last Service Date</TableCell>
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
                <TableCell align="right">{row.model}</TableCell>
                <TableCell align="right">{row.color}</TableCell>
                <TableCell align="right">{new Date(row.lastServiceDate).toDateString()}</TableCell>
                <TableCell align="center">
                  <IconButton aria-label="delete">
                    <DeleteIcon />
                  </IconButton>
                  <IconButton aria-label="update">
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
