using System.Windows.Forms;

using Venera.Adapters;

namespace Venera.Forms {
	public class DynForm {

		protected FMain programForm;

		public virtual void Generate(FMain aForm) {
			programForm = aForm;
			// aForm.User.History.Push(this);
		}

	}
}
