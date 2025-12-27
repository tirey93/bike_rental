import { SignIn } from '../../components/SignIn/SignIn';
import { useAuth } from '../../contexts/AuthContext';
import { Main } from '../../components/Main/Main';

function App() {
  const { user } = useAuth();
  return (
    <>
      {user ? <Main></Main> : <SignIn></SignIn>}
    </>
  );
}

export default App;