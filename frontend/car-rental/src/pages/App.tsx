import { SignIn } from '../components/SignIn/SignIn';
import { useAuth } from '../hooks/useAuth';
import { Main } from './Main';

function App() {
  const { user } = useAuth();
  return (
    <>
      {user ? <Main></Main> : <SignIn></SignIn>}
    </>
  );
}

export default App;