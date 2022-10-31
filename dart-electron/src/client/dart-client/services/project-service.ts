import { ConnectionService } from "./connection-service";

export class ProjectService<T> extends ConnectionService<T>{
    constructor(connection: signalR.HubConnection, container: string) {
        super(connection, container)
    }
}

