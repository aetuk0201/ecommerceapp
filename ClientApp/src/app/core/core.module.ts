import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SharedModule } from '../shared/shared.module';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadCrumbComponent } from './bread-crumb/bread-crumb.component';
import { BreadcrumbModule } from 'primeng/breadcrumb';

@NgModule({
  declarations: [
    NavBarComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    SectionHeaderComponent,
    BreadCrumbComponent,
  ],
  imports: [RouterModule, SharedModule, BreadcrumbModule],
  exports: [NavBarComponent, SectionHeaderComponent, BreadCrumbComponent],
})
export class CoreModule {}
