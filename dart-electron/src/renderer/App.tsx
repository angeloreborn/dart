import { MemoryRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import * as React from 'react';
import DefaultAppBar from 'components/AppBar/DefaultAppBar';
import InternalApi from 'api-internal/api-internal.index'
import os from 'os';
interface Props {
  window?: () => Window;
}

export default function App(props: Props) {
  os.userInfo();
  return (
    <React.Fragment>
        <DefaultAppBar/>
        <Router>

        </Router>
    </React.Fragment>

  );
}
