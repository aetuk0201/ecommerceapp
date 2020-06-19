import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorModule } from 'primeng/paginator';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagingComponent } from './components/paging/paging.component';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api/';
import { MessageComponent } from './components/message/message.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingComponent,
    MessageComponent,
    OrderTotalsComponent,
  ],
  imports: [CommonModule, PaginatorModule, MessageModule, MessagesModule],
  providers: [MessageService],
  exports: [
    CommonModule,
    PaginatorModule,
    PagingHeaderComponent,
    PagingComponent,
    MessageModule,
    MessagesModule,
    MessageComponent,
    OrderTotalsComponent,
  ],
})
export class SharedModule {}
