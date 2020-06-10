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
    /// Interaction logic for RapportC.xaml
    /// </summary>
    public partial class RapportC : Window
    {
        private TrainingManager training;

        public RapportC(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
            
                List<CyclingSession> cTraining = training.GetAllCyclingSessions();
                foreach (var ct in cTraining)
                {
                output.Text += ct.ToString() + "\n";
                }
            

        }
    }
}
