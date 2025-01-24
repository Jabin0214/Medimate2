import { createBrowserRouter } from 'react-router-dom';
import React from 'react';
import App from '../src/App';
import SearchPage from './pages/searchPage';

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
  },
  {
    path: '/search',
    element: <SearchPage />,
  },
]);

export default router;