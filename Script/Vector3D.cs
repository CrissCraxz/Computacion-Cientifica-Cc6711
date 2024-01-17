using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cc6711.Script
{
    internal class Vector3D : Vector
    {
        public double Zo;


        public Vector3D() { }

        public Vector3D(double x0, double y0, double z0, Color color)
        {
            this.Xo = x0;
            this.Yo = y0;
            this.Zo = z0;
            color0 = color;
        }

        public void Axonometria(double x0, double y0, double z0, out double ax, out double ay)
        {

            //  ax = y0 - ((x0 * 0.55) * Math.Cos(0.785)); // x0/2
            //  ay = z0 - ((x0 * 0.5) * Math.Sin(0.785));
            ax = x0 + ((0.5) * y0 * Math.Cos(0.8)); // x0/2
            ay = ((0.5) * y0 * Math.Sin(0.8)) + z0;
        }

        public override void Encender(Bitmap lienzo)
        {
            double ax, ay;
            int Sx, Sy;
            Axonometria(Xo, Yo, Zo, out ax, out ay);
            Pantalla(ax, ay, out Sx, out Sy);
            if (Sx >= 0 && Sx < 600 && Sy >= 0 && Sy < 500)
            {
                lienzo.SetPixel(Sx, Sy, color0);
            }
        }

    }
}
