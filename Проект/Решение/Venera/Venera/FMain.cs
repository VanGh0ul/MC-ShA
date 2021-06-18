using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Venera.Utils;
using Venera.Forms;
using Venera.Adapters;

using System.Drawing;
using Venera.NewComponents;

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
			new DynProductsBandForm().Generate(this);
			/*
			OrganizationIdBasedPanelList List = new OrganizationIdBasedPanelList();

			List.AddAPanel(1, "Организация 1", Properties.Resources.no_image);
			List.AddAPanel(1, "Организация 1", Properties.Resources.no_image);
			List.AddAPanel(1, "Организация 1", Properties.Resources.no_image);
			List.AddAPanel(1, "Организация 1", Properties.Resources.no_image);
			List.AddAPanel(1, "Организация 1", Properties.Resources.no_image);


			this.Controls.Add(List);
			*/
			/*
			UserPanel Elem = new UserPanel(1, "Пользователь 1", "user1@mail.ru");
			Elem.Font = Styles.TextFont;
			Elem.Width = 150;
			Elem.BorderStyle = BorderStyle.FixedSingle;

			this.Controls.Add(Elem);
			*/
			/*
			ProductBand Band = new ProductBand();
			Band.Size = new Size(800, 400);

			Button AddButton = new Button();
			AddButton.Text = "Добавить";
			AddButton.Size = new Size(70, 20);
			AddButton.Location = new Point(810, 50);

			AddButton.Click += delegate(Object s, EventArgs evArgs) {
				OpenFileDialog Ofd = new OpenFileDialog();
				if(Ofd.ShowDialog() == DialogResult.OK)
					Band.AddElement(new BandElement(1, Image.FromFile(Ofd.FileName), "Anime Girls", "Price: Love", "Count: 0", "Added: 2021-01-01", "No organization"));
			};

			Controls.Add(Band);
			Controls.Add(AddButton);
			*/

			if (!QueryUtils.CheckConnection(Conn))
				MessageBox.Show("Ну удалось установить соединение с БД");

		}

	}
}
