import React from 'react';
import logo from './logo.svg';
import './App.css';
// const signalR = require("@microsoft/signalr");
import * as signalR from '@microsoft/signalr'
function App() {

  let connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7079/dart-testHub",{
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
  
  connection.on("send", (data: any) => {
      console.log(data);
  });
  
  connection.start()
      .then(() => connection.invoke("SendMessage", "Hello"));

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
