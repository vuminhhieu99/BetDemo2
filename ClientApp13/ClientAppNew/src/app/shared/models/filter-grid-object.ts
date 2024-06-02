import { Operator } from "../enumaration/operator";

export class FilterGridObject {
    operator : Operator = Operator.Add;
    items : Array<FilterGridObject> = [];
    constructor(){}
}