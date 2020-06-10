using DataLayer;
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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        private TrainingManager training;
        public Delete(TrainingManager t)
        {
            InitializeComponent();
            this.training = t;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrainingManager tm = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            List<int> cTraining = new List<int>();
            List<int> rTraining = new List<int>();

            int id = 0;
            if (int.TryParse(idInput.Text, out int inputInt))
            {               
                id = inputInt;
                cTraining.Add(id);
       
                MessageBoxResult result = MessageBox.Show("Are you sure?","Delete", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            tm.RemoveTrainings(cTraining, rTraining);
                            MessageBox.Show("Deleted");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Not deleted");
                        }
                        break;
                    case MessageBoxResult.No:
                        break;                  

                }                               
            }
        }
       
    }
}
