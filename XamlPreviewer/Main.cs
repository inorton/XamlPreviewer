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
			
			if ( args.Length > 0 )
				win.LoadFile( args[0] );
			
			Application.Run ();
		}
	}
}
