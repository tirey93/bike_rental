import { FormControl, InputLabel, Select, MenuItem, Button } from "@mui/material";
import { FormWrapper, Wrapper } from "../../pages/App.styles";
import { useError } from "../../hooks/useError.";

type Props = {
 
}
export const SignIn = ({}: Props) => {
   const { error, dispatchError } = useError();

    return ( 
      <FormWrapper>
        <Wrapper>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">User</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              label="Age">
              <MenuItem value={10}>Ten</MenuItem>
              <MenuItem value={20}>Twenty</MenuItem>
              <MenuItem value={30}>Thirty</MenuItem>
            </Select>
          </FormControl>
          <Button variant="contained" onClick={() => dispatchError('test')}>Sign in</Button>
          {error}
        </Wrapper>
      </FormWrapper>
    );
}