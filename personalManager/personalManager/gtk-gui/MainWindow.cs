
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action PlneAction;
	private global::Gtk.Action PersonenAction;
	private global::Gtk.Action SchichtenAction;
	private global::Gtk.Action addAction;
	private global::Gtk.Action orientationPortraitAction;
	private global::Gtk.Action fileAction;
	private global::Gtk.Action openAction;
	private global::Gtk.Action ffnenAction;
	private global::Gtk.Action homeTBButton;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.Toolbar toolbar1;
	private global::WidgetLibrary.SelectWidget selectwidget;
	private global::Gtk.Table table1;
	private global::Gtk.Label dateLabel;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.Fixed fixed2;
	private global::Gtk.Label musicFestivalLabel;
	private global::Gtk.Label musicNameLabel;
	private global::Gtk.Label timeLabel;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.PlneAction = new global::Gtk.Action ("PlneAction", global::Mono.Unix.Catalog.GetString ("Pläne"), null, null);
		this.PlneAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Pläne");
		w1.Add (this.PlneAction, null);
		this.PersonenAction = new global::Gtk.Action ("PersonenAction", global::Mono.Unix.Catalog.GetString ("Personen"), null, null);
		this.PersonenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Personen");
		w1.Add (this.PersonenAction, null);
		this.SchichtenAction = new global::Gtk.Action ("SchichtenAction", global::Mono.Unix.Catalog.GetString ("Schichten"), null, null);
		this.SchichtenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Schichten");
		w1.Add (this.SchichtenAction, null);
		this.addAction = new global::Gtk.Action ("addAction", global::Mono.Unix.Catalog.GetString ("Neu"), null, "gtk-add");
		this.addAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Neu");
		w1.Add (this.addAction, null);
		this.orientationPortraitAction = new global::Gtk.Action ("orientationPortraitAction", global::Mono.Unix.Catalog.GetString ("Anzeigen"), null, "gtk-orientation-portrait");
		this.orientationPortraitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Anzeigen");
		w1.Add (this.orientationPortraitAction, null);
		this.fileAction = new global::Gtk.Action ("fileAction", global::Mono.Unix.Catalog.GetString ("Anzeigen"), null, "gtk-file");
		this.fileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Anzeigen");
		w1.Add (this.fileAction, null);
		this.openAction = new global::Gtk.Action ("openAction", global::Mono.Unix.Catalog.GetString ("Öffnen"), null, "gtk-open");
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Öffnen");
		w1.Add (this.openAction, null);
		this.ffnenAction = new global::Gtk.Action ("ffnenAction", global::Mono.Unix.Catalog.GetString ("Öffnen"), null, "Times");
		this.ffnenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Öffnen");
		w1.Add (this.ffnenAction, null);
		this.homeTBButton = new global::Gtk.Action ("homeTBButton", null, null, "gtk-home");
		w1.Add (this.homeTBButton, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.ExtensionEvents = ((global::Gdk.ExtensionMode)(1));
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Home");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='PlneAction' action='PlneAction'><menuitem name='openAction' action='openAction'/></menu><menu name='PersonenAction' action='PersonenAction'><menuitem name='addAction' action='addAction'/><menuitem name='orientationPortraitAction' action='orientationPortraitAction'/></menu><menu name='SchichtenAction' action='SchichtenAction'><menuitem name='ffnenAction' action='ffnenAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='homeTBButton' action='homeTBButton'/><separator/><toolitem name='openAction' action='openAction'/><separator/><toolitem name='addAction' action='addAction'/><toolitem name='orientationPortraitAction' action='orientationPortraitAction'/><separator/><toolitem name='ffnenAction' action='ffnenAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.selectwidget = new global::WidgetLibrary.SelectWidget ();
		this.selectwidget.Events = ((global::Gdk.EventMask)(256));
		this.selectwidget.Name = "selectwidget";
		this.vbox1.Add (this.selectwidget);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.selectwidget]));
		w4.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table (((uint)(2)), ((uint)(3)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		this.table1.BorderWidth = ((uint)(12));
		// Container child table1.Gtk.Table+TableChild
		this.dateLabel = new global::Gtk.Label ();
		this.dateLabel.Name = "dateLabel";
		this.dateLabel.Xalign = 0F;
		this.dateLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("DATUM");
		this.table1.Add (this.dateLabel);
		global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.dateLabel]));
		w5.XOptions = ((global::Gtk.AttachOptions)(4));
		w5.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		this.table1.Add (this.fixed1);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.fixed1]));
		w6.LeftAttach = ((uint)(1));
		w6.RightAttach = ((uint)(2));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.fixed2 = new global::Gtk.Fixed ();
		this.fixed2.Name = "fixed2";
		this.fixed2.HasWindow = false;
		this.table1.Add (this.fixed2);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.fixed2]));
		w7.TopAttach = ((uint)(1));
		w7.BottomAttach = ((uint)(2));
		w7.LeftAttach = ((uint)(1));
		w7.RightAttach = ((uint)(2));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.musicFestivalLabel = new global::Gtk.Label ();
		this.musicFestivalLabel.Name = "musicFestivalLabel";
		this.musicFestivalLabel.Xalign = 1F;
		this.musicFestivalLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Bezirksmusikfest");
		this.table1.Add (this.musicFestivalLabel);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.musicFestivalLabel]));
		w8.LeftAttach = ((uint)(2));
		w8.RightAttach = ((uint)(3));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.musicNameLabel = new global::Gtk.Label ();
		this.musicNameLabel.Name = "musicNameLabel";
		this.musicNameLabel.Xalign = 1F;
		this.musicNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("MV - Thüringerberg");
		this.table1.Add (this.musicNameLabel);
		global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.musicNameLabel]));
		w9.TopAttach = ((uint)(1));
		w9.BottomAttach = ((uint)(2));
		w9.LeftAttach = ((uint)(2));
		w9.RightAttach = ((uint)(3));
		w9.YOptions = ((global::Gtk.AttachOptions)(0));
		// Container child table1.Gtk.Table+TableChild
		this.timeLabel = new global::Gtk.Label ();
		this.timeLabel.Name = "timeLabel";
		this.timeLabel.Xalign = 0F;
		this.timeLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Uhrzeit");
		this.table1.Add (this.timeLabel);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.timeLabel]));
		w10.TopAttach = ((uint)(1));
		w10.BottomAttach = ((uint)(2));
		w10.XOptions = ((global::Gtk.AttachOptions)(4));
		w10.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox1.Add (this.table1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
		w11.Position = 3;
		w11.Expand = false;
		w11.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 653;
		this.DefaultHeight = 377;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.homeTBButton.Activated += new global::System.EventHandler (this.OnHomeTBButtonActivated);
	}
}
