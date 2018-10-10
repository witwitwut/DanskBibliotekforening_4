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
using System.Windows.Shapes;

namespace DanskBibliotekForening_4
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void textBoxCprNr_GotMouseCapture(object sender, MouseEventArgs e)
        {
            this.textBoxCprNr.Text = "";
        }

        private void textBoxPassword_GotMouseCapture(object sender, MouseEventArgs e)
        {
            this.textBoxPassword.Text = "";
        }
    }
}
