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

		string name; 
		string date;
		string starttime; 
		string stoptime;
		
		public TimesWidget ()
		{
			this.Build ();

			#region Labelstyle
			//projectTitelLabel.Pattern = "________________________________________________________________________________"; //Unterstreichung - Projekttitel
			Gdk.Color bluecolor = new Gdk.Color (255, 100, 50);
			//dateLabel.ModifyFg (Gtk.StateType.Normal, bluecolor);
			headerLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 15"));
			timesManagementHeaderLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 11"));
			outputHeaderLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 11"));
			#endregion
			fillTreeView();

		}

		private void fillTreeView ()
		{
			#region TreeView füllen
			// Create a column for the date name
			Gtk.TreeViewColumn nameColumn = new Gtk.TreeViewColumn ();
			nameColumn.Title = "Bezeichnung";
			
			// Create the text cell that will display the date
			Gtk.CellRendererText nameTitleCell = new Gtk.CellRendererText ();
			nameColumn.PackStart (nameTitleCell, true); // Add the cell to the column
			
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
			timesTreeview.AppendColumn (dateColumn);
			timesTreeview.AppendColumn (starttimeColumn);
			timesTreeview.AppendColumn (endtimeColumn);
			
			// Tell the Cell Renderers which items in the model to display
			nameColumn.AddAttribute (nameTitleCell, "text", 0);
			dateColumn.AddAttribute(dateTitleCell, "text", 1);
			starttimeColumn.AddAttribute(starttimeTitleCell, "text", 2);
			endtimeColumn.AddAttribute(endtimeTitleCell, "text", 3);
			
			List<String[]> timeDetails = SelectWidget.connection.readTimeDetails(); // PARAMETER neu einfügen!
			
			foreach (string[] s in timeDetails) {
				stempsListStore.AppendValues (s[0], s[1], s[2], s[3]);
			}
			
			// Assign the model to the TreeView
			
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

		protected void OnNewButtonClicked (object sender, EventArgs e)
		{
			SelectWidget w = (SelectWidget) this.Parent;
			w.ViewNewTimesWidget();
		}

		protected void OnDeleteButtonClicked (object sender, EventArgs e)
		{
			MessageDialog warningMD = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.YesNo, "Schicht wirklich entfernen?");
			if ((ResponseType)warningMD.Run () == ResponseType.Yes) {

				bool delOK = SelectWidget.connection.deleteTime (name, date, starttime, stoptime);
				if (delOK == true) {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Schicht wurde entfernt!");
					md.Run ();
					md.Destroy ();
					warningMD.Destroy ();
				} else {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Schicht konnte nicht entfernt werden!");
					md.Run ();
					md.Destroy ();
					warningMD.Destroy ();
				}
			} else {
				warningMD.Destroy ();
			}
		}


		protected void OnRefreshButtonClicked (object sender, EventArgs e)
		{			
			fillTreeView();
		}

		protected void OnTimesTreeviewCursorChanged (object sender, EventArgs e)
		{
			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;
			
			// THE ITER WILL POINT TO THE SELECTED ROW
			if(selection.GetSelected(out model, out iter)){
				name = (model.GetValue (iter, 0).ToString());
				date = (model.GetValue (iter, 1).ToString());
				starttime = (model.GetValue (iter, 2).ToString());
				stoptime = (model.GetValue (iter, 3).ToString());
			}
		}
	}
}

