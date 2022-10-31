import {HubConnection, HubConnectionState} from '@microsoft/signalr'

export class ConnectionService<T>{
    public connection : signalR.HubConnection;
    public container : string;
    constructor(connection: signalR.HubConnection, container: string) {
       this.connection = connection;
       this.container = container;
    }

    public async invokeService<T>(method: string, ...args: any[]){
        if (this.connection.state == HubConnectionState.Disconnected){
            console.log('connecting');
            console.log(this.connection.state);
            await this.connection.start();   
        }
        
        this.connection.send("ServiceHandler", this.container, method, args);
    }



    public async All(): Promise<HubConnection>{
        this.invokeService(this.All.name)
        return this.connection;
    }

    public async Test(): Promise<HubConnection>{
        this.invokeService(this.Test.name)
        return this.connection;
    }
}