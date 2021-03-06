using System;
using System.Windows.Forms;

namespace Venera.NewComponents {

	// Класс кнопок Далее и Назад на формах регистрации и создания организации
	class BackNextButtons : TableLayoutPanel {

		public Button BBack { get; private set; }
		public Button BNext { get; private set; }
		
		public event EventHandler BackClick;
		public event EventHandler NextClick;
		
		public BackNextButtons() {
			
			BBack = new Button();
			BNext = new Button();

			BBack.Click += delegate(Object s, EventArgs e) {
				BackClick(BBack, new EventArgs());
			};
			BNext.Click += delegate(Object s, EventArgs e) {
				NextClick(BNext, new EventArgs());
			};

			BBack.Text = "<";
			BBack.Dock = DockStyle.Fill;
			BBack.Height = 30;

			BNext.Text = "Далее";
			BNext.Dock = DockStyle.Fill;

			this.AutoSize = true;

			// this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

			this.ColumnCount = 3;
			this.RowCount = 1;

			this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
			this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
			this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

			this.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			this.Controls.Add(BBack, 1, 0);
			this.Controls.Add(BNext, 2, 0);

		}

	}

}
