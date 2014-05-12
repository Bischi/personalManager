using System;
using Gtk;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System.Diagnostics;

namespace WidgetLibrary
{
	public class SQLiteConnection : DBConnector
	{
		SqliteConnection sqlite_conn;
		SqliteCommand sqlite_cmd;
		SqliteDataReader datareader;

		public SQLiteConnection ()
		{
			connect ();
		}

		private bool connect()
		{
			sqlite_conn = new SqliteConnection ("Data Source=" + System.Environment.CurrentDirectory.ToString () + "/personalManager.sqlite3");
			try {
				sqlite_conn.Open ();
			} catch (Exception e) {
				return false;
				//TODO Log errors
			}
			return true;
		}


		public override List<string[]> readWorker () // Personen für ListView auslesen
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT w.*, tbl_timedetail.name, tbl_area.name, tbl_task.name, tbl_typ.name FROM tbl_time t INNER JOIN tbl_worker w ON t.fk_worker = w.id LEFT JOIN tbl_workplace wp ON t.fk_workplace = wp.id LEFT JOIN tbl_area ON wp.fk_area = tbl_area.id LEFT JOIN tbl_task ON wp.fk_task = tbl_task.id LEFT JOIN tbl_typ ON wp.fk_typ = tbl_typ.id LEFT JOIN tbl_timedetail ON t.fk_timedetail = tbl_timedetail.id;";
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				string readstartdate = ""; 
				string readname = "";
				string readenddate = ""; 
				string readDescript = ""; 
				int readhourprice = 0; 

				string[] personArr = new string[14];
				int i = 0;
//				List<string[]> persons = new List<string>();

				while (datareader.Read())
				{
					personArr[i] = datareader.GetString (0);

				}
				sqlite_conn.Close ();
				
//				persons.Add(Convert.ToString (readstartdate));
//				persons.Add (Convert.ToString(readenddate));
//				persons.Add (readDescript);
//				persons.Add (Convert.ToString (readhourprice));
				
				return null;
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}

		public override List<string> readAreas ()
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				if(sqlite_conn.State == ConnectionState.Closed)
					sqlite_conn.Open();
				sqlite_cmd.CommandText = "SELECT name FROM tbl_area";
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				string readname = ""; 
				List<string> areaLIST = new List<string>(); // To Save Areas and return them

				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					areaLIST.Add (readname);
				}
				sqlite_conn.Close ();
				return areaLIST; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}

		public override List<string> readTyp ()
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT name FROM tbl_typ";

				sqlite_conn.Open ();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				string readname = "";
				List<string> typs = new List<string>(); // To Save typs and return them
				
				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					typs.Add (readname);
				}
				sqlite_conn.Close ();
				return typs; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}


		public override int readAreaID (string area)
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT id FROM tbl_area WHERE name= '"+area+"'";
				
				sqlite_conn.Open ();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override List<string> readTasks (int areaID)
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT DISTINCT name FROM tbl_task inner join tbl_workplace on tbl_task.id = tbl_workplace.fk_task WHERE tbl_workplace.fk_area="+areaID+"";

				sqlite_conn.Open ();

				datareader = sqlite_cmd.ExecuteReader ();

				string readname = "";
				List<string> tasks = new List<string>(); // To Save tasks and return them


				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					tasks.Add (readname);
				}
				sqlite_conn.Close (); 
				return tasks; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}

		public override List<string> readTime ()
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT name FROM tbl_timedetail";
				
				sqlite_conn.Open ();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				string readname = "";
				List<string> times = new List<string>(); // To Save typs and return them
				
				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					times.Add (readname);
				}
				sqlite_conn.Close ();
				return times; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}


		public override bool addWorker (string fname, string lname, string village, string hnr, int plz, string email, string mobile, string tel, string street)
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_worker (fname, lname, hnr, PLZ, village, email, mobile, telephone, street) VALUES ('"+fname+"', '"+lname+"','"+hnr+"','"+plz+"','"+village+"','"+email+"','"+mobile+"','"+tel+"','"+street+"')";
				sqlite_conn.Open(); 
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();
				
				int WorkerID = this.readWorkerID(fname,lname,village,hnr,email);
				
				if(WorkerID != 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();				
				return false;
			}
		}

		public override int readWorkerID (string fname, string lname, string village, string hnr, string email)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_worker WHERE fname= '"+fname+"' AND lname= '"+lname+"'AND village= '"+village+"' AND hnr= '"+hnr+"' AND email= '"+email+"'";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override int readTaskID (string name)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_task WHERE name ='"+name+"'";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override int readTypID (string name)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_typ WHERE name ='"+name+"'";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override int readWorkplaceID (int fk_area, int fk_task, int fk_typ)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_workplace WHERE fk_area = "+fk_area+" AND fk_task = "+fk_task+" AND fk_typ = "+fk_typ+"";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override int readTimeID (string name)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_time WHERE name ='"+name+"'";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override int readTimeDetailID (string name)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT id FROM tbl_timedetail WHERE name ='"+name+"'";
				sqlite_conn.Open ();
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				sqlite_conn.Close ();
				return readID; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override bool addToTime (int fk_worker, int fk_workplace, int fk_timedetail)
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_time (fk_worker, fk_workplace, fk_timedetail) VALUES ('"+fk_worker+"','"+fk_workplace+"','"+fk_timedetail+"')";
				sqlite_conn.Open(); 
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();
				
				return true;
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();				
				return false;
			}
		}

//		public override List<string[]> readWorker ()
//		{
//			try {
//				
//				sqlite_cmd = sqlite_conn.CreateCommand ();
//				
//				sqlite_cmd.CommandText = "SELECT * FROM tbl_worker";
//				
//				sqlite_conn.Open ();
//				
//				datareader = sqlite_cmd.ExecuteReader ();
//			
//				List<string> worker = new List<string>(); // To Save typs and return them
//				
//				while (datareader.Read())
//				{
//					string readName = datareader.GetString(0);
//					string readLName = datareader.GetString(1);
//					string readhnr = datareader.GetString(2);
//					int readPlz = datareader.GetInt16(3);
//					string readVillage = datareader.GetString(4);
//					string readEmail = datareader.GetString(5);
//					string readMobile = datareader.GetString(6);
//					string readTel = datareader.GetString(7);
//					string readStreet = datareader.GetString(8);
//
//					worker.Add (readName);
//					worker.Add (readLName);
//					worker.Add (readhnr);
//					worker.Add (Convert.ToString(readPlz));
//					worker.Add (readVillage);
//					worker.Add (readEmail);
//					worker.Add (readTel);
//					worker.Add (readStreet);
//
//				}
//				sqlite_conn.Close ();
//
//				return worker; 
//			}  
//			catch (Exception ex) 
//			{
//				sqlite_conn.Close ();
//				return null; 
//			}
//		}

/*


		#region Login
		public override bool login (string uname, string pwd)
		{
			try 
			{			
				bool userExist = this.checkAmountUser(); // ist ein User im System vorhanden?

				if (userExist == false)
				{
					MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Herzlich Willkommen zu CustomerManager! Sie müssen nur noch einen Benutzer anlegen und schon kann es losgehen!");
					md.Run();
					md.Destroy();

					CustomerWindow cw = new CustomerWindow(); //neuer Benutzer muss erstellt werden 
					cw.addUser(); 

					return false; 
				}
				else
				{
					bool corrUname = this.checkUserExist(uname);
						
					if(corrUname == true)
					{
						bool loginOK = this.checkPassword(uname, pwd);

						if(loginOK == true)
						{
							return true; 
						}
						else
						{
							MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Das Passwort stimmt nicht!");
							md.Run();
							md.Destroy();
							return false;
						}
					}
					else
					{
						MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Dieser Benutzername ist nicht im System vorhanden!");
						md.Run();
						md.Destroy();
						return false; 
					}
				}
			} 
			catch (Exception x)
			{
				sqlite_conn.Close ();
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, x.Message);
				md.Run();
				md.Destroy();
				return false; 
			}
		}

		private bool checkAmountUser()
		{
			try
			{
				#region Benutzername vorhanden - Prüfung
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT count(*) FROM tbl_users";
				
				if(!connect())
					throw new Exception();

				// Now the SQLiteCommand object can give us a DataReader-Object:
				int amountUser = Convert.ToInt32(sqlite_cmd.ExecuteScalar());
				sqlite_conn.Close();
				
				if(amountUser == 0)
				{
					return false; 
				}
				else
				{
					return true;
				}
				#endregion
			}
			catch(Exception exce)
			{
				sqlite_conn.Close ();

				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, Convert.ToString(exce));
				md.Run();
				md.Destroy(); 
				return true;
			}
		}

		private bool checkUserExist(string uname) // existiert ein Benutzer mit dem angegebenen Benutzernamen?
		{
			try
			{
				#region Benutzername vorhanden - Prüfung
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT count(*) FROM tbl_users Where username='"+uname+"'";
				
				sqlite_conn.Open();
				
				// Now the SQLiteCommand object can give us a DataReader-Object:
				int exist = Convert.ToInt32(sqlite_cmd.ExecuteScalar());

				sqlite_conn.Close(); 
				
				if(exist == 0)
				{
					return false; 
				}
				else
				{
					return true;
				}
				#endregion
			}
			catch
			{
				sqlite_conn.Close ();
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Es ist ein Fehler bei der Benutzerauslesung geschehen!");
				md.Run();
				md.Destroy(); 
				return false; 
			}
		}
		#endregion

		#region Userkonfigurationen
		public override bool addUser (string gender, string vname, string nname, string uname, string password, string email, string telnumber, string mobilenumber, Int32 plz, string country, string street, string hnr, DateTime regidate, Int16 status, string cname, string ctyp) //Benutzer im System hinzufügen
		{
			if (ctyp == "Privat") 
			{

				try {
					sqlite_cmd = sqlite_conn.CreateCommand ();
					sqlite_cmd.CommandText = "INSERT into tbl_users(gender, vname, nname, uname, password, email, telnumber, mobilenumber, plz, country, street, hnr, regidate, fk_companies, status) VALUES ('"+gender+"', '"+vname+"', '"+nname+"', '"+uname+"', '"+password+"','"+email+"','"+telnumber+"','"+mobilenumber+"','"+plz+"','"+country+"','"+street+"','"+hnr+"','"+regidate+"','1','1')";
					sqlite_conn.Open ();
					sqlite_cmd.ExecuteNonQuery ();
					sqlite_conn.Close ();
					return true; 
				} catch (Exception ex) {
					sqlite_conn.Close ();
					return false; 
				}
			} 
			else 
			{
				int fk_companies = this.getFKcompany (cname);
				
				try {
					sqlite_cmd = sqlite_conn.CreateCommand ();
					sqlite_cmd.CommandText = "INSERT into tbl_users(gender, vname, nname, uname, password, email, telnumber, mobilenumber, plz, country, street, hnr, regidate, fk_companies, status) VALUES ('"+gender+"', '"+vname+"', '"+nname+"', '"+uname+"','"+password+"','"+email+"','"+telnumber+"','"+mobilenumber+"','"+plz+"','"+country+"','"+street+"','"+hnr+"','"+regidate+"','"+fk_companies+"','1')";
					sqlite_conn.Open ();
					sqlite_cmd.ExecuteNonQuery ();
					sqlite_conn.Close ();
					return true; 
				} catch (Exception ex) {
					sqlite_conn.Close ();
					return false; 
				}
			}
		}

		public bool dropUser(string username, string email, string pwd) // Benutzer im System löschen
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "UPDATE tbl_users SET status='0' WHERE username='"+username+"' AND email='"+email+"'";
				sqlite_conn.Open();
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();
				return true; 
			}
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return false;
	
			}
		}

		public bool viewUser() // Benutzer anzeigen
		{
			return true; 
		}

		public bool viewUsers () // Alle Benutzer im System anzeigen
		{
			return true; 
		}
		#endregion

		public bool checkPassword(string uname, string pwd) // Passwort eines bestimmten Bentzers für den Status ändern prüfen
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand();
				sqlite_cmd.CommandText = "Select password From tbl_users WHERE username='"+uname+"'";
				sqlite_conn.Open (); //Datenbankverbindung öffnen

				// Now the SQLiteCommand object can give us a DataReader-Object:
				datareader = sqlite_cmd.ExecuteReader ();

				string readPwd = ""; // ausgelesene Passwort für den Benutzernamen 

				while (datareader.Read())
				{
					readPwd = datareader.GetString(0);
				}
				sqlite_conn.Close ();

				if(readPwd == pwd)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			catch (Exception ex)
			{
				sqlite_conn.Close ();
				return false; 
			}
		}



		#region Unternehmen 
		public override bool addCompany (string name, Int16 plz, string country, string street, string hnr, string web, string pname, string email, string telnumber, string mobilenumber, DateTime regidate, string typ)
		{
			int fk_typcompany = getFKTypcompany (typ); //ID von CompanyTyp aus tbl_typcompany bekommen

			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT into tbl_companies(fk_typcompany, name, plz, country, street, hnr, web, pname, email, telnumber, mobilenumber, regidate) VALUES ('"+fk_typcompany+"', '"+name+"', '"+plz+"', '"+country+"', '"+street+"','"+hnr+"','"+web+"','"+pname+"','"+email+"','"+telnumber+"','"+mobilenumber+"','"+regidate+"')";
				sqlite_conn.Open ();
				sqlite_cmd.ExecuteNonQuery ();
				sqlite_conn.Close ();
				return true; 
			} catch (Exception ex) {
				sqlite_conn.Close ();
				return false; 
			}
		}


		private int getFKcompany(string name)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();

				sqlite_cmd.CommandText = "SELECT id FROM tbl_companies WHERE name='"+name+"'";

				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 99999999; // ausgelesene ID von Typ von Company
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}

				sqlite_conn.Close ();
				return readID; 
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 1; 
			}
		}


		private int getFKTypcompany (string typ)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT id FROM tbl_typcompany WHERE typ ='"+typ+"'";
				
				sqlite_conn.Open();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 99999999; // ausgelesene ID von Typ von Company
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				
				sqlite_conn.Close ();
				return readID; 
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 1; 
			}
		}

		#endregion

		#region Customer
		public override bool addCustomer (string gender, string vname, string nname, string email, string telnumber, string mobilenumber, int plz, string country, string street, string hnr, string regidate, string cname)
		{
			int fk_companies = this.getFKcompany (cname);

			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_customers (nname, vname, fk_companies, email, telnumber, mobilenumber, plz, country, street, hnr, regidate, gender, status) VALUES ('"+nname+"', '"+vname+"','"+fk_companies+"','"+email+"','"+telnumber+"','"+mobilenumber+"','"+plz+"','"+country+"','"+street+"','"+hnr+"','"+regidate+"','"+gender+"','1')";
				sqlite_conn.Open();
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();

				return true;
			} 

			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return false; 
			}
		}


		#endregion
		 
		#region Supplier

		public override List<string> readTyp ()
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();				
				sqlite_cmd.CommandText = "SELECT typ FROM tbl_typ";
				datareader = sqlite_cmd.ExecuteReader ();

				string readname = ""; // ausgelesene ID von Typ von Company
				List<string> typs = new List<string>();
				
				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					typs.Add (readname);
				}
				sqlite_conn.Close ();
				return typs; 
			} 
			catch (Exception ex)
			{
				sqlite_conn.Close ();
				return null; 
			}
		}

		private int getFKtyp(string typ)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();				
				sqlite_cmd.CommandText = "SELECT id FROM tbl_typ WHERE typ ='"+typ+"'";
				sqlite_conn.Open();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				
				sqlite_conn.Close ();
				return readID; 
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		private int getFKsupplier (string supplier)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();				
				sqlite_cmd.CommandText = "SELECT id FROM tbl_suppliers WHERE name ='"+supplier+"'";
				sqlite_conn.Open();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				int readID = 0;
				
				while (datareader.Read())
				{
					readID = datareader.GetInt16(0);
				}
				
				sqlite_conn.Close ();
				return readID; 
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override bool addSupplier(String name, String street, String hnr, Int32 plz, String land, String web, String typ, String pname, String email, String telephone, String mobile, String regidate)
		{


			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_suppliers (name, plz, country, street, hnr, web, pname, email, telnumber, mobilenumber, regidate) VALUES ('"+name+"', '"+plz+"','"+land+"','"+street+"','"+hnr+"','"+web+"','"+pname+"','"+email+"','"+telephone+"','"+mobile+"','"+regidate+"')";
				sqlite_conn.Open(); 
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();

				int fksupplier = getFKsupplier(name);
				int fktyp = getFKtyp(typ);

				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_suppliers_typ (fk_suppliers, fk_typ) VALUES ('"+fksupplier+"','"+fktyp+"')";
				sqlite_conn.Open ();
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();

				return true;
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return false; 
			}

		}

		public override bool addSupTyp (String typ)
		{
			try 
			{
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT INTO tbl_typ (typ) VALUES ('"+typ+"')";
				sqlite_conn.Open(); 
				sqlite_cmd.ExecuteNonQuery();
				sqlite_conn.Close();
				
				return true;
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return false; 
			}
		}
		#endregion


		public override System.Collections.Generic.List<string> readCompany (string typ)
		{
			int fk_typcompany = getFKTypcompany (typ); //ID von CompanyTyp aus tbl_typcompany bekommen

			try {

				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT name FROM tbl_companies WHERE fk_typcompany ='"+fk_typcompany+"'";
				
				sqlite_conn.Open();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				string readname = ""; // ausgelesene ID von Typ von Company
				List<string> companies = new List<string>();
				
				while (datareader.Read())
				{
					readname = datareader.GetString(0);
					companies.Add (readname);
				}
				sqlite_conn.Close ();
				return companies; 
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
		}
	
		public override System.Collections.Generic.List<string> readProjectDetails (short Pid, string Pname) //Auslesung Projektdetails
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT startdate, enddate, description, hourprice FROM tbl_projects WHERE (id ="+Pid+" AND name='"+Pname+"')";
				
				datareader = sqlite_cmd.ExecuteReader ();

				string readstartdate = ""; 
				string readenddate = ""; 
				string readDescript = ""; 
				int readhourprice = 0; 

				List<string> projDetails = new List<string>();

				while (datareader.Read())
				{
					readstartdate = datareader.GetString(0); 
					readenddate = datareader.GetString(1);
					readDescript = datareader.GetString(2);
					readhourprice = datareader.GetInt16(3);
				}
				sqlite_conn.Close ();

				projDetails.Add(Convert.ToString (readstartdate));
				projDetails.Add (Convert.ToString(readenddate));
				projDetails.Add (readDescript);
				projDetails.Add (Convert.ToString (readhourprice));

				return projDetails;
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return null; 
			}
			
		}

		public override Int64 readSumHours (short projID)
		{
			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "SELECT sum(duration) FROM tbl_times WHERE fk_projects = "+projID+"";

				sqlite_conn.Open ();

				datareader = sqlite_cmd.ExecuteReader ();
				
				Int64 readDuration = 0;
				Int64 gesDuration = 0;
				
				while (datareader.Read())
				{
					gesDuration = datareader.GetInt64(0); 
				}
				sqlite_conn.Close ();
				
				return gesDuration;
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return 0; 
			}
		}

		public override bool addStartTime (short projID, string date, string startTime, string description, short userID)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "INSERT into tbl_times(fk_projects, date, starttime, description, fk_user) VALUES ('"+projID+"', '"+date+"', '"+startTime+"', '"+description+"', "+userID+")";
				sqlite_conn.Open ();
				sqlite_cmd.ExecuteNonQuery ();
				sqlite_conn.Close ();
				return true; 
			} catch (Exception ex) {
				sqlite_conn.Close ();
				return false; 
			}
		}

		public override bool addEndTime (short projID, string date, string startTime, string endTime, int duration, string description, short userID, int price)
		{
			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				sqlite_cmd.CommandText = "UPDATE tbl_times SET endtime='"+endTime+"', description='"+description+"', duration = "+duration+", price = "+price+" WHERE (fk_projects = "+projID+" AND date = '"+date+"' AND starttime='"+startTime+"' AND fk_user = "+userID+")";
				sqlite_conn.Open ();
				sqlite_cmd.ExecuteNonQuery ();
				sqlite_conn.Close ();
				return true; 
			} catch (Exception ex) {
				sqlite_conn.Close ();
				return false; 
			}
		}

		public override List<String[]> readStemps (short projID)
		{
			List<String[]> returnVal = new List<string[]>();

			string readName = readUname (projID);

			try {
				
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
//				sqlite_cmd.CommandText = "SELECT date, description, duration, price FROM tbl_times WHERE fk_projects = "+projID+"";
				sqlite_cmd.CommandText = "SELECT * FROM tbl_times WHERE fk_projects = "+projID+"";

				sqlite_conn.Open ();
				
				datareader = sqlite_cmd.ExecuteReader ();

				while (datareader.Read())
				{
					string[] tempArr = new string[5];

					tempArr[0] = datareader.GetString(1); 
					tempArr[1] = datareader.GetString(5);
					int readDur = datareader.GetInt16(4);
					tempArr[2] = Convert.ToString (readDur);
					int readPrice = datareader.GetInt32 (7);
					tempArr[3] = Convert.ToString (readPrice);
					tempArr[4] = readName;

					returnVal.Add (tempArr);
				}
				sqlite_conn.Close ();

				
				return returnVal;
			}  
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return returnVal; 
			}

			return returnVal;
		}

		private string readUname(int userid)
		{
			string readName = "";

			try {
				sqlite_cmd = sqlite_conn.CreateCommand ();
				
				sqlite_cmd.CommandText = "SELECT nname FROM tbl_users WHERE id ='"+userid+"'";
				
				sqlite_conn.Open();
				
				datareader = sqlite_cmd.ExecuteReader ();
				
				readName = ""; // ausgelesene ID von Typ von Company
				
				while (datareader.Read())
				{
					readName = datareader.GetString(0);
				}
				datareader.Close ();
				sqlite_conn.Close ();
				return readName; 
			} 
			catch (Exception ex) 
			{
				sqlite_conn.Close ();
				return readName; 
			}
		}
*/
	}
}

