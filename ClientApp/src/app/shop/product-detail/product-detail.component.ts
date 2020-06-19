import { CartService } from './../../cart/cart.service';
import { ShopService } from './../shop.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  productId: number;
  quantity = 1;

  constructor(
    private shopService: ShopService,
    private cartService: CartService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.productId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.getProduct(this.productId);
  }

  addItemToCart() {
    this.cartService.addItemToCart(this.product, this.quantity);
  }

  incrementQuantity(): void {
    this.quantity++;
  }

  decrementQuantity(): void {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  getProduct(id: number): void {
    this.shopService.getProduct(id).subscribe(
      (productItem) => {
        this.product = productItem;
        console.log(this.product.name);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
