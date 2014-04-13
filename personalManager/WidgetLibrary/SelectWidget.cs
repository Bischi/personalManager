using System;
using Gtk;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SelectWidget : Gtk.Bin
	{
		PersonWidget pw;
		public static DBConnector connection;
		
		public SelectWidget ()
		{
			this.Build ();
			connection = new SQLiteConnection();

			pw = new PersonWidget();
		}

		public void onHomeButtonClicked()
		{
			this.Remove(pw);
			this.Add(hbuttonbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}

		protected void onplanButtonClicked (object sender, EventArgs e)
		{
			this.Remove(hbuttonbox3);
			this.Add(pw);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}

		protected void onpersonButtonClicked (object sender, EventArgs e)
		{
			this.Remove(hbuttonbox3);
			pw.SetSizeRequest(750, 650);
			this.Add(pw);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}
	}
}

