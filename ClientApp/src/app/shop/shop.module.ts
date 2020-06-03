import { NgModule } from '@angular/core';
import { SharedModule } from './../shared/shared.module';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';

@NgModule({
  declarations: [ShopComponent, ProductItemComponent],
  imports: [SharedModule],
  exports: [ShopComponent],
})
export class ShopModule {}
