import { Component, OnInit } from '@angular/core';
import { BookModel } from './_models/bookmodel';
import { BookService } from './_services/book.service';
import { AuthorModel } from './_models/authormodel';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  selectedBook: any = {} as BookModel;
  listBooks: any = [] as BookModel[];
  updateMode: any = false as boolean;
  autherList: any = [] as AuthorModel[];

  constructor(private _book: BookService) {

  }

  ngOnInit() {
    this.bindBooks();
    this.autherList = [];
  }

  // Bind Books
  bindBooks() {
    this._book.getAllBooks()
    .subscribe((result: any) => {
      console.log(result);
      this.listBooks = result.data;
      console.log(this.listBooks);
    });
  }
  bindBook(bookId) {
    this._book.getBook(bookId)
    .subscribe((result: BookModel) => {
      console.log(result);
      this.selectedBook = Object.assign({}, result);
    });
  }
 
  onValueChange(value: Date): void {
    this.selectedBook.dateOfPublication = (value).getTime() / 1000;
  }

  saveBook() {
    console.log(this.selectedBook);
    const _authorListTemp = [];
    this.autherList.forEach(function (item) {
      console.log(item);
      _authorListTemp.push(item.value);
    });
    this.selectedBook.authors = _authorListTemp;
    
    if (this.selectedBook.id !== '') {
      this._book.updateBook(this.selectedBook)
      .subscribe((result) => {
        console.log(result);
        this.bindBooks();
        this.updateMode = false;
      });
    } else {
      this._book.saveBook(this.selectedBook)
      .subscribe((result) => {
        console.log(result);
        this.bindBooks();
        this.updateMode = false;
      });
    }
    console.log(this.selectedBook);
  }
  deleteBook(bookId: any) {
    this._book.deleteBook(bookId)
    .subscribe((result) => {
      console.log(result);
      this.bindBooks();
      this.updateMode = false;
    });
  }
  addnewOnClick() {
    this.selectedBook.id = '';
    this.selectedBook.name = '';
    this.autherList = [];
    this.updateMode = true;
  }
  editBook(model: any) {
    this.updateMode = true;
    this.selectedBook = Object.assign({}, model);
    const _authorListTemp = [];

    this.selectedBook.authors.forEach(function (value) {
      console.log(value);
      _authorListTemp.push({display: value, value: value});
    });
    this.autherList = _authorListTemp;
    console.log(this.autherList);
  }
  cancelOnClick() {
    this.updateMode = false;
    console.log(this.selectedBook);
    this.autherList = [];
  }

}
