using System;
using System.Windows;
using Mono.MoonDesk;

namespace ViewModels
{
  public class XamlPanelViewModel : ViewModelBase
  {
    public XamlPanelViewModel () {
    }

    private FrameworkElement _userContent;
    public FrameworkElement UserContent {
      get {
        return _userContent;
      }
      set {
        if ( value != null ){
          value.DataContext = new Object();
        }
        _userContent = value;
        OnPropertyChanged("UserContent");
      }
    }

    private double _scaleValue = 1.0;
    public double ScaleValue {
      get {
        return _scaleValue;
      }
      set {
        _scaleValue = value;
        OnPropertyChanged("ScaleValue");
        OnPropertyChanged("ScalePercent");
      }
    }

    public string ScalePercent {
      get { return String.Format("{0:00}%",ScaleValue * 100); }
    }
  }
}

