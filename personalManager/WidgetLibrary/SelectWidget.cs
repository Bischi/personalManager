using System;
using Gtk;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SelectWidget : Gtk.Bin
	{
		PersonWidget pw;
		TimesWidget tw;
		NewTimesWidget ntw; 
		WorkerWidget ww;


		public static DBConnector connection;
		
		public SelectWidget ()
		{
			this.Build ();
			connection = new SQLiteConnection();

			pw = new PersonWidget();
			tw = new TimesWidget();
			ntw = new NewTimesWidget();
			ww = new WorkerWidget();
		}

		public void onHomeButtonClicked()
		{
			this.Remove(pw);
			this.Remove (tw);
			this.Remove (ntw);
			this.Remove (ww);
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
			this.Name = "Pläne";
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

		protected void OnTimesButtonClicked (object sender, EventArgs e)
		{
			this.Remove(hbuttonbox3);
			tw.SetSizeRequest(750, 650);
			this.Add(tw);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}

		public void ViewNewTimesWidget()
		{
			this.Remove(tw);
			ntw.SetSizeRequest(650, 650);
			this.Add(ntw);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}

		public void ViewWorkerWidgket()
		{
			this.Remove(hbuttonbox3);
			this.Remove (pw);
			this.Remove (ntw);
			this.Remove (tw);
			ww.SetSizeRequest(650, 650);
			this.Add(ww);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}

		public void ViewPersonWidget()
		{
			this.Remove(ww);
			pw.SetSizeRequest(750, 650);
			this.Add(pw);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
		}
	}
}

