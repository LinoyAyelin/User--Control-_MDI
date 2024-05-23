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
    public partial class Container : Form
    {
        Child myChild1;
        Child myChild2;
        
     
       
        public Container()
        {
            this.Width = 0;
            this.Height = 0;

            InitializeComponent();
           

            myChild1 = new Child();
            myChild1.MdiParent = this;
            this.Width += myChild1.Width;
            this.Height += myChild1.Height;
            myChild1.EventFromChild += new delegate_MyEventHadler(MDI_event_From_Child);
            myChild1.Show();

            myChild2 = new Child();
            myChild2.MdiParent = this;
            this.Width += myChild2.Width;
            this.Height += myChild2.Height;
            myChild2.EventFromChild += new delegate_MyEventHadler(MDI_event_From_Child);
            myChild2.Show();
            
        }




        private void MDI_event_From_Child(object sender, myEventArgs e)
        {
            List<Control> allControls = new List<Control>();
            List<Control> tempList1 = new List<Control>();
             
            foreach (Control t in e.user.Controls)
            {
                if (e.color == "Red" && t.BackColor.R > 0 && t.BackColor.B==0 && t.BackColor.G==0)
                    tempList1.Add(t);

                if (e.color == "Blue" && t.BackColor.B > 0&& t.BackColor.R == 0 && t.BackColor.G == 0)
                    tempList1.Add(t);

                if (e.color == "Gray" && t.BackColor.R == t.BackColor.B && t.BackColor.B == t.BackColor.G)
                    tempList1.Add(t);
            }

            foreach (Control a in tempList1)
            {
                if (e.shape == "Square")
                {
                    if (a.Height == a.Width)
                    {
                        allControls.Add(a);
                    }
                }

                if (e.shape == "Rectangle")
                {
                    if (a.Height != a.Width)
                    {
                        allControls.Add(a);
                    }
                }
            }


            if (e.sortby == "Up")
            {
                allControls.Sort((x, y) => x.Width * x.Height - y.Width * y.Height);
            }

            if (e.sortby == "Down")
            {
                allControls.Sort((x, y) => -(x.Width * x.Height) + (y.Width * y.Height));
            }

            Arrange(e.user, allControls);
        }


        private void Container_Load_1(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        
        public void Arrange(UserControl1 User, List<Control> tempList)
        {
            User.Controls.Clear();
            int currPosition = 1;
            for (int i = 0; i < tempList.Count; i++)
            {
                Control tempControl = tempList[i];
                tempControl.Location = new Point(currPosition, 2);
                User.Controls.Add(tempControl);
                currPosition += tempControl.Width + 2;
            }
        }
    }
}
