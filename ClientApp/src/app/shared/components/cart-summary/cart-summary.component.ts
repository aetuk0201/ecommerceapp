import { ICart } from './../../models/cart';
import { Observable } from 'rxjs';
import { CartService } from './../../../cart/cart.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ICartItem } from '../../models/cartItem';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.scss'],
})
export class CartSummaryComponent implements OnInit {
  cart$: Observable<ICart>;
  @Output() decrement: EventEmitter<ICartItem> = new EventEmitter<ICartItem>();
  @Output() increment: EventEmitter<ICartItem> = new EventEmitter<ICartItem>();
  @Output() remove: EventEmitter<ICartItem> = new EventEmitter<ICartItem>();
  isCart: boolean;

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cart$ = this.cartService.cart$;
  }

  decrementItemQuantity(item: ICartItem) {
    this.decrement.emit(item);
  }

  incrementItemQuantity(item: ICartItem) {
    this.increment.emit(item);
  }

  removeCartItem(item: ICartItem) {
    this.remove.emit(item);
  }
}
