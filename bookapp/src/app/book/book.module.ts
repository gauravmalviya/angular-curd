import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './book.component';
import { BookRoutes } from './book.routing';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    TagInputModule,
    BrowserAnimationsModule,
    FormsModule,
    CommonModule,
    RouterModule.forChild(BookRoutes),
    BsDatepickerModule.forRoot()
  ],
  declarations: [
    BookComponent,
  ]
})
export class BookModule { }

