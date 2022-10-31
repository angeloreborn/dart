import { ConnectionService } from "./connection-service";

export class WindowsService<T> extends ConnectionService<T>{
    constructor(connection: signalR.HubConnection, container: string) {
        super(connection, container)
    }

    public FileSearch(path: string, extention: string){
        this.invokeService(this.FileSearch.name, path, extention);
    }
}

