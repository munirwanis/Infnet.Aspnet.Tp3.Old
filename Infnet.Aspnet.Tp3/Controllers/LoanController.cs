using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Models;
using Infnet.Aspnet.Tp3.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace Infnet.Aspnet.Tp3.Controllers
{
    public class LoanController : Controller
    {
        private readonly IContext _repositoryContext;
        public LoanController(IContext context)
        {
            _repositoryContext = context;
        }

        // GET: Loan
        public ActionResult Index()
        {
            var response = new List<LoanViewModel>();
            var loanEntity = this._repositoryContext.LoanRepository.GetListData();
            loanEntity.ForEach(x =>
            {
                var book = this._repositoryContext.BooksRepository.GetData(x.BookId);
                response.Add(new LoanViewModel
                {
                    BookId = x.BookId,
                    Id = x.Id,
                    LoanDate = x.LoanDate,
                    DevolutionDate = x.DevolutionDate,
                    Book = new BookViewModel
                    {
                        Author = book.Author,
                        Id = book.Id,
                        Publisher = book.Publisher,
                        Title = book.Title,
                        Year = book.Year
                    }
                });
            });
            return View(response.OrderByDescending(x => x.DevolutionDate));
        }

        // GET: Loan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private void SetSelectList()
        {
            var bookEntity = this._repositoryContext.BooksRepository.GetListData();
            var loanEntity = this._repositoryContext.LoanRepository.GetListData();
            var notLentBooks = (from books in bookEntity
                                join loans in loanEntity on books.Id equals loans.BookId into loan
                                from l in loan.DefaultIfEmpty()
                                where l == null ||
                                      DateTime.Now < l.LoanDate ||
                                      DateTime.Now > l.DevolutionDate
                                select new SelectListItem
                                {
                                    Text = books.Title,
                                    Value = books.Id.ToString()
                                }).Distinct().ToList();
            ViewBag.BooksList = notLentBooks;
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            this.SetSelectList();
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        public ActionResult Create(LoanViewModel loan, int BooksList)
        {
            try
            {
                var loanEntity = new LoanEntity
                {
                    BookId = BooksList,
                    DevolutionDate = loan.DevolutionDate,
                    LoanDate = loan.LoanDate
                };

                var result = this._repositoryContext.LoanRepository.InsertData(loanEntity);

                return result ? RedirectToAction("Index") : RedirectToAction("Create");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Loan/Edit/5
        public ActionResult Edit(int id)
        {
            this.SetSelectList();
            var response = new LoanViewModel();
            var loanEntity = this._repositoryContext.LoanRepository.GetData(id);
            response.BookId = loanEntity.BookId;
            response.Id = loanEntity.Id;
            response.DevolutionDate = loanEntity.DevolutionDate;
            var bookEntity = this._repositoryContext.BooksRepository.GetData(response.BookId);
            response.Book = new BookViewModel
            {
                Author = bookEntity.Author,
                Id = bookEntity.Id,
                Publisher = bookEntity.Publisher,
                Title = bookEntity.Title,
                Year = bookEntity.Year
            };
            return View(response);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LoanViewModel model, int BooksList)
        {
            try
            {
                var loanEntity = new LoanEntity
                {
                    Id = id,
                    BookId = BooksList,
                    LoanDate = model.LoanDate,
                    DevolutionDate = model.DevolutionDate
                };
                var result = this._repositoryContext.LoanRepository.UpdateData(loanEntity);
                return result ? RedirectToAction("Index") : RedirectToAction("Edit");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View("Edit");
            }
        }

        // GET: Loan/Delete/5
        public ActionResult Delete(int id)
        {
            var response = new LoanViewModel();
            var loanEntity = this._repositoryContext.LoanRepository.GetData(id);
            response.BookId = loanEntity.BookId;
            response.Id = loanEntity.Id;
            response.DevolutionDate = loanEntity.DevolutionDate;
            var bookEntity = this._repositoryContext.BooksRepository.GetData(response.BookId);
            response.Book = new BookViewModel
            {
                Author = bookEntity.Author,
                Id = bookEntity.Id,
                Publisher = bookEntity.Publisher,
                Title = bookEntity.Title,
                Year = bookEntity.Year
            };
            return View(response);
        }

        // POST: Loan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var result = this._repositoryContext.LoanRepository.DeleteData(id);
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
