namespace Sample_Web_API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Sample_Web_API.Models;



    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IConfiguration configuration;

        public ValuesController(IConfiguration config)
        {
            this.configuration = config;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<Books> bookList = new List<Books>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from BooksDB.dbo.Books", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books booksData = new Books();
                    booksData.Book_ID = Convert.ToInt32(reader["Book_Id"]);
                    booksData.Author = Convert.ToString(reader["Author"]);
                    booksData.Book_Name = Convert.ToString(reader["Book_Name"]);
                    booksData.Book_Desc = Convert.ToString(reader["Book_Desc"]);
                    booksData.Price = Convert.ToDouble(reader["Price"]);
                    booksData.Pages = Convert.ToInt32(reader["Pages"]);
                    booksData.Book_URL = Convert.ToString(reader["Books_URL"]);
                    booksData.Img_URL = Convert.ToString(reader["Img_URL"]);
                    booksData.Publisher = Convert.ToString(reader["Publisher"]);
                    booksData.Language = Convert.ToString(reader["Books_Language"]);
                    booksData.ISBN = Convert.ToInt64(reader["ISBN"]);
                    bookList.Add(booksData);
                }
                return Json(bookList);
            }
            catch (Exception)
            {
                return Json(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }


        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_GetBooksData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@BookID", SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Books booksData = new Books();
                while (reader.Read())
                {
                    booksData.Book_ID = Convert.ToInt32(reader["Book_Id"]);
                    booksData.Author = Convert.ToString(reader["Author"]);
                    booksData.Book_Name = Convert.ToString(reader["Book_Name"]);
                    booksData.Book_Desc = Convert.ToString(reader["Book_Desc"]);
                    booksData.Price = Convert.ToDouble(reader["Price"]);
                    booksData.Pages = Convert.ToInt32(reader["Pages"]);
                    booksData.Book_URL = Convert.ToString(reader["Books_URL"]);
                    booksData.Img_URL = Convert.ToString(reader["Img_URL"]);
                    booksData.Publisher = Convert.ToString(reader["Publisher"]);
                    booksData.Language = Convert.ToString(reader["Books_Language"]);
                    booksData.ISBN = Convert.ToInt64(reader["ISBN"]);
                }
                return Json(booksData);
            }
            catch (Exception)
            {
                return Json(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }


        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(Books books)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_InsertBooksData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = books.Book_Name;
                sqlCommand.Parameters.Add("@Author", SqlDbType.VarChar).Value = books.Author;
                sqlCommand.Parameters.Add("@Book_URL", SqlDbType.VarChar).Value = books.Book_URL;
                sqlCommand.Parameters.Add("@Img_URL", SqlDbType.VarChar).Value = books.Img_URL;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = books.Book_Desc;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Money).Value = books.Price;
                sqlCommand.Parameters.Add("@Pages", SqlDbType.Int).Value = books.Pages;
                sqlCommand.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = books.Publisher;
                sqlCommand.Parameters.Add("@Language", SqlDbType.VarChar).Value = books.Language;
                sqlCommand.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = Convert.ToString(books.ISBN);


                connection.Open();
                sqlCommand.ExecuteNonQuery();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, Books books)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_UpdateBooksData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = books.Book_Name == null ? (object)DBNull.Value : books.Book_Name;
                sqlCommand.Parameters.Add("@Author", SqlDbType.VarChar).Value = books.Author == null ? (object)DBNull.Value : books.Author;
                sqlCommand.Parameters.Add("@Book_URL", SqlDbType.VarChar).Value = books.Book_URL == null ? (object)DBNull.Value : books.Book_URL;
                sqlCommand.Parameters.Add("@Img_URL", SqlDbType.VarChar).Value = books.Img_URL == null ? (object)DBNull.Value : books.Img_URL;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = books.Book_Desc == null ? (object)DBNull.Value : books.Book_Desc;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Money).Value = books.Price == null ? (object)DBNull.Value : books.Price;
                sqlCommand.Parameters.Add("@Pages", SqlDbType.Int).Value = books.Pages == null ? (object)DBNull.Value : books.Pages;
                sqlCommand.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = books.Publisher == null ? (object)DBNull.Value : books.Publisher;
                sqlCommand.Parameters.Add("@Language", SqlDbType.VarChar).Value = books.Language == null ? (object)DBNull.Value : books.Language;
                sqlCommand.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = books.ISBN == null ? (object)DBNull.Value : Convert.ToString(books.ISBN);


                connection.Open();
                sqlCommand.ExecuteNonQuery();
                return Get(id);
            }
            catch (Exception)
            {
                return Json(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand("delete from BooksDB.dbo.Books where [Book_Id]=@BookID", connection);
                if (id != 0)
                {
                    sqlCommand.Parameters.Add("@BookID", SqlDbType.Int).Value = id;
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    return Json(new HttpResponseMessage(HttpStatusCode.OK));
                }
                else
                {
                    return Json(new HttpResponseMessage(HttpStatusCode.BadRequest));
                }
            }
            catch (Exception)
            {
                return Json(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
