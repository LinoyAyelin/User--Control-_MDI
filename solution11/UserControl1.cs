using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solution11
{
    public delegate void delegate_MyEventHadler(object sender, myEventArgs e);


    public partial class UserControl1 : UserControl
    {
        public event delegate_MyEventHadler EventFromUserControl1;

        public Control[] arrControls;
        private static Random ucRand = new Random();
        

        public UserControl1()
        {
            InitializeComponent();
            int arrSize = ucRand.Next(12, 23);
            arrControls = new Control[arrSize];
            int currPosition = 1;
            
            for (int i = 0; i < arrSize; i++)
            {
                arrControls[i] = new Label();
                arrControls[i].Location = new Point(currPosition, 2);
                
                int temp = ucRand.Next(15,30);

                switch (ucRand.Next(4))
                {
                    case 0: arrControls[i].Size = new Size(temp, temp); break;
                    case 1: arrControls[i].Size = new Size(temp*2, temp*2); break;
                    case 2: arrControls[i].Size = new Size(temp , temp * 2); break;
                    case 3: arrControls[i].Size = new Size( temp*2,temp ); break;
                }

                int c = ucRand.Next(100, 255);
                switch (ucRand.Next(3))
                {
                    case 0: arrControls[i].BackColor = Color.FromArgb(ucRand.Next(100, 255), 0,0); break;
                    case 1: arrControls[i].BackColor = Color.FromArgb(0, 0, ucRand.Next(100, 255)); break;
                    case 2: arrControls[i].BackColor = Color.FromArgb(c,c,c); break;
                }
                currPosition += arrControls[i].Size.Width + 2;
                this.Controls.Add(arrControls[i]);
            }
        }

        private void UserControl1_Click(object sender, EventArgs e)
        {
            myEventArgs temp = new myEventArgs();    
            temp.user = this;
            
            if (EventFromUserControl1 != null)
                EventFromUserControl1(this, temp);

        }
    }
}
