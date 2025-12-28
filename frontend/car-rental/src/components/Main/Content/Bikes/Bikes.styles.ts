import { TableContainer, TableContainerProps } from "@mui/material";
import styled from "styled-components";

export const ContainerStyled = styled(TableContainer)<TableContainerProps>({
  maxWidth: "50vw",
  margin: "2rem",
  "& .MuiTableCell-head": {
    fontWeight: "bold",
  },
});