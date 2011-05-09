using System;
using Gtk;
using Moonlight.Gtk;
using Mono.MoonDesk;

using ViewModels;

namespace XamlPreviewer
{
	public class MainClass
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
      mw.DefaultWidth = 160;
      mw.DefaultHeight = 120;
      mw.Resize( win_w, win_h );

      mw.ShowAll();
      mw.Host.Content = new System.Windows.Controls.TextBlock(){ Text = "Loading..." };


      ViewResolver resolver = new ViewResolver( mw.Host );
      var xp = resolver.Loader.LoadView<XamlPanelViewModel>("Views;Views/XamlPanel.xaml");
      win.XpVM = xp.ViewModel;
      mw.Host.Content = xp.View;

			if ( args.Length > 0 )
				win.LoadFile( args[0] );
			
			Application.Run ();
		}
	}
}
