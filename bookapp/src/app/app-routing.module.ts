import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './book/book.component';


export const Approutes: Routes = [
    {
      path: '',
      children: [
        {
          path: 'book',
          component: BookComponent,
          children: [
            { path: '', redirectTo: '/book', pathMatch: 'full' },
            {
              path: '',
              loadChildren: './book/book.module#BookModule'
            },
          ]
        },
      ]
  },
  {
    path: '**',
    redirectTo: '/book'
  }
];

