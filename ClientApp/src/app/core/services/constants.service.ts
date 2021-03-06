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

  // Order
  createOrderUrl = '/api/order/createorder';

  // Cart
  getCartByIdUrl = '/api/cart/GetCartById';
  addUpdateCartUrl = '/api/cart/AddOrUpdateCart';
  deleteCartUrl = '/api/cart/DeleteCart';

  // Delivery Methods
  deliveryMethodsUrl = '/api/order/GetDeliveryMethods';

  // Account
  loginUrl = '/api/account/login';
  registerUrl = '/api/account/register';
  getCurrentUserUrl = '/api/account/getcurrentuser';
  getUserAddressUrl = '/api/account/getuseraddress';
  updateUserAddressUrl = '/api/account/updateuseraddress';

  // Misc
  emailExistsUrl = '/api/account/emailexists';

  // sort
  sortNameAsc = 'nameAsc';
  sortNameDesc = 'nameDesc';
  sortPriceAsc = 'priceAsc';
  sortPriceDesc = 'priceDesc';

  // Regex
  regexEmail = '^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$';

  constructor() {}
}
