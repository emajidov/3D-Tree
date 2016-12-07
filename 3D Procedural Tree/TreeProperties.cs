using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3D_Procedural_Tree {

    public partial class TreeProperties :Form {
        float l, k1, k2, k3, m2, m3, ax, az, bx, bz, cx, cz, l2, l3;
        int n;
        List<Point> vx = new List<Point>();
        private void button1_MouseClick(object sender,MouseEventArgs e) {
            takeValues();
            drawBranch(0,0,0,l,ax,az,n,ax,az,bx,bz,cx,cz);

        }
        public TreeProperties() {
            InitializeComponent();
        }

        public int i = 1;
        StreamWriter sw = new StreamWriter("c:\\Users\\Elgun\\Desktop\\test9.obj");
        private void drawBranch(float x,float y,float z,float l,float anglex,float anglez,int depth,
             float ax,float az,float bx,float bz,float cx,float cz) {
            if(depth==0) return;
            anglez+=az;
            anglex+=ax;
            float l1 = l*k1;
            float l2 = l*k2;
            float l3 = l*k3;
           
            float x1 = x+l*(float)Math.Cos(anglex)*(float)Math.Sin(anglez);
            float y1 = y+l*(float)Math.Sin(anglex)*(float)Math.Sin(anglez);
            float z1 = z+l*(float)Math.Cos(anglez);


          
            float x2s = x+l*m2*(float)Math.Cos(anglex)*(float)Math.Sin(anglez);
            float y2s = y+l*m2*(float)Math.Sin(anglex)*(float)Math.Sin(anglez);
            float z2s = z+l*m2*(float)Math.Cos(anglez);
            
            float x2e = x2s+l2*(float)Math.Cos(anglex+bx)*(float)Math.Sin(anglez+bz);
            float y2e = y2s+l2*(float)Math.Sin(anglex+bx)*(float)Math.Sin(anglez+bz);
            float z2e = z2s+l2*(float)Math.Cos(anglez+bz);
           
            float x3s = x+l*m3*(float)Math.Cos(anglex)*(float)Math.Sin(anglez);
            float y3s = y+l*m3*(float)Math.Sin(anglex)*(float)Math.Sin(anglez);
            float z3s = z+l*m3*(float)Math.Cos(anglez);
   
            float x3e = x3s+l3*(float)Math.Cos(anglex-cx)*(float)Math.Sin(anglez-cz);
            float y3e = y3s+l3*(float)Math.Sin(anglex-cx)*(float)Math.Sin(anglez-cz);
            float z3e = z3s+l3*(float)Math.Cos(anglez-cz);


            String starta = "v "+x+" "+y+" "+z;
            String enda = "v "+x1+" "+y1+" "+z1;
            String startb = "v "+x2s+" "+y2s+" "+z2s;
            String endb = "v "+x2e+" "+y2e+" "+z2e;
            String startc = "v "+x3s+" "+y3s+" "+z3s;
            String endc = "v "+x3e+" "+y3e+" "+z3e;
            String f1 = "f "+i+" "+(i+1)+" "+i;
            String f2 = "f "+(i+2)+" "+(i+3)+" "+(i+2);
            String f3 = "f "+(i+4)+" "+(i+5)+" "+(i+4);
            Write(starta);
            Write(enda);
            Write(f1);
            Write(startb);
            Write(endb);
            Write(f2);
            Write(startc);
            Write(endc);
            Write(f3);
            i=i+6;
            depth--;
            // recursievely calling drawBranch() method from end coordinates of each branch
            drawBranch(x1,y1,z1,l1,anglex,anglez,depth,ax,az,bx,bz,cx,cz);
            drawBranch(x2e,y2e,z2e,l2,anglex+bx,anglez+bz,depth,ax,az,bx,bz,cx,cz);
            drawBranch(x3e,y3e,z3e,l3,anglex-cx,anglez-cz,depth,ax,az,bx,bz,cx,cz);

        }
        public void Write(String s) {
            try {

                //Pass the filepath and filename to the StreamWriter Constructor


                //Write a line of text
                sw.WriteLine(s);

            }
            catch(Exception e) {
                Console.WriteLine("Exception: "+e.Message);
            }
            finally {
                Console.WriteLine("Executing finally block.");
            }
        }


        private void TreeProperties_Load(object sender,EventArgs e) {

        }
        public void takeValues() {
            this.l=(float)L.Value;
            this.k1=(float)k_1.Value;
            this.k2=(float)k_2.Value;
            this.k3=(float)k_3.Value;
            this.m2=(float)m_2.Value;
            this.m3=(float)m_3.Value;
            this.ax=(float)a_x.Value;
            this.az=(float)a_z.Value;
            this.bx=(float)b_x.Value;
            this.bz=(float)b_z.Value;
            this.cx=(float)c_x.Value;
            this.cz=(float)c_z.Value;
            this.n=(int)level.Value;
            this.l2=l*k2;
            this.l3=l*k3;

        }
        public float sin(float a) {
            return (float)Math.Sin(a);
        }
        public float cos(float a) {
            return (float)Math.Cos(a);
        }
    }
}
