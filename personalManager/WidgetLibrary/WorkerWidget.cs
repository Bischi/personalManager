using System;
using Gtk;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class WorkerWidget : Gtk.Bin
	{
		public WorkerWidget ()
		{
			this.Build ();
		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			if (checkTextBoxValue() == true) {
				bool addOK = SelectWidget.connection.addWorker (fnameEntry.Text, lnameEntry.Text, villageEntry.Text, hnrEntry.Text, Convert.ToInt32 (plzEntry.Text), emailEntry.Text, mobileEntry.Text, telEntry.Text);
			}
			else 
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Bitte Name, Mobil oder Telefonnummer eingeben!");
				md.Run();
				md.Destroy();
			}
		}

		private bool checkTextBoxValue ()
		{
			if (fnameEntry.Text != "" && lnameEntry.Text != "" && mobileEntry.Text != "" || telEntry.Text != "") 
			{
				return true;
			} 
			else 
			{
				return false;
			}
		}

		protected void OnEditButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnEditButtonActivated (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBackButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

