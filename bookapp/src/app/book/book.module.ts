import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './book.component';
import { BookRoutes } from './book.routing';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule, PaginationModule  } from 'ngx-bootstrap';
import { Ng2SearchPipeModule } from 'ng2-search-filter'; // importing the module
import { Ng2OrderModule } from 'ng2-order-pipe'; // importing the module

@NgModule({
  imports: [
    TagInputModule,
    BrowserAnimationsModule,
    FormsModule,
    CommonModule,
    RouterModule.forChild(BookRoutes),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    Ng2SearchPipeModule, // including into imports
    Ng2OrderModule
  ],
  declarations: [
    BookComponent,
  ]
})
export class BookModule { }

