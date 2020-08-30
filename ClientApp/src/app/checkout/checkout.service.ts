import { IOrderToCreate } from './../shared/models/order';
import { IDeliveryMethod } from './../shared/models/deliveryMethod';
import { ConstantsService } from './../core/services/constants.service';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CheckoutService {
  baseUrl = environment.baseUrl;

  constructor(
    private http: HttpClient,
    private constantsService: ConstantsService
  ) {}

  createOrder(order: IOrderToCreate) {
    return this.http.post(
      this.baseUrl + this.constantsService.createOrderUrl,
      order
    );
  }

  getDeliveryMethods() {
    return this.http
      .get(this.baseUrl + this.constantsService.deliveryMethodsUrl)
      .pipe(
        map((dm: IDeliveryMethod[]) => {
          return dm.sort((a, b) => b.price - a.price);
        })
      );
  }
}
