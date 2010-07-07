
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
		
			Border cont = new Border ();
			cont.Margin = new System.Windows.Thickness (8.0);
			outer = cont;
			
			MoonHost.Content = cont;
			
			this.Add (MoonHost);
			this.ShowAll ();
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
	}
}
