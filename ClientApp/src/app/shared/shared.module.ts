import { RouterModule } from '@angular/router';
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
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingComponent,
    MessageComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent,
    CartSummaryComponent,
  ],
  imports: [
    CommonModule,
    PaginatorModule,
    MessageModule,
    MessagesModule,
    ReactiveFormsModule,
    DropdownModule,
    CdkStepperModule,
    RouterModule,
  ],
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
    ReactiveFormsModule,
    DropdownModule,
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    CartSummaryComponent,
  ],
})
export class SharedModule {}
