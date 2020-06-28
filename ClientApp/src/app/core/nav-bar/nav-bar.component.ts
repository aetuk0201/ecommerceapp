import { AccountService } from './../../account/account.service';
import { Observable } from 'rxjs';
import { CartService } from './../../cart/cart.service';
import { Component, OnInit } from '@angular/core';
import { ICart } from 'src/app/shared/models/cart';
import { IAppUser } from 'src/app/shared/models/appUser';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent implements OnInit {
  cart$: Observable<ICart>;
  currentUser$: Observable<IAppUser>;

  constructor(
    private cartService: CartService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.cart$ = this.cartService.cart$;
    this.currentUser$ = this.accountService.currentuser$;
  }

  logout(): void {
    this.accountService.logout();
  }
}
