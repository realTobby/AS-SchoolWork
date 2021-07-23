using System.ComponentModel;

namespace LabelDesigner.Models
{
  public class PrintDataRow
  {
    [DisplayName("Variablenname")]
    public string VariableName { get; set; }
    [DisplayName("Variablenwert")]
    public string VariableValue { get; set; }
  }
}
