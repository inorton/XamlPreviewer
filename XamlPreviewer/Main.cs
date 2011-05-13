using System;
using Gtk;
using Moonlight.Gtk;
using Mono.MoonDesk;
using System.Windows;

using ViewModels;

namespace XamlPreviewer
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			Gtk.Application.Init ();
			MoonlightRuntime.Init ();
			
      MoonWindow mw = new MoonWindow();
   
      mw.Title = "Xaml Preview";
      mw.DefaultWidth = 160;
      mw.DefaultHeight = 100;
      mw.Resize( 700, 200 );

      mw.ShowAll();
      mw.Host.Content = new System.Windows.Controls.TextBlock(){ Text = "Loading..." };

      int win_x;
      int win_y;
      int win_w;
      int win_h;
      
      mw.GetPosition( out win_x, out win_y );
      mw.GetSize( out win_w, out win_h );
      
      
      MainWindow win = new MainWindow ();
      win.Title = "Xaml Source";
      win.Show ();
      win.Move( win_x, win_y + win_h + 32 );
      win.Resize( 700, 200 );

      ViewResolver resolver = new ViewResolver( mw.Host );
      var xp = resolver.Loader.LoadView<XamlPanelViewModel>("Views;Views/XamlPanel.xaml");
      win.XpVM = xp.ViewModel;
      mw.Host.Content = xp.View as FrameworkElement;

			if ( args.Length > 0 )
				win.LoadFile( args[0] );
			
			Gtk.Application.Run ();
		}
	}
}
