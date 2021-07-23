using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelDesigner.Models
{
  public enum Code128ElementProperties
  {
     BarcodeText,
     BarcodeScale,
     BarcodeHeight
  }

  public class Code128Element : BaseZPLElement, IZPLElement
  {
    #region Private Fields
    private string _barcodeScale = string.Empty;
    private string _barcodeText = string.Empty;
    private string _barcodeHeight = string.Empty;
    #endregion

    #region Public Fields
    #endregion

    #region Properties
    public string BarcodeText
    {
      get { return base.Content; }
      set { base.Content = value; base.OnPropertyChanged(nameof(BarcodeText)); }
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
    #endregion

    #region Methods
    public string GetElementName()
    {
      return base.ElementName;
    }

    public ElementType GetElementType()
    {
      return ElementType.Code128;
    }

    public string GetZPLProperty(ElementType type, string key)
    {
      if (type == ElementType.Code128)
      {
        if (Enum.IsDefined(typeof(Code128ElementProperties), key))
        {
          if (key == Code128ElementProperties.BarcodeText.ToString())
          {
            return BarcodeText;
          }
          if (key == Code128ElementProperties.BarcodeHeight.ToString())
          {
            return BarcodeHeight;
          }
          if (key == Code128ElementProperties.BarcodeScale.ToString())
          {
            return BarcodeScale;
          }
        }
      }
      return string.Empty;
    }

    public string GetZPLSnippet()
    {
      // ^BYw,r,h
      //    // ^BCo,h,f,g,e,m
      //    scaleMark = string.Format("^BY{0}", zplElement.BarcodeScale);
      //    barcodeMark = string.Format("^BCN,{0},Y,N,N",zplElement.BarcodeHeight);
      //    contentMark = string.Format("^FD>:{0}^FS", zplElement.Content);
      //    resultZPL = resultZPL + scaleMark + barcodeMark + contentMark + System.Environment.NewLine;
      //    break;

      string zplResult = string.Empty;

      string scaleFactor = string.Format("^BY{0}", BarcodeScale);
      string barcodeMark = string.Format("^BCN,{0},Y,N,N", BarcodeHeight);
      string barocdeContent = string.Format("^FD>:{0}^FS", BarcodeText);

      zplResult = zplResult + scaleFactor + barcodeMark + barocdeContent + System.Environment.NewLine;

      return zplResult;
    }

    public void SetElementName(string name)
    {
      base.ElementName = name;
    }

    public void SetZPLProperty(ElementType type, string key, string value)
    {
      if (type == ElementType.Code128)
      {
        if (Enum.IsDefined(typeof(Code128ElementProperties), key))
        {
          if (key == Code128ElementProperties.BarcodeText.ToString())
          {
            BarcodeText = value;
          }
          if (key == Code128ElementProperties.BarcodeScale.ToString())
          {
            BarcodeScale = value;
          }
          if (key == Code128ElementProperties.BarcodeHeight.ToString())
          {
            BarcodeHeight = value;
          }
        }
      }
    }
    #endregion


  }
}
