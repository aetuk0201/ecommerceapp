import { ShopService } from './../shop.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  productId: number;

  constructor(
    private shopService: ShopService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.productId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.getProduct(this.productId);
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
