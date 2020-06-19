import { v4 as uuid } from 'uuid';
import { ICartItem } from './cartItem';

export interface ICart {
  id: string;
  cartItems: ICartItem[];
}

export class Cart implements ICart {
  id = uuid();
  cartItems: ICartItem[] = [];
}

export interface ICartTotals {
  shipping: number;
  subtotal: number;
  total: number;
}
