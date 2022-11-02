import {HubConnection, HubConnectionState} from '@microsoft/signalr'

export class ConnectionService<T>{
    public connection : signalR.HubConnection;
    public container : string;
    constructor(connection: signalR.HubConnection, container: string) {
       this.connection = connection;
       this.container = container;
    }

    public async invokeService<T>(method: string, ...args: any[]) : Promise<SeviceReponse>{
        try{
            if (this.connection.state == HubConnectionState.Disconnected){
                await this.connection.start();   
            }        
            return await this.connection.send("ServiceHandler", this.container, method, args);
        }catch(exception: SeviceReponse){
            return exception;
        }
    }

    public async All(): Promise<SeviceReponse>{
        return await this.invokeService(this.All.name)
    }

    public bind_All(handler: (reponse: T[]) => void){
        this.connection.on(this.bind_All.name, (response: T[])=> handler(response))
    }

    public async AllAs(): Promise<SeviceReponse>{
        return await this.invokeService(this.AllAs.name)
    }
}