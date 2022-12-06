using AutoMapper;
using booklib.Entities;
using booklib.Models;
using Microsoft.AspNetCore.Mvc;

namespace booklib.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ModeratorController(DatabaseContext databaseContext, IConfiguration configuration, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookListPartial()
        {
            List<BookModel> books = 
                _databaseContext.Books.ToList().Select(x=>_mapper.Map<BookModel>(x)).ToList();

            return PartialView("_BookListPartial", books);
        }

        public IActionResult AddNewBookPartial()
        {
            return PartialView("_AddNewBookPartial", new BookModel());
        }

        public IActionResult AddNewBook(BookModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Books.Any(x => x.BookName.ToLower() == model.BookName.ToLower() && x.Author.ToLower() == model.Author.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.BookName), "Bu isimde bir kitap zaten var.");
                    return PartialView("_AddNewBookPartial", model);

                }

                Book book = _mapper.Map<Book>(model);


                _databaseContext.Books.Add(book);
                _databaseContext.SaveChanges();

                return PartialView("_AddNewBookPartial", model);
            }

            return PartialView("_AddNewBookPartial", model);
        }

        public IActionResult DeleteBook(Guid id)
        {
            Book book= _databaseContext.Books.Find(id);

            if (book != null)
            {
                _databaseContext.Books.Remove(book);
                _databaseContext.SaveChanges();
            }

            return BookListPartial();
        }
        //meghabab

        //[HttpPost]
        //public IActionResult Index(BookModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if(_databaseContext.Books.Any(x => x.BookName.ToLower() == model.BookName.ToLower() && x.Author.ToLower() == model.Author.ToLower()))
        //        {
        //            ModelState.AddModelError(nameof(model.BookName), "Kitap mevcut, Stok arttırımı yapabilirsiniz.");
        //            return View(model);
        //        }
        //        //Book book = new Book()
        //        //{
        //        //    BookName = model.BookName,
        //        //    Author = model.Author,
        //        //    BookType = model.BookType,
        //        //    //BookImageFileName = model.BookImageFileName,
        //        //    BookSubject = model.BookSubject,
        //        //    PublishingDate = model.PublishingDate,
        //        //    Stock = model.Stock
        //        //};

        //        Book book = _mapper.Map<Book>(model);

        //        _databaseContext.Books.Add(book);
        //        int affectedRowCount = _databaseContext.SaveChanges();

        //        if (affectedRowCount == 0)
        //        {
        //            ModelState.AddModelError("", "Kitap eklenememiştir.");
        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(model);
        //}
    }
}
