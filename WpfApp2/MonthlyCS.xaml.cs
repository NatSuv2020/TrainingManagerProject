using DomainLibrary.Domain;
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
    /// Interaction logic for MonthlyCS.xaml
    /// </summary>
    public partial class MonthlyCS : Window
    {
        private TrainingManager training;
        public MonthlyCS(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            int jaarT = 0;
            int maandT = 0;
            if (int.TryParse(inputYear.Text.Trim(), out int inputInt))
            {
                jaarT = inputInt;
            }
            if (int.TryParse(inputMonth.Text.Trim(), out int input2))
            {               
                maandT = input2;
              
            }
            Report r = training.GenerateMonthlyCyclingReport(jaarT, maandT);
            if (list.SelectedItem != null)
            {
                if(list.SelectedIndex==0)
                {
                    output.Text = "";
                    var maxDistance = r.MaxDistanceSessionCycling.ToString();
                    output.Text += maxDistance;
                }
                if (list.SelectedIndex == 1)
                {
                    output.Text = "";
                    var maxWatt = r.MaxWattSessionCycling.ToString();
                    output.Text += maxWatt;
                }
                if (list.SelectedIndex == 2)
                {
                    output.Text = "";
                    var maxSpeed = r.MaxSpeedSessionCycling.ToString();
                    output.Text += maxSpeed;
                    
                }
                if (list.SelectedIndex == 3)
                {
                    output.Text = "";
                    var rides = r.Rides;
                    foreach(var ride in rides)
                    {
                        output.Text += ride.ToString() + "\n";
                    }
                    
                }
                if (list.SelectedIndex == 4)
                {
                    output.Text = "";
                    
                    var totalDistance = r.TotalCyclingDistance.ToString();
                    output.Text += totalDistance;
                }
                if (list.SelectedIndex == 5)
                {
                    output.Text = "";
                    var totalCyclinglTrainingTime = r.TotalCyclingTrainingTime.ToString();
                    output.Text += totalCyclinglTrainingTime;
                }
            }
            var totalSessions = r.TotalSessions.ToString();
            var totalTrainingTime = r.TotalTrainingTime.ToString();

            outputTotal.Text = "Total Training Time: " +totalTrainingTime + "\n" + "Total Sessions: " +totalSessions + "\n";






           
         
        }
    }
}
