using System;
using System.Collections.Generic;

namespace WidgetLibrary
{
	public abstract class DBConnector
	{
//		public abstract bool login(String user, String password);
//		public abstract bool addUser(String gender, String vname, String nname, String uname, String password, String email, String telnumber, String mobilenumber, Int32 plz, String country, String street, String hnr, DateTime regidate, Int16 status, string cname, string ctyp);
//		public abstract bool addCompany(String name, Int16 plz, String country, String street, String hnr, String web, String pname, String email, String telnumber, String mobilenumber, DateTime regidate, String typ);
//		public abstract List<string> readCompany(String typ); //für ComboBox in Firmenregistrierung; CompanyWindow und CustomerWindow
//
//		public abstract List<string> readProjectDetails(Int16 Pid, String Pname); //Auslesung ProjectBeschreibung für Specific Window
//		public abstract Int64 readSumHours(Int16 projID); // Gesamtstunden für Geldbetrag auslesen
//		public abstract bool addStartTime(Int16 projID, String date, String startTime, String description, Int16 userID); // Starzeit in Tabelle tbl_times einfügen
//		public abstract bool addEndTime(Int16 projID, String date, String startTime, String endTime, Int32 duration, String description, Int16 userID, Int32 price); // Endzeit eintragen in tbl_times
//
//		public abstract bool addCustomer(String gender, String vname, String nname, String email, String telnumber, String mobilenumber, Int32 plz, String country, String street, String hnr, string regidate, String cname);
//
//
//		//Supplier
//		public abstract bool addSupplier(String name, String street, String hnr, Int32 plz, String land, String web, String typ, String pname, String email, String telephone, String mobile, String regidate);
//		public abstract List<string> readTyp(); // für ComboBox im Supplier Window
//		public abstract bool addSupTyp (String typ);
//


		public abstract List<String[]> readWorker();
		public abstract List<string> readAreas();
		public abstract List<string> readTyp();
		public abstract int readAreaID(String area);
		public abstract List<string> readTasks(int areaID);
		public abstract List<string> readTime(); //wird bei der Erstellung des Arbeiters und bei der Erstellung des  
	
		//public abstract bool addWorker (String fname, String lname, String village, String hnr, Int32 plz, String email, String mobile, String telephone, String street);

		public abstract bool addWorker (String fname, String lname, String village, String hnr, Int32 plz, String email, String mobile, String telephone, String street);
//		public abstract int readWorkerID (string fname, string lname, string village, Int16 hnr, string email);

//		public abstract bool addWorker (String fname, String lname, String village, String hnr, Int32 plz, String email, String mobile, String tel, String street);
		public abstract int readWorkerID (string fname, string lname, string village, string hnr, string email);

		public abstract int readWorkplaceID(int fk_area, int fk_task, int fk_typ);
		public abstract bool addToTime(int fk_worker, int fk_workplace, int fk_timedetail);

		public abstract int readTaskID(string name);
		public abstract int readTypID(string name);
		public abstract int readTimeDetailID (string name); //wird fuer das Hinzufuegen bei der Erstellung eines neuen Benutzers benoetigt, um die richtige Schicht in die tbl_time eintragen zu koennen
		public abstract int readTimeID(string name);




		//Schichten anlegen, bearbeiten, loeschen
		public abstract List<String[]> readTimeDetails(); //wird fuer das Anzeigen im SChichten-fenster benoetigt, wenn sie bearbeitet werden
		public abstract bool addTime(string name, string date, string starttime, string stoptime);
		public abstract bool updateTime(int id, string name, string date, string starttime, string stoptime);
		public abstract int checkOutTimedetailID(string name, string starttime);
		public abstract bool deleteTime(string name, string date, string starttime, string stoptime);


//		public abstract bool editWorker(string fname, string lname, string email, string village);
	}
}
