import { IAddress } from './address';

export interface IOrderToCreate {
  cartId: string;
  deliveryMethodId: number;
  addressToShip: IAddress;
}

export interface IOrderItem {
  productId: number;
  productName: string;
  imageUrl: string;
  price: number;
  quantity: number;
}

export interface IOrder {
  id: number;
  customerEmail: string;
  orderDate: Date;
  addressToShip: IAddress;
  deliveryMethod: string;
  shippingPrice: number;
  orderItems: IOrderItem[];
  subtotal: number;
  total: number;
  status: string;
}
