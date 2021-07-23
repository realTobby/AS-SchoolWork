using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace oszimt.drive4ever
{
    public class ViewModel :INotifyPropertyChanged
    { 
        public List<T_Fragen> fragenBuffer = new List<T_Fragen>();

        public DiveDataConnector diveDataConnector = new DiveDataConnector();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    private T_Fragen frage;
        public T_Fragen Frage
        {
            get { return frage; }
            set { frage = value; OnPropertyChange("Frage"); }
        }

        private string frageLabel;
        public string FrageLabel
        {
            get { return frageLabel; }
            set { frageLabel = value; OnPropertyChange("FrageLabel"); }
        }

        private string buttonStatus = "Beantworten";
        public string ButtonStatus
        {
            get { return buttonStatus; }
            set { buttonStatus = value; OnPropertyChange("ButtonStatus"); }
        }

        private bool checkZufallsFrage = false;
        public bool CheckZufallsFrage
        {
            get { return checkZufallsFrage; }
            set { checkZufallsFrage = value; OnPropertyChange("CheckZufallsFrage"); }
        }



        private bool radioCheckedA = false;
        public bool RadioCheckedA
        {
            get { return radioCheckedA; }
            set { radioCheckedA = value; OnPropertyChange("RadioCheckedA"); }
        }

        private bool radioCheckedB = false;
        public bool RadioCheckedB
        {
            get { return radioCheckedB; }
            set { radioCheckedB = value; OnPropertyChange("RadioCheckedB"); }
        }


        private bool radioCheckedC = false;
        public bool RadioCheckedC
        {
            get { return radioCheckedC; }
            set { radioCheckedC = value; OnPropertyChange("RadioCheckedC"); }
        }

        private bool radioCheckedD = false;
        public bool RadioCheckedD
        {
            get { return radioCheckedD; }
            set { radioCheckedD = value; OnPropertyChange("RadioCheckedD"); }
        }

        private bool allowedToClick = true;
        public bool AllowedToClick
        {
            get { return allowedToClick; }
            set { allowedToClick = value; OnPropertyChange("AllowedToClick"); }
        }



        public List<int> frageBuffer = new List<int>();
        public Random rnd = new Random();
        public bool checkAnswer = false;
        public ViewModel()
        {
            frageBuffer.Add(0);
            GetNextQuestion();
        }

        private SolidColorBrush backColorForA;
        public SolidColorBrush BackColorForA
        {
            get { return backColorForA; }
            set { backColorForA = value; OnPropertyChange("BackColorForA"); }
        }

        private SolidColorBrush backColorForB;
        public SolidColorBrush BackColorForB
        {
            get { return backColorForB; }
            set { backColorForB = value; OnPropertyChange("BackColorForB"); }
        }

        private SolidColorBrush backColorForC;
        public SolidColorBrush BackColorForC
        {
            get { return backColorForC; }
            set { backColorForC = value; OnPropertyChange("BackColorForC"); }
        }

        private SolidColorBrush backColorForD;
        public SolidColorBrush BackColorForD
        {
            get { return backColorForD; }
            set { backColorForD = value; OnPropertyChange("BackColorForD"); }
        }

        public void ResetUI()
        {
            AllowedToClick = true;

            RadioCheckedA = false;
            RadioCheckedB = false;
            RadioCheckedC = false;
            RadioCheckedD = false;

            BackColorForA = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BackColorForB = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BackColorForC = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BackColorForD = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }



        public void GetNextQuestion()
        {
            ResetUI();
            if (frageBuffer.Count() == 16)
            {
                MessageBox.Show("Quiz vollständig beantwortet! Komme bald wieder :)");
                ResetUI();
            }
            else
            {
                if (CheckZufallsFrage == true)
                {
                    int rndQuestion = rnd.Next(0, diveDataConnector.T_Fragen.ToList().Count() - 1);

                    if (frageBuffer.Exists(x => x == rndQuestion))
                    {

                        GetNextQuestion();
                    }
                    else
                    {
                        T_Fragen diveData = diveDataConnector.T_Fragen.ToList().First(x => x.P_Fragen_ID == rndQuestion);
                        frageBuffer.Add(diveData.P_Fragen_ID);
                        Frage = diveData;
                        FrageLabel = "Frage: " + (frageBuffer.Count() - 1) + " von 15";
                    }
                }
                else
                {
                    int lastId = frageBuffer.Last();
                    T_Fragen diveData = diveDataConnector.T_Fragen.ToList().First(x => x.P_Fragen_ID == lastId + 1);
                    frageBuffer.Add(diveData.P_Fragen_ID);
                    Frage = diveData;
                    FrageLabel = "Frage: " + (frageBuffer.Count() - 1) + " von 15";
                }
            }
        }
    }
}
