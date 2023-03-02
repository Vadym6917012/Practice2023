import { Model } from "./model.model"
import { Price } from "./price.model"

export interface Car {
    id: number,
    vehicleModelId: number,
    vehicleModel: Model | any,
    imageUrl: string | any,
    engineCapacity: number,
    priceId: number,
    price: Price[] | any,
    description: string
}