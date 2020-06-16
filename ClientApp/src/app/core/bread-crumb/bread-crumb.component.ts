import { ShopService } from './../../shop/shop.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { MenuItem } from 'primeng/api';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-bread-crumb',
  templateUrl: './bread-crumb.component.html',
  styleUrls: ['./bread-crumb.component.scss'],
})
export class BreadCrumbComponent implements OnInit {
  static readonly ROUTE_DATA_BREADCRUMB = 'breadcrumb';
  readonly home = { icon: 'pi pi-home', url: 'home' };
  menuItems: MenuItem[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private shopService: ShopService
  ) {}

  ngOnInit(): void {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(
        () =>
          (this.menuItems = this.createBreadcrumbs(this.activatedRoute.root))
      );
  }

  private createBreadcrumbs(
    route: ActivatedRoute,
    url: string = '',
    breadcrumbs: MenuItem[] = []
  ): MenuItem[] {
    const children: ActivatedRoute[] = route.children;

    if (children.length === 0) {
      return breadcrumbs;
    }

    for (const child of children) {
      const routeURL: string = child.snapshot.url
        .map((segment) => segment.path)
        .join('/');
      if (routeURL !== '') {
        url += `/${routeURL}`;
      }

      const label =
        child.snapshot.data[BreadCrumbComponent.ROUTE_DATA_BREADCRUMB];

      this.setBreadcrumbLabelForShopDetailView(
        breadcrumbs,
        this.shopService,
        url,
        routeURL,
        label
      );
      // set the label for product item as it relates to the shop
      //   if (url.indexOf('/shop/') !== -1) {
      //     if (routeURL) {
      //       const productId = !isNaN(parseInt(routeURL, 10))
      //         ? parseInt(routeURL, 10)
      //         : 0;

      //       this.shopService.getProduct(productId).subscribe((response) => {
      //         label = response.name;
      //         breadcrumbs.push({ label, url });
      //       });
      //     }
      //   } else {
      //     if (label) {
      //       breadcrumbs.push({ label, url });
      //     }
      //   }

      return this.createBreadcrumbs(child, url, breadcrumbs);
    }
  }

  private setBreadcrumbLabelForShopDetailView(
    breadcrumbs: MenuItem[],
    shopService: ShopService,
    url: string,
    routeURL: string,
    label: any
  ): void {
    if (url.indexOf('/shop/') !== -1) {
      if (routeURL) {
        const productId = !isNaN(parseInt(routeURL, 10))
          ? parseInt(routeURL, 10)
          : 0;

        this.shopService.getProduct(productId).subscribe((response) => {
          label = response.name;
          breadcrumbs.push({ label, url });
        });
      }
    } else {
      if (label) {
        breadcrumbs.push({ label, url });
      }
    }
  }
}
