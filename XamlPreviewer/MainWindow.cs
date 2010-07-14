using System;
using System.IO;
using GtkSourceView;

using System.Windows.Controls;

using Moonlight.Gtk;

public partial class MainWindow : Gtk.Window
{

	private string src = String.Empty;
	private SourceBuffer sb;
	private SourceView sv;
	private Gtk.ScrolledWindow sw;
	
	private string filename = String.Empty;

	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		sb = new SourceBuffer (SourceLanguageManager.Default.GetLanguage ("xml"));
		sb.HighlightSyntax = true;
		sb.HighlightMatchingBrackets = true;
		
		sv = new SourceView (sb);
		sw = new Gtk.ScrolledWindow ();
		sw.Add (sv);

		Gtk.Adjustment a1 = new Gtk.Adjustment (50.0, 0, 100.0, 1.0, 10.0, 5.0);
		Gtk.Adjustment a2 = new Gtk.Adjustment (50.0, 0, 100.0, 1.0, 10.0, 5.0);
	
		vpaned1.Child2.Destroy ();
		vpaned1.Add2 (sw);
		vpaned1.ShowAll ();
		
		xamlpanel2.SetScrollAdjustments( a1, a2 );
	}

	protected void OnDeleteEvent (object sender, Gtk.DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}


	protected virtual void OnTextEditorKeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
	{
		UpdatePreview();
	}


	public void UpdatePreview ()
	{

		string tmp = sb.Text;
		statusbar1.Push (0, "Updating...");
		
		if (src.Equals (tmp)){
			return;
		}
			
		src = tmp;
		
		Console.Error.WriteLine(src);
		
		try {

			xamlpanel2.ReloadXaml (src);
			statusbar1.Push (0, "ok");
		} catch (System.Windows.Markup.XamlParseException ex) {
			statusbar1.Push (0, ex.Message);
		}

	}

	public override string ToString ()
	{
		return src;
	}
	
	protected virtual void OnVscale1ChangeValue (object o, Gtk.ChangeValueArgs args)
	{
		xamlpanel2.SetScale( vscale1.Value/100.0, vscale1.Value/100.0 );
	}
	
	protected virtual void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog ("Open File", this, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Ok);
		int x = fc.Run ();
		if (x == (int)Gtk.ResponseType.Ok) {
			if (fc.Filename != null) {
				StreamReader sr = new StreamReader (fc.Filename);
				filename = fc.Filename;
				sb.Text = sr.ReadToEnd();
				sr.Close();
				UpdatePreview();
			}
		}
		fc.Visible = false;
		fc.Dispose();	
	}
	
	protected virtual void OnSaveAsActionActivated (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog ("Save Xaml File", this, Gtk.FileChooserAction.Save, "Cancel", Gtk.ResponseType.Cancel, "Save", Gtk.ResponseType.Ok);
		int x = fc.Run ();
		if (x == (int)Gtk.ResponseType.Ok) {
			if (fc.Filename != null) {
				StreamWriter sw = new StreamWriter (fc.Filename);
				filename = fc.Filename;
				sw.Write( sb.Text );
				sw.Close();
				statusbar1.Push(0,"Saved..");
			}
		}
		fc.Visible = false;
		fc.Dispose();
	}
	
	
	
	protected virtual void OnGtkScrolledWindow1Realized (object sender, System.EventArgs e)
	{
	}
	
	protected void Save ()
	{
		if (filename.Equals (String.Empty))
			return;
		StreamWriter sw = new StreamWriter (filename);
		sw.Write (sb.Text);
		sw.Close ();
		statusbar1.Push (0, "Saved..");
	}
	
	protected virtual void OnSaveActionActivated (object sender, System.EventArgs e)
	{
		Save ();
	}
	
	
	
	
	
	
	
	
}
