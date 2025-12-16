import { Button } from '../atoms/Button';
import { AppProviders } from '../providers/AppProviders';
import { Wrapper } from './App.styles';

function App() {
  return (
    <AppProviders>
      <Wrapper>
        <Button>Test</Button>
      </Wrapper>
    </AppProviders>
  );
}

export default App;