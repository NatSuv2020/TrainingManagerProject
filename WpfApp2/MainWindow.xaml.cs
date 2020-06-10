using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DomainLibrary.Domain.TrainingManager t;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window addCycling1 = new addCycling(t);
            addCycling1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window addRunning1 = new addRunning(t);
            addRunning1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            
            Window recentC = new RecentCS(t);
            recentC.Show();
          
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window recentT = new RecentRS(t);
            recentT.Show();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window rapportR = new RapportR(t);
            rapportR.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window rapportC = new RapportC(t);
            rapportC.Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window delete = new Delete(t);
            delete.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window monthlyRS = new MonthlyRS(t);
            monthlyRS.Show();
        }


        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            t = new DomainLibrary.Domain.TrainingManager(new UnitOfWork(new TrainingContext(null)));
            Window monthlyCS = new MonthlyCS(t);
            monthlyCS.Show();

        }
    }
}
