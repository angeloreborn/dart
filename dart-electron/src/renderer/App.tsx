import { MemoryRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import * as React from 'react';
import DefaultAppBar from 'components/AppBar/DefaultAppBar';
import client from 'client/dart-client/dart-client-core'

interface Props {
  window?: () => Window;
}

export default function App(props: Props) {
  React.useEffect(()=>{
    client.project.requestAllProjects();
  },[])

  return (
    <React.Fragment>
        <DefaultAppBar/>
        <Router>

        </Router>
    </React.Fragment>

  );
}
