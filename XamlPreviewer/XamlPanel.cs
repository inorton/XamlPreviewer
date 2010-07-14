
using System;
using Moonlight.Gtk;

using System.Windows.Controls;
using System.Windows.Markup;

namespace XamlPreviewer
{
	
	public delegate void ChangedEventHanlder( object sender, EventArgs e );

	[System.ComponentModel.ToolboxItem(true)]
	public partial class XamlPanel : Gtk.Bin
	{

		public MoonlightHost MoonHost = null;
		Border outer;
		
		public string Xaml = null;
		
		public XamlPanel ()
		{
			this.Build ();
			MoonHost = new MoonlightHost ();
		
			Grid align = new Grid ();
			align.Background = new System.Windows.Media.SolidColorBrush (System.Windows.Media.Colors.Gray);
		
			Border cont = new Border ();
			cont.Background = new System.Windows.Media.SolidColorBrush (System.Windows.Media.Colors.White);
			
			cont.Margin = new System.Windows.Thickness (8.0);
			cont.Padding = new System.Windows.Thickness (0.0);
			cont.CornerRadius = new System.Windows.CornerRadius ( 5.0 );
			cont.BorderThickness = new System.Windows.Thickness( 5.5 );
			cont.BorderBrush = new System.Windows.Media.SolidColorBrush( System.Windows.Media.Colors.DarkGray );
			outer = cont;
			
			cont.RenderTransform = new System.Windows.Media.ScaleTransform(){ ScaleX = 0.75, ScaleY = 0.75 };
			
			align.Children.Add( outer );
			
			MoonHost.Content = align;
			this.Remove( frame1 );
			this.Add( MoonHost );
			this.ShowAll ();
		}
		
		public void SetScale( double x, double y )
		{
			((System.Windows.Media.ScaleTransform)outer.RenderTransform).ScaleX = x;
			((System.Windows.Media.ScaleTransform)outer.RenderTransform).ScaleY = y;
		
		}
		
		public void ReloadXaml (string xaml)
		{
			lock (MoonHost) {
				object o = XamlReader.Load (xaml);
				
				if (o is System.Windows.UIElement ) {
					outer.Child = (System.Windows.UIElement)o;
				}
				
				// MoonHost.LoadXaml (xaml);
			}
		}
		
		public event ChangedEventHanlder Changed;
		
		protected virtual void OnChanged (EventArgs a)
		{
			if (Changed != null)
				Changed (this, a);
		}
		
		protected virtual void OnRealized (object sender, System.EventArgs e)
		{
			
		}
		
		
		
	}
}
