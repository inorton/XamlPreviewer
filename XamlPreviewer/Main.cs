using System;
using Gtk;
using Moonlight.Gtk;
using Mono.MoonDesk;

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
      int win_x;
      int win_y;
      int win_w;
      int win_h;

      win.GetPosition( out win_x, out win_y );
      win.GetSize( out win_w, out win_h );

      MoonWindow mw = new MoonWindow();

      mw.Move( 16 + win_x + win_w, win_y );
      mw.DefaultWidth = 500;
      mw.WidthRequest = win_w;
      mw.HeightRequest = win_h;

      mw.ShowAll();
      mw.Host.Content = new System.Windows.Controls.TextBlock(){ Text = "Loading..." };
      win.MoonWindow = mw;
			
			if ( args.Length > 0 )
				win.LoadFile( args[0] );
			
			Application.Run ();
		}
	}
}
