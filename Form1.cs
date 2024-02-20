using Cc6711.Script;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cc6711
{
    public partial class Form1 : Form
    {
        private List<Point> puntos = new List<Point>();

        Bitmap pantalla = new Bitmap(600, 500);
        Color[] paleta = new Color[16];
        Color[] paletaT = new Color[16];
        private Color viewPortBackColor;
        int yp, xp;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseClick += pictureBox1_MouseClick;




            paleta[0] = Color.Black;
            paleta[1] = Color.Navy;
            paleta[2] = Color.Green;
            paleta[3] = Color.Aqua;
            paleta[4] = Color.Red;
            paleta[5] = Color.Purple;
            paleta[6] = Color.FromArgb(132, 60, 11);
            paleta[7] = Color.LightGray;
            paleta[8] = Color.DarkGray;
            paleta[9] = Color.Blue;
            paleta[10] = Color.Lime;
            paleta[11] = Color.Silver;
            paleta[12] = Color.Teal;
            paleta[13] = Color.Fuchsia;
            paleta[14] = Color.Yellow;
            paleta[15] = Color.White;


            paletaT[1] = Color.FromArgb(130, 70, 30);
            paletaT[1] = Color.FromArgb(200, 100, 50);



        }


        private void App_Load(object sender, EventArgs e)
        {
            viewPortBackColor = pictureBox1.BackColor;
            // Add ITems


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AzulVerde(pantalla);
            AzulVerdeGradiente(pantalla);
            pictureBox1.Image = pantalla;
        }

        public static Color[] CrearPaleta()
        {

            // Crea una paleta de colores y devuelve el arreglo
            Color[] paleta = new Color[16];
            paleta[0] = Color.Black;
            paleta[1] = Color.Navy;
            paleta[2] = Color.Green;
            paleta[3] = Color.Aqua;
            paleta[4] = Color.Red;
            paleta[5] = Color.Purple;
            paleta[6] = Color.FromArgb(132, 60, 11);
            paleta[7] = Color.LightGray;
            paleta[8] = Color.DarkGray;
            paleta[9] = Color.Blue;
            paleta[10] = Color.Lime;
            paleta[11] = Color.Silver;
            paleta[12] = Color.Teal;
            paleta[13] = Color.Fuchsia;
            paleta[14] = Color.Yellow;
            paleta[15] = Color.White;


            return paleta;
        }
        public static Bitmap AzulVerdeGradiente(Bitmap bmp)
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    int green = (int)(255 - 0.425 * i);  // Calcular componente verde
                    int blue = (int)(0.425 * i);  // Calcular componente azul

                    bmp.SetPixel(i, j, Color.FromArgb(0, blue, green));
                }

            }
            return bmp;

        }


        public static Bitmap RojoAzul(Bitmap bmp)
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {


                    int black = (int)(((i - 600) / -600) * 255);  // Calcular componente rojo
                    int blue = (int)(255 * (i / 600.0));  // Calcular componente azul

                    bmp.SetPixel(i, j, Color.FromArgb(black, 0, blue));
                }

            }
            return bmp;
        }

        //pintar picturebox entero de azul
        public static Bitmap Azul(Bitmap bmp)
        {

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    bmp.SetPixel(i, j, Color.Blue);
                }

            }

            return bmp;
        }

        public double PerlinNoise(int x, int y)
        {
            int n = x + y * 57;
            n = (n << 13) ^ n;
            return (1.0 - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0);
        }
        public static Bitmap AzulMitadVerde(Bitmap bmp)
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if (i <= 225)
                    {
                        bmp.SetPixel(i, j, Color.Blue);
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.Green);
                    }
                }
            }

            return bmp;
        }

        private void buttonRMP_Click(object sender, EventArgs e)
        {
            RojoAzul(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double x;
            x = -9;
            do
            {
                vector.Xo = x;
                vector.Yo = (2 * x) - 3;

                vector.color0 = Color.Blue;
                vector.Encender(pantalla);

                x = x + 0.02;
            } while (x <= 9);
            pictureBox1.Image = pantalla;
        }

        private void buttonVt_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double x;
            int ha = pantalla.Height / 2;
            x = -2;
            do
            {
                vector.Xo = x;
                vector.Yo = 2 * x - 3;
                vector.color0 = Color.Red;
                vector.Encender(pantalla);
                x = x + 0.02;

            } while (x <= 3);

            x = -5;
            do
            {
                vector.Xo = x;
                vector.Yo = 3;
                vector.color0 = Color.Red;
                vector.Encender(pantalla);
                x = x + 0.02;

            } while (x <= 3);


            pictureBox1.Image = pantalla;



        }

        private void buttonGraficosVectoriales_Click(object sender, EventArgs e)
        {
            /*
            Vector vector = new Vector();
            double t = -10;
            double dt = 0.001;
            double b= 5;
            do
            {
                vector.Xo = t;
                vector.Yo = dt;
                vector.Encender(pantalla);
                pictureBox1.Image= pantalla;
                t = t + dt;
            } while (t<=b);

            */

            Segmento segmento = new Segmento();
            segmento.Xo = -10;
            segmento.Yo = -2;
            segmento.xf = 6;
            segmento.yf = 4;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;


        }

        private void buttonDiagonalVertical_Click(object sender, EventArgs e)
        {
            Segmento segmento = new Segmento();
            segmento.Xo = -10;
            segmento.Yo = -2;
            segmento.xf = 6;
            segmento.yf = 4;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;


            segmento.Xo = 6;
            segmento.Yo = 4;
            segmento.xf = 6;
            segmento.yf = -2;
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;


            segmento.Xo = 6;
            segmento.Yo = -2;
            segmento.xf = 10;
            segmento.yf = 8.33;
            segmento.color0 = Color.Black;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

        }

        private void buttonCircunferencia_Click(object sender, EventArgs e)
        {


            Circunferencia circuference = new Circunferencia();
            circuference.Xo = -2;
            circuference.Yo = -1;
            circuference.Rd = 3;
            circuference.color0 = Color.Black;
            circuference.Encender(pantalla);

            circuference.Xo = 6;
            circuference.Yo = 4;
            circuference.Rd = 1.1;
            circuference.color0 = Color.Green;
            circuference.Encender(pantalla);

            circuference.Xo = -2;
            circuference.Yo = -1;
            circuference.Rd = 1;
            circuference.color0 = Color.Blue;
            circuference.Encender(pantalla);
            pictureBox1.Image = pantalla;



        }

        private void buttonEjes_Click(object sender, EventArgs e)
        {
            //Eje en 2D
            Segmento segmento = new Segmento();
            segmento.Xo = 0;
            segmento.Yo = -8.33;
            segmento.xf = 0;
            segmento.yf = 8.33;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;


            segmento.Xo = 10;
            segmento.Yo = 0;
            segmento.xf = -10;
            segmento.yf = 0;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

            //(0,1)(4,8.33)(10,2)(0,7)








        }

        //realiza un metodo para dibujar los ejes en forma de cruz, guiate en el metodo de arriba

        private void buttonCv_Click(object sender, EventArgs e)
        {
            CurvaV curvaV = new CurvaV();
            curvaV.Xo = 3; curvaV.Yo = -1;
            curvaV.tipo = 0;

            curvaV.color0 = Color.Red;
            curvaV.Rx = 1;
            curvaV.Ry = 1;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;



        }

        private void buttonCv2_Click(object sender, EventArgs e)
        {
            CurvaV curvaV = new CurvaV();
            curvaV.Xo = -3; curvaV.Yo = -1;
            curvaV.tipo = 1;
            curvaV.color0 = Color.Red;
            curvaV.Rx = -2;
            curvaV.Ry = -2;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void buttonCv3_Click(object sender, EventArgs e)
        {
            CurvaV curvaV = new CurvaV();
            curvaV.Xo = 0; curvaV.Yo = 5;
            curvaV.tipo = 2;
            curvaV.color0 = Color.Red;
            curvaV.Rx = 2;
            curvaV.Ry = 2;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void buttonV4_Click(object sender, EventArgs e)
        {
            CurvaV curvaV = new CurvaV();
            curvaV.Xo = 0; curvaV.Yo = -3;
            curvaV.tipo = 3;
            curvaV.color0 = Color.Red;
            curvaV.Rx = 2;
            curvaV.Ry = 2;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;



            curvaV.Xo = 0; curvaV.Yo = 4;
            curvaV.tipo = 3;
            curvaV.color0 = Color.Blue;
            curvaV.Rx = 4;
            curvaV.Ry = 4;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;


            curvaV.Xo = -5; curvaV.Yo = -5;
            curvaV.tipo = 3;
            curvaV.color0 = Color.Black;
            curvaV.Rx = 1;
            curvaV.Ry = 1;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double t = -8, dt = 0.001;
            do
            {
                vector.Xo = t;
                vector.Yo = Math.Pow(2, t);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                vector.Yo = Math.Pow(t, 2) / 5 - 3;
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                vector.Yo = Math.Log(t);
                vector.color0 = Color.Green;
                vector.Encender(pantalla);
                vector.Yo = Math.Cos(t) * 2 + Math.Sin(t);
                vector.color0 = Color.Yellow;
                vector.Encender(pantalla);
                vector.Yo = Math.Pow(t, 3);
                vector.color0 = Color.Purple;
                vector.Encender(pantalla);
                t = t + dt;

            } while (t <= 8);
            pictureBox1.Image = pantalla;



        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double t = -8;
            double dt = 0.001;
            do
            {
                //1ra
                vector.Xo = t;
                vector.Yo = Math.Pow(3, t);
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                //2da
                /*
                vector.Yo = 1+1.098*(t-0);
                vector.color0 = Color.Purple;
                vector.Encender(pantalla);
                //3ra
                vector.Yo = 1+1.098 * (t - 0)+((1.206)*Math.Pow(t - 0,2))/2;
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                */
                //4ta
                vector.Yo = 1 + 1.098 * (t - 0) + ((1.206) * Math.Pow(t - 0, 2) / 2) + ((1.3259) * Math.Pow(t - 0, 3) / 6) + ((1.4567) * Math.Pow(t - 0, 4) / 24);
                vector.color0 = Color.Orange;
                vector.Encender(pantalla);

                t = t + dt;
            } while (t <= 8);
            pictureBox1.Image = pantalla;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double x = -10, dx = 0.002;
            do
            {
                vector.Xo = x;
                vector.Yo = (-0.03 * Math.Pow(x, 2) + 3);
                vector.color0 = Color.Green;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 10);
            pictureBox1.Image = pantalla;

            //xa es un punto de la recta

            double xa = -5;
            double ya = (-0.03 * Math.Pow(xa, 2) + 3);
            double m = (-0.06 * xa);

            Segmento segment = new Segmento();
            segment.Xo = -10;
            segment.Yo = ((m) * (segment.Xo - xa) + ya);
            segment.xf = 10;
            segment.yf = ((m) * (segment.xf - xa) + ya);
            segment.color0 = Color.Blue;
            segment.Encender(pantalla);
            pictureBox1.Image = pantalla;

            xa = 3;
            ya = (-0.03 * Math.Pow(xa, 2) + 3);
            m = (-0.06 * xa);

            Segmento segmento = new Segmento();
            segmento.Xo = -10;
            segmento.Yo = ((m) * (segmento.Xo - xa) + ya);
            segmento.xf = 10;
            segmento.yf = ((m) * (segmento.xf - xa) + ya);
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;


            xa = 2;
            ya = (-0.03 * Math.Pow(xa, 2) + 3);
            m = (-0.06 * xa);


            segmento.Xo = -10;
            segmento.Yo = ((m) * (segmento.Xo - xa) + ya);
            segmento.xf = 10;
            segmento.yf = ((m) * (segmento.xf - xa) + ya);
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;



        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            vector.Apagar(pantalla);
            pictureBox1.Image = pantalla;

        }

        private void buttonP_Click(object sender, EventArgs e)
        {

            /*
            Color[] paleta0 = CrearPaleta();

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Bitmap pantalla = new Bitmap(width, height);
            int colorT;
            Color c;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Ajusta la fórmula para evitar valores demasiado grandes y negativos
                    colorT = (int)( Math.Pow(2, x) +  Math.Pow(2, y)) % 15;


                    c = paleta0[colorT];
                    pantalla.SetPixel(x, y, c);
                }
            }

            pictureBox1.Image = pantalla;

            */

            Color[] paleta0 = new Color[16];
            paleta0[0] = Color.Black;
            paleta0[1] = Color.Navy;
            paleta0[2] = Color.Green;
            paleta0[3] = Color.Aqua;
            paleta0[4] = Color.Red;
            paleta0[5] = Color.Purple;
            paleta0[6] = Color.FromArgb(132, 60, 11);
            paleta0[7] = Color.LightGray;
            paleta0[8] = Color.DarkGray;
            paleta0[9] = Color.Blue;
            paleta0[10] = Color.Lime;
            paleta0[11] = Color.Silver;
            paleta0[12] = Color.Teal;
            paleta0[13] = Color.Fuchsia;
            paleta0[14] = Color.Yellow;
            paleta0[15] = Color.White;

            double colorT;
            Color c;




            for (int x = 0; x < 600; x++)
            {

                for (int y = 0; y < 500; y++)
                {
                    colorT = (Math.Cos(x) + Math.Sqrt(y)) % 15;

                    c = paleta0[(int)colorT];
                    pantalla.SetPixel(x, y, c);
                }
            }


            pictureBox1.Image = pantalla;

        }

        private void buttonPc_Click(object sender, EventArgs e)
        {
            Color[] paleta0 = new Color[16];
            paleta0[0] = Color.Black;
            paleta0[1] = Color.Navy;
            paleta0[2] = Color.Green;
            paleta0[3] = Color.Aqua;
            paleta0[4] = Color.Red;
            paleta0[5] = Color.Purple;
            paleta0[6] = Color.FromArgb(132, 60, 11);
            paleta0[7] = Color.LightGray;
            paleta0[8] = Color.DarkGray;
            paleta0[9] = Color.Blue;
            paleta0[10] = Color.Lime;
            paleta0[11] = Color.Silver;
            paleta0[12] = Color.Teal;
            paleta0[13] = Color.Fuchsia;
            paleta0[14] = Color.Yellow;
            paleta0[15] = Color.White;

            double colorT;
            Color c;




            for (int x = 0; x < 600; x++)
            {

                for (int y = 0; y < 500; y++)
                {
                    colorT = ((x * x) + (y * y)) % 15;


                    c = paleta0[(int)colorT];
                    pantalla.SetPixel(x, y, c);
                }
            }


            pictureBox1.Image = pantalla;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color[] nuevaPaleta = new Color[16];
            nuevaPaleta[0] = Color.DarkSlateGray;
            nuevaPaleta[1] = Color.MediumPurple;
            nuevaPaleta[2] = Color.ForestGreen;
            nuevaPaleta[3] = Color.Cyan;
            nuevaPaleta[4] = Color.IndianRed;
            nuevaPaleta[5] = Color.Orchid;
            nuevaPaleta[6] = Color.FromArgb(255, 128, 0);
            nuevaPaleta[7] = Color.SlateGray;
            nuevaPaleta[8] = Color.Gray;
            nuevaPaleta[9] = Color.SteelBlue;
            nuevaPaleta[10] = Color.Chartreuse;
            nuevaPaleta[11] = Color.LightSlateGray;
            nuevaPaleta[12] = Color.DarkCyan;
            nuevaPaleta[13] = Color.Magenta;
            nuevaPaleta[14] = Color.Gold;
            nuevaPaleta[15] = Color.Azure;
            double colorT;
            Color c;




            for (int x = 0; x < 600; x++)
            {

                for (int y = 0; y < 500; y++)
                {
                    colorT = (Math.Cos(x * 2) + Math.Sqrt(x)) % 15;


                    c = nuevaPaleta[(int)colorT];
                    pantalla.SetPixel(x, y, c);
                }
            }


            pictureBox1.Image = pantalla;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Color[] nuevaPaleta = new Color[16];
            nuevaPaleta[0] = Color.DarkSlateGray;
            nuevaPaleta[1] = Color.MediumPurple;
            nuevaPaleta[2] = Color.ForestGreen;
            nuevaPaleta[3] = Color.Cyan;
            nuevaPaleta[4] = Color.IndianRed;
            nuevaPaleta[5] = Color.Orchid;
            nuevaPaleta[6] = Color.FromArgb(255, 128, 0);
            nuevaPaleta[7] = Color.SlateGray;
            nuevaPaleta[8] = Color.Gray;
            nuevaPaleta[9] = Color.SteelBlue;
            nuevaPaleta[10] = Color.Chartreuse;
            nuevaPaleta[11] = Color.LightSlateGray;
            nuevaPaleta[12] = Color.DarkCyan;
            nuevaPaleta[13] = Color.Magenta;
            nuevaPaleta[14] = Color.Gold;
            nuevaPaleta[15] = Color.Azure;
            double colorT;
            Color c;

            for (int x = 0; x < 600; x++)
            {

                for (int y = 0; y < 500; y++)
                {
                    colorT = ((x * x) + (y * y)) % 15;


                    c = nuevaPaleta[(int)colorT];
                    pantalla.SetPixel(x, y, c);
                }
            }


            pictureBox1.Image = pantalla;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i, j, colorm;
            if (comboBox1.Text == "Paleta 1")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        // Fórmula mejorada para crear mosaicos
                        colorm = (int)((i / 5) + (Math.Cos(j))) % 15;
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }
            }

            if (comboBox1.Text == "Paleta 2")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        colorm = (int)(Math.Cos(i) + Math.Sqrt(j)) % 15;
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }

            }
            if (comboBox1.Text == "Paleta 3")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        colorm = (int)(int)(Math.Tanh(i) + Math.Sqrt(j * 12) * Math.PI) % 12;
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }

            }

            if (comboBox1.Text == "Paleta 4")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        colorm = (int)((1 + Math.Abs((Math.Cos(j * 6) + Math.Sqrt(i * 6))))) % 10;
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }

            }

            if (comboBox1.Text == "Paleta 5")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        colorm = (int)((int)((7 + (Math.Cos(j * 6) + Math.Sqrt(i * 6))) + Math.Sqrt(j * 8)) % 3);
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }

            }

            if (comboBox1.Text == "Paleta 6")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        colorm = (int)(100 + Math.Cos(i * j) / 2 + Math.Sqrt(i) / 8) % 2;
                        pantalla.SetPixel(i, j, paleta[colorm]);
                        pictureBox1.Image = pantalla;

                    }
                }

            }

            if (comboBox1.Text == "Paleta 7")
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {

                        if ((i + 7 * j * 5) % 2 == 0)
                        {

                            colorm = (int)(((Math.Sqrt(i * (j * j) / 12)) + Math.Cos((i * i * 2) * j)) % 2);
                            pantalla.SetPixel(i, j, paleta[colorm]);
                            pictureBox1.Image = pantalla;
                        }


                    }

                }

            }

            if (comboBox1.Text == "Paleta 8")
            {

                for (i = 0; i <= 15; i++)
                {
                    paletaT[i] = Color.FromArgb((int)(4.66 * i + 130), (int)(2 * i + 70), (int)(1.333 * i + 30));


                }

                int colorT;
                Color c;
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {
                        //colorT = (int)(Math.Pow(i, 2) - Math.Pow(j, 2)) % paleta1.Length;

                        colorT = (int)((Math.Sqrt(i + 50.5) + Math.Cos(i) + 10 * j) / 2.3) % 15;
                        if (colorT < 0)
                        {
                            colorT += paletaT.Length;
                        }
                        //Console.WriteLine(colorT);
                        c = paletaT[colorT];
                        pantalla.SetPixel(i, j, c);
                    }
                }
                pictureBox1.Image = pantalla;


            }

            if (comboBox1.Text == "Madera")
            {
                for (i = 0; i < 16; i++)
                {
                    paleta[i] = Color.FromArgb((int)-3 * i + 193, (int)-2.87 * i + 154, (int)-3.73 * i + 107);
                }
                double conts = -0.5;
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {
                        conts = conts - 0.0001;
                        int colorT = (int)(Math.Abs(Math.Sin(i / conts) * Math.Sin(j * 0.7 / conts)) * 200) % 15;
                        Color c = paleta[colorT];
                        pantalla.SetPixel(i, j, c);
                    }
                }
                pictureBox1.Image = pantalla;


            }
            if (comboBox1.Text == "Tela Jean")
            {
                for (i = 0; i < 15; i++)
                {
                    paleta[i] = Color.FromArgb(Convert.ToInt32(-6.93 * i + 124),
                      Convert.ToInt32(-9.06 * i + 170), Convert.ToInt32(-8.26 * i + 198));
                }

                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {
                        double value = PerlinNoise(i, j);

                        // Escala y ajusta el valor para que esté en el rango de colores
                        int colorT = (int)((value + 1.0) * 7.5) % 15;
                        Color c = paleta[colorT];
                        pantalla.SetPixel(i, j, c);
                        pictureBox1.Image = pantalla;
                    }
                }


            }

            if (comboBox1.Text == "Cesped")
            {
                Color c;
                Color[] paleteC = new Color[16];

                for (i = 0; i <= 15; i++)
                {
                    int r = (int)(0 + (i * (0 - 0)) / 15);
                    int g = (int)(200 + (i * (100 - 200)) / 15);
                    int b = (int)(0 + (i * (0 - 0)) / 15);
                    paleteC[i] = Color.FromArgb(r, g, b);
                }

                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 500; j++)
                    {
                        int colorT = (int)(Math.Sin(i * 10) * Math.Sqrt(j * i)) % 15;
                        if (colorT < 0 || colorT > 15)
                        {
                            c = paleteC[0];
                            pantalla.SetPixel(i, j, c);
                            continue;
                        }
                        c = paleteC[colorT];
                        pantalla.SetPixel(i, j, c);
                    }

                }
                pictureBox1.Image = pantalla;
            }

            if (comboBox1.Text == "Fuego")
            {
                Color[] paleta0 = new Color[16];
                for (int x = 0; x < 15; x++)
                {
                    paleta0[x] = Color.FromArgb((int)((x * 255) / 15), (int)(x * 0 / 15), (int)(x * 0 / 15));
                }

                int width = 600, height = 500;

                Bitmap bmp = new Bitmap(width, height);
                double colorT;
                Color c;
                for (double x = 1; x < 600; x++)
                {
                    for (double y = 1; y < 500; y++)
                    {

                        colorT = ((((255 - x - 1) * (255 - x - 1)) / (int)Math.PI) + ((550 - y - 1) / 3)) % 15;
                        c = paleta0[(int)colorT];

                        pantalla.SetPixel((int)x, (int)y, c);

                    }
                }
                pictureBox1.Image = pantalla;
            }


        }

        private async void buttonSc_Click(object sender, EventArgs e)
        {
            CurvaV curvaV = new CurvaV();
            curvaV.Xo = -4;
            curvaV.Yo = -2;
            curvaV.tipo = 1;
            curvaV.Rx = 1;
            curvaV.Ry = 1;
            curvaV.color0 = Color.Black;
            curvaV.Encender(pantalla);
            pictureBox1.Image = pantalla;



            CurvaV curvaV1 = new CurvaV();
            curvaV1.Xo = 4;
            curvaV1.Yo = 2;
            curvaV1.tipo = 1;
            curvaV1.Rx = 1;
            curvaV1.Ry = 1;
            curvaV1.color0 = Color.Blue;
            curvaV1.Encender(pantalla);
            pictureBox1.Image = pantalla;

            System.Windows.Forms.Application.DoEvents();

            Thread.Sleep(20);
            curvaV1.Apagar(pantalla);



            curvaV1.Xo = 4;
            curvaV1.Yo = 2;
            curvaV1.tipo = 1;
            curvaV1.Rx = 1;
            curvaV1.Ry = 1;
            curvaV1.color0 = Color.Blue;
            curvaV1.Encender(pantalla);
            Thread.Sleep(2000);
            pictureBox1.Image = pantalla;
            System.Windows.Forms.Application.DoEvents();
            await Task.Delay(30);
            //limpiar





        }

        private void buttonParac_Click(object sender, EventArgs e)
        {
            // Fase 1 para crear parabola 
            Vector vector = new Vector();
            vector.color0 = Color.Blue;
            double dt = 0.0001;
            double t = -8;


            do
            {
                vector.Xo = t;
                vector.Yo = -((t + 8) * (t + 2)) / 2.25;

                vector.Encender(pantalla);
                t = t + dt;
            } while (t <= -2);
            pictureBox1.Image = pantalla;

            //Fase 2 segunda parabola
            Vector vector1 = new Vector();
            vector1.color0 = Color.Black;
            dt = 0.0001;
            t = -2;


            do
            {
                vector1.Xo = t;
                vector1.Yo = -((t + 2) * (t - 2)) / 1.33;

                vector1.Encender(pantalla);
                t = t + dt;
            } while (t <= 2);
            pictureBox1.Image = pantalla;

            //fase 3 tercera parabola

            Vector vector2 = new Vector();
            vector2.color0 = Color.Purple;
            dt = 0.0001;
            t = 2;


            do
            {
                vector2.Xo = t;
                vector2.Yo = -((t - 2) * (t - 6)) / 2.33;

                vector2.Encender(pantalla);
                t = t + dt;
            } while (t <= 6);
            pictureBox1.Image = pantalla;

            // fase de animacion de cirvunferencia en las parabolas

            //1ra circunferencia en la parabola 1
            Circunferencia circunferencia = new Circunferencia();

            dt = 0.2;
            t = -8;
            circunferencia.Rd = 0.25;
            do
            {
                circunferencia.Xo = t;
                circunferencia.color0 = Color.Purple;
                circunferencia.Yo = -((t + 8) * (t + 2)) / 2.25;
                circunferencia.Encender(pantalla);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(20);

                pictureBox1.Image = pantalla;
                circunferencia.ApagarAnimacion(pantalla);



                t = t + dt;
            } while (t <= -2);

            //2ra circunferencia en la parabola 1
            Circunferencia circunferencia1 = new Circunferencia();

            dt = 0.2;
            t = -2;
            circunferencia1.Rd = 0.25;
            do
            {
                circunferencia1.Xo = t;
                circunferencia1.color0 = Color.Purple;
                circunferencia1.Yo = -((t + 2) * (t - 2)) / 1.33;
                circunferencia1.Encender(pantalla);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(20);
                pictureBox1.Image = pantalla;

                circunferencia1.ApagarAnimacion(pantalla);

                t = t + dt;
            } while (t <= 2);
            pictureBox1.Image = pantalla;


            //1ra circunferencia en la parabola 2
            Circunferencia circunferencia2 = new Circunferencia();

            dt = 0.2;
            t = 2;
            circunferencia2.Rd = 0.25;
            do
            {
                circunferencia2.Xo = t;

                circunferencia2.Yo = -((t - 2) * (t - 6)) / 2.33;
                circunferencia2.color0 = Color.Purple;
                circunferencia2.Encender(pantalla);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(20);

                pictureBox1.Image = pantalla;
                circunferencia2.ApagarAnimacion(pantalla);

                t = t + dt;
            } while (t < 6);


        }

        private void buttonRrecta_Click(object sender, EventArgs e)
        {
            Segmento segmento = new Segmento();
            segmento.Xo = 1;
            segmento.Yo = 1;
            segmento.xf = -3;
            segmento.yf = 8.33;
            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

            segmento.Xo = -10;
            segmento.Yo = -2.48;

            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void buttonRfPractica_Click(object sender, EventArgs e)
        {
            Segmento segmento = new Segmento();
            segmento.Xo = 1;
            segmento.Yo = 1;
            segmento.xf = -10;
            segmento.yf = -7;
            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

            segmento.Xo = -10;
            segmento.Yo = -7.2;

            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //parabola
            /*
            Vector vector = new Vector();
            double x = -10, dx = 0.002;
            do
            {
                vector.Xo = x;
                vector.Yo = (-0.03 * Math.Pow(x, 2) + 3);
                vector.color0 = Color.Green;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 10);
            pictureBox1.Image = pantalla;

            // Ejes 
            Segmento segmento = new Segmento();
            segmento.Xo = 0;
            segmento.Yo = -8.33;
            segmento.xf = 0;
            segmento.yf = 8.33;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

            segmento.Xo = 10;
            segmento.Yo = 0;
            segmento.xf = -10;
            segmento.yf = 0;
            segmento.color0 = Color.Red;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
            */







        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Curvas de nivel
            Vector vector = new Vector();
            double x, dx;
            x = -8;
            dx = 0.0002;
            do
            {
                vector.Xo = x;
                vector.Yo = 3 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;

            //2da
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = 6 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;

            //3ra
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = 8 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;
            //4ta
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = -4 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;
            //5ta
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = -7 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Black;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;

            //6ta
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = 2.23 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;

            //7ma
            x = -8;
            dx = 0.0002;

            do
            {
                vector.Xo = x;
                vector.Yo = -3.222 * Math.Pow(Math.E, -4 * x);
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                x += dx;
            } while (x <= 8);

            pictureBox1.Image = pantalla;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordenadas = me.Location;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.FillEllipse(Brushes.Red, coordenadas.X - 5, coordenadas.Y - 5, 10, 10);
            }

            puntos.Add(coordenadas);

        }

        private void button7_Click(object sender, EventArgs e)
        {



            using (Graphics g = Graphics.FromImage(pantalla))
            {
                using (Pen pen = new Pen(Color.Blue))
                {
                    if (puntos.Count == 2)
                    {
                        g.DrawLines(pen, puntos.ToArray());
                    }
                    else if (puntos.Count == 3)
                    {
                        DibujarCurvaDeCasteljau(g, pen, puntos[0], puntos[1], puntos[2]);

                    }
                    else if (puntos.Count == 4)
                    {
                        g.DrawBeziers(pen, puntos.ToArray());
                    }
                }
            }

            pictureBox1.Image = pantalla;


        }

        private void buttonTestPractice_Click(object sender, EventArgs e)
        {
            Vector vector = new Vector();
            double t = -2, dt = 0.001;

            do
            {
                vector.Xo = t;
                vector.Yo = Math.Log(t + 8);
                vector.color0 = Color.Blue;
                vector.Encender(pantalla);
                vector.Yo = Math.Log(10) + 1 / 10 * (t - 2) - 1 / 200 * (Math.Pow(t - 2, 2));
                vector.color0 = Color.Blue;



                vector.Encender(pantalla);
                t = t + dt;
            } while (t <= 8);
            pictureBox1.Image = pantalla;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Segmento segmento = new Segmento();
            segmento.Xo = -1;
            segmento.Yo = 0;
            segmento.xf = -3;
            segmento.yf = 8.33;
            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
            //
            segmento.Xo = -3;
            segmento.Yo = 8.33;
            segmento.Xo = -7;
            segmento.Yo = -8.33;
            //-10; 1,69
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;

            ///asnimacion
            ///







        }

        static double modeloEnfermedad(double t, double y, double k, double M)
        {
            return k * y * (M - y);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Vector3D vector3D = new Vector3D();
            double z, t;

            t = 0;
            do
            {
                vector3D.Xo = t / 3 - 2;
                vector3D.Yo = 1 + 3 * Math.Sin(t);
                vector3D.Zo = 2 + 3 * Math.Cos(t);
                vector3D.color0 = Color.Blue;
                vector3D.Encender(pantalla);
                t = t + 0.001;
            } while (t <= 15);
            pictureBox1.Image = pantalla;

        }

        //SUPERFICIES VECTORIALES
        private void button10_Click(object sender, EventArgs e)
        {
            Vector3D vector3D = new Vector3D();
            double t, dt, h, dh;
            t = 0;
            h = 0;
            dt = 0.1;
            dh = 0.2;
            do
            {
                do
                {
                    //el valor de 1 le da la posicion de la figura
                    vector3D.Xo = 5 + 2 * Math.Cos(t);
                    vector3D.Yo = 0 + 3 * Math.Sin(t);
                    vector3D.Zo = -2 + (h / 3);
                    vector3D.color0 = Color.Black;
                    vector3D.Encender(pantalla);
                    h += dh;
                } while (h <= 9);
                h = 0;
                t += dt;
            } while (t <= 6.3);
            pictureBox1.Image = pantalla;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //SUPERFICIE 2
            Vector3D vector3D = new Vector3D();
            double t, dt, h, dh, rd;
            t = -(Math.PI) / 2;

            h = 0;
            dt = 0.1;
            dh = 0.2;
            rd = 2;
            do
            {
                h = 0;
                do
                {
                    //el valor de 1 le da la posicion de la figura
                    vector3D.Xo = -2 + rd * Math.Cos(t) * Math.Cos(h);
                    vector3D.Yo = -2 + rd * Math.Cos(t) * Math.Sin(h);
                    vector3D.Zo = -2 + rd * Math.Sin(t);
                    vector3D.color0 = Color.Blue;
                    vector3D.Encender(pantalla);
                    h += dh;
                } while (h <= 2 * Math.PI);

                t += dt;
            } while (t <= Math.PI / 2);
            pictureBox1.Image = pantalla;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //SUPERFICE 3
            Vector3D vector3D = new Vector3D();
            double t, dt, h, dh, rd, ps;
            t = 0;
            h = 0;
            dt = 0.1;
            dh = 0.2;
            rd = 0.75;
            ps = 3;
            do
            {
                h = 0;
                do
                {
                    //el valor de 1 le da la posicion de la figura
                    vector3D.Xo = rd * (4 + Math.Cos(t)) * Math.Cos(h) + ps;

                    vector3D.Yo = rd * (3.5 + Math.Cos(t)) * Math.Sin(h) + 2;

                    vector3D.Zo = rd * Math.Sin(t) + 5;

                    vector3D.color0 = Color.Red;
                    vector3D.Encender(pantalla);
                    h += dh;
                } while (h <= 2 * Math.PI);

                t += dt;
            } while (t <= 2 * Math.PI);
            pictureBox1.Image = pantalla;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Segmento segmento = new Segmento();
            segmento.Xo = -1;
            segmento.Yo = 0;
            segmento.xf = -2;
            segmento.yf = -8.33;
            segmento.color0 = Color.Gray;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
            //
            segmento.Xo = -4.01;
            segmento.Yo = 8.33;
            // segmento.xf = -3.44;
            // segmento.yf = -8.33;

            //-10; 1,69
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button14_Click(object sender, EventArgs e)
        {


        }

        private void button15_Click(object sender, EventArgs e)
        {



            double h = 2, ht;
            Segmento segmento = new Segmento();
            for (ht = 2; ht <= 8.33; ht++)
            {
                h += ht;
                segmento.Xo = -10;
                segmento.Yo = h * -1;
                segmento.xf = 10;
                segmento.yf = h * -1;
                segmento.color0 = Color.Blue;
                segmento.Encender(pantalla);
                pictureBox1.Image = pantalla;
            }

            segmento.Xo = -10;
            segmento.Yo = -2;
            segmento.xf = 10;
            segmento.yf = -2;
            segmento.color0 = Color.Blue;
            segmento.Encender(pantalla);



            /////////////////





            double d = 0;
            double d1 = 0;

            do
            {

                segmento.Xo = -5 * d;
                segmento.Yo = -2;
                segmento.xf = -8.3 * d1;
                segmento.yf = -8.33;
                segmento.color0 = Color.Blue;
                segmento.Encender(pantalla);
                d += 0.2;
                d1 += 0.5;



            } while (d < 8.33 && d1 <8.33);
            pictureBox1.Image = pantalla;

            d = 0;
            d1 = 0;


            do
            {

                segmento.Xo = 5 * d;
                segmento.Yo = -2;
                segmento.xf = 8.3 * d1;
                segmento.yf = -8.33;
                segmento.color0 = Color.Blue;
                segmento.Encender(pantalla);
                d += 0.2;
                d1 += 0.5;



            } while (d < 8.33 && d1 < 8.33);
            pictureBox1.Image = pantalla;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.GrafOnda(pantalla); 
            pictureBox1.Image = pantalla;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.GrafOnda2(pantalla);
            pictureBox1.Image = pantalla;
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo
            double t = 0;
            //maneja la posicion de la onda 
            do
            {
                //arreglar
                onda.GrafOnda2(pantalla);
                t += 0.1;
                onda.t = t;
                System.Windows.Forms.Application.DoEvents();
                //await Task.Delay(100);
                pictureBox1.Image = pantalla;
                

                
                

            } while (onda.t <= 2*Math.PI);
          
        
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.Interferencia3Ondas(pantalla);
            pictureBox1.Image = pantalla;
        }




        private void button20_Click_1(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 
            do
            {
                onda.Interferencia3Ondas(pantalla);
                onda.t += 0.1;
                System.Windows.Forms.Application.DoEvents();
                pictureBox1.Image = pantalla;
            } while (onda.t <= 2 * Math.PI);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 2;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 0;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.ond3D(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Vector3D vector3D = new Vector3D();
            double l = -8;
            double h;
            double z;
            double w = 2;
            double v = 9.3;
            double t = 0;
            do
            {
                h = -6;
                do
                {
                    vector3D.Xo = l;
                    vector3D.Yo = h;
                    z = (w * (Math.Sqrt(Math.Pow((l - (0)), 2) + Math.Pow((h - (0)), 2)))) - t * v;
                    vector3D.Zo = (0.6) * Math.Sin(z) + 2.0;  // Ajusta el valor (+2.0) según tus necesidades

                    vector3D.color0 = Color.Black;
                    vector3D.Encender(pantalla);
                    pictureBox1.Image = pantalla;
                    h = h + 0.2;
                } while (h <= 6);
                l = l + 0.2;
            } while (l <= 8);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 2;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 0;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.Interferencia_onda3D(pantalla);
           
            System.Windows.Forms.Application.DoEvents();
            pictureBox1.Image = pantalla;
  
        }

        private async void button24_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 2;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 0.7;    // Altura máxima
           // onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 
            double t = 0.02, dt =0;
            do {

                onda.color0 = Color.LightSkyBlue;
                onda.Interferencia_onda3D(pantalla);
                await Task.Delay(40);

                onda.color0 = Color.White;
                onda.Interferencia_onda3D(pantalla);
                pictureBox1.Image = pantalla;

                onda.t = dt;
                dt += t;
                
            } while (t <= 1.80);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.GrafOndaIn2D(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Onda onda = new Onda();
            onda.w = 1.5;  // Parametro que determina la longitud de onda
            onda.v = 9.3;  // Velocidad de proporcion 
            onda.m = 1;    // Altura máxima
            onda.t = 0;    // Tiempo

            //maneja la posicion de la onda 

            onda.GrafOndaIn3D(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();
            cuerdaVibrante.color0 = Color.Green;
            cuerdaVibrante.t = 1.30;
            cuerdaVibrante.cuerdaVibrante2D(pantalla);
            pictureBox1.Image = pantalla;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();
            
            double t = 2.5;

            do {
                cuerdaVibrante.t = t;
                cuerdaVibrante.color0 = Color.Black;
                cuerdaVibrante.cuerdaVibrantepRUEBA(pantalla);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(15);

                cuerdaVibrante.Apagar(pantalla);
                cuerdaVibrante.color0 = viewPortBackColor;
                cuerdaVibrante.color0 = viewPortBackColor;
                pictureBox1.Image = pantalla;
                t += 0.05;
                if (t>= 20)
                {
                    t = 0;
                }

            } while (true);
            
            
        }



        private void button29_Click(object sender, EventArgs e)
        {
            double h = 1.0;
            double t0 = 0.0;
            double y0 = 1.0;

            double tn = 20.0;

            RungeKutta((t, y) => 0.001 * (500 - t) * y, h, t0, y0, tn);

            Console.ReadLine();

        }

        private void DibujarCurvaDeCasteljau(Graphics g, Pen pen, Point p0, Point p1, Point p2)
        {
            // Parámetro t que varía entre 0 y 1
            for (double t = 0; t <= 1; t += 0.01)
            {
                // Puntos intermedios utilizando el algoritmo de De Casteljau
                double x01 = (1 - t) * p0.X + t * p1.X;
                double y01 = (1 - t) * p0.Y + t * p1.Y;

                double x12 = (1 - t) * p1.X + t * p2.X;
                double y12 = (1 - t) * p1.Y + t * p2.Y;

                double x = (1 - t) * x01 + t * x12;
                double y = (1 - t) * y01 + t * y12;

                // Dibujar un pequeño segmento de la curva
                g.DrawEllipse(pen, (float)x, (float)y, 1, 1);
            }
        }


        // Nuevo método que contiene la simulación
        static void RungeKutta(Func<double, double, double> function, double h, double t0, double y0, double tn)
        {
            double t = t0;
            double y = y0;

            while (t <= tn)
            {
                Console.WriteLine($"t = {t}, y = {y}");

                double k1 = h * function(t, y);
                double k2 = h * function(t + h / 2, y + k1 / 2);
                double k3 = h * function(t + h / 2, y + k2 / 2);
                double k4 = h * function(t + h, y + k3);

                y = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                t = t + h;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {

            CuerdaVibrante cuerdaVibrante = new CuerdaVibrante();

            double t = 0;

            do
            {
                cuerdaVibrante.t = 0;
                cuerdaVibrante.color0 = Color.Green;
                cuerdaVibrante.cuerdaVibrantepRUEBA(pantalla);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(15);

                cuerdaVibrante.Apagar(pantalla);
                cuerdaVibrante.color0 = viewPortBackColor;
                cuerdaVibrante.color0 = viewPortBackColor;
                pictureBox1.Image = pantalla;
                t += 0.005;
                if (t >= 20)
                {
                    t = 0;
                }

            } while (true);



        }

        // bRungeKutta metodo
        private void button31_Click(object sender, EventArgs e)
        {
            dgRungeKutta.Columns.Clear();
            dgRungeKutta.Rows.Clear();
            dgRungeKutta.RowHeadersVisible = false;

            chart1.Series["Solución numérica"].Points.Clear();

            dgRungeKutta.Columns.Add("Tiempo", "Tiempo");
            dgRungeKutta.Columns.Add("Enfermos", "Enfermos");

            dgRungeKutta.Columns["Tiempo"].Width = 65;
            dgRungeKutta.Columns["Enfermos"].Width = 95;
            dgRungeKutta.Columns["Tiempo"].ReadOnly = true;
            dgRungeKutta.Columns["Enfermos"].ReadOnly = true;
            dgRungeKutta.Columns["Tiempo"].DefaultCellStyle.BackColor = Color.LightGray;

            double t0 = 0, y0 = 1, tf = 20, k = 0.001, h = 1, k1, k2, k3, k4;
            int m = 500;

            do
            {
                k1 = h * modeloEnfermedad(t0, y0, k, m);
                k2 = h * modeloEnfermedad(t0 + h / 2, y0 + k1 / 2, k, m);
                k3 = h * modeloEnfermedad(t0 + h / 2, y0 + k2 / 2, k, m);
                k4 = h * modeloEnfermedad(t0 + h, y0 + k3, k, m);

                y0 += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                t0 += h;

                y0 = Math.Round(y0, 5);
                dgRungeKutta.Rows.Add(t0, y0);
                chart1.Series["Solución numérica"].Points.AddXY(t0, y0);
            } while (t0 < tf);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            dgPandemia.Columns.Clear();
            dgPandemia.Rows.Clear();
            dgPandemia.RowHeadersVisible = false;

            chart1.Series["Solución analítica"].Points.Clear();

            dgPandemia.Columns.Add("Tiempo", "Tiempo");
            dgPandemia.Columns.Add("Enfermos", "Enfermos");

            dgPandemia.Columns["Tiempo"].Width = 65;
            dgPandemia.Columns["Enfermos"].Width = 95;
            dgPandemia.Columns["Tiempo"].ReadOnly = true;
            dgPandemia.Columns["Enfermos"].ReadOnly = true;
            dgPandemia.Columns["Tiempo"].DefaultCellStyle.BackColor = Color.LightCyan;

            int m = 500;
            double k = 0.001, h = 1, y;
            double t = 1, tf = 20;
            do
            {
                y = m / (1 + (m - k / k) * Math.Pow(Math.E, -m * k * t));

                y = Math.Round(y, 5);
                dgPandemia.Rows.Add(t, y);
                chart1.Series["Solución analítica"].Points.AddXY(t, y);
                t += h;

            } while (t <= tf);
        }


        // Función diferencial
        private static double Function(double t, double y, double k, double M)
        {
            return k * y * (M - y);
        }








    }



}












/*
if (comboBox1.Text == "PALETAS")
{
    for (i = 0; i < 200; i++)
    {
        for (j = 0; j < 220; j++)
        {

            colorm = (i * i + j * j) % 16;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;


        }
    }
    for (i = 200; i < 400; i++)
    {
        for (j = 0; j < 220; j++)
        {

            colorm = (int)(10 + Math.Cos(i * j)) % 15;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;

        }
    }
    for (i = 400; i < 600; i++)
    {
        for (j = 0; j < 220; j++)
        {

            colorm = (int)(Math.Abs(i / 2 * j) + Math.Sqrt(2 * i)) % 15;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;

        }
    }
    for (i = 0; i < 200; i++)
    {
        for (j = 220; j < 440; j++)
        {

            colorm = (int)((1 + Math.Abs((Math.Cos(j * 6) + Math.Sqrt(i * 6))) + Math.Sqrt(j + i)) + (i * i)) % 16;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;

        }
    }
    for (i = 200; i < 400; i++)
    {
        for (j = 220; j < 440; j++)
        {

            colorm = (int)((7 + Math.Abs((Math.Cos(j * 6) + Math.Sqrt(i * 6))) + Math.Sqrt(j + i))) % 15;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;

        }
    }
    for (i = 400; i < 600; i++)
    {
        for (j = 220; j < 440; j++)
        {

            colorm = (int)(100 + Math.Cos(i * j) + Math.Sqrt(3 * i)) % 15;
            lienzo.SetPixel(i, j, paleta0[colorm]);
            VentanaP.Image = lienzo;

        }
    }

}
*/

/*
if (comboBox1.Text == "Piedra")
{
    for (i = 0; i < 600; i++)
    {
        for (j = 0; j < 500; j++)
        {


            colorm = (int)((i * j) * Math.PI) % 15 % 15;
            pantalla.SetPixel(i, j, paleta[colorm]);
            pictureBox1.Image = pantalla;

        }
    }

}

if (comboBox1.Text == "Jean")
{
    for (i = 0; i < 600; i++)
    {
        for (j = 0; j < 500; j++)
        {

            colorm = (int)((1 + Math.Abs((Math.Cos(j * 6) + Math.Sqrt(i * 6))) + Math.Sqrt(j + i)) + (i * i)) % 16;
            pantalla.SetPixel(i, j, paleta[colorm]);
            pictureBox1.Image = pantalla;

        }
    }

}

if (comboBox1.Text == "Cesped")
{
    for (i = 0; i < 600; i++)
    {
        for (j = 0; j < 500; j++)
        {

            colorm = (int)(Math.Abs(i / 2 * j) + Math.Sqrt(2 * i)) % 15;
            pantalla.SetPixel(i, j, paleta[colorm]);
            pictureBox1.Image = pantalla;

        }
    }


}
 */




