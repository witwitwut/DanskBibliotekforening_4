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
using Biz;
using Repository;

namespace DanskBibliotekForening_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBiz CB = new ClassBiz();
        ClassLogin CL = new ClassLogin();

        public MainWindow()
        {
            LogIn windowLogIn = new LogIn(CL, CB, this);
            InitializeComponent();
            this.mainGrid.DataContext = CB;
            windowLogIn.Show();
            this.Hide();
        }

        private void comboBoxLendBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
