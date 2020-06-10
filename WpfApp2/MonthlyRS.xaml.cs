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
    /// Interaction logic for MonthlyRS.xaml
    /// </summary>
    public partial class MonthlyRS : Window
    {
        private TrainingManager training;
        public MonthlyRS(TrainingManager t)
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
            Report r = training.GenerateMonthlyRunningReport(jaarT, maandT);
            if (list.SelectedItem != null)
            {
                if (list.SelectedIndex == 0)
                {
                    output.Text = "";
                    var maxDistance = r.MaxDistanceSessionRunning.ToString();
                    output.Text += maxDistance;
                }
            
                if (list.SelectedIndex == 1)
                {
                    output.Text = "";
                    var maxSpeed = r.MaxSpeedSessionRunning.ToString();
                    output.Text += maxSpeed;

                }
                if (list.SelectedIndex == 2)
                {
                    output.Text = "";
                    var runes = r.Runs;
                    foreach (var rune in runes)
                    {
                        output.Text += rune.ToString() + "\n";
                    }

                }
                if (list.SelectedIndex == 3)
                {
                    output.Text = "";

                    var totalDistance = r.TotalRunningDistance.ToString();
                    output.Text += totalDistance;
                }
                if (list.SelectedIndex == 4)
                {
                    output.Text = "";
                    var totalRunninglTrainingTime = r.TotalRunningTrainingTime.ToString();
                    output.Text += totalRunninglTrainingTime;
                }
            }
            var totalSessions = r.TotalSessions.ToString();
            var totalTrainingTime = r.TotalTrainingTime.ToString();

            outputTotal.Text = "Total Training Time: " + totalTrainingTime + "\n" + "Total Sessions: " + totalSessions + "\n";
        }
    }
}
