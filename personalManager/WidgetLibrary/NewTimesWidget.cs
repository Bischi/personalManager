using System;
using System.Drawing;
using Gtk;

namespace WidgetLibrary
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class NewTimesWidget : Gtk.Bin
	{
		string TimeName;
		string Starttime; 
		string Endtime; 
		bool checkTimeTitel; // für die Bezeichnung- Methode: CheckEntry()
		bool checkStartTime; // für die Startzeit- Methode: CheckEntry()
		bool checkStopTime; // für die Stopzeit- Methode: CheckEntry()
		bool edit; 
		int TimeDetailid; //vor der Bearbeitung wird die ID ausgelesen, damit man dann die Daten über diese ID updaten kann

		public NewTimesWidget (bool edit) // Bearbeitungsmodus oder nicht?
		{
			this.Build ();


			if (edit == true) {
				edit = true; 
			}

		}

		public bool editMode (string name, string date, string starttime, string endtime) //wenn bearbeitet werden muss, dann diese Methode aufrufen, um die Entrys zu fuellen
		{
			TimeDetailid = SelectWidget.connection.checkOutTimedetailID (name, starttime); // liest die ID von der Schicht aus

			if (TimeDetailid == 0) { //Wenn die id = 0 gilt, dann ist die Auslesung nicht erfolgt
				MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Schicht kann nicht bearbeitet werden!");
				md.Run ();
				md.Destroy ();
				return false; 
			}

			nameEntry.Text = name;
			dateLabel.Text = date;
			if (date == "10.07.2015") {

			}
			if (date == "11.07.2015") {
				
			}
			if (date == "12.07.2015") {
				
			}
			string[] starthourSplit = starttime.Split(new char[2]);
			startHourEntry.Text = starthourSplit[0];
			StartMinuteEntry.Text = "";
			stopHourEntry.Text = "";
			StopMinuteEntry.Text = "";
			return true;
		}

		protected void OnSaveButtonClicked (object sender, EventArgs e)
		{
			if (edit == false) { //Neue Schicht, wenn Bearbeitung nein 
				bool checkOK = CheckEntry ();
				bool addOK = false;

				if (checkOK == true)
					addOK = SelectWidget.connection.addTime (nameEntry.Text, dateLabel.Text, Starttime, Endtime);

				if (addOK == true) {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Schicht wurde erfolgreich hinzugefügt!");
					md.Run ();
					md.Destroy ();
				} else {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "FEHLER! Die Schicht konnt nicht hinzugefügt werden!");
					md.Run ();
					md.Destroy ();
				}
			} else { //alte Schicht updaten / bearbeiten --> benoetigt die id
				bool checkOK = CheckEntry ();
				bool addOK = false;
				
				if (checkOK == true)

					addOK = SelectWidget.connection.updateTime (TimeDetailid, nameEntry.Text, dateLabel.Text, Starttime, Endtime);
				
				if (addOK == true) {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Schicht wurde erfolgreich hinzugefügt!");
					md.Run ();
					md.Destroy ();
				} else {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "FEHLER! Die Schicht konnt nicht hinzugefügt werden!");
					md.Run ();
					md.Destroy ();
				}
			}
		}

		private bool CheckEntry () // Prüft, ob alle Felder richtig ausgefüllt sind
		{
			if (nameEntry.Text != "")
				checkTimeTitel = true;

			if (startHourEntry.Text != "" && StartMinuteEntry.Text != "") {
				try {
					Convert.ToInt32 (startHourEntry.Text);
					Convert.ToInt32 (StartMinuteEntry.Text);
					Starttime = startHourEntry.Text+':'+StartMinuteEntry.Text;
				} catch (Exception ex) {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Nur Zahlen sind als Zeit gültig!");
					md.Run ();
					md.Destroy ();
					checkStartTime = false;
					return false;
				}
				checkStartTime = true;
			}

			if (stopHourEntry.Text != "" && StopMinuteEntry.Text != "") {
				try {
					Convert.ToInt32 (stopHourEntry.Text);
					Convert.ToInt32 (StopMinuteEntry.Text);
					Endtime = stopHourEntry.Text+':'+StopMinuteEntry.Text;
				} catch (Exception ex) {
					MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Nur Zahlen sind als Zeit gültig!");
					md.Run ();
					md.Destroy ();
					checkStartTime = false;
					return false;
				}
				checkStopTime = true;
			}

			if (checkTimeTitel == true && checkStartTime == true && checkStopTime == true) {
				return true;
			} else {
				return false;
			}
		}

		protected void OnBackButtonClicked (object sender, EventArgs e)
		{
			SelectWidget sw = (SelectWidget) this.Parent;
			sw.ViewTimesWidget();
		}

		protected void OnDayComboboxChanged (object sender, EventArgs e)
		{
			if (dayCombobox.ActiveText == "Freitag") {
				dateLabel.Text = "10.07.2015";
			}

			if (dayCombobox.ActiveText == "Samstag") {
				dateLabel.Text = "14.07.2015";
			}

			if (dayCombobox.ActiveText == "Sonntag") {
				dateLabel.Text = "12.07.2015";
			}
		}
	}
}

