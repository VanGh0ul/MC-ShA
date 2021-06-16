﻿using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

using Venera.NewComponents;
using Venera.Forms;
using Venera.Adapters;
using Venera.Utils;

namespace Venera.Forms {

	class DynRegisterForm : DynForm {

		public TableLayoutPanel formContent { get; private set; }

		public Label LTitle { get; private set; }

		public Label LName { get; private set; }
		public TextBox TbName { get; private set; }

		public Label LEmail { get; private set; }
		public TextBox TbEmail { get; private set; }

		public Label LPassword { get; private set; }
		public PasswordField PfPassword { get; private set; }

		public Label LRepeatPassword { get; private set; }
		public PasswordField PfRepeatPassword { get; private set; }

		private FlowLayoutPanel FlpChoose;
		public RadioButton RbCreateOrganization { get; private set; }
		public RadioButton RbCreateWorker { get; private set; }

		private BackNextButtons BackNext;


		public DynRegisterForm() {
			
			formContent = new TableLayoutPanel();
			LTitle = new Label();
			LName = new Label();
			TbName = new TextBox();
			LEmail = new Label();
			TbEmail = new TextBox();
			LPassword = new Label();
			PfPassword = new PasswordField();
			LRepeatPassword = new Label();
			PfRepeatPassword = new PasswordField();
			FlpChoose = new FlowLayoutPanel();
			RbCreateOrganization = new RadioButton();
			RbCreateWorker = new RadioButton();
			BackNext = new BackNextButtons();

			BackNext.BackClick += RegistrationFormBackButton;

			BackNext.NextClick += RegistrationButtonClick;

			#region Свойства компонентов
			LTitle.Text = "Регистрация";
			LTitle.AutoSize = true;
			LTitle.Anchor = AnchorStyles.None;
			LTitle.Font = new Font("Helvetica", 25);

			LName.Text = "ФИО";
			TextStyle(LName);

			TextBoxStyle(TbName);

			LEmail.Text = "Электронный адрес";
			TextStyle(LEmail);

			TextBoxStyle(TbEmail);

			LPassword.Text = "Пароль";
			TextStyle(LPassword);

			PasswordFieldStyle(PfPassword);

			LRepeatPassword.Text = "Повторите Пароль";
			TextStyle(LRepeatPassword);

			PasswordFieldStyle(PfRepeatPassword);

			RbCreateOrganization.Text = "Создать организацию";
			RbCreateOrganization.AutoSize = true;
			RbCreateOrganization.Font = new Font("Helvetica", 10);

			RbCreateWorker.Text = "Работник";
			RbCreateWorker.AutoSize = true;
			RbCreateWorker.Font = new Font("Helvetica", 10);
			RbCreateWorker.Top = 50;
			RbCreateWorker.Checked = true;

			FlpChoose.FlowDirection = FlowDirection.TopDown;
			FlpChoose.WrapContents = false;
			FlpChoose.AutoSize = true;
			FlpChoose.Controls.Add(RbCreateOrganization);
			FlpChoose.Controls.Add(RbCreateWorker);
			
			BackNext.BBack.Font = new Font("Helvetica", 10);
			BackNext.BNext.Font = new Font("Helvetica", 10);
			#endregion

			#region Таблица
			// formContent.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

			formContent.Dock = DockStyle.Fill;

			formContent.ColumnCount = 3;
			formContent.RowCount = 15;

			formContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
			formContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
			formContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));

			// Пустой промежуток
			formContent.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

			// Регистрация
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Пустой промежуток
			formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));

			// ФИО
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Поле ФИО
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Электронный адрес
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Поле электронный адрес
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Пароль
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Поле Пароль
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Повторите пароль
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Поле Повтора пароля
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Пустой промежуток
			formContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));

			// Выбор
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Кнопки
			formContent.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			// Пустой промежуток
			formContent.RowStyles.Add(new RowStyle(SizeType.Percent, 20));


			formContent.Controls.Add(LTitle, 1, 1);
			formContent.Controls.Add(LName, 1, 3);
			formContent.Controls.Add(TbName, 1, 4);
			formContent.Controls.Add(LEmail, 1, 5);
			formContent.Controls.Add(TbEmail, 1, 6);
			formContent.Controls.Add(LPassword, 1, 7);
			formContent.Controls.Add(PfPassword, 1, 8);
			formContent.Controls.Add(LRepeatPassword, 1, 9);
			formContent.Controls.Add(PfRepeatPassword, 1, 10);
			formContent.Controls.Add(FlpChoose, 1, 12);
			formContent.Controls.Add(BackNext, 1, 13);


			#endregion
		}

													// Вид компонентов
		private void TextStyle(Label aLabel) {
			aLabel.AutoSize = true;
			aLabel.Font = new Font("Helvetica", 10);
		}

		private void TextBoxStyle(TextBox aTextBox) {
			aTextBox.Dock = DockStyle.Fill;
			aTextBox.Font = new Font("Helvetica", 10);
		}

		private void PasswordFieldStyle(PasswordField aPassField) {
			aPassField.Dock = DockStyle.Fill;
			aPassField.TextField.Font = new Font("Helvetica", 10);
			aPassField.ViewButton.BackgroundImageLayout = ImageLayout.Zoom;
			aPassField.ViewButton.BackgroundImage = Properties.Resources.see_password;
		}


													// Генерация формы регистрации
		public override void Generate(FMain aForm) {

			base.Generate(aForm);

			programForm.Controls.Clear();
			Size FormSize = new Size(400, 500);
			programForm.MinimumSize = FormSize;
			//aForm.MaximumSize = FormSize;
			programForm.Size = FormSize;
			programForm.Text = "Регистрация";
			programForm.Controls.Add(formContent);

		}


													// Кнопка регистрации
		private void RegistrationButtonClick(Object s, EventArgs e) {
			
			string Name = TbName.Text.Trim(); 
			string Email = TbEmail.Text.Trim();
			string Pass = PfPassword.TextField.Text.Trim();
			string RepeatPass = PfRepeatPassword.TextField.Text.Trim();

													// Проверка электронной почты
			if (!QueryUtils.CheckEmail(Email)) {
				MessageBox.Show("Электронаня почта имеет неправильный формат");
				return;
			}

													// Проверка имени пользователя
			if (!QueryUtils.CheckUserName(Name)) {
				MessageBox.Show("Имя пользователя слишком длинное либо содержит неподдерживаемые символы");
				return;
			}
													// Проверка пароля
			if (!QueryUtils.CheckPassword(Pass)) {
				MessageBox.Show("Пароль должен содержать от 6 до 16 символов, а так же содержать хотябы 1 заглавную букву и цифру");
				return;
			}

			if (Pass != RepeatPass) {
				MessageBox.Show("Пароли не совпадают");
				return;
			}

													// Проверка ункальности эл. адреса

			if (!QueryUtils.CheckUserEmailUnique(programForm.Conn, Email)) {
				MessageBox.Show("Данный электронный адрес уже есть в системе");
				return;
			}


													// Если выбрано "Создать рабочего"
			if (RbCreateWorker.Checked) {
				programForm.User.Register(Name, Email, Pass);
				new DynAuthForm().Generate(programForm);
			} else
				;// new DynCreateOrganizationForm(programForm, this);
		}
		
													// Переход на форму авторизации
		private void RegistrationFormBackButton(Object s, EventArgs e) {
			programForm.User.History.Pop().Generate(programForm);
		}
	


	}

}
