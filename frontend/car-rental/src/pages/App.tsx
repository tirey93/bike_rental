import { Button } from '../common/atoms/Button';
import { Label } from '../common/atoms/Label';
import { Title } from '../common/atoms/Title';
import FormField from '../common/molecules/FormField';
import { AppProviders } from '../providers/AppProviders';
import { FormWrapper, Wrapper } from './App.styles';

function App() {
  return (
    <AppProviders>
      <FormWrapper>
        <FormField label='Login' name='login' id='login' placeholder='login'></FormField>
        <FormField label='Password' name='password' id='password' placeholder='password' type='password'></FormField>
        <Button type='submit'>Sign in</Button>
      </FormWrapper>
    </AppProviders>
  );
}

export default App;