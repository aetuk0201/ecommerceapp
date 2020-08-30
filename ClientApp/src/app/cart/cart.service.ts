import { IDeliveryMethod } from './../shared/models/deliveryMethod';
import { ICartItem } from './../shared/models/cartItem';
import { IProduct } from './../shared/models/product';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from './../core/services/constants.service';
import { environment } from './../../environments/environment.dev';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ICart, Cart, ICartTotals } from '../shared/models/cart';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;
  private cartSource = new BehaviorSubject<ICart>(null);
  cart$ = this.cartSource.asObservable();
  private cartTotalSource = new BehaviorSubject<ICartTotals>(null);
  cartTotal$ = this.cartTotalSource.asObservable();
  shippingCost = 0;

  constructor(
    private http: HttpClient,
    private constantsService: ConstantsService
  ) {}

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.shippingCost = deliveryMethod.price;
    this.calculateTotals();
  }

  getCart(id: string) {
    return this.http
      .get(this.baseUrl + this.constantsService.getCartByIdUrl + '?id=' + id)
      .pipe(
        map((cart: ICart) => {
          this.cartSource.next(cart);
          this.calculateTotals();
        })
      );
  }

  setCart(cart: ICart) {
    return this.http
      .post(this.baseUrl + this.constantsService.addUpdateCartUrl, cart)
      .subscribe(
        (response: ICart) => {
          this.cartSource.next(response);
          this.calculateTotals();
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

  incrementItemQuantity(item: ICartItem) {
    const cart = this.getCurrentCartValue();
    const foundItemIndex = cart.cartItems.findIndex((x) => x.id === item.id);
    cart.cartItems[foundItemIndex].quantity++;
    this.setCart(cart);
  }

  decrementItemQuantity(item: ICartItem) {
    const cart = this.getCurrentCartValue();
    const foundItemIndex = cart.cartItems.findIndex((x) => x.id === item.id);
    if (cart.cartItems[foundItemIndex].quantity > 1) {
      cart.cartItems[foundItemIndex].quantity--;
      this.setCart(cart);
    } else {
      this.removeItemFromCart(item);
    }
  }

  removeItemFromCart(item: ICartItem) {
    const cart = this.getCurrentCartValue();
    if (cart.cartItems.some((x) => x.id === item.id)) {
      cart.cartItems = cart.cartItems.filter((i) => i.id !== item.id);

      if (cart.cartItems.length > 0) {
        this.setCart(cart);
      } else {
        this.deleteCart(cart);
      }
    }
  }

  deleteCart(cart: ICart) {
    return this.http
      .delete(
        this.baseUrl + this.constantsService.deleteCartUrl + '?id=' + cart.id
      )
      .subscribe(
        () => {
          this.cartSource.next(null);
          this.cartTotalSource.next(null);
          if (localStorage.getItem('cart_id') != null) {
            localStorage.removeItem('cart_id');
          }
        },
        (error) => {
          this.handleError(error);
        }
      );
  }

  deleteCartFromLocalStorage(id: string) {
    this.cartSource.next(null);
    this.cartTotalSource.next(null);
    if (localStorage.getItem('cart_id') != null) {
      localStorage.removeItem('cart_id');
    }
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

  private calculateTotals() {
    const cart = this.getCurrentCartValue();
    const shipping = this.shippingCost;
    const subtotal = cart.cartItems.reduce(
      (a, b) => b.price * b.quantity + a,
      0
    ); // 0 is intial value of a. subsequent calculations will change that number
    const total = subtotal + shipping;
    this.cartTotalSource.next({ shipping, subtotal, total });
  }

  handleError(error: any) {
    console.log(error);
  }
}
