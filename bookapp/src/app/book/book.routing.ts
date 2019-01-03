import { Routes } from '@angular/router';
import { BookComponent } from './book.component';


export const BookRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: BookComponent,
        data: {
          title: 'Book',
          urls: [
            { title: 'Book', url: '/book' },
            { title: 'Book' }
          ]
        }
      },
    ]
  }
];
