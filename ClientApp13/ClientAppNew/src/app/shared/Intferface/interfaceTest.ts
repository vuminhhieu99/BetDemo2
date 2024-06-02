export interface Itest {
    /**
     * name
     */
    checkTest(): Number;
}


export class testClass implements Itest{
    checkTest(): Number{}
} 