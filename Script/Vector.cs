using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cc6711.Script
{
    internal class Vector
    {
        //  factor de aumento dividir x1 y x2, y1,y2 para 2
        
        public double x1 = -10/2, x2 = 10/2, y1 = -8.33 / 2, y2 = 8.33 / 2, sx1 = 0, sx2 = 600, sy1 = 0, sy2 = 500, Xo, Yo;
        
        public Color color0;

        public Vector() { }
        public Vector(int Xo, int Yo, Color color0)
        {
            this.Xo = Xo;
            this.Yo = Yo;
            this.color0 = color0;
        }


        public void Pantalla(double x, double y, out int sx, out int sy)
        {
            sx = (int)(((x - x1) / (x1 - x2)) * (sx1 - sx2) + sx1);
            sy = (int)(((y - y2) / (y2 - y1)) * (sy1 - sy2) + sy1);
        }

        //out double
        public void transform(double sx, double sy, out double x, out double y)
        {
            x = ((x1 - x2) * (sx - sx1) / (sx1 - sx2)) + x1;
            y = ((y2 - y1) * (sy - sy1) / (sy1 - sy2)) + y2;
        }
        public virtual void Encender(Bitmap pixelVec)
        {
            int Sx, Sy;
            Pantalla(Xo, Yo, out Sx, out Sy);
            if (Sx >= 0 && Sx < 600 && Sy >= 0 && Sy < 500)
            {

                    pixelVec.SetPixel(Sx, Sy, color0);
                
            }


        }

        public virtual void Apagar(Bitmap pixelVec)
        {
            for (int i = 0; i < pixelVec.Width; i++)
            {
                for (int j = 0; j < pixelVec.Height; j++)
                {
                    pixelVec.SetPixel(i, j, Color.White);
                }
            }
            Encender(pixelVec);

        }

        public virtual void ApagarAnimacion(Bitmap pixelVec)
        {
            color0 = Color.White;
            Encender(pixelVec);

        }



    }
}
