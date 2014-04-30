using System;
using Gtk;
using WidgetLibrary;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.SetPosition(Gtk.WindowPosition.Center);
		#region Labelstyle
		//projectTitelLabel.Pattern = "________________________________________________________________________________"; //Unterstreichung - Projekttitel
		Gdk.Color bluecolor = new Gdk.Color (255, 100, 50);
		//dateLabel.ModifyFg (Gtk.StateType.Normal, bluecolor);
		dateLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, 11"));
		timeLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, 11"));
		musicFestivalLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 12"));
		musicNameLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 12"));
		#endregion

		#region Datumanzeige / Uhrzeitanzeige

		DateTime now = DateTime.Now; 
		string currentDate = now.ToShortDateString ();
		string currentTime = now.ToShortTimeString ();

		dateLabel.Text = currentDate;
		timeLabel.Text = currentTime;

		#endregion
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	} // Click on X - Button on topright

	protected void OnHomeTBButtonActivated (object sender, EventArgs e)
	{
		selectwidget.onHomeButtonClicked();
		this.SetPosition(Gtk.WindowPosition.CenterAlways);
		this.ReshowWithInitialSize();
	} //Home-Button pressed

	protected void OnAddWorkerActivated (object sender, EventArgs e)
	{
//		SelectWidget w = (SelectWidget) this.Parent;
//		w.ViewNewTimesWidget();
	}
}
