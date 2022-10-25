import { MemoryRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import * as React from 'react';
import DefaultAppBar from 'components/AppBar/DefaultAppBar';
import client from 'client/dart-client/dart-client-core'
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';

interface Props {
  window?: () => Window;
}

export default function App(props: Props) {
  React.useEffect(()=>{
    client.project.connection.on("All",(e)=>{
      console.log("all projects");
      console.log(e);
    })
    client.project.All();
  },[])

  return (
    <React.Fragment>
        <DefaultAppBar/>
        <Router>

        </Router>
    </React.Fragment>

  );
}
