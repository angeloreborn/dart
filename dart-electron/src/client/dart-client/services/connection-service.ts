import {HubConnectionState} from '@microsoft/signalr'

export class ConnectionService<T>{
    public connection : signalR.HubConnection;
    public container : string;
    constructor(connection: signalR.HubConnection, container: string) {
       this.connection = connection;
       this.container = container;
    }

    public async invokeService<T>(method: string, obj? : T){
        if (this.connection.state != HubConnectionState.Connected){
            await this.connection.start();
        }
        this.connection.send("ServiceHandler", this.container, method, obj);
    }

    public All(){
        this.invokeService(this.All.name)
    }
}