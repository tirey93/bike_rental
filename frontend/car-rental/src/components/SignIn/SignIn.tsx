import { FormControl, InputLabel, Select, MenuItem, Button } from "@mui/material";
import { FormWrapper, Wrapper } from "../../pages/App.styles";
import { useError } from "../../hooks/useError.";
import { useAuth } from "../../hooks/useAuth";
import { useState } from "react";

type Props = {
 
}
export const SignIn = ({}: Props) => {
   const { error } = useError();
   const { signIn } = useAuth();
   const [selectedUser, setSelectedUser] = useState<string>('');

   const onChange = (value: string) => {
      console.log(value); 
      setSelectedUser(value);
   }

    return ( 
      <FormWrapper>
        <Wrapper>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">User</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              onChange={(e) => onChange(e.target.value)}
              value={selectedUser}
              label="Age">
              <MenuItem value='admin'>Admin</MenuItem>
              <MenuItem value='user1'>User1</MenuItem>
              <MenuItem value='user2'>User2</MenuItem>
            </Select>
          </FormControl>
          <Button disabled={selectedUser === ''} variant="contained" onClick={() => signIn(selectedUser)}>Sign in</Button>
          {error}
        </Wrapper>
      </FormWrapper>
    );
}