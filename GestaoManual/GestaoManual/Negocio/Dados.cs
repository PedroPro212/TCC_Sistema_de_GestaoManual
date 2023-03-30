﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GestaoManual.Negocio
{
    public class Dados
    {
        private MySqlConnection connection;
        public Dados()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public bool UpdateSenha(Classes.Dados dados)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE login SET senha = @senha WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("senha", dados.Senha));
                comando.Parameters.Add(new MySqlParameter("id", dados.Id));
                comando.ExecuteNonQuery();
                connection.Clone();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateTel(Classes.Dados dados)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE funcionarios SET tel = @tel WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("tel", dados.Tel));
                comando.Parameters.Add(new MySqlParameter("id", dados.Id));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateEmail(Classes.Dados dados)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"UPDATE funcionarios SET email = @email WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("email", dados.Email));
                comando.Parameters.Add(new MySqlParameter("id", dados.Id));
                comando.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}