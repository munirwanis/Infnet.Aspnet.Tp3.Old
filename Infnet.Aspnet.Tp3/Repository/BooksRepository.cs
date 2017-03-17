using Infnet.Aspnet.Tp3.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infnet.Aspnet.Tp3.Repository
{
    internal class BooksRepository : IRepository
    {
        private string connString;
        public BooksRepository(string connString)
        {
            this.connString = connString;
        }

        public bool DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public TObject GetData<TObject>(int id) where TObject : BaseEntity, new()
        {
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"SELECT * FROM Books WHERE Id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                TObject book = null;
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                book = new BooksEntity();
                                book.Author = (string)reader["Author"];
                                book.Id = (int)reader["id"];
                                book.Publisher = (string)reader["Publisher"];
                                book.Title = (string)reader["Title"];
                                book.Year = (int)reader["Year"];
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
                return book;
            }
        }

        public List<TObject> GetListData<TObject>() where TObject : BaseEntity, new()
        {
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"SELECT * FROM Books WHERE";
                var command = new SqlCommand(query, conn);
                List<BooksEntity> books = null;
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            books = new List<BooksEntity>();
                            while (reader.Read())
                            {
                                book = new BooksEntity();
                                book.Author = (string)reader["Author"];
                                book.Id = (int)reader["id"];
                                book.Publisher = (string)reader["Publisher"];
                                book.Title = (string)reader["Title"];
                                book.Year = (int)reader["Year"];
                                books.Add(book);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
                return books;
            }
        }

        public bool InsertData(object data)
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(int id)
        {
            throw new NotImplementedException();
        }
    }
}