using System;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PersonWidget : Gtk.Bin
	{
		public PersonWidget ()
		{
			this.Build ();


			#region TreeView füllen
			// Create a column for the date name
			Gtk.TreeViewColumn fnameColumn = new Gtk.TreeViewColumn ();
			fnameColumn.Title = "Vorname";
			
			// Create the text cell that will display the date
			Gtk.CellRendererText fnameTitleCell = new Gtk.CellRendererText ();
			fnameColumn.PackStart (fnameTitleCell, true); // Add the cell to the column
			
			// Create a column for the description 
			Gtk.TreeViewColumn lnameColumn = new Gtk.TreeViewColumn ();
			lnameColumn.Title = "Nachname";
			Gtk.CellRendererText lnameTitleCell = new Gtk.CellRendererText ();
			lnameColumn.PackStart (lnameTitleCell, true);
			
			// Create a column for the description 
			Gtk.TreeViewColumn areaColumn = new Gtk.TreeViewColumn ();
			areaColumn.Title = "Abteilung";
			Gtk.CellRendererText areaTitleCell = new Gtk.CellRendererText ();
			areaColumn.PackStart (areaTitleCell, true); 
			
			Gtk.TreeViewColumn timesColumn = new Gtk.TreeViewColumn ();
			timesColumn.Title = "Schicht";
			Gtk.CellRendererText timesTitleCell = new Gtk.CellRendererText ();
			timesColumn.PackStart (timesTitleCell, true);
			
			Gtk.TreeViewColumn starttimeColumn = new Gtk.TreeViewColumn ();
			starttimeColumn.Title = "Start";
			Gtk.CellRendererText starttimeTitleCell = new Gtk.CellRendererText ();
			starttimeColumn.PackStart (starttimeTitleCell, true);

			Gtk.TreeViewColumn endtimeColumn = new Gtk.TreeViewColumn ();
			endtimeColumn.Title = "Ende";
			Gtk.CellRendererText endtimeTitleCell = new Gtk.CellRendererText ();
			endtimeColumn.PackStart (endtimeTitleCell, true);

			Gtk.TreeViewColumn emailColumn = new Gtk.TreeViewColumn ();
			emailColumn.Title = "email";
			Gtk.CellRendererText emailTitleCell = new Gtk.CellRendererText ();
			emailColumn.PackStart (emailTitleCell, true);

			Gtk.TreeViewColumn mobileColumn = new Gtk.TreeViewColumn ();
			mobileColumn.Title = "Handy";
			Gtk.CellRendererText mobileTitleCell = new Gtk.CellRendererText ();
			mobileColumn.PackStart (mobileTitleCell, true);

			Gtk.TreeViewColumn teleColumn = new Gtk.TreeViewColumn ();
			teleColumn.Title = "Telefon";
			Gtk.CellRendererText teleTitleCell = new Gtk.CellRendererText ();
			teleColumn.PackStart (teleTitleCell, true);
			
			
			// Add the columns to the TreeView
			personalTreeView.AppendColumn (fnameColumn);
			personalTreeView.AppendColumn (lnameColumn);
			personalTreeView.AppendColumn (areaColumn);
			personalTreeView.AppendColumn (timesColumn);
			personalTreeView.AppendColumn (starttimeColumn);
			personalTreeView.AppendColumn (endtimeColumn);
			personalTreeView.AppendColumn (emailColumn);
			personalTreeView.AppendColumn (mobileColumn);
			personalTreeView.AppendColumn (teleColumn);
			
			// Tell the Cell Renderers which items in the model to display
			fnameColumn.AddAttribute (fnameTitleCell, "text", 0);
			lnameColumn.AddAttribute (lnameTitleCell, "text", 1);
			areaColumn.AddAttribute(areaTitleCell, "text", 2);
			timesColumn.AddAttribute(timesTitleCell, "text", 3);
			starttimeColumn.AddAttribute(starttimeTitleCell, "text", 4);
			endtimeColumn.AddAttribute(endtimeTitleCell, "text", 5);
			emailColumn.AddAttribute(emailTitleCell, "text", 6);
			mobileColumn.AddAttribute(mobileTitleCell, "text", 7);
			teleColumn.AddAttribute(teleTitleCell, "text", 8);
			
			
			
			
			// Create a model that will hold two strings - Artist Name and Song Title
			Gtk.ListStore stempsListStore = new Gtk.ListStore (typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string));
			
			// Add some data to the store
			stempsListStore.AppendValues ("Martin", "Bischof", "Abteilung", "Schicht", "Startzeit", "Endzeit", "Email", "Mobile", "Telefon");
			
			
//			List<String[]> stempsDetail = MainClass.connection.readStemps(1); // PARAMETER neu einfügen!
//			
//			foreach (string[] s in stempsDetail) {
//				stempsListStore.AppendValues (s[0], s[1], s[2], s[3], s[4]);
//			}
//			
//			
//			
//			// Assign the model to the TreeView
			personalTreeView.Model = stempsListStore;
			
			
#endregion


		}
	}
}

