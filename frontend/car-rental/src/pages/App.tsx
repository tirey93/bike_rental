import { AppProviders } from '../providers/AppProviders';
import { SignIn } from '../components/SignIn/SignIn';
import { useAuth } from '../hooks/useAuth';

function App() {
  const {user, signIn, signOut} = useAuth();

  return (
    <AppProviders>
      <SignIn></SignIn>
    </AppProviders>
  );
}

export default App;