using DomainLibrary.Domain;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for addCycling.xaml
    /// </summary>
    public partial class addCycling : Window
    {
        private TrainingManager training ;
        public addCycling(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;          

        }
        private BikeType GetBikeType()
        {
            
            BikeType type = BikeType.IndoorBike;
            switch (bikeType.Text)
            {
                case "MountainBike":
               
                    type = BikeType.MountainBike;
                    
                    break;
                case "CityBike":
                    type = BikeType.CityBike;
                    break;
                
                case "RacingBike":
                    type = BikeType.RacingBike;
                    
                    break;
                case "IndoorBike":
                    type = BikeType.IndoorBike;
                    break;
            }
            return type;
        }
        private TrainingType GetTrainingType()
        {
           
            TrainingType type = TrainingType.Recuperation;
            switch (trainingType.Text)
            {
                case "Interval":
               
                    type = TrainingType.Interval;
                    
                    break;
                case "Endurance":
                    type = TrainingType.Endurance;
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

            return (DateTime)trainingDate.SelectedDate.ToDateTime();
        }
        private TimeSpan GetTime()
        {
            // SfTimePicker sfTimePicker = new SfTimePicker();

            //Adding SfTimePicker as window content
            // this.Content = sfTimePicker;
            //SfTimePicker sfTimePicker = new SfTimePicker();
            //var time=sfTimePicker.FormatString = "HH:mm:ss";

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
            BikeType bikeType = GetBikeType();
            try
            {
                training.AddCyclingTraining(date, distance, time, averageSpeed, averageWatt, trainType, comments, bikeType);
                MessageBox.Show("Training werd toegevoegd");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Niet gelukt om training toe te voegen");

            }
           
        }

        private void length_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
