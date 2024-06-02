export class Tournament {
    Id?: number;
    Name?: string;
    CreateDate: Date = new Date();
    CreateId?: number;
    CreateName?: string;
    ModifiedDate?: Date = new Date();
    ModifiedId?: number;
    ModifiedName?: string;
    IsDetected: boolean = false;
    constructor(){}
}