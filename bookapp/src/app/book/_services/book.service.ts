import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookModel } from '../_models/bookmodel';

@Injectable()
export class BookService {
    constructor(private http: HttpClient) { }
    baseUrl = 'http://localhost:5000/api/book/';


    getAllBooks() {
        return this.http.get<BookModel[]>(this.baseUrl);
    }
    getBook(id) {
        return this.http.get<BookModel>(this.baseUrl + id);
    }
    saveBook(model: any) {
        return this.http.post(this.baseUrl, model);
    }
    updateBook(model: any) {
        return this.http.patch(this.baseUrl + model.id, model);
    }
    deleteBook(model: any) {
        return this.http.delete(this.baseUrl + model.id);
    }

}
