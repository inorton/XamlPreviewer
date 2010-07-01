using System;
using Gtk;
using Moonlight.Gtk;

namespace XamlPreviewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			
			MoonlightRuntime.Init ();
			
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
