using System;
using System.IO;
using GtkSourceView;
using System.Windows.Controls;

using Moonlight.Gtk;
using XamlPreviewer;
using Mono.MoonDesk;

public partial class MainWindow : Gtk.Window
{
	private string src = String.Empty;
	private SourceBuffer sb = null;
	private SourceView sv = null;

  public MoonWindow MoonWindow { get; set; }

	private static System.Timers.Timer updateTimer = new System.Timers.Timer( 1500 );
			
	private string filename = String.Empty;

	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		sb = new SourceBuffer (SourceLanguageManager.Default.GetLanguage ("xml"));
		sb.HighlightSyntax = true;
		sb.HighlightMatchingBrackets = true;
		
		sv = new SourceView (sb);
		scrolledwindow1.Add (sv);

		updateTimer.Elapsed += delegate {
			RunUpdate();
		};
						
		sb.Changed += delegate {
			UpdatePreview();
		};

    vbox1.ShowAll();
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
		lock ( updateTimer ){
			statusbar1.Push(0,"Typing....");
			updateTimer.Stop();
			updateTimer.Enabled = false;
			updateTimer.Interval = 1500;
			updateTimer.Start();
		}
		
	} 
	
	
	public void RunUpdate()
	{
		string tmp = sb.Text;
		
		if (src.Equals (tmp)){
			return;
		}
			
		src = tmp;
		
		Console.Error.WriteLine(src);
		Gtk.Application.Invoke( this, new EventArgs(), delegate {
			try {
        MoonWindow.Host.LoadXaml(src);

				statusbar1.Push (0, "ok");
			} catch (System.Windows.Markup.XamlParseException ex) {
				statusbar1.Push (0, ex.Message);
			}
		} );

	}

	public override string ToString ()
	{
		return src;
	}

	public void LoadFile( string path )
	{
		StreamReader sr = new StreamReader (path);
		filename = path;
		sb.Text = sr.ReadToEnd();
		sr.Close();
		UpdatePreview();
	
	}
	
	protected virtual void OnOpenActionActivated (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog ("Open File", this, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Ok);
		int x = fc.Run ();
		if (x == (int)Gtk.ResponseType.Ok) {
			if (fc.Filename != null) {
				LoadFile( fc.Filename );
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
