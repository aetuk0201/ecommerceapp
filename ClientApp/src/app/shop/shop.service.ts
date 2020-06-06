import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { environment } from './../../environments/environment';
import { ConstantsService } from '../core/services/constants.service';
import { IProduct } from '../shared/models/product';
import { IPagedProductList } from '../shared/models/pagedProductList';
import { IDepartment } from '../shared/models/department';
import { IProductType } from './../shared/models/productType';
import { ICategory } from './../shared/models/category';
import { ShopParams } from './../shared/models/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl: string = environment.baseUrl;
  products: IProduct[];

  pagedProductsList$ = this.http
    .get<IPagedProductList>(this.baseUrl + this.constants.getProductsUrl)
    .pipe(
      map((x) => x.data),
      catchError((err) => this.handleError(err))
    );

  constructor(private http: HttpClient, private constants: ConstantsService) {}

  getProducts(shopParams: ShopParams): Observable<IPagedProductList> {
    let params = new HttpParams();

    if (shopParams.departmentId !== 0) {
      params = params.append(
        'departmentId',
        shopParams.departmentId.toString()
      );
    }

    if (shopParams.categoryId !== 0) {
      params = params.append('categoryId', shopParams.categoryId.toString());
    }

    if (shopParams.productTypeId !== 0) {
      params = params.append(
        'productTypeId',
        shopParams.productTypeId.toString()
      );
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http
      .get<IPagedProductList>(this.baseUrl + this.constants.getProductsUrl, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body; // returns stronly typed response (IPagedProductList)
        }),
        catchError((err) => this.handleError(err))
      );
  }

  getProduct(id: number): Observable<IProduct> {
    const params = new HttpParams();
    // params.set('productId', id.toString());{ params }
    return this.http.get<IProduct>(
      this.baseUrl + this.constants.getProductUrl + '?productId=' + id
    );
  }

  getDepartments(): Observable<IDepartment[]> {
    return this.http
      .get<IDepartment[]>(this.baseUrl + this.constants.getDepartmentsUrl)
      .pipe(catchError((err) => this.handleError(err)));
  }

  getCategories(): Observable<ICategory[]> {
    return this.http
      .get<ICategory[]>(this.baseUrl + this.constants.getCategoriesUrl)
      .pipe(catchError((err) => this.handleError(err)));
  }

  getProductTypes(): Observable<IProductType[]> {
    return this.http
      .get<IProductType[]>(this.baseUrl + this.constants.getProductTypesUrl)
      .pipe(catchError((err) => this.handleError(err)));
  }

  handleError(err: HttpErrorResponse): Observable<any> {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // client side error
      errorMessage = `An error occured: ${err.error.message}`;
    } else {
      // backend error
      errorMessage = `Api service returned an error. ${err.status}: ${err.error}`;
    }

    // log error

    return throwError(errorMessage);
  }
}
