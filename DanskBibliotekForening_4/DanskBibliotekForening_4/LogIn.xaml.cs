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
using Biz;
using Repository;

namespace DanskBibliotekForening_4
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        Window callingWindow;

        private ClassLogin _CL;
        private ClassBiz _CB;

        public LogIn(ClassLogin inCL, ClassBiz inCB, Window inWN)
        {
            InitializeComponent();
            CL = inCL;
            CB = inCB;
            callingWindow = inWN;
            this.textBoxCprNr.DataContext = CL;
            this.textBoxPassword.DataContext = CL;
        }

        public ClassLogin CL
        {
            get { return _CL; }
            set { _CL = value; }
        }
        
        public ClassBiz CB
        {
            get { return _CB; }
            set { _CB = value; }
        }
        
        private void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            CL.GetUserData();
            if ( CL.cp.id == 0)
            {
                MessageBox.Show("Du har indtastet forkert CprNr eller Password");
            }
            else
            {
                CB.laanteboeger = CB.GetAllLentBoks(CL.cp.id.ToString());
                this.Hide();
                callingWindow.Show();
            }
        }
    }
}
