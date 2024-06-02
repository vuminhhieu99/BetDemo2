import { Subject } from "rxjs";
import * as _ from 'lodash';

export class BaseFunction {
    public static unDestroy(_unsubscribe: Subject<any>){
        if(_unsubscribe){
            _unsubscribe.next(undefined);
            _unsubscribe.complete();
            _unsubscribe.unsubscribe();
        }
    } 
    public static IsNullOrEmpty(value?: any){
        return _.isNull(value) || _.isEmpty(value);
    }

    public static ConverParamUrl(object: any = {}){
        if(Object.keys(object).length <=0){
            return '';
        }
        else{
            let param ='';
            for (const property in object) {
                param += `&${property}=${object[property]}`;
            }
            param.replace("&","?");
            return param.replace("&","?");          
        }
    }
     
    public static GridBuiltFilter(object: any){
        //todo
    }

    /**
     * Clone object
     * @param data object cần clone
     * vmhieu 2.10.2022
     */
    public static cloneData(data: object): object {
        return _.clone(data);
    }

    /**
     * Clone với mọi kiểu giá trị
     * @param data object cần clone
     * @returns 
     * vmhieu 2.10.2022
     */
    public static cloneDataAny(data: any): any {
        return _.clone(data);
    }

    /**
     * Clone với mọi kiểu giá trị
     * @param data object cần clone
     * @returns 
     * vmhieu 2.10.2022
     */
     public static cloneDeepData(data: any): any {
        return _.cloneDeep(data);
    }

    /**
     * So sánh ngang bawngfchuẩn
     * @param value giá trị trước
     * @param other gí trị sau
     * @returns 
     * vmhieu 2.10.2022
     */
    public static equals(value: any, other: any): boolean {
        return _.eq(value, other);
    }

    /**
     * giá trị là 1 mảng
     * @param value1 
     * @param value2 
     * @returns 
     */
     public static isArray(value: any): boolean {
        return _.isArray(value);

    }

    /**
     * giá trị là 1 Boolean
     * @param value1 
     * @param value2 
     * @returns 
     */
     public static isBoolean(value: any): boolean {
        return _.isBoolean(value);
    }

    /**
     * giá trị là 1 "", null, undefined, NaN, or number
     * @param value1 
     * @param value2 
     * @returns 
     */
     public static isEmpty(value: any): boolean {
        return _.isEmpty(value);
    }

    /**
     * giá trị là 1 mảng
     * @param value1 
     * @param value2 
     * @returns default value = []
     */
    public static toArray(value : any): Array<any> {
        return _.toArray(value);
    }
}
