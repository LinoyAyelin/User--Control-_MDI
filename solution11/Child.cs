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
    public partial class Child : Form
    {
       

        public event delegate_MyEventHadler EventFromChild;

        public UserControl1 uc1 = new UserControl1();
        public UserControl1 uc2 = new UserControl1();

        public Child()
        {
            InitializeComponent();


            uc1.Location = new Point(0, 80);
            uc1.EventFromUserControl1 += new delegate_MyEventHadler(FromUserControl1);
            this.Controls.Add(uc1);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            uc2.Location = new Point(0, 150);
            uc2.EventFromUserControl1 += new delegate_MyEventHadler(FromUserControl1);
            this.Controls.Add(uc2);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }


       public void FromUserControl1 (object sender, myEventArgs e)
        {
         

            if (radioButton1.Checked)
                e.color = "Red";
            if (radioButton2.Checked)
                e.color = "Blue";
            if (radioButton3.Checked)
                e.color = "Gray";


            e.shape = comboBox2.SelectedItem.ToString();
            e.sortby= comboBox1.SelectedItem.ToString();


            if (EventFromChild != null)
                EventFromChild(this, e);
        }
        

        private void Child_Click(object sender, EventArgs e)  //   שינוי צבע של child 2 ע"י לחיצה על child1
        {
            foreach(Child myChild in this.MdiParent.MdiChildren)
           if(ReferenceEquals(myChild,this)!=true)
           {
                    Random r = new Random();
                    myChild.BackColor = Color.FromArgb(r.Next(0, 256),r.Next(0, 256), r.Next(0, 256));
           }
        }


      
    }

}
    

