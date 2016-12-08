using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Procedural_Tree {
    public struct Vector {
        public float x, y, z;
        public Vector(float x,float y,float z) {
            this.x=x;
            this.y=y;
            this.z=z;
        }

        public float DotProduct(Vector v) {
            return this.x*v.x+this.y*v.y+this.z*v.z;
        }
        public Vector scale(float l) {
            return new Vector(this.x*l,this.y*l,this.z*l);
        }
        public Vector add(Vector v) {
            return new Vector(this.x + v.x, this.y + v.y, this.z + v.z);
        }
    }
    public struct Matrix {
        //specifically 3x3 matrix, so holding 3 vectors
        //[x1, y1, z1]
        //[x2, y2, z2]
        //[x3, y3, z3]
        Vector vx, vy, vz;

        //IDENTITY MATRIX(3x3)
        public static Matrix I_MATRIX = new Matrix(new Vector(1,0,0),new Vector(0,1,0),new Vector(0,0,1));

        public Matrix(Vector vx,Vector vy,Vector vz) {
            this.vx=vx; this.vy=vy; this.vz=vz;
        }
       

        public Vector MultiplyByVector(Vector vec) //Matrix(3x3) X Vector(3x1) = Vector(3x1)
        {
            //[x1, y1, z1]   [x]   [x1*x + y1*y + z1*z]      [new_x]
            //[x2, y2, z2] X [y] = [x2*x + y2*y + z2*z] ==>> [new_y]
            //[x3, y3, z3]   [z]   [x3*x + y3*y + z3*z]      [new_z]
            float x = this.vx.DotProduct(vec);
            float y = this.vy.DotProduct(vec);
            float z = this.vz.DotProduct(vec);
            return new Vector(x,y,z);
        }

        public Matrix MultiplyByMatrix(Matrix mat) {
            //in matrix multiplication, 
            //rows of first matrix is multiplied(dotproduct) with columns of second matrix
            Vector col_x_vec = new Vector(mat.vx.x,mat.vy.x,mat.vz.x);
            Vector col_y_vec = new Vector(mat.vx.y,mat.vy.y,mat.vz.y);
            Vector col_z_vec = new Vector(mat.vx.z,mat.vy.z,mat.vz.z);

            float x_x = this.vx.DotProduct(col_x_vec);
            float x_y = this.vx.DotProduct(col_y_vec);
            float x_z = this.vx.DotProduct(col_z_vec);

            float y_x = this.vy.DotProduct(col_x_vec);
            float y_y = this.vy.DotProduct(col_y_vec);
            float y_z = this.vy.DotProduct(col_z_vec);

            float z_x = this.vz.DotProduct(col_x_vec);
            float z_y = this.vz.DotProduct(col_y_vec);
            float z_z = this.vz.DotProduct(col_z_vec);

            Vector x = new Vector(x_x,x_y,x_z);
            Vector y = new Vector(y_x,y_y,y_z);
            Vector z = new Vector(z_x,z_y,z_z);
            Matrix result = new Matrix(x,y,z);
            return result;
        }

        public static Matrix GetRotationMatrixFor_X_Axis(float angle_z) 
        {
            Vector vx = new Vector(1,0,0);
            Vector vy = new Vector(0,(float)Math.Cos(angle_z),-1*(float)Math.Sin(angle_z));
            Vector vz = new Vector(0,(float)Math.Sin(angle_z),(float)Math.Cos(angle_z));
            return new Matrix(vx,vy,vz);
        }
        public static Matrix GetRotationMatrixFor_Z_Axis(float angle_x) {
            Vector vx = new Vector((float)Math.Cos(angle_x),-1*(float)Math.Sin(angle_x),0);
            Vector vy = new Vector((float)Math.Sin(angle_x),(float)Math.Cos(angle_x),0);
            Vector vz = new Vector(0,0,1);
            return new Matrix(vx,vy,vz);
        }
    }

}
public class Tree {


}
