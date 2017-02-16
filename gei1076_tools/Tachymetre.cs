using System;
using System.Drawing;
using System.Windows.Forms;

namespace gei1076_tools
{
    
    public class Tachymetre : Control
    {
        Image image;
        Bitmap bitmap;
        int cx, cy;
        double valeur = 0;

        private const double valeurLimiteMin = 0;
        private const double valeurLimiteMax = 260;


        Pen crayon = new Pen(Color.Red, 3);
        int longueurAiguille = 100;
        double facteurAiguille = 0.75;

        double angle = 360;
        double angleDecalage = 130;
        double angleLimiteMin = 0;
        double angleLimiteMax = 260;


        Font police = new Font("Courrier new", 24f, FontStyle.Bold);

        public double Valeur
        {
            get
            {
                return valeur;
            }
            set
            {
                valeur = value;

                if (valeur > valeurLimiteMax) valeur = valeurLimiteMax;
                if (valeur < valeurLimiteMin) valeur = valeurLimiteMin;

                angle = (valeur - valeurLimiteMin) * (angleLimiteMax - angleLimiteMin) / (valeurLimiteMax - valeurLimiteMin);
                angle = ((360 - angle) + angleDecalage) * Math.PI / 180;

                base.Refresh();
            }
        }

        public double ValeurLimiteMax
        {
            get
            {
                return valeurLimiteMax;
            }
        }

        public double ValeurLimiteMin
        {
            get
            {
                return valeurLimiteMin;
            }
        }

        public Tachymetre()
        {
            Valeur = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float fx = (float)(cx - Math.Sin(angle) * longueurAiguille);
            float fy = (float)(cy - Math.Cos(angle) * longueurAiguille);

            string chaine = valeur.ToString();
            SizeF sf = e.Graphics.MeasureString(chaine, police);

            e.Graphics.DrawLine(crayon, cx, cy, fx, fy);
            e.Graphics.DrawString(chaine, police, Brushes.Red, cx - sf.Width / 2, (float)(Height * 0.65));
            
        }

        protected override void OnResize(EventArgs e)
        {

            

            Width = Height = Math.Max(Width, Height);
            
            image =  images.speedometer;
            
            bitmap = new Bitmap(image, new Size (Width, Height));

            BackgroundImage = bitmap;

            DoubleBuffered = true;

            cx = Width / 2;
            cy = Height / 2;

            longueurAiguille = (int)( Width / 2 * facteurAiguille);

            police = new Font("Courrier new", Height * 0.05f, FontStyle.Bold);

            base.OnResize(e);

        }

        public override void Refresh()
        {
            base.Refresh();
        }
    }
}
