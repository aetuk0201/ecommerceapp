import { ICartItem } from './../shared/models/cartItem';
import { IProduct } from './../shared/models/product';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './../core/services/constants.service';
import { environment } from './../../environments/environment.dev';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ICart, Cart } from '../shared/models/cart';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;
  private cartSource = new BehaviorSubject<ICart>(null);
  cart$ = this.cartSource.asObservable();

  constructor(
    private http: HttpClient,
    private constantsService: ConstantsService
  ) {}

  getCart(id: string) {
    return this.http
      .get(this.baseUrl + this.constantsService.getCartByIdUrl + '?id=' + id)
      .pipe(
        map((cart: ICart) => {
          this.cartSource.next(cart);
          console.log(this.getCurrentCartValue());
        })
      );
  }

  setCart(cart: ICart) {
    return this.http
      .post(this.baseUrl + this.constantsService.addUpdateCartUrl, cart)
      .subscribe(
        (response: ICart) => {
          this.cartSource.next(response);
          console.log(response);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getCurrentCartValue() {
    return this.cartSource.value;
  }

  addItemToCart(item: IProduct, quantity = 1) {
    const itemToAdd: ICartItem = this.mapProductItemToCartItem(item, quantity);
    const cart = this.getCurrentCartValue() ?? this.createCart();
    cart.cartItems = this.addOrUpdateItem(cart.cartItems, itemToAdd, quantity);
    this.setCart(cart);
  }

  private addOrUpdateItem(
    items: ICartItem[],
    itemToAdd: ICartItem,
    quantity: number
  ): ICartItem[] {
    const index = items.findIndex((i) => i.id === itemToAdd.id);
    if (index === -1) {
      // if there's no match
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity; // update quantity instead
    }
    return items;
  }

  private createCart(): ICart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }

  private mapProductItemToCartItem(
    item: IProduct,
    quantity: number
  ): ICartItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      imageUrl: item.imageUrl,
      quantity,
      department: item.department,
      category: item.category,
      productType: item.productType,
    };
  }
}
