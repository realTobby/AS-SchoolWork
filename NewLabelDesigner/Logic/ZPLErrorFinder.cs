using LabelDesigner.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ZPLUtility.Models;

namespace LabelDesigner.Logic
{
    public class ZPLErrorFinder
    {

        public List<ZPLMessage> CheckForErrors(List<ZPLCommandGroup> zplGroups)
        {
            List<ZPLMessage> resultList = new List<ZPLMessage>();

            // check for basic errors first

            // how many XA and XZ exist?
            // if count doesnt match, let the user know

            int xaCount = 0;
            int xzCount = 0;

            foreach(var group in zplGroups)
            {

                foreach(var command in group.Commands)
                {
                    if (command.CommandName.Contains("XA"))
                        xaCount++;
                    if (command.CommandName.Contains("XZ"))
                        xzCount++;
                }

            }


            if (xaCount != xzCount)
                resultList.Add(new ZPLMessage() { isError = true, Message = string.Format("Ungleiche Anzahl XA/XZ Kommandos.{0}XA: {1}, XZ: {2}", System.Environment.NewLine, xaCount, xzCount) });



            if (resultList.Count == 0)
                resultList.Add(new ZPLMessage() { Message = "Der LabelDesigner kann keine Fehler im ZPL finden!" });

            return resultList;
        }



    }


    [ValueConversion(typeof(int), typeof(Brush))]
    public class ErrorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int errorCount = (int)value;

            if (errorCount > 0)
                return Brushes.Red;

            return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }

    [ValueConversion(typeof(int), typeof(System.Enum))]
    public class ErrorCountToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int errorCount = (int)value;

            if (errorCount > 0)
                return MahApps.Metro.IconPacks.PackIconBoxIconsKind.SolidCommentX;

            return MahApps.Metro.IconPacks.PackIconBoxIconsKind.SolidCommentCheck;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }

}
