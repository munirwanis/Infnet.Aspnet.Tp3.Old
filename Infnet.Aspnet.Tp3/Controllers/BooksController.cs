using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Models;
using Infnet.Aspnet.Tp3.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Infnet.Aspnet.Tp3.Controllers
{
    public class BooksController : Controller
    {
        private Context _repositoryContext;
        public BooksController()
        {
            _repositoryContext = new Context();
        }
        // GET: Books
        public ActionResult Index()
        {
            var response = new List<BookViewModel>();
            var booksEntity = this._repositoryContext.BooksRepository.GetListData();
            booksEntity.ForEach(x => {
                response.Add(new BookViewModel {
                    Author = x.Author,
                    Id = x.Id,
                    Publisher = x.Publisher,
                    Title = x.Title,
                    Year = x.Year
                });
            });
            return View(response);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                // TODO: Add insert logic here
                var bookEntity = new BooksEntity
                {
                    Author = book.Author,
                    Publisher = book.Publisher,
                    Title = book.Title,
                    Year = book.Year
                };

                var result = this._repositoryContext.BooksRepository.InsertData(bookEntity);

                return result ? RedirectToAction("Index") : RedirectToAction("Create");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
