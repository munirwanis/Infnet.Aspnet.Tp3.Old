using Infnet.Aspnet.Tp3.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Infnet.Aspnet.Tp3.Repository
{
    internal class BooksRepository : IRepository<BooksEntity>
    {
        private string connString;
        public BooksRepository(string connString)
        {
            this.connString = connString;
        }

        public bool DeleteData(int id)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"DELETE FROM Books WHERE Id = @Id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Id", id);
                BooksEntity book = new BooksEntity();
                try
                {
                    conn.Open();
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return rows > 0;
            }
        }

        public BooksEntity GetData(int id)
        {
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"SELECT * FROM Books WHERE Id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                BooksEntity book = new BooksEntity();
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                book.Author = (string)reader["Author"];
                                book.Id = (int)reader["id"];
                                book.Publisher = (string)reader["Publisher"];
                                book.Title = (string)reader["Title"];
                                book.Year = (int)reader["Year"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return book;
            }
        }

        public List<BooksEntity> GetListData()
        {
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"SELECT * FROM Books";
                var command = new SqlCommand(query, conn);
                List<BooksEntity> books = new List<BooksEntity>();
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var book = new BooksEntity();
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
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return books;
            }
        }

        public bool InsertData(BooksEntity data)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"INSERT INTO Books (Author, Publisher, Title, Year) VALUES (@Author, @Publisher, @Title, @Year)";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Author", data.Author);
                command.Parameters.AddWithValue("@Publisher", data.Publisher);
                command.Parameters.AddWithValue("@Title", data.Title);
                command.Parameters.AddWithValue("@Year", data.Year);
                BooksEntity book = new BooksEntity();
                try
                {
                    conn.Open();
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return rows > 0;
            }
        }

        public bool UpdateData(BooksEntity data)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this.connString))
            {
                string query = @"UPDATE Books SET Author = @Author, Publisher = @Publisher, Title = @Title, Year = @Year WHERE Id = @Id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Author", data.Author);
                command.Parameters.AddWithValue("@Publisher", data.Publisher);
                command.Parameters.AddWithValue("@Title", data.Title);
                command.Parameters.AddWithValue("@Year", data.Year);
                command.Parameters.AddWithValue("@Id", data.Id);
                BooksEntity book = new BooksEntity();
                try
                {
                    conn.Open();
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                return rows > 0;
            }
        }
    }
}