import { MemoryRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import * as React from 'react';
import DefaultAppBar from 'components/AppBar/DefaultAppBar';
import client from 'client/dart-client/dart-client-core'
import { ProjectModel } from 'models (autogenerated)'
import Section from 'components/generic/Section';
interface Props {
  window?: () => Window;
}

export default function App(props: Props) {

  const [projets, setProjects] = React.useState<ProjectModel[]>();
  React.useEffect(() => {
    
    client.project.All();


    client.project.connection.on("All",(projects : ProjectModel[])=>{
      console.log("all projects");
      console.log(projects);
      setProjects(projects);
    })
   
  },[])

  function requestAllProjects(){
    client.project.All();
  }

  return (
    <Section>
          <button onClick={requestAllProjects}>Reload</button>

                  {projets?.map(p=>{
                    return <h1>{p.id}{p.createdDate.toString()}</h1>
                  })}
          <DefaultAppBar/>
          <Router>
          </Router>
    </Section>

  );
}
