import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { PaginatorModule } from 'primeng/paginator';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagingComponent } from './components/paging/paging.component';

@NgModule({
  declarations: [PagingHeaderComponent, PagingComponent],
  imports: [CommonModule, HttpClientModule, PaginatorModule],
  exports: [
    CommonModule,
    HttpClientModule,
    PaginatorModule,
    PagingHeaderComponent,
    PagingComponent,
  ],
})
export class SharedModule {}