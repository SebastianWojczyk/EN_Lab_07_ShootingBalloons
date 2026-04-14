using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingBalloons
{
    public partial class Form1 : Form
    {
        List<Circle> balloons = new List<Circle>();
        Timer timerBalloonGenerate;
        Timer timerMoving;
        Random random = new Random();
        Point mouseLocation;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;

            timerBalloonGenerate = new Timer();
            timerBalloonGenerate.Interval = 1000;
            timerBalloonGenerate.Tick += TimerBalloonGenerate_Tick;
            timerBalloonGenerate.Start();

            timerMoving = new Timer();
            timerMoving.Interval = 30;
            timerMoving.Tick += TimerMoving_Tick;
            timerMoving.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
            Invalidate();
        }

        private void TimerMoving_Tick(object sender, EventArgs e)
        {
            foreach (Circle c in balloons)
            {
                c.Move();
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);

            foreach (Circle c in balloons)
            {

                e.Graphics.FillEllipse(Brushes.Green, c.Position.X,
                                                   c.Position.Y,
                                                   c.Size,
                                                   c.Size);
                e.Graphics.DrawEllipse(Pens.Black, c.Position.X,
                                                   c.Position.Y,
                                                   c.Size,
                                                   c.Size);
            }
            e.Graphics.DrawLine(Pens.Black,
                                this.ClientSize.Width/2, 
                                this.ClientSize.Height, 
                                mouseLocation.X, 
                                mouseLocation.Y);
        }

        private void TimerBalloonGenerate_Tick(object sender, EventArgs e)
        {
            bool LeftToRight = random.Next()%2==0 ? true : false;
            int positionX;
            int directionX;
            if(LeftToRight)
            {
                positionX = -50;
                directionX = random.Next(1,3);
            }
            else
            {
                positionX = this.ClientSize.Width;
                directionX = -random.Next(1, 3);
            }

            balloons.Add(new Circle(random.Next(20, 50),
                                    new Point(positionX, random.Next(0, 100)),
                                    new Point(directionX, 0) ));
            Invalidate();
        }
    }
}
