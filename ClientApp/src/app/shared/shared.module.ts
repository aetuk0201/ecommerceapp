import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { PaginatorModule } from 'primeng/paginator';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagingComponent } from './components/paging/paging.component';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api/';
import { MessageComponent } from './components/message/message.component';

@NgModule({
  declarations: [PagingHeaderComponent, PagingComponent, MessageComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule,
    PaginatorModule,
    MessageModule,
    MessagesModule,
  ],
  providers: [MessageService],
  exports: [
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule,
    PaginatorModule,
    PagingHeaderComponent,
    PagingComponent,
    MessageModule,
    MessagesModule,
    MessageComponent,
  ],
})
export class SharedModule {}
