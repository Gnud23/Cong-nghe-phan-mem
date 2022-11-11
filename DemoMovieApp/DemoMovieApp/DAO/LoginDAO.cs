﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoMovieApp.DAO
{
    class LoginDAO
    {
        private static LoginDAO instance;
        
        public static LoginDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginDAO();
                return instance;
            }
            private set => instance = value;
        }

        public bool validateAccount(String username, String password)
        {
            Connection connection = new Connection();
            connection.openConnection();

            try
            {
                SqlCommand c = new SqlCommand("select * from KhachHang where soDienThoai = @username and matKhau = @password", connection.GetSqlConnection());
                
                c.Parameters.AddWithValue("@username", username);
                c.Parameters.AddWithValue("@password", password);
                
                SqlDataReader data = c.ExecuteReader();

                if (data.Read() == true)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.closeConnection();

            return false;
        }

    }
}
