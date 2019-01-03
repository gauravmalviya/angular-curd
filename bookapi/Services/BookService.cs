using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bookapi.Data;
using bookapi.ServiceContracts;
using bookapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using bookapi.Data.Entities;
using System.Linq;

namespace bookapi.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly BookDbContext _context;
        public BookService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; //injected automapper            
        }
        public async Task<List<BookViewModel>> GetBooks()
        {
            var _books = await _context.Books.Include("Authors").Where(x => x.IsDeleted == false).ToListAsync();
            var result = _mapper.Map<List<BookViewModel>>(_books);
            return result;
        }
        public async Task<BookViewModel> GetBook(string id)
        {
            var _book = await _context.Books.Include("Authors").FirstOrDefaultAsync(x => x.Id.ToLower() == id.ToLower());
            if (_book == null)
                return null;

            var result = _mapper.Map<BookViewModel>(_book);
            return result;
        }

        public async Task<string> SaveBook(BookViewModel inputData)
        {
            Book oBook = new Book();
            string bookId = Guid.NewGuid().ToString();
            oBook.Id = bookId;
            oBook.Name = inputData.Name;
            oBook.NumberOfPages = inputData.NumberOfPages;
            oBook.CreateDate = DateTime.UtcNow;
            oBook.DateOfPublication = inputData.DateOfPublication;
            oBook.IsDeleted = false;
            _context.Books.Add(oBook);
            Author oAuthor;
            foreach (string _authorName in inputData.Authors)
            {
                oAuthor = new Author();
                oAuthor.Name = _authorName;
                oAuthor.BookId = bookId;
                oAuthor.Id = Guid.NewGuid().ToString();
                _context.Authors.Add(oAuthor);
            }
            await _context.SaveChangesAsync();
            return oBook.Id;
        }

        public async Task<string> UpdateBook(string id, BookViewModel inputData)
        {
            var oBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (oBook == null)
                return null;

            var oBookAuthers = await _context.Authors.Where(x => x.BookId.ToLower() == id.ToLower()).ToListAsync();
            _context.Authors.RemoveRange(oBookAuthers);
            _context.SaveChanges();
            string bookId = id;
            oBook.Id = bookId;
            oBook.Name = inputData.Name;
            oBook.NumberOfPages = inputData.NumberOfPages;
            oBook.UpdateDate = DateTime.UtcNow;
            oBook.DateOfPublication = inputData.DateOfPublication;
            oBook.IsDeleted = false;
            Author oAuthor;
            foreach (string _authorName in inputData.Authors)
            {
                oAuthor = new Author();
                oAuthor.Name = _authorName;
                oAuthor.BookId = bookId;
                oAuthor.Id = Guid.NewGuid().ToString();
                _context.Authors.Add(oAuthor);
            }
            await _context.SaveChangesAsync();
            return oBook.Id;
        }

        public async Task<int> DeleteBook(string id)
        {
            bool retVal = true;
            Data.Entities.Book _book = await _context.Books.FirstOrDefaultAsync(x => x.Id.ToLower() == id.ToLower());
            if (_book == null)
            {
                return 0;
            }

            _book.IsDeleted = true;
            _book.UpdateDate = DateTime.UtcNow;
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}