import { CartService } from './../../cart/cart.service';
import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss'],
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;

  constructor(private cartService: CartService) {}

  ngOnInit(): void {}

  addItemToBasket() {
    this.cartService.addItemToCart(this.product);
  }
}
