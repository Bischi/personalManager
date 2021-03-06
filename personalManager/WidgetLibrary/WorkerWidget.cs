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
			#endregion
		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			try
			{
				Convert.ToInt32 (plzEntry.Text);
			}
			catch (Exception ex)  
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Nur Zahlen sind als PLZ gültig!");
				md.Run();
				md.Destroy();
				return;
			}


			if (checkTextBoxValue() == true) {
			
				bool addOK = SelectWidget.connection.addWorker (fnameEntry.Text, lnameEntry.Text, villageEntry.Text, hnrEntry.Text, Convert.ToInt32 (plzEntry.Text), emailEntry.Text, mobileEntry.Text, telEntry.Text, streetEntry.Text);
				int readWorkerID = SelectWidget.connection.readWorkerID (fnameEntry.Text, lnameEntry.Text, villageEntry.Text, hnrEntry.Text, emailEntry.Text);
				int readAreaID = SelectWidget.connection.readAreaID(areaCombobox.ActiveText);
				int readTaskID = SelectWidget.connection.readTaskID(taskCombobox.ActiveText);
				int readTypID = SelectWidget.connection.readTypID(typCombobox.ActiveText);
				int readWorkplaceID = SelectWidget.connection.readWorkplaceID(readAreaID, readTaskID, readTypID); 
				int readTimeDetailID = SelectWidget.connection.readTimeDetailID(timesCombobox.ActiveText);

				if(addOK == true && readWorkerID != 0 && readAreaID != 0 && readTypID != 0 && readWorkplaceID != 0 && readTimeDetailID != 0)
				{
					bool addToTimes = SelectWidget.connection.addToTime(readWorkerID, readWorkplaceID, readTimeDetailID);

					if(addToTimes = true)
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
					MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Person konnte nicht hinzugefügt werden.");
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

