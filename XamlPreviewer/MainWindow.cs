using System;

using System.Windows.Controls;

using System.Windows.Markup;
using Moonlight.Gtk;

public partial class MainWindow : Gtk.Window
{
	private DateTime last_change;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		last_change = System.DateTime.Now;
		
		xamlpanel2.ReloadXaml (textview3.Buffer.Text);
	}

	protected void OnDeleteEvent (object sender, Gtk.DeleteEventArgs a)
	{
		Gtk.Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnTextview3KeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
	{
		string src = textview3.Buffer.Text;
		
		object co = XamlReader.Load (src);
		
		Console.Error.WriteLine (co.GetType ().ToString ());
		
		if (System.DateTime.Now.Subtract (last_change).TotalSeconds > 2) {
			try {
				xamlpanel2.ReloadXaml (src);
				statusbar1.Push (0, "ok");
			} catch (System.Windows.Markup.XamlParseException ex) {
				statusbar1.Push (0, ex.Message);
			}
		
		}
		last_change = System.DateTime.Now;
		
	}
	
	
}
