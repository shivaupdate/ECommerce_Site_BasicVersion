import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductCardComponent } from './product-card/product-card.component';

@NgModule({
  imports: [
    CommonModule,
    MatCardModule,FormsModule
  ],
  exports: [ProductListComponent],
  declarations: [ProductListComponent, ProductCardComponent]
})
export class ProductModule { }