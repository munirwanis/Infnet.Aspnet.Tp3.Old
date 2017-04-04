using Infnet.Aspnet.Tp3.Controllers;
using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Models;
using Infnet.Aspnet.Tp3.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infnet.Aspnet.Tests
{
    [TestClass]
    public class BooksTest
    {
        private BooksController _booksController;
        private BooksEntity _bookEntity;
        private BookViewModel _bookViewModelSuccess;
        private BookViewModel _bookViewModelFail;

        [TestInitialize]
        public void Initialize()
        {
            var bookRepoMock = new Mock<IRepository<BooksEntity>>();
            var loanRepoMock = new Mock<IRepository<LoanEntity>>();
            this._bookEntity = new BooksEntity
            {
                Author = "Success Test",
                Id = 0,
                Publisher = "Testing",
                Title = "Art of Test",
                Year = 2012,
            };
            var bookEntityFail = new BooksEntity
            {
                Author = "Fail Test",
                Id = 2,
                Publisher = "Testing",
                Title = "Art of Test",
                Year = 2012,
            };

            this._bookViewModelSuccess = new BookViewModel
            {
                Id = 0,
                Author = this._bookEntity.Author,
                Publisher = this._bookEntity.Publisher,
                Title = this._bookEntity.Title,
                Year = this._bookEntity.Year
            };
            this._bookViewModelFail = new BookViewModel
            {
                Id = 0,
                Author = this._bookEntity.Author,
                Publisher = this._bookEntity.Publisher,
                Title = this._bookEntity.Title,
                Year = this._bookEntity.Year
            };

            bookRepoMock.Setup(bookRepo => bookRepo.DeleteData(1)).Returns(true);
            bookRepoMock.Setup(bookRepo => bookRepo.DeleteData(2)).Returns(false);
            bookRepoMock.Setup(bookRepo => bookRepo.InsertData(this._bookEntity)).Returns(true);
            bookRepoMock.Setup(bookRepo => bookRepo.InsertData(bookEntityFail)).Returns(false);
            bookRepoMock.Setup(bookRepo => bookRepo.UpdateData(this._bookEntity)).Returns(true);
            bookRepoMock.Setup(bookRepo => bookRepo.UpdateData(bookEntityFail)).Returns(false);
            bookRepoMock.Setup(bookRepo => bookRepo.GetData(1)).Returns(this._bookEntity);
            bookRepoMock.Setup(bookRepo => bookRepo.GetListData()).Returns(new List<BooksEntity> { this._bookEntity });
            var context = new Context(bookRepoMock.Object, loanRepoMock.Object);
            this._booksController = new BooksController(context);
        }

        [TestMethod, TestCategory("BooksController")]
        public void Books_GetDataSuccess_Test()
        {
            var actionResult = this._booksController.Details(1) as ViewResult;
            var bookModel = actionResult.Model as BookViewModel;

            Assert.AreEqual("Success Test", bookModel.Author);
        }

        [TestMethod, TestCategory("BooksController")]
        public void Books_DeleteDataSuccess_Test()
        {
            var actionResult = (RedirectToRouteResult) this._booksController.Delete(1, this._bookViewModelSuccess);
            Assert.AreEqual("Index", actionResult.RouteValues.Values.FirstOrDefault());
        }

        [TestMethod, TestCategory("BooksController")]
        public void Books_DeleteDataFail_Test()
        {
            var actionResult = (RedirectToRouteResult)this._booksController.Delete(2, this._bookViewModelSuccess);
            Assert.AreEqual("Delete", actionResult.RouteValues.Values.FirstOrDefault());
        }

        [TestMethod, TestCategory("BooksController")]
        public void Books_InsertDataSuccess_Test()
        {
            var actionResult = (RedirectToRouteResult)this._booksController.Create(this._bookViewModelSuccess);
            Assert.AreEqual("Index", actionResult.RouteValues.Values.FirstOrDefault());
        }

        [TestMethod, TestCategory("BooksController")]
        public void Books_InsertDataFail_Test()
        {
            var actionResult = (RedirectToRouteResult)this._booksController.Create(this._bookViewModelFail);
            Assert.AreEqual("Create", actionResult.RouteValues.Values.FirstOrDefault());
        }
    }
}