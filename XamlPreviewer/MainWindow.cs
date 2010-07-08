using System;
using System.IO;

using System.Windows.Controls;

using Moonlight.Gtk;

public partial class MainWindow : Gtk.Window
{

	private string src = String.Empty;

	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		

		
		xamlpanel2.ReloadXaml (TextEditor.Buffer.Text);
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

		string tmp = TextEditor.Buffer.Text;
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
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog("Open File", this, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Ok );
		int x = fc.Run();
		if ( x == (int)Gtk.ResponseType.Ok ){
			if ( fc.Filename != null ){
				StreamReader sr = new StreamReader( fc.Filename );
				TextEditor.Buffer.Text = sr.ReadToEnd();
				sr.Close();
				UpdatePreview();
			}
		}
		fc.Visible = false;
		fc.Dispose();	
	}
	
	protected virtual void OnSaveActionActivated (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog("Save Xaml File", this,  Gtk.FileChooserAction.Save, "Cancel", Gtk.ResponseType.Cancel, "Save", Gtk.ResponseType.Ok );
		int x = fc.Run();
		if ( x == (int)Gtk.ResponseType.Ok ){
			if ( fc.Filename != null ){
				StreamWriter sw = new StreamWriter(fc.Filename);
				sw.Write( TextEditor.Buffer.Text );
				sw.Close();
				statusbar1.Push(0,"Saved..");
			}
		}
		fc.Visible = false;
		fc.Dispose();
	}
	
	
	
	
	
}
