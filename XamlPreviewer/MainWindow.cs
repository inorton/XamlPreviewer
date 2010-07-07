using System;

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
	
	
}
