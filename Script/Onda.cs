using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cc6711.Script
{
    internal class Onda: Vector
    {
        // t es el tiempo, v la velocidad, w longitud de la onda en el ambiente, m altura maxima
        public double w, t, v,m;
        public double psy =0, psx=0;


        Color[] paleta0 = new Color[16];



        public void ColoresPaleta()
        {
            paleta0[0] = Color.Black;
            paleta0[1] = Color.Navy;
            paleta0[2] = Color.Green;
            paleta0[3] = Color.Aqua;
            paleta0[4] = Color.Red;
            paleta0[5] = Color.Purple;
            paleta0[6] = Color.Maroon;
            paleta0[7] = Color.LightGray;
            paleta0[8] = Color.DarkGray;
            paleta0[9] = Color.Blue;
            paleta0[10] = Color.Lime;
            paleta0[11] = Color.Silver;
            paleta0[12] = Color.Teal;
            paleta0[13] = Color.Fuchsia;
            paleta0[14] = Color.Yellow;
            paleta0[15] = Color.White;

        }

        public void PaletaOndaNew()
        {
            //RGB(30, 30, 30) => RGB(200, 200, 200)
            int r, g, b;
            for (int i = 0; i < 15; i++)
            {
                //r = (int)(30 + (i * (200 - 30) / 15));
                //g = (int)(30 + (i * (200 - 30) / 15));
                //b = (int)(30 + (i * (200 - 30) / 15));

                r = (int)(-11.33 * i) + 200;
                g = (int)(-11.33 * i) + 200;
                b = (int)(-11.33 * i) + 200;
                paleta0[i] = Color.FromArgb(r, g, b);
            }
        }


        public void GrafOnda(Bitmap pixelVec)
        {
            double x, y, z;
            int color0;

            //ColoresPaleta(); 
            PaletaOndaNew();
            Color c;

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transform(i, j, out x, out y);
                    //Opcion 1
                    //x = x + 6; //Posicion en el punto X
                    //y = y - 0; //Posicion en el punto Y
                    //z = w * (Math.Sqrt((x * x) + (y * y))) - v * t;

                    //Opcion 2
                    z = w * (Math.Sqrt(((x + 4) * (x + 4)) + ((y + 1) * (y + 1))) - v * t);
                    z = m * Math.Sin(z) + 1;
                    color0 = (int)(z * 7.5);  //Se multiplica por 7.5 porque se tiene 15 colores y se lo divide para 2 porque la funcion seno toma valores de -1 a 1
                    c = paleta0[color0];
                    pixelVec.SetPixel(i, j, c);
                }
            }
        }

        public void GrafOnda2(Bitmap pantalla)
        {
            //z corresponde a la onda si se requiere dos o mas ondas entonces se jugara con z1, z2, z3, etc
            double x, y, z1,z2,z;
            int color0;

            //ColoresPaleta(); 
            PaletaOndaNew();
            Color c;

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transform(i, j, out x, out y);
                    //Opcion 1
                    //x = x + 6; //Posicion en el punto X
                    //y = y - 0; //Posicion en el punto Y
                    //z = w * (Math.Sqrt((x * x) + (y * y))) - v * t;

                    //Opcion 2
                    z1 = w * (Math.Sqrt(((x + 4) * (x + 4)) + ((y + 2) * (y + 2))) - v * t);
                    z2 = w * (Math.Sqrt(((x + 4) * (x + 4)) + ((y - 2) * (y - 2))) - v * t);
                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z = z1 + z2;
                    color0 = (int)(z * 3.75); //Al tener dos fuentes el grafico va a tomar valores d 0 - 2 
                    c = paleta0[color0];
                    pantalla.SetPixel(i, j, c);

                }
            }
        }

        public void Interferencia3Ondas(Bitmap pantalla)
        {
            //z corresponde a la onda si se requiere dos o mas ondas entonces se jugara con z1, z2, z3, etc
            double x, y, z1, z2, z, z3;
            int color0;

            ColoresPaleta(); 
            //PaletaOndaNew();
            Color c;

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transform(i, j, out x, out y);
                    //Opcion 1
                    //x = x + 6; //Posicion en el punto X
                    //y = y - 0; //Posicion en el punto Y
                    //z = w * (Math.Sqrt((x * x) + (y * y))) - v * t;

                    //Opcion 2
                    z1 = w * (Math.Sqrt(((x + 4) * (x + 4)) + ((y + 2) * (y + 2))) - v * t);
                    z2 = w * (Math.Sqrt(((x + 4) * (x + 4)) + ((y - 2) * (y - 2))) - v * t);
                    //PARA LOS PUNTOS DEBERAN ESTAR IGUAL EN LA X Y PARA DEMARCAR DICHA POSICION
                    // (+2, 3.55)
                    // craxz z3 = w * (Math.Sqrt(((x - 2) * (x - 2)) + ((y - 3.55) * (y - 3.55))) - v * t);
                    // 1.03, 5.55
                    //z3 = w * (Math.Sqrt(((x - 1.03) * (x - 1.03)) + ((y - 5.55) * (y - 5.55))) - v * t);
                    z3 = w * (Math.Sqrt(((x - 2) * (x - 2)) + ((y - 3.55) * (y - 3.55))) - v * t);
                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;
                    z = z1 + z2+ z3;
                    color0 = (int)(z * 2.5); //Al tener dos fuentes el grafico va a tomar valores d 0 - 2 
                    c = paleta0[color0];
                    pantalla.SetPixel(i, j, c);

                }
            }
        }

        public void ond3D(Bitmap pantalla)
        {
            Vector3D v3D = new Vector3D();
            double l, h, z, d;

            l = -8;
            do
            {
                h = -6;
                do
                {

                    v3D.color0 = Color.Red;

                    v3D.Xo = l ;
                    v3D.Yo = h;
                    z = (Math.Sin(w * (Math.Sqrt((l - 0) * (l - 0) + (h-0) * (h-0)) - v * t))); ;
                    v3D.Zo = 1*Math.Sin(z);
                    v3D.color0 = Color.Black;
                    v3D.Encender(pantalla);

                    h += 0.2;
                } while (h <= 6);
                l += 0.2;
            } while (l <= 7);

        }

        public void Interferencia_onda3D(Bitmap pantalla) 
        {
            Vector3D v3D = new Vector3D();
            double l, h, z1, d1,z2,d2;

            l = -9;
            do
            {
                h = -7;
                do
                {

                    v3D.color0 = Color.Red;

                   
                    // fuente 1 (0,3,0)
                    // fuente 2 (0,-3,0)
                    d1 = (Math.Sin(w * (Math.Sqrt((l - 0) * (l - 0) + (h - 3) * (h - 3)) - v * t)));
                    z1 = 0.4 * Math.Sin(d1);

                    d2 = (Math.Sin(w * (Math.Sqrt((l - 0) * (l - 0) + (h + 3) * (h + 3)) - v * t)));
                    z2 = 0.4 * Math.Sin(d2);



                    v3D.Xo = l;
                    v3D.Yo = h;
                    v3D.Zo = z1+z2;
                    v3D.color0 = Color.Black;
                    v3D.Encender(pantalla);

                    h += 0.2;
                } while (h <= 7);
                l += 0.2;
            } while (l <= 9);
        }


    }
}