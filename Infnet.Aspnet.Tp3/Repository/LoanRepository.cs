using Infnet.Aspnet.Tp3.Entities;
using Infnet.Aspnet.Tp3.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Infnet.Aspnet.Tp3.Repository
{
    public class LoanRepository : IRepository<LoanEntity>
    {
        private readonly IConfigurationUtility _configurationUtility;
        public LoanRepository(IConfigurationUtility configurationUtility)
        {
            this._configurationUtility = configurationUtility;
        }

        public bool DeleteData(int id)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this._configurationUtility.ConnectionString))
            {
                string query = @"DELETE FROM Loan WHERE Id = @Id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Id", id);
                LoanEntity loan = new LoanEntity();
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

        public LoanEntity GetData(int id)
        {
            using (var conn = new SqlConnection(this._configurationUtility.ConnectionString))
            {
                string query = @"SELECT * FROM Loan WHERE Id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                LoanEntity loan = new LoanEntity();
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                loan.BookId = (int)reader["BookId"];
                                loan.Id = (int)reader["id"];
                                loan.LoanDate = (DateTime)reader["LoanDate"];
                                loan.DevolutionDate = (DateTime)reader["DevolutionDate"];
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
                return loan;
            }
        }

        public List<LoanEntity> GetListData()
        {
            using (var conn = new SqlConnection(this._configurationUtility.ConnectionString))
            {
                string query = @"SELECT * FROM Loan";
                var command = new SqlCommand(query, conn);
                List<LoanEntity> loans = new List<LoanEntity>();
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var loan = new LoanEntity();
                                loan.BookId = (int)reader["BookId"];
                                loan.Id = (int)reader["id"];
                                loan.LoanDate = (DateTime)reader["LoanDate"];
                                loan.DevolutionDate = (DateTime)reader["DevolutionDate"];
                                loans.Add(loan);
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
                return loans;
            }
        }

        public bool InsertData(LoanEntity data)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this._configurationUtility.ConnectionString))
            {
                string query = @"INSERT INTO Loan (LoanDate, DevolutionDate, BookId) VALUES (@LoanDate, @DevolutionDate, @BookId)";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@LoanDate", data.LoanDate);
                command.Parameters.AddWithValue("@DevolutionDate", data.DevolutionDate);
                command.Parameters.AddWithValue("@BookId", data.BookId);
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

        public bool UpdateData(LoanEntity data)
        {
            int rows = 0;
            using (var conn = new SqlConnection(this._configurationUtility.ConnectionString))
            {
                string query = @"UPDATE Loan SET LoanDate = @LoanDate, DevolutionDate = @DevolutionDate, BookId = @BookId WHERE Id = @Id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@LoanDate", data.LoanDate);
                command.Parameters.AddWithValue("@DevolutionDate", data.DevolutionDate);
                command.Parameters.AddWithValue("@BookId", data.BookId);
                command.Parameters.AddWithValue("@Id", data.Id);
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