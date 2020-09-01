

export class User {
    public id?: number;
    public chatId: number;
    public username: string;
    public password: string;
    public startSendWordTime?: Date;
    public finishSendWordTime?: Date;
    public token?: string;
}