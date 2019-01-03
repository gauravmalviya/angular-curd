import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './book.component';
import { BookRoutes } from './book.routing';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    RouterModule.forChild(BookRoutes),
  ],
  declarations: [
    BookComponent,
  ]
})
export class BookModule { }

