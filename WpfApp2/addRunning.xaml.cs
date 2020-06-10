using DomainLibrary.Domain;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for addRunning.xaml
    /// </summary>
    public partial class addRunning : Window
    {
        private TrainingManager training;
        public addRunning(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = GetDate();
            float? distance = GetDistance();
            TimeSpan time = GetTime();
            int? averageWatt = GetWatt();
            TrainingType trainType = GetTrainingType();
            float? averageSpeed = GetAverageSpeed();
            string comments = GetComment();
            try
            {
                training.AddRunningTraining(date, (int)distance, time, averageSpeed, trainType, comments);
                MessageBox.Show("Training werd toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Niet gelukt om training toe te voegen");
            }
           
        }
        private TrainingType GetTrainingType()
        {
           // TrainingType type = new TrainingType();
            TrainingType type = TrainingType.Endurance;
            switch (trainingType.Text)
            {
                case "Endurance":
                    type = TrainingType.Endurance;
                    break;
                case "Interval":
                    type = TrainingType.Interval;
                    break;
                case "Recuperation":
                    type = TrainingType.Recuperation;
                    break;

            }
            return type;

        }
        public float? GetAverageSpeed()
        {
            float? speed = 0;
            if (float.TryParse(aSpeed.Text, out float avSpeed))
            {
                speed = avSpeed;
            }
            else
            {

            }
            return speed;
        }
        public float? GetAverageDuration()
        {
            float? duration = 0;
            if (float.TryParse(aDuration.Text, out float avDuration))
            {
                duration = avDuration;
            }
            else
            {

            }
            return duration;
        }
        public float? GetDistance()
        {
            float? distance = 0;
            if (float.TryParse(length.Text, out float di))
            {
                distance = di;
            }
            else
            {

            }
            return distance;
        }
        public int? GetWatt()
        {
            int? watt = 0;
            if (int.TryParse(aWatt.Text, out int wattage))
            {
                watt = wattage;
            }
            else
            {

            }
            return watt;
        }


        private DateTime GetDate()
        {
            //DateTime time = new DateTime();
            // if(trainingDate.SelectedDate!= null)

            return (DateTime)trainingDate.SelectedDate;
        }
        private TimeSpan GetTime()
        {
            TimeSpanEdit timeSpanEdit1 = new TimeSpanEdit();
            timeSpanEdit1.Format = " h 'hours' m 'minutes' s 'sec' ";
            timeSpanEdit1.Value = timeSpanEdit.Value;

            return (TimeSpan)timeSpanEdit.Value;
        }


        private string GetComment()
        {
            string comm = "";
            return comm = comment.Text.ToString();
        }
        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = GetDate();
            float? distance = GetDistance();
            TimeSpan time = GetTime();
            int? averageWatt = GetWatt();
            TrainingType trainType = GetTrainingType();
            float? averageSpeed = GetAverageSpeed();
            string comments = GetComment();
            
            training.AddRunningTraining(date, (int)distance, time, averageSpeed, trainType, comments);
        }
    }
}
