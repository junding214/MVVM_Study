using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snippet_代码片段
{
    public partial class Form1 : Form
    {

        public int MyProperty { get; set; }

        private int _my;

        public int MY
        {
            get { return _my; }
            set { _my = value; }
        }
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.RaisePropertyChanged("Name");


            }
        }
        
    }
}
