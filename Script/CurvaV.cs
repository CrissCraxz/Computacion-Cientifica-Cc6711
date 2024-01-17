using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cc6711.Script
{
    internal class CurvaV : Circunferencia
    {
        public int tipo;
        public double cx, Rx, Ry, cy;
        public void Encender(Bitmap bitmap) { 
            Vector vector = new Vector();
            double t, dt;
            if (tipo == 0)
            {
                //curva 0
                //F(t) = sen (2t), cos(3t)
                t =0;
                dt = 0.001;
                do {
                    //Xo - Yo movimiento de la figura dentro del mapa 
                    //Rx - Ry es el escalamiento de la curva dentro de la ventana pantalla
                    vector.Xo = Xo+ Rx * Math.Sin(2*t);
                    vector.Yo = Yo+ Ry * Math.Cos(3*t);
                    vector.color0 = color0;
                    vector.Encender(bitmap);
                    t = t + dt;
                    // 0 <= t <=2PI
                } while (t <= 2*Math.PI);
            } if (tipo == 1)
            {
                t = 0;
                dt = 0.001;
                do
                {
                    //Xo - Yo movimiento de la figura dentro del mapa 
                    //Rx - Ry es el escalamiento de la curva dentro de la ventana pantalla
                    vector.Xo = Xo + Rx * Math.Cos(4 * t)*Math.Cos(t);
                    vector.Yo = Yo + Ry * Math.Cos(4 * t)*Math.Sin(t);
                    vector.color0 = color0;
                    vector.Encender(bitmap);
                    t = t + dt;
                    // 0 <=t <=2PI
                } while (t <= 2 * Math.PI);
            }
            if (tipo == 2)
            {
                t = 0;
                dt = 0.001;
                do
                {
                    //Xo - Yo movimiento de la figura dentro del mapa 
                    //Rx - Ry es el escalamiento de la curva dentro de la ventana pantalla
                    vector.Xo = Xo + Rx * Math.Pow( Math.Sin(t),3);
                    vector.Yo = Yo + Ry * Math.Pow( Math.Cos(t),3);
                    vector.color0 = color0;
                    vector.Encender(bitmap);
                    t = t + dt;
                    // 0 <=t <=2PI
                } while (t <= 2 * Math.PI);
            } if (tipo == 3 )
            {
                t = 0;
                dt = 0.001;
                do
                {
                    //Xo - Yo movimiento de la figura dentro del mapa 
                    //Rx - Ry es el escalamiento de la curva dentro de la ventana pantalla
                    vector.Xo = Xo + Rx * Math.Sin(8*t/5)*Math.Cos(t);
                    vector.Yo = Yo + Ry * Math.Sin(8*t/5)*Math.Sin(t);
                    vector.color0 = color0;
                    vector.Encender(bitmap);
                    t = t + dt;
                    // 0 <=t <=10PI
                } while (t <= 10 * Math.PI);
            }
        }
    }
}
