import { AccountService } from './account/account.service';
import { CartService } from './cart/cart.service';
import { Component, OnInit } from '@angular/core';
import { ICart } from './shared/models/cart';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'The Shop';

  constructor(
    private cartService: CartService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.loadCart();
    this.loadCurrentUser();
  }

  loadCurrentUser(): void {
    const token = localStorage.getItem('token');

    this.accountService.getCurrentUser(token).subscribe(
      () => {
        console.log('loaded user');
      },
      (error) => {
        this.handleError(error);
      }
    );
  }

  loadCart(): void {
    const cartId = localStorage.getItem('cart_id');

    if (cartId) {
      this.cartService.getCart(cartId).subscribe(
        () => {
          console.log('initialized cart');
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  handleError(error: HttpErrorResponse) {
    console.log(error);
  }
}
