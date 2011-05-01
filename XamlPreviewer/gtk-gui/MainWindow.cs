
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action openAction;
	private global::Gtk.Action saveAsAction;
	private global::Gtk.Action saveAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.VPaned vpaned1;
	private global::Gtk.HBox hbox1;
	private global::XamlPreviewer.XamlPanel xamlpanel2;
	private global::Gtk.VScale vscale1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView TextEditor;
	private global::Gtk.Statusbar statusbar1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.openAction = new global::Gtk.Action ("openAction", null, null, "gtk-open");
		w1.Add (this.openAction, null);
		this.saveAsAction = new global::Gtk.Action ("saveAsAction", null, null, "gtk-save-as");
		w1.Add (this.saveAsAction, null);
		this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
		w1.Add (this.saveAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='openAction' action='openAction'/><toolitem name='saveAction' action='saveAction'/><toolitem name='saveAsAction' action='saveAsAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(0));
		this.toolbar1.IconSize = ((global::Gtk.IconSize)(3));
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vpaned1 = new global::Gtk.VPaned ();
		this.vpaned1.CanFocus = true;
		this.vpaned1.Name = "vpaned1";
		this.vpaned1.Position = 250;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.xamlpanel2 = new global::XamlPreviewer.XamlPanel ();
		this.xamlpanel2.Events = ((global::Gdk.EventMask)(256));
		this.xamlpanel2.Name = "xamlpanel2";
		this.hbox1.Add (this.xamlpanel2);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.xamlpanel2]));
		w3.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.vscale1 = new global::Gtk.VScale (null);
		this.vscale1.WidthRequest = 36;
		this.vscale1.CanFocus = true;
		this.vscale1.Name = "vscale1";
		this.vscale1.Inverted = true;
		this.vscale1.Adjustment.Lower = 5;
		this.vscale1.Adjustment.Upper = 200;
		this.vscale1.Adjustment.PageIncrement = 5;
		this.vscale1.Adjustment.StepIncrement = 1;
		this.vscale1.Adjustment.Value = 75;
		this.vscale1.DrawValue = true;
		this.vscale1.Digits = 0;
		this.vscale1.ValuePos = ((global::Gtk.PositionType)(3));
		this.hbox1.Add (this.vscale1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vscale1]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Padding = ((uint)(5));
		this.vpaned1.Add (this.hbox1);
		global::Gtk.Paned.PanedChild w5 = ((global::Gtk.Paned.PanedChild)(this.vpaned1 [this.hbox1]));
		w5.Resize = false;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.TextEditor = new global::Gtk.TextView ();
		this.TextEditor.CanFocus = true;
		this.TextEditor.Name = "TextEditor";
		this.TextEditor.Editable = false;
		this.GtkScrolledWindow.Add (this.TextEditor);
		this.vpaned1.Add (this.GtkScrolledWindow);
		this.vbox1.Add (this.vpaned1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vpaned1]));
		w8.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		this.vbox1.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1135;
		this.DefaultHeight = 915;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.openAction.Activated += new global::System.EventHandler (this.OnOpenActionActivated);
		this.saveAsAction.Activated += new global::System.EventHandler (this.OnSaveAsActionActivated);
		this.saveAction.Activated += new global::System.EventHandler (this.OnSaveActionActivated);
		this.vscale1.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnVscale1ChangeValue);
		this.TextEditor.KeyReleaseEvent += new global::Gtk.KeyReleaseEventHandler (this.OnTextEditorKeyReleaseEvent);
	}
}