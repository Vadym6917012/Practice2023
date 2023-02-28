import { Color } from "./color.model";
import { Make } from "./make.model";

export interface Model {
    id: number,
    name: string,
    makeId: number,
    make: Make | any,
    vehicleColorId: number,
    vehicleColor: Color | any
}