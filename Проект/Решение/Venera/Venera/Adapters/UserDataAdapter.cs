using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using Venera.Utils;
using Venera.Forms;

namespace Venera.Adapters {
	public class UserDataAdapter {

		public MySqlConnection Conn { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Role { get; private set; }
		public string Email { get; private set; }
		public DateTime RegDate { get; private set; }
		public Stack<DynForm> History { get; private set;}
		// public OrganizationDataAdapter Organization { get; private set; }

		public UserDataAdapter(MySqlConnection conn) {
			Conn = conn;
			History = new Stack<DynForm>();
		}

		// Регистрация пользователя
		public void Register(string name, string email, string pass) {
			
			// Зашифровать пароль
			string HashedPas = QueryUtils.GetMD5Hash(pass);

			// Запрос для получения ид роли обычного пользователя
			MySqlCommand GetRoleIdQuery = Conn.CreateCommand();
			GetRoleIdQuery.CommandText = "select id from user_role where name = 'usual'";

			Conn.Open();

			MySqlDataReader RoleIdReader = GetRoleIdQuery.ExecuteReader();

			int RoleId;

			try {
				if (!RoleIdReader.HasRows)
					throw new Exception("Роль 'usual' не была найдена");
		
				RoleIdReader.Read();

				RoleId = RoleIdReader.GetInt32("id");
			
			} finally {
				RoleIdReader.Close();
				Conn.Close();
			}

			// Отправить данные
			MySqlCommand InsertQuery = Conn.CreateCommand();
			InsertQuery.CommandText = 
				"insert into user(name, email, password, role_id, reg_date)" + 
				"values (@name, @email, @password, @role_id, @reg_date)";

			InsertQuery.Parameters.Add("name", MySqlDbType.VarChar).Value = name;
			InsertQuery.Parameters.Add("email", MySqlDbType.VarChar).Value = email;
			InsertQuery.Parameters.Add("password", MySqlDbType.VarChar).Value = HashedPas;
			InsertQuery.Parameters.Add("role_id", MySqlDbType.Int32).Value = RoleId;
			InsertQuery.Parameters.Add("reg_date", MySqlDbType.Date).Value = DateTime.Now;

			Conn.Open();

			InsertQuery.ExecuteNonQuery();

			Conn.Close();
		}

		// Авторизация пользователя
		public bool Auth(string email, string pass) {
			
			// Получение Ид пользователя
			MySqlCommand GetUserIdQuery = Conn.CreateCommand();
			GetUserIdQuery.CommandText = "select id from user where email = @email and password = @pass";

			GetUserIdQuery.Parameters.Add("email", MySqlDbType.VarChar).Value = email;
			GetUserIdQuery.Parameters.Add("pass", MySqlDbType.VarChar).Value = QueryUtils.GetMD5Hash(pass);

			bool Result = false;

			Conn.Open();

			MySqlDataReader UserIdReader = GetUserIdQuery.ExecuteReader();

			if (UserIdReader.HasRows) {
				
				Result = true;

				UserIdReader.Read();

				Id = UserIdReader.GetInt32("id");

				UserIdReader.Close();

				// Получение данных пользователя
				GetData(Id);

			}

			Conn.Close();

			return Result;
		}

		public void GetData(int id) {
			
		}

		public void Update (string name, string pass) {
		
		}

		public void IncreaseRole() {
		
		}

	}
}
