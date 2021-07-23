using LabelDesigner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelDesigner.Models
{
  public enum ElementType
  {
    Text,
    EAN13,
    Code128,
    Grafik,
    QR,
    DataMatrix
  }

  public class ZPLElement : BaseNotifier
  {

    private int _id = 0;
    private ElementType _elementType = ElementType.Text;
    private string _elementName = string.Empty;
    
    private string _content = string.Empty;
    
    private string _barcodeScale = "4";
    private string _barcodeHeight = "50";
    private string _imageFullPath = "";
    public int ID
    {
      get { return _id; }
      set { _id = value; base.OnPropertyChanged(nameof(ID)); }
    }

    public ElementType ElementType
    {
      get { return _elementType; }
      set { _elementType = value; base.OnPropertyChanged(nameof(ElementType)); }
    }

    public string ElementName
    {
      get { return _elementName; }
      set { _elementName = value; base.OnPropertyChanged(nameof(ElementName)); }
    }

   

    

    

    public string BarcodeScale
    {
      get { return _barcodeScale; }
      set { _barcodeScale = value; base.OnPropertyChanged(nameof(BarcodeScale)); }
    }

    public string BarcodeHeight
    {
      get { return _barcodeHeight; }
      set { _barcodeHeight = value; base.OnPropertyChanged(nameof(BarcodeHeight)); }
    }

    public string ImageFullPath
    {
      get { return _imageFullPath; }
      set { _imageFullPath = value; base.OnPropertyChanged(nameof(ImageFullPath)); }
    }

    public ZPLElement(string x, string y, ElementType type)
    {
      _elementType = type;
    }
  }
}
