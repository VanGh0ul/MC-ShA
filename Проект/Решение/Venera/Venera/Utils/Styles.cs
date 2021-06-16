using System;
using System.Drawing;
using System.Windows.Forms;

using Venera.NewComponents;

namespace Venera.Utils {
	public static class Styles {

		public readonly static Font TextFont = new Font("Helvetica", 10);

		public static void TextStyle(Label aLabel) {
			aLabel.AutoSize = true;
			aLabel.Font = TextFont;
		}

		public static void TextBoxStyle(TextBox aTextBox) {
			aTextBox.Dock = DockStyle.Fill;
			aTextBox.Font = TextFont;
		}

		public static void PasswordFieldStyle(PasswordField aPassField) {
			aPassField.Dock = DockStyle.Fill;
			aPassField.TextField.Font = TextFont;
			aPassField.ViewButton.BackgroundImageLayout = ImageLayout.Zoom;
			aPassField.ViewButton.BackgroundImage = Properties.Resources.see_password;
		}

	}
}
