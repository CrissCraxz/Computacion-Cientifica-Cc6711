using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cc6711.Script
{
    internal class CuerdaVibrante : Vector
    {
        public double t;
        public CuerdaVibrante() { }

        public CuerdaVibrante(double t) {
            this.t = t;
        }

         private double F(double x)
        {
            return x /5;//(-x * (x - 4)) / 2;
           // return x * (2 - x);
        }

        private double G(double x)
        {
            return x;
        }

        public void FourierC(double x, out double fou)
        {
           
            double aK, bK;
            
            //x = 0;
            double k = 3.897;
            double SumF = 0;
           
            do
            {
                k += 1;
                aK = 0.11 * (4 * 2 * Math.Sin(k * Math.PI * 0.5) + 4 * Math.Sin(k * Math.PI ));

                aK *= 0.5;

                bK = (0.11) * ( 4 * 2 * Math.Sin(k * Math.PI * 0.5) + 4 * Math.Sin(k * Math.PI ));
                bK = bK * (2 / (k * Math.PI *1));


                SumF = SumF + (aK * Math.Cos((k * Math.PI* 1* t) / 4) + bK * Math.Sin((k * Math.PI* 1* t) / 4)) *Math.Sin(k * Math.PI * x / 4);


            } while (k <= 20);
            fou = SumF;
        }

        public double F2(double x)
        {
            return x * (2 - x);
        }

        public double G2(double y)
        {
            return y * (3 - y);
        }

        public void cuerdaVibrante2D(Bitmap pantalla)
        {
            Vector vector = new Vector();
            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();
            double x = 0;
            vector.color0 = color0;
            do
            {
                vector.Xo = x;
                FourierC(x, out double fou);
                vector.Yo = fou;
                vector.Encender(pantalla);
                x += 0.001;
            } while (x <= 4);
        }

    
        /// animacion de la cuerda vibrante para 2d
        
        public void cuerdaVibranteAnimacion(Bitmap pantalla)
        {

            Vector vector = new Vector();
            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();
            double x = 0;
            vector.color0 = color0;
            do
            {
                vector.Xo = x;
                FourierC(x, out double fou);
                vector.Yo = fou;
                vector.Encender(pantalla);
                x += 0.01;
            } while (x <= 5);
        }

        public void cuerdaVibrantepRUEBA(Bitmap pantalla)
        {
            Vector vector = new Vector();
            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();
            double x = 0;
            double k = 3.897;
            vector.color0 = color0;
            do
            {
                vector.Xo = x*k;
                FourierC(x, out double fou);
                vector.Yo = fou;
                vector.Encender(pantalla);
                x += 0.001;
            } while (x <= 6);
        }


    }
}
