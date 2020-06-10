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
    /// Interaction logic for RecentRS.xaml
    /// </summary>
    public partial class RecentRS : Window
    {
        private TrainingManager training;
        public RecentRS(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            int laatseTrainings = 0;
            if (int.TryParse(input.Text, out int inputInt))
            {
                laatseTrainings = inputInt;
                List<RunningSession> cTrainings = training.GetPreviousRunningSessions(laatseTrainings);

                foreach (var ct in cTrainings)
                {

                    output.Text += ct.ToString() + "\n";

                }
            }
        }
    }
}
