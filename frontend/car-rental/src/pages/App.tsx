import { FormControl, InputLabel, MenuItem, Select, TextField } from '@mui/material';
import { AppProviders } from '../providers/AppProviders';
import { FormWrapper, Wrapper } from './App.styles';

function App() {
  return (
    <AppProviders>
      <FormWrapper>
        <Wrapper>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">Age</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              label="Age"
            >
              <MenuItem value={10}>Ten</MenuItem>
              <MenuItem value={20}>Twenty</MenuItem>
              <MenuItem value={30}>Thirty</MenuItem>
            </Select>
          </FormControl>
        </Wrapper>
      </FormWrapper>
    </AppProviders>
  );
}

export default App;