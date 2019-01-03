import { Routes } from '@angular/router';
import { BookComponent } from './book.component';


export const BookRoutes: Routes = [
  {
    path: 'book',
    children: [
      {
        path: '',
        component: BookComponent,
        data: {
          title: 'Book',
          urls: [
            { title: 'Book', url: '/books' },
            { title: 'Book' }
          ]
        }
      },
    ]
  }
];
