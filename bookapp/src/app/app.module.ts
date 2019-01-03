import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { Approutes } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookModule } from './book/book.module';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BookService } from './book/_services/book.service';

@NgModule({
   declarations: [
      AppComponent,
   ],
   imports: [
      BrowserModule,
      CommonModule,
      HttpClientModule,
      RouterModule.forRoot(Approutes, { useHash: false }),
      BookModule
   ],
   providers: [BookService],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
