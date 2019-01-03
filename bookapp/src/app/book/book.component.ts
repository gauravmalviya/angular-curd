import { Component, OnInit } from '@angular/core';
import { BookModel } from './_models/bookmodel';
import { BookService } from './_services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  selectedBook: any = {} as BookModel;
  listBooks: any = [] as BookModel[];
  updateMode: any = false as boolean;

   constructor(private _book: BookService) {

  }

  ngOnInit() {
    this.bindBooks();
  }

  // Bind Books
  bindBooks() {
    this._book.getAllBooks()
    .subscribe((result: BookModel[]) => {
      console.log(result);
      this.listBooks = result;
    });
  }
  bindBook(bookId) {
    this._book.getBook(bookId)
    .subscribe((result: BookModel) => {
      console.log(result);
      this.selectedBook = Object.assign({}, result);
    });
  }
  saveBook() {
    if (this.selectedBook.bookId > 0) {
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
    this.selectedBook.bookId = 0;
    this.updateMode = true;
  }
  editSocietyEmployees(model: any) {
    this.updateMode = true;
    this.selectedBook = Object.assign({}, model);
  }
  cancelOnClick() {
    this.updateMode = false;
    console.log(this.selectedBook);
  }

}
