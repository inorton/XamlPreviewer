using System;
using System.Reflection;
using Gtk;
using Moonlight.Gtk;
using Mono.MoonDesk;
using System.Windows;
using System.Collections.Generic;

using Mono.Options;

using ViewModels;

namespace XamlPreviewer
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
      var libs = new List<Assembly>();
      var opts = new OptionSet();
      opts.Add( "r=", "load extra {ASSEMBLY}",
        x => {
          try {
              libs.Add( System.Reflection.Assembly.LoadFile(x) );
            } catch ( System.IO.FileNotFoundException ){
              Console.Error.WriteLine("Error: no such assembly file " + x );
              System.Environment.Exit(1);
            } catch ( Exception e ){
              Console.Error.WriteLine("Error: " + e.Message );
              System.Environment.Exit(1);
            }
          } );
      opts.Add( "help","print this message",
        x => {
          Console.WriteLine("Usage: xamlpreviewer [OPTIONS] [FILE.xaml]");
          Console.WriteLine();
          opts.WriteOptionDescriptions(Console.Out);
          Console.WriteLine();
          System.Environment.Exit(1);
          } );

      var remain = opts.Parse( args );
      string file = null;
      if ( remain.Count > 0 ) file = remain[0];

      Start( file, libs );
    }


    static void Start( string loadxaml, IEnumerable<Assembly> libs )
    {
			Gtk.Application.Init ();

      MoonBase.Init( libs );

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

			if ( loadxaml != null ){
        try {
				  win.LoadFile( loadxaml );
        } catch ( Exception e ) {
          xp.ViewModel.UserContent = new System.Windows.Controls.TextBlock()
            { Text = String.Format("Error\n\n{0}", e.Message ),
              Padding = new System.Windows.Thickness(10.0),
              FontStyle = System.Windows.FontStyles.Italic };
        }

      }
			
			Gtk.Application.Run ();
		}
	}
}
