using System;
using Gdk;
using Gtk;
using System.Drawing;
using System.Collections.Generic;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class WorkerWidget : Gtk.Bin
	{
		public WorkerWidget ()
		{
			this.Build ();
			editToggleButton.Visible = false;

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

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			if (checkTextBoxValue() == true) {
				bool addOK = SelectWidget.connection.addWorker (fnameEntry.Text, lnameEntry.Text, villageEntry.Text, hnrEntry.Text, Convert.ToInt32 (plzEntry.Text), emailEntry.Text, mobileEntry.Text, telEntry.Text, streetEntry.Text);
				int readWorkerID = SelectWidget.connection.readWorkerID (fnameEntry.Text, lnameEntry.Text, villageEntry.Text, hnrEntry.Text, emailEntry.Text);
				int readAreaID = SelectWidget.connection.readAreaID(areaCombobox.ActiveText);
				int readTaskID = SelectWidget.connection.readTaskID(taskCombobox.ActiveText);
				int readTypID = SelectWidget.connection.readTypID(typCombobox.ActiveText);

				int readWorkplaceID; 
				bool addToTimes;

				if(addOK = true)
				{
					fnameEntry.Text = "";
					lnameEntry.Text = "";
					emailEntry.Text = "";
					mobileEntry.Text = "";
					telEntry.Text = "";
					plzEntry.Text = "";
					villageEntry.Text = "";
					streetEntry.Text = "";
					hnrEntry.Text = "";
					
					areaCombobox.Clear ();
					taskCombobox.Clear ();
					typCombobox.Clear ();
					timesCombobox.Clear ();

					MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Person wurde hinzugefügt!");
					md.Run();
					md.Destroy();
				}
			}
			else 
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Bitte Name, Mobil oder Telefonnummer eingeben!");
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

		protected void OnBackButtonClicked (object sender, EventArgs e)
		{
			SelectWidget sw = (SelectWidget) this.Parent;
			sw.ViewPersonWidget();
		}

		protected void OnEditToggleButtonActivated (object sender, EventArgs e) // EditToggleButton activated
		{
			fnameEntry.Sensitive = true;
			lnameEntry.Sensitive = true;
			emailEntry.Sensitive = true;
			mobileEntry.Sensitive = true;
			telEntry.Sensitive = true;
			plzEntry.Sensitive = true;
			villageEntry.Sensitive = true;
			streetEntry.Sensitive = true;
			hnrEntry.Sensitive = true;

			areaCombobox.Sensitive = true;
			taskCombobox.Sensitive = true;
			typCombobox.Sensitive = true;
			timesCombobox.Sensitive = true;
		}

		protected void OnAreaComboboxChanged (object sender, EventArgs e)
		{
			int readAreaID = SelectWidget.connection.readAreaID(areaCombobox.ActiveText);
			if(readAreaID != 0)
			{
				List<String> taskList = SelectWidget.connection.readTasks(readAreaID);

				if(taskList.Capacity != 0)
				{
					ListStore taskLS = new ListStore(typeof(string));
					taskCombobox.Model = taskLS;
					
					foreach(string s in taskList)
						taskLS.AppendValues(s);
					
					taskLS.AppendValues("");
					taskCombobox.Sensitive = true;
				}
				else
				{
					taskCombobox.Sensitive = false;
				}
			}
		}
	}
}

