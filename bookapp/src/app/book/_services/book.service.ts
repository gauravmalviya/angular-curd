import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookModel } from '../_models/bookmodel';

@Injectable()
export class BookService {
    constructor(private http: HttpClient) { }
    baseUrl = 'http://localhost:6550/api/book/';


    getAllBooks() {
        return this.http.get<BookModel[]>(this.baseUrl + 'books/');
    }
    getBook(bookId) {
        return this.http.get<BookModel>(this.baseUrl + 'book/' + bookId);
    }
    saveBook(model: any) {
        return this.http.post(this.baseUrl + 'book/' + model.bookId, model);
    }
    updateBook(model: any) {
        return this.http.patch(this.baseUrl + 'book/' + model.bookId, model);
    }
    deleteBook(model: any) {
        return this.http.delete(this.baseUrl + 'book/' + model.bookId, model);
    }

}
