using LabelDesigner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelDesigner.Models
{
  public enum BasicTextElementProperties
  {
    Text,
    TextSizeX,
    TextSizeY
  }

  public class BasicTextElement : BaseZPLElement, IZPLElement
  {
    #region Private Fields
    private string _textSizeX = "50";
    private string _textSizeY = "50";
    #endregion

    #region Public Fields

    #endregion

    #region Properties
    public string TextSizeX
    {
      get { return _textSizeX; }
      set { _textSizeX = value; base.OnPropertyChanged(nameof(TextSizeX)); }
    }
    public string TextSizeY
    {
      get { return _textSizeY; }
      set { _textSizeY = value; base.OnPropertyChanged(nameof(TextSizeY)); }
    }
    public string Text
    {
      get { return base.Content; }
      set { base.Content = value; base.OnPropertyChanged(nameof(Text)); }
    }
    
    #endregion

    #region Methods
    public string GetZPLSnippet()
    {
      string zplResult = "";

      string fontMark = string.Format("^A0N,{0},{1}", TextSizeX, TextSizeY);
      string contentMark = string.Format("^FD{0}^FS", Text);

      zplResult = base.GetZPLPosition() + fontMark + contentMark + System.Environment.NewLine;

      return zplResult;
    }

    public void SetZPLProperty(ElementType type, string key, string value)
    {
      if(type == ElementType.Text)
      {
        if(Enum.IsDefined(typeof(BasicTextElementProperties), key))
        {
          if (key == BasicTextElementProperties.Text.ToString())
          {
            Text = value;
          }
          if (key == BasicTextElementProperties.TextSizeX.ToString())
          {
            TextSizeX = value;
          }
          if (key == BasicTextElementProperties.TextSizeY.ToString())
          {
            TextSizeY = value;
          }
        }
      }
    }

    public string GetZPLProperty(ElementType type, string key)
    {
      if (type == ElementType.Text)
      {
        if (Enum.IsDefined(typeof(BasicTextElementProperties), key))
        {
          if (key == BasicTextElementProperties.Text.ToString())
          {
            return Text;
          }
          if (key == BasicTextElementProperties.TextSizeX.ToString())
          {
            return TextSizeX;
          }
          if (key == BasicTextElementProperties.TextSizeY.ToString())
          {
            return TextSizeY;
          }
        }
      }
      return string.Empty;
    }

    public ElementType GetElementType()
    {
      return ElementType.Text;
    }

    public string GetElementName()
    {
      return base.ElementName;
    }

    public void SetElementName(string name)
    {
      base.ElementName = name;
    }
    #endregion
  }
}
