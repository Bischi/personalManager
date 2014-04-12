using System;
using Gtk;
using WidgetLibrary;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		#region Labelstyle
		//projectTitelLabel.Pattern = "________________________________________________________________________________"; //Unterstreichung - Projekttitel
		Gdk.Color bluecolor = new Gdk.Color (255, 100, 50);
		//dateLabel.ModifyFg (Gtk.StateType.Normal, bluecolor);
		dateLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, 11"));
		timeLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, 11"));
		musicFestivalLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 12"));
		musicNameLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 12"));
		#endregion

	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnHomeTBButtonActivated (object sender, EventArgs e)
	{
		selectwidget.onHomeButtonClicked();
		this.ReshowWithInitialSize();
	}
}
