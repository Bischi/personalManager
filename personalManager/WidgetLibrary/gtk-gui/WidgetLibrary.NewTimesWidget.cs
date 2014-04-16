
// This file has been generated by the GUI designer. Do not modify.
namespace WidgetLibrary
{
	public partial class NewTimesWidget
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.Label headerLabel;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Table table1;
		private global::Gtk.Label dateLabel;
		private global::Gtk.ComboBox dayCombobox;
		private global::Gtk.Fixed fixed1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Entry startHourEntry;
		private global::Gtk.Label label11;
		private global::Gtk.Entry StartMinuteEntry;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Entry entry10;
		private global::Gtk.Label label12;
		private global::Gtk.Entry entry11;
		private global::Gtk.Label label14;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;
		private global::Gtk.Label label5;
		private global::Gtk.Entry nameEntry;
		private global::Gtk.Table table3;
		private global::Gtk.Button button560;
		private global::Gtk.Button button561;
		private global::Gtk.ToggleButton editTogglebutton;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget WidgetLibrary.NewTimesWidget
			global::Stetic.BinContainer.Attach (this);
			this.ExtensionEvents = ((global::Gdk.ExtensionMode)(1));
			this.Name = "WidgetLibrary.NewTimesWidget";
			// Container child WidgetLibrary.NewTimesWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.headerLabel = new global::Gtk.Label ();
			this.headerLabel.Name = "headerLabel";
			this.headerLabel.Xalign = 0F;
			this.headerLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Neue Schicht ");
			this.vbox1.Add (this.headerLabel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.headerLabel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.HeightRequest = 6;
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(5)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.dateLabel = new global::Gtk.Label ();
			this.dateLabel.Name = "dateLabel";
			this.dateLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("12.12.12");
			this.table1.Add (this.dateLabel);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.dateLabel]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(3));
			w3.RightAttach = ((uint)(4));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.dayCombobox = global::Gtk.ComboBox.NewText ();
			this.dayCombobox.AppendText (global::Mono.Unix.Catalog.GetString ("Freitag"));
			this.dayCombobox.AppendText (global::Mono.Unix.Catalog.GetString ("Samstag"));
			this.dayCombobox.AppendText (global::Mono.Unix.Catalog.GetString ("Sonntag"));
			this.dayCombobox.Name = "dayCombobox";
			this.table1.Add (this.dayCombobox);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.dayCombobox]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.HeightRequest = 17;
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.table1.Add (this.fixed1);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.fixed1]));
			w5.TopAttach = ((uint)(4));
			w5.BottomAttach = ((uint)(5));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.startHourEntry = new global::Gtk.Entry ();
			this.startHourEntry.CanFocus = true;
			this.startHourEntry.Name = "startHourEntry";
			this.startHourEntry.IsEditable = true;
			this.startHourEntry.WidthChars = 2;
			this.startHourEntry.MaxLength = 2;
			this.startHourEntry.InvisibleChar = '●';
			this.hbox1.Add (this.startHourEntry);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.startHourEntry]));
			w6.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString (" : ");
			this.hbox1.Add (this.label11);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label11]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.StartMinuteEntry = new global::Gtk.Entry ();
			this.StartMinuteEntry.CanFocus = true;
			this.StartMinuteEntry.Name = "StartMinuteEntry";
			this.StartMinuteEntry.IsEditable = true;
			this.StartMinuteEntry.WidthChars = 2;
			this.StartMinuteEntry.MaxLength = 2;
			this.StartMinuteEntry.InvisibleChar = '●';
			this.hbox1.Add (this.StartMinuteEntry);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.StartMinuteEntry]));
			w8.Position = 2;
			this.table1.Add (this.hbox1);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox1]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entry10 = new global::Gtk.Entry ();
			this.entry10.CanFocus = true;
			this.entry10.Name = "entry10";
			this.entry10.IsEditable = true;
			this.entry10.WidthChars = 2;
			this.entry10.MaxLength = 2;
			this.entry10.InvisibleChar = '●';
			this.hbox2.Add (this.entry10);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entry10]));
			w10.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString (" : ");
			this.hbox2.Add (this.label12);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label12]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entry11 = new global::Gtk.Entry ();
			this.entry11.CanFocus = true;
			this.entry11.Name = "entry11";
			this.entry11.IsEditable = true;
			this.entry11.WidthChars = 2;
			this.entry11.MaxLength = 2;
			this.entry11.InvisibleChar = '●';
			this.hbox2.Add (this.entry11);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entry11]));
			w12.Position = 2;
			this.table1.Add (this.hbox2);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox2]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.Xalign = 1F;
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("Datum :");
			this.table1.Add (this.label14);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1 [this.label14]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Bezeichnung :");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Tag :");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Startzeit :");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w17.TopAttach = ((uint)(2));
			w17.BottomAttach = ((uint)(3));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Endzeit :");
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w18.TopAttach = ((uint)(3));
			w18.BottomAttach = ((uint)(4));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.nameEntry = new global::Gtk.Entry ();
			this.nameEntry.CanFocus = true;
			this.nameEntry.Name = "nameEntry";
			this.nameEntry.IsEditable = true;
			this.nameEntry.InvisibleChar = '●';
			this.table1.Add (this.nameEntry);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1 [this.nameEntry]));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table (((uint)(1)), ((uint)(3)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.button560 = new global::Gtk.Button ();
			this.button560.CanFocus = true;
			this.button560.Name = "button560";
			this.button560.UseUnderline = true;
			// Container child button560.Gtk.Container+ContainerChild
			global::Gtk.Alignment w21 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w22 = new global::Gtk.HBox ();
			w22.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w23 = new global::Gtk.Image ();
			w23.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-floppy", global::Gtk.IconSize.Menu);
			w22.Add (w23);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w25 = new global::Gtk.Label ();
			w25.LabelProp = global::Mono.Unix.Catalog.GetString ("Speichern");
			w25.UseUnderline = true;
			w22.Add (w25);
			w21.Add (w22);
			this.button560.Add (w21);
			this.table3.Add (this.button560);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table3 [this.button560]));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button561 = new global::Gtk.Button ();
			this.button561.CanFocus = true;
			this.button561.Name = "button561";
			this.button561.UseUnderline = true;
			// Container child button561.Gtk.Container+ContainerChild
			global::Gtk.Alignment w30 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w31 = new global::Gtk.HBox ();
			w31.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w32 = new global::Gtk.Image ();
			w32.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-ok", global::Gtk.IconSize.Menu);
			w31.Add (w32);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w34 = new global::Gtk.Label ();
			w34.LabelProp = global::Mono.Unix.Catalog.GetString ("Zurück");
			w34.UseUnderline = true;
			w31.Add (w34);
			w30.Add (w31);
			this.button561.Add (w30);
			this.table3.Add (this.button561);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.table3 [this.button561]));
			w38.LeftAttach = ((uint)(2));
			w38.RightAttach = ((uint)(3));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.editTogglebutton = new global::Gtk.ToggleButton ();
			this.editTogglebutton.CanFocus = true;
			this.editTogglebutton.Name = "editTogglebutton";
			this.editTogglebutton.UseUnderline = true;
			// Container child editTogglebutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w39 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w40 = new global::Gtk.HBox ();
			w40.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w41 = new global::Gtk.Image ();
			w41.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			w40.Add (w41);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w43 = new global::Gtk.Label ();
			w43.LabelProp = global::Mono.Unix.Catalog.GetString ("Bearbeiten");
			w43.UseUnderline = true;
			w40.Add (w43);
			w39.Add (w40);
			this.editTogglebutton.Add (w39);
			this.table3.Add (this.editTogglebutton);
			global::Gtk.Table.TableChild w47 = ((global::Gtk.Table.TableChild)(this.table3 [this.editTogglebutton]));
			w47.LeftAttach = ((uint)(1));
			w47.RightAttach = ((uint)(2));
			w47.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table3);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table3]));
			w48.Position = 3;
			w48.Expand = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
		}
	}
}
