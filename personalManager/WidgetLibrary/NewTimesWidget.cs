using System;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NewTimesWidget : Gtk.Bin
	{
		public NewTimesWidget ()
		{
			this.Build ();
		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnEditTogglebuttonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBackButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnDayComboboxChanged (object sender, EventArgs e)
		{
			if (dayCombobox.ActiveText == "Freitag") {
				dateLabel.Text = "09.07.2014";
			}

			if (dayCombobox.ActiveText == "Samstag") {
				dateLabel.Text = "10.07.2014";
			}

			if (dayCombobox.ActiveText == "Sonntag") {
				dateLabel.Text = "11.07.2014";
			}
		}
	}
}

