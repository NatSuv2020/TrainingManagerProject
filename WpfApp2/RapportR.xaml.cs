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
    /// Interaction logic for RapportR.xaml
    /// </summary>
    public partial class RapportR : Window
    {
        private TrainingManager training;
        public RapportR(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
            this.training = t;

            List<RunningSession> rTraining = training.GetAllRunningSessions();
            foreach (var rt in rTraining)
            {
                output.Text += rt.ToString() + "\n";
            }
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
