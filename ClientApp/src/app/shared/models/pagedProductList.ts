import { IProduct } from './product';

export interface IPagedProductList {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}
