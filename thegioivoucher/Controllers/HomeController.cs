using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using thegioivoucher.Models;

namespace thegioivoucher.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {

            List<User> listUser = new List<User>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From Users";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(dataReader["id"]);
                        user.Username = Convert.ToString(dataReader["username"]);
                        user.Password = Convert.ToString(dataReader["password"]);
                        user.Status = Convert.ToString(dataReader["status"]);
                        user.CreatedDate = Convert.ToDateTime(dataReader["created_date"]);
                        user.UpdatedDate = Convert.ToDateTime(dataReader["updated_date"]);

                        listUser.Add(user);
                    }
                }

                connection.Close();
            }
            return View(listUser);
        }


        public IActionResult Detail()
        {

            List<User> listUser = new List<User>();
            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //SqlDataReader
            //    connection.Open();

            //    string sql = "Select * From Users";
            //    SqlCommand command = new SqlCommand(sql, connection);

            //    using (SqlDataReader dataReader = command.ExecuteReader())
            //    {
            //        while (dataReader.Read())
            //        {
            //            User user = new User();
            //            user.Id = Convert.ToInt32(dataReader["id"]);
            //            user.Username = Convert.ToString(dataReader["username"]);
            //            user.Password = Convert.ToString(dataReader["password"]);
            //            user.Status = Convert.ToString(dataReader["status"]);
            //            user.CreatedDate = Convert.ToDateTime(dataReader["created_date"]);
            //            user.UpdatedDate = Convert.ToDateTime(dataReader["updated_date"]);

            //            listUser.Add(user);
            //        }
            //    }

            //    connection.Close();
            //}
            return View(listUser);
        }


        public IActionResult DraftListCoupon()
        {

            List<User> listUser = new List<User>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From Users";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(dataReader["id"]);
                        user.Username = Convert.ToString(dataReader["username"]);
                        user.Password = Convert.ToString(dataReader["password"]);
                        user.Status = Convert.ToString(dataReader["status"]);
                        user.CreatedDate = Convert.ToDateTime(dataReader["created_date"]);
                        user.UpdatedDate = Convert.ToDateTime(dataReader["updated_date"]);

                        listUser.Add(user);
                    }
                }

                connection.Close();
            }
            return View(listUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
