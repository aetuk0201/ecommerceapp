import { AuthGuard } from './core/guards/auth.guard';
import { AccountRoutingModule } from './account/account-routing.module';
import { MessageComponent } from './shared/components/message/message.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { SharedModule } from './shared/shared.module';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductDetailComponent } from './shop/product-detail/product-detail.component';
import { ShopComponent } from './shop/shop.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '',
    data: {
      breadcrumb: 'Home',
    },
    component: HomeComponent,
  },
  {
    path: 'test-error',
    data: {
      breadcrumb: 'Test Error',
    },
    component: TestErrorComponent,
  },
  {
    path: 'server-error',
    data: {
      breadcrumb: 'Server Error',
    },
    component: ServerErrorComponent,
  },
  {
    path: 'not-found',
    data: {
      breadcrumb: 'Not Found',
    },
    component: NotFoundComponent,
  },
  {
    path: 'message',
    data: {
      breadcrumb: 'Message',
    },
    component: MessageComponent,
  },
  {
    path: 'shop',
    loadChildren: () =>
      import('./shop/shop.module').then((mod) => mod.ShopModule),
    data: {
      breadcrumb: 'Shop',
    },
  },
  {
    path: 'cart',
    loadChildren: () =>
      import('./cart/cart.module').then((mod) => mod.CartModule),
    data: {
      breadcrumb: '',
    },
  },
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./checkout/checkout.module').then((mod) => mod.CheckoutModule),
    data: {
      breadcrumb: '',
    },
  },
  {
    path: 'account',
    loadChildren: () =>
      import('./account/account.module').then((mod) => mod.AccountModule),
    data: {
      breadcrumb: '',
    },
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [SharedModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
