using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Venera.Utils;
using Venera.Forms;
using Venera.Adapters;

namespace Venera {
	public partial class FMain : Form {
		
		public MySqlConnection Conn { get; private set; }

		public UserDataAdapter User { get; private set; }

		public FMain() {
			InitializeComponent();

			Conn = QueryUtils.GetConnection();
			User = new UserDataAdapter(Conn);
			 

		}

		private void FMain_Load(object sender, EventArgs e) {
			new DynAuthForm().Generate(this);

			if (!QueryUtils.CheckConnection(Conn))
				MessageBox.Show("Ну удалось установить соединение с БД");

		}

	}
}
