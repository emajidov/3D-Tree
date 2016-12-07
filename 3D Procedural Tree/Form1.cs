using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Procedural_Tree {
    public partial class Form1 :Form {
        int l, m2, m3, k1, k2, k3, ax, az, bx, bz, cx, cz, n;

     

        public Form1() {
            InitializeComponent();
            }

   private void openFile(object sender,EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory="C:\\Users\\Elgun";
            if(dialog.ShowDialog()==DialogResult.OK) {

                }
            }
        public void drawLine() {

            }
        }
    }
