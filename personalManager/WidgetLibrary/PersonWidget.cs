using System;
using Gtk;
using Gdk;
using System.Collections.Generic;


namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PersonWidget : Gtk.Bin
	{

		#region Stringdefinitionen

		string fname = "";
		string lname = "";
		string area = "";
		string task = "";
		string times = "";
		string starttime = "";
		string endtime = "";
		string email = "";
		string mobile = "";
		string tele = "";

		#endregion


		Gtk.TreeModelFilter filter;

		Gtk.ListStore stempsListStore = new Gtk.ListStore (typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string), typeof (string));


		public PersonWidget ()
		{
			this.Build ();

			#region Labelstyle
			//projectTitelLabel.Pattern = "________________________________________________________________________________"; //Unterstreichung - Projekttitel
			Gdk.Color bluecolor = new Gdk.Color (255, 100, 50);
			//dateLabel.ModifyFg (Gtk.StateType.Normal, bluecolor);
			PHeaderLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 11"));
			PVHeaderLabel.ModifyFont (Pango.FontDescription.FromString ("Calibri, Bold 11"));
			#endregion

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

			// Create a column for the description 
			Gtk.TreeViewColumn taskColumn = new Gtk.TreeViewColumn ();
			taskColumn.Title = "Aufgabe";
			Gtk.CellRendererText taskTitleCell = new Gtk.CellRendererText ();
			taskColumn.PackStart (taskTitleCell, true); 

			// Create a column for the description 
			Gtk.TreeViewColumn typColumn = new Gtk.TreeViewColumn ();
			typColumn.Title = "Typ";
			Gtk.CellRendererText typTitleCell = new Gtk.CellRendererText ();
			typColumn.PackStart (typTitleCell, true); 
			
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
			personalTreeView.AppendColumn (taskColumn);
			personalTreeView.AppendColumn (typColumn);
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
			taskColumn.AddAttribute(taskTitleCell, "text", 3);
			typColumn.AddAttribute(typTitleCell, "text", 4);
			timesColumn.AddAttribute(timesTitleCell, "text", 5);
			starttimeColumn.AddAttribute(starttimeTitleCell, "text", 6);
			endtimeColumn.AddAttribute(endtimeTitleCell, "text", 7);
			emailColumn.AddAttribute(emailTitleCell, "text", 8);
			mobileColumn.AddAttribute(mobileTitleCell, "text", 9);
			teleColumn.AddAttribute(teleTitleCell, "text", 10);
			
			
			
			
			// Create a model that will hold two strings - Artist Name and Song Title

			
			// Add some data to the store
			stempsListStore.AppendValues ("Martin", "Bischof", "Wein", "Aufgabe", "Typ", "Schicht", "Startzeit", "Endzeit", "Email", "Mobile", "Telefon");
			stempsListStore.AppendValues ("Andreas", "Stark", "Abteilung", "Aufgabe", "Typ", "Schicht", "Startzeit", "Endzeit", "Email", "Mobile", "Telefon");
			
			
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


			
			// Instead of assigning the ListStore model directly to the TreeStore, we create a TreeModelFilter
			// which sits between the Model (the ListStore) and the View (the TreeView) filtering what the model sees.
			// Some may say that this is a "Controller", even though the name and usage suggests that it is still part of
			// the Model.
			filter = new Gtk.TreeModelFilter (stempsListStore, null);
			
			// Specify the function that determines which rows to filter out and which ones to display
			filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
			
			// Assign the filter as our tree's model
			personalTreeView.Model = filter;

			#endregion

			#region areaComboBox - Fill areas

			List<String> areaList = SelectWidget.connection.readAreas();
			ListStore ls = new ListStore(typeof(string));
			areaCombobox.Model = ls;
			
			foreach(string s in areaList)
				ls.AppendValues(s);

			ls.AppendValues ("");
			#endregion

			#region typComboBox - Fill Typ
			List<String> typList = SelectWidget.connection.readTyp();
			ListStore typLS = new ListStore(typeof(string));
			typCombobox.Model = typLS;

			foreach(string s in typList)
				typLS.AppendValues(s);

			typLS.AppendValues("");
			#endregion

			#region taskComboBox - Fill Tasks
			int readAreaID = SelectWidget.connection.readAreaID(areaCombobox.ActiveText);
			if(readAreaID != 0)
			{
				List<String> taskList = SelectWidget.connection.readTasks(readAreaID);
				ListStore taskLS = new ListStore(typeof(string));
				taskCombobox.Model = taskLS;
				
				foreach(string s in taskList)
					taskLS.AppendValues(s);
				
				taskLS.AppendValues("");
			}


			#endregion

			#region timesComboBox - Fill Times
			List<String> timeList = SelectWidget.connection.readTime();
			ListStore timeLS = new ListStore(typeof(string));
			timesCombobox.Model = timeLS;
			
			foreach(string s in timeList)
				timeLS.AppendValues(s);
			
			timeLS.AppendValues("");
			#endregion
		}

		protected void OnPersonalTreeViewCursorChanged (object sender, EventArgs e) //Auslesen der Werte des aktuellen Datensatzes
		{
			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;
			
			// THE ITER WILL POINT TO THE SELECTED ROW
			if(selection.GetSelected(out model, out iter)){
				 fname = (model.GetValue (iter, 0).ToString());
				 lname = (model.GetValue (iter, 1).ToString());
				 area = (model.GetValue (iter, 2).ToString());
				 task = (model.GetValue (iter, 3).ToString());
				 times = (model.GetValue (iter, 4).ToString());
				 starttime = (model.GetValue (iter, 5).ToString());
				 endtime = (model.GetValue (iter, 6).ToString());
				 email = (model.GetValue (iter, 7).ToString());
				 mobile = (model.GetValue (iter, 8).ToString());
				 tele = (model.GetValue (iter, 9).ToString());
			}
		}

		protected void OnPersonAddButtonClicked (object sender, EventArgs e)
		{
			SelectWidget sw = (SelectWidget) this.Parent;
			sw.ViewWorkerWidgket();
		}

		protected void OnPersonEditButtonClicked (object sender, EventArgs e)
		{
			/* 
 			 * SelectWidget sw = (SelectWidget) this.Parent;
			   w.ViewNewTimesWidget();
			 * 
			 * 
			 */
		}

		protected void OnFnameEntryChanged (object sender, EventArgs e)
		{
			filter.Refilter ();
		}

		#region Filtering of ListView

		private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			string fnameName = model.GetValue (iter, 0).ToString ();
			string lnameName = model.GetValue (iter, 1).ToString ();
			string areaName = model.GetValue (iter, 2).ToString ();
			string taskName = model.GetValue (iter, 3).ToString ();
			string typName = model.GetValue (iter, 4).ToString ();
			string timesName = model.GetValue (iter, 5).ToString ();

			if (fnameEntry.Text == "" && lnameEntry.Text == "" && areaCombobox.ActiveText == null && taskCombobox.ActiveText == null && typCombobox.ActiveText == null && timesCombobox.ActiveText == null)
				return true;
			string areaComboboxValue = "";
			if(areaCombobox.ActiveText != null)
				areaComboboxValue = areaCombobox.ActiveText;

			string taskComboboxValue = "";
			if(taskCombobox.ActiveText != null)
				taskComboboxValue = taskCombobox.ActiveText;
			
			string typComboboxValue = "";
			if(typCombobox.ActiveText != null)
				typComboboxValue = typCombobox.ActiveText;

			string timesComboboxValue = "";
			if(timesCombobox.ActiveText != null)
				timesComboboxValue = timesCombobox.ActiveText;

			if (fnameName.IndexOf (fnameEntry.Text) > -1 && lnameName.IndexOf (lnameEntry.Text) > -1 && areaName.IndexOf (areaComboboxValue) > -1 && taskName.IndexOf (taskComboboxValue) > -1 && typName.IndexOf (typComboboxValue) > -1 && timesName.IndexOf (timesComboboxValue) > -1)
				return true;
			else
				return false;
		}

		protected void OnLnameEntryChanged (object sender, EventArgs e)
		{
			filter.Refilter ();
		}

		protected void OnAreaComboboxChanged (object sender, EventArgs e)
		{
			int readAreaID = SelectWidget.connection.readAreaID(areaCombobox.ActiveText);
			if(readAreaID != 0)
			{
				List<String> taskList = SelectWidget.connection.readTasks(readAreaID);

				ListStore taskLS = new ListStore(typeof(string));
				taskCombobox.Model = taskLS;
				
				foreach(string s in taskList)
					taskLS.AppendValues(s);
				
				taskLS.AppendValues("");
			}
			filter.Refilter ();
		}

		protected void OnTaskComboboxChanged (object sender, EventArgs e)
		{
			filter.Refilter ();
		}

		protected void OnTimesComboboxChanged (object sender, EventArgs e)
		{
			filter.Refilter ();
		}

		protected void OnTypComboboxChanged (object sender, EventArgs e)
		{
			filter.Refilter ();
		}
		#endregion

		protected void OnPrintButtonClicked (object sender, EventArgs e)
		{
			Print pr = new Print();
		}

		protected void OnPrintViewButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnExportButtonClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

