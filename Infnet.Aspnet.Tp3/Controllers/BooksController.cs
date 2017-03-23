using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Models;
using Infnet.Aspnet.Tp3.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var response = new BookViewModel();
            var bookEntity = this._repositoryContext.BooksRepository.GetData(id);
            response.Author = bookEntity.Author;
            response.Id = bookEntity.Id;
            response.Publisher = bookEntity.Publisher;
            response.Title = bookEntity.Title;
            response.Year = bookEntity.Year;
            return View(response);
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
            var response = new BookViewModel();
            var bookEntity = this._repositoryContext.BooksRepository.GetData(id);
            response.Author = bookEntity.Author;
            response.Id = bookEntity.Id;
            response.Publisher = bookEntity.Publisher;
            response.Title = bookEntity.Title;
            response.Year = bookEntity.Year;
            return View(response);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookViewModel model)
        {
            try
            {
                var bookEntity = new BooksEntity
                {
                    Id = id,
                    Author = model.Author,
                    Publisher = model.Publisher,
                    Title = model.Title,
                    Year = model.Year
                };
                var result = this._repositoryContext.BooksRepository.UpdateData(bookEntity);
                return result ? RedirectToAction("Index") : RedirectToAction("Edit");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View("Edit");
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var response = new BookViewModel();
            var bookEntity = this._repositoryContext.BooksRepository.GetData(id);
            response.Author = bookEntity.Author;
            response.Id = bookEntity.Id;
            response.Publisher = bookEntity.Publisher;
            response.Title = bookEntity.Title;
            response.Year = bookEntity.Year;
            return View(response);
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookViewModel model)
        {
            try
            {
                var result = this._repositoryContext.BooksRepository.DeleteData(id);
                return result ? RedirectToAction("Index") : RedirectToAction("Delete");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View("Delete");
            }
        }
    }
}
