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

      var mw = new MoonArea();
      mw.Content = new System.Windows.Controls.TextBlock(){ Text = "Loading..." };

      MainWindow win = new MainWindow ();
      win.Title = "Xaml Source";
      win.Show ();
      win.Resize( 750, 600 );

      win.MoonAreaContainer.Add( mw );

      ViewResolver resolver = new ViewResolver( mw );
      var xp = resolver.Loader.LoadView<XamlPanelViewModel>("Views;Views/XamlPanel.xaml");
      win.XpVM = xp.ViewModel;
      mw.Content = xp.View as FrameworkElement;

			if ( args.Length > 0 )
				win.LoadFile( args[0] );
			
			Gtk.Application.Run ();
		}
	}
}
