import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConstantsService {
  getProductsUrl = '/api/product/GetProductsWithSpec';
  getProductUrl = '/api/product/GetProductByIdWithSpec';
  getDepartmentsUrl = '/api/product/GetDepartments';
  getDepartmentByIdUrl = '/api/product/GetDepartmentById';
  getCategoriesUrl = '/api/product/GetCategories';
  getCategoryByIdUrl = '/api/product/GetCategoryById';
  getProductTypesUrl = '/api/product/GetProductTypes';
  getProductTypesByIdUrl = '/api/product/GetProductTypesById';

  getCartByIdUrl = '/api/cart/GetCartById';
  addUpdateCartUrl = '/api/cart/AddOrUpdateCart';
  deleteCartUrl = '/api/cart/DeleteCart';

  // sort
  sortNameAsc = 'nameAsc';
  sortNameDesc = 'nameDesc';
  sortPriceAsc = 'priceAsc';
  sortPriceDesc = 'priceDesc';

  constructor() {}
}
