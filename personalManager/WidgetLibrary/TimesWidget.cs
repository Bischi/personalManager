using System;
using Gtk;
using Gdk;
using System.Collections.Generic;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TimesWidget : Gtk.Bin
	{

		Gtk.ListStore stempsListStore = new Gtk.ListStore (typeof (string), typeof (string), typeof (string), typeof (string), typeof (string));


		public TimesWidget ()
		{
			this.Build ();

			#region Labelstyle
			//projectTitelLabel.Pattern = "________________________________________________________________________________"; //Unterstreichung - Projekttitel
			Gdk.Color bluecolor = new Gdk.Color (255, 100, 50);
			//dateLabel.ModifyFg (Gtk.StateType.Normal, bluecolor);
			headerLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 15"));
			#endregion

			#region TreeView füllen
			// Create a column for the date name
			Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn ();
			nameColumn.Title = "Bezeichnung";
			
			// Create the text cell that will display the date
			Gtk.CellRendererText nameTitleCell = new Gtk.CellRendererText ();
			nameColumn.PackStart (nameTitleCell, true); // Add the cell to the column
			
			// Create a column for the description 
			Gtk.TreeViewColumn dayColumn = new Gtk.TreeViewColumn ();
			dayColumn.Title = "Tag";
			Gtk.CellRendererText dayTitleCell = new Gtk.CellRendererText ();
			dayColumn.PackStart (dayTitleCell, true);
			
			// Create a column for the description 
			Gtk.TreeViewColumn dateColumn = new Gtk.TreeViewColumn ();
			dateColumn.Title = "Datum";
			Gtk.CellRendererText dateTitleCell = new Gtk.CellRendererText ();
			dateColumn.PackStart (dateTitleCell, true); 
			
			// Create a column for the description 
			Gtk.TreeViewColumn starttimeColumn = new Gtk.TreeViewColumn ();
			starttimeColumn.Title = "Startzeit";
			Gtk.CellRendererText starttimeTitleCell = new Gtk.CellRendererText ();
			starttimeColumn.PackStart (starttimeTitleCell, true); 
			
			Gtk.TreeViewColumn endtimeColumn = new Gtk.TreeViewColumn ();
			endtimeColumn.Title = "Endzeit";
			Gtk.CellRendererText endtimeTitleCell = new Gtk.CellRendererText ();
			endtimeColumn.PackStart (endtimeTitleCell, true);
			
			
			// Add the columns to the TreeView
			timesTreeview.AppendColumn (nameColumn);
			timesTreeview.AppendColumn (dayColumn);
			timesTreeview.AppendColumn (dateColumn);
			timesTreeview.AppendColumn (starttimeColumn);
			timesTreeview.AppendColumn (endtimeColumn);
			
			// Tell the Cell Renderers which items in the model to display
			nameColumn.AddAttribute (nameTitleCell, "text", 0);
			dayColumn.AddAttribute (dayTitleCell, "text", 1);
			dateColumn.AddAttribute(dateTitleCell, "text", 2);
			starttimeColumn.AddAttribute(starttimeTitleCell, "text", 3);
			endtimeColumn.AddAttribute(endtimeTitleCell, "text", 4);
			
	
			stempsListStore.AppendValues ("Vormittag Schicht", "Samstag", "21.07.2014", "08:10", "12:50");
			
			
			//			List<String[]> stempsDetail = MainClass.connection.readStemps(1); // PARAMETER neu einfügen!
			//			
			//			foreach (string[] s in stempsDetail) {
			//				stempsListStore.AppendValues (s[0], s[1], s[2], s[3], s[4]);
			//			}
			//			
			//			
			//			
			//			// Assign the model to the TreeView
			
			timesTreeview.Model = stempsListStore;
			
			#endregion

		}


		protected void OnExportButtonClicked (object sender, EventArgs e)
		{

		}

		protected void OnPrintViewButtonClicked (object sender, EventArgs e)
		{

		}

		protected void OnPrintButtonClicked (object sender, EventArgs e)
		{

		}

		protected void OnEditButtonClicked (object sender, EventArgs e)
		{

		}

		protected void OnNewButtonClicked (object sender, EventArgs e)
		{
			SelectWidget w = (SelectWidget) this.Parent;
			w.ViewNewTimesWidget();
		}
	}
}

