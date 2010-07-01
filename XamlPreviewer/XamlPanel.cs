
using System;
using Moonlight.Gtk;

namespace XamlPreviewer
{
	
	public delegate void ChangedEventHanlder( object sender, EventArgs e );

	[System.ComponentModel.ToolboxItem(true)]
	public partial class XamlPanel : Gtk.Bin
	{

		public MoonlightHost MoonHost = null;
		
		public string Xaml = null;
		
		public XamlPanel ()
		{
			this.Build ();
			MoonHost = new MoonlightHost ();
		
			this.Add (MoonHost);
			this.ShowAll ();
		}
		
		public void ReloadXaml (string xaml)
		{
			lock ( MoonHost ){
				MoonHost.LoadXaml (xaml);
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
