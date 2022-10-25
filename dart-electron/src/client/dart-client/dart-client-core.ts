import * as signalR from '@microsoft/signalr'
import config from './dart-client'
import { ProjectService } from './services/dart-client-project'
class DartClient{
    private connection : signalR.HubConnection;
    public project : ProjectService<ProjectModel>;
    
    // client services
    constructor() {
        this.connection = new signalR.HubConnectionBuilder()
        .withUrl(config.wssOverHttpsDomain,{
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets
        })
        .build();
    
        this.connection.on("send", (data: any) => {
            console.log(data);
        });

        this.connection.onclose((err: any)=>{
            this.connection.start();
        })

        

        this.project = new ProjectService<ProjectModel>(this.connection, "IProjectService");
    }

    public send<T>(method: string, container: string, obj:T){
        this.connection.send(method, container, obj)
    }
   
}

export default new DartClient();

