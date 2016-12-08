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
        public TreeProperties() {
            InitializeComponent();
        }
        float l, k1, k2, k3, m2, m3, ax, az, bx, bz, cx, cz, l2, l3;

        private void button1_MouseClick(object sender,EventArgs e) {
            takeValues();
            draw(n,l,0,0,0,ax,az,bx,bz,cx,cz);
        }

        int n;
        StreamWriter sm = new StreamWriter("C:\\Users\\Elgun\\Desktop\\am.obj");
        public void draw(int n,float l,float x,float y,float z,float ax,float az,float bx,float bz,float cx,float cz) {

            Vector i = new Vector(x,y,z);
            Matrix rX = Matrix.GetRotationMatrixFor_X_Axis(az);
            Matrix rZ = Matrix.GetRotationMatrixFor_Z_Axis(ax);
            Matrix tr = rX.MultiplyByMatrix(rZ);
            Vector p1 = tr.MultiplyByVector(new Vector(0,0,1));
            Vector p2 = p1.scale(l*m2);
            Vector p3 = p1.scale(l*m3);
            p1=p1.scale(l);
            Vector p1End = tr.MultiplyByVector(p1);
            p1End=p1End.add(p1);


            Matrix rfX = Matrix.GetRotationMatrixFor_X_Axis(bz);
            Matrix rfZ = Matrix.GetRotationMatrixFor_Z_Axis(bx);
            Matrix fTr = rfX.MultiplyByMatrix(rfZ);
            Vector p2End = fTr.MultiplyByVector(new Vector(0,0,1));
            p2End=p2End.scale(l*k2);
            p2End=p2End.add(p2);

            Matrix rgX = Matrix.GetRotationMatrixFor_X_Axis(cz);
            Matrix rgZ = Matrix.GetRotationMatrixFor_Z_Axis(cx);
            Matrix gTr = rgX.MultiplyByMatrix(rgZ);
            Vector p3End = fTr.MultiplyByVector(new Vector(0,0,1));
            // p3=p3.scale(l*m3);
            p3End=p3End.scale(l*k2);
            p3End=p3End.add(p3);
            int j = 1;
            sm.WriteLine("v "+x+" "+y+" "+z);
            sm.WriteLine("v "+p1.x+" "+p1.y+" "+p1.z);
            sm.WriteLine("f "+j+" "+(j+1)+" "+j);
            sm.WriteLine("v "+p1.x+" "+p1.y+" "+p1.z);
            sm.WriteLine("v "+p1End.x+" "+p1End.y+" "+p1End.z);
            sm.WriteLine("f "+(j+2)+" "+(j+3)+" "+(j+2));
            sm.WriteLine("v "+p2.x+" "+p2.y+" "+p2.z);
            sm.WriteLine("v "+p2End.x+" "+p2End.y+" "+p2End.z);
            sm.WriteLine("f "+(j+4)+" "+(j+5)+" "+(j+4));
            sm.WriteLine("v "+p3.x+" "+p3.y+" "+p3.z);
            sm.WriteLine("v "+p3End.x+" "+p3End.y+" "+p3End.z);
            sm.WriteLine("f "+(j+6)+" "+(j+7)+" "+(j+6));
            j=j+7; if(n==0) {
                return;
            }
            draw(n-1,l*k1,p1End.x,p1End.y,p1End.z,ax,az,bx,bz,cx,cz);
            if(n==0) sm.Close();
        

    }


    //sm.WriteLine("v 0 0 0");
    //sm.WriteLine("v "+p1.x+" "+p1.y+" "+p1.z);
    //sm.WriteLine("f 1 2 1");
    //sm.WriteLine("v "+p1.x+" "+p1.y+" "+p1.z);
    //sm.WriteLine("v "+p1End.x+" "+p1End.y+" "+p1End.z);
    //sm.WriteLine("f 3 4 3");
    //sm.WriteLine("v "+p2.x+" "+p2.y+" "+p2.z);
    //sm.WriteLine("v "+p2End.x+" "+p2End.y+" "+p2End.z);
    //sm.WriteLine("f 5 6 5");
    //sm.WriteLine("v "+p3.x+" "+p3.y+" "+p3.z);
    //sm.WriteLine("v "+p3End.x+" "+p3End.y+" "+p3End.z);
    //sm.WriteLine("f 7 8 7");
    //sm.Close();



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
