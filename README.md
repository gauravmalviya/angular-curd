# angular-curd


## Backend WebAPI

Create a MVC WebApi application with Entity Framework (code first) with the following endpoints
GET /books - get all books
GET /book/{id} - get book by id
DELETE /book/{id} - delete book (should not delete item in DB, only mark it is deleted)
POST /book/{id} - create book
PATCH /book/{id} - update book (partial, update only fields which was sent)

Book object
{
id: string, // guid
name: string,
numberOfPages: number,
dateOfPublication: number, // utc timestamp
createDate: number, // utc timestamp, internal only (not returned by api)
updateDate: number, // utc timestamp, internal only (not returned by api)
authors: string[]
}



##  Front end Angular:

Create a simple Angular2/4/5/6 application with two pages:
a. List of books sorted by book names (asc), 5 items on pages + paging
b. Book details (name, authors, number of pages, date of publication)
Just hardcode some list with 13 books in the code. Skip any styling work.
Add "Edit" button to book details page which will allow to edit all fields. And also "Save" and "Cancel" buttons to save or discard changes.
