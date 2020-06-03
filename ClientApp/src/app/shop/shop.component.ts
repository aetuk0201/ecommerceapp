import { catchError, map, tap } from 'rxjs/operators';
import { Observable, EMPTY, Subscription } from 'rxjs';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

import { IProduct } from '../shared/models/product';
import { IProductType } from './../shared/models/productType';
import { ICategory } from './../shared/models/category';
import { IDepartment } from './../shared/models/department';
import { IPagedProductList } from '../shared/models/pagedProductList';

import { ConstantsService } from './../core/services/constants.service';
import { ShopService } from './shop.service';

import { ShopParams } from './../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  constructor(
    private shopService: ShopService,
    private constantService: ConstantsService
  ) {}

  @ViewChild('search') searchText: ElementRef;
  products: IProduct[];
  departments: IDepartment[];
  categories: ICategory[];
  productTypes: IProductType[];
  totalCount = 0;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: this.constantService.sortPriceAsc },
    { name: 'Price: High to Low', value: this.constantService.sortPriceDesc },
  ];
  shopParams = new ShopParams();

  errorMessage = '';
  products$: Observable<void | IProduct[]>;

  ngOnInit(): void {
    this.getProducts();
    this.getDepartments();
    this.getCategories();
    this.getProductTypes();

    // this.pagedProductsList$ = this.shopService.getProducts()
    // .pipe(catchError(err => {
    //     this.errorMessage = err;
    //     return EMPTY; // we can also return and observable of([])
    // }));

    // this.shopService.pagedProductsList$.subscribe((x) => {});

    // this.shopService.getProducts().subscribe(
    //   (response) => {
    //     this.products = response.data;
    //     // console.log(this.products);
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );
  }

  getProductsAll(): void {
    this.products$ = this.shopService.pagedProductsList$.pipe(
      tap((x) => {
        console.log(x);
      }),
      map((p) => {
        // this.products$ = p.data;
      }),
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY; // we can also return and observable of([])
      })
    );
  }

  getProducts(): void {
    this.shopService.getProducts(this.shopParams).subscribe(
      (response: IPagedProductList) => {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
        // console.log(this.products);
      },
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      })
    );
  }

  getDepartments(): void {
    this.shopService.getDepartments().subscribe((response) => {
      this.departments = [{ id: 0, name: 'All' }, ...response];
    }),
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY; // we can also return and observable of([])
      });
  }

  getCategories(): void {
    this.shopService.getCategories().subscribe((response) => {
      this.categories = [{ id: 0, name: 'All' }, ...response];
    }),
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY; // we can also return and observable of([])
      });
  }

  getProductTypes(): void {
    this.shopService.getProductTypes().subscribe((response) => {
      this.productTypes = [{ id: 0, name: 'All' }, ...response];
    }),
      catchError((err) => {
        this.errorMessage = err;
        return EMPTY;
      });
  }

  onDepartmentSelected(departmentId: number): void {
    this.shopParams.departmentId = departmentId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onCategorySelected(categoryId: number): void {
    this.shopParams.categoryId = categoryId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onProductTypeSelected(productTypeId: number): void {
    this.shopParams.productTypeId = productTypeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(page: any): void {
    const pageValue = page + 1;
    if (this.shopParams.pageNumber !== pageValue) {
      this.shopParams.pageNumber = pageValue;
      this.getProducts();
    }
  }

  onSearch(searchText: string): void {
    this.shopParams.search = searchText;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(): void {
    this.searchText.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
