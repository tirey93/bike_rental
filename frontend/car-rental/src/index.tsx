import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './pages/App/App';
import { AppProviders } from './pages/App/App.providers';
import { BrowserRouter } from 'react-router-dom';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <AppProviders>
        <App />
      </AppProviders>
    </BrowserRouter>
  </React.StrictMode>
);
