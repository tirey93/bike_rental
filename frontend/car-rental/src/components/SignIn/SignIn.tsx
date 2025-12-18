import { FormControl, InputLabel, Select, MenuItem, Button } from "@mui/material";
import { FormWrapper, Wrapper } from "../../pages/App.styles";
import { useError } from "../../hooks/useError.";
import { useAuth } from "../../hooks/useAuth";

type Props = {
 
}
export const SignIn = ({}: Props) => {
   const { error, dispatchError } = useError();
   const {user, signIn, signOut} = useAuth();

    return ( 
      <FormWrapper>
        <Wrapper>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">User</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value=''
              label="Age">
              <MenuItem value={10}>Ten</MenuItem>
              <MenuItem value={20}>Twenty</MenuItem>
              <MenuItem value={30}>Thirty</MenuItem>
            </Select>
          </FormControl>
          <Button variant="contained" onClick={() => signIn('user112')}>Sign in</Button>
          {error}
        </Wrapper>
      </FormWrapper>
    );
}