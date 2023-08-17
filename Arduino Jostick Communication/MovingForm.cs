using System;
using System.Windows.Forms;

namespace Arduino_Jostick_Communication
{
    public partial class MovingForm : Form
    {
        private int num;
        public string directionX, directionY, offsetX, offsetY;
        public int booldirectionX, booldirectionY, booloffsetX, booloffsetY;

        public MovingForm(int num, string directionX, string directionY, string offsetX, string offsetY)
        {
            InitializeComponent();
            UpdateValues(this.num, directionX, directionY, offsetX, offsetY);
            MoveForm();
            //this.KeyDown += MovingForm_KeyDown;
        }

        internal void MoveForm()
        {
            Console.WriteLine("MovingForm.cs" + this.num + this.directionX + this.directionY + this.offsetX + this.offsetY);
            Console.WriteLine("Debug: booldirectionX: " + booldirectionX);
            Console.WriteLine("Debug: booldirectionY: " + booldirectionY);
            // W, A, S, D, UP, DOWN, LEFT, RIGHT 키에 따라 동작
            switch (this.booldirectionY)
            {
                case 1:
                    this.Left -= this.num;
                    Console.WriteLine("W1");
                    break;

                case 2:
                    this.Left += this.num;
                    Console.WriteLine("S2");
                    break;
            }
            switch (this.booldirectionX)
            {
                case 1:
                    this.Top -= this.num;
                    Console.WriteLine("D3");
                    break;

                case 2:
                    this.Top += this.num;
                    Console.WriteLine("A4");
                    break;
            }
        }

        // 새로운 데이터가 들어올 때마다 호출되어 데이터를 업데이트하는 메서드
        internal void UpdateValues(int num, string directionX, string directionY, string offsetX, string offsetY)
        {
            this.num = num;
            this.directionX = directionX;
            this.directionY = directionY;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            //Console.WriteLine("MovingForm.cs");
            //Console.WriteLine("MovingForm.cs" + this.num + directionX + directionY + offsetX + offsetY);
            //Console.WriteLine("MovingForm.cs"+this.num + this.directionX + this.directionY + this.offsetX + this.offsetY);


            Console.WriteLine($"KarL direction X : {directionX.Trim()}");
            Console.WriteLine($"KarL direction Y : {directionY.Trim()}");

            if (directionX.Equals("S"))
            {
                this.booldirectionX = 2;
                Console.WriteLine("KarL booldirectionX : 2");
            }
            else if (directionX.Equals("W"))
            {
                this.booldirectionX = 1;
                Console.WriteLine("KarL booldirectionX : 1");
            }
            else
            {
                this.booldirectionX = 0;
                Console.WriteLine("KarL booldirectionX : 0");
            }

            if (this.directionY == "D")
            {
                this.booldirectionY = 2;
                //Console.WriteLine("booldirectionY : 2");
            }
            else if (this.directionY == "A")
            {
                this.booldirectionY = 1;
                //Console.WriteLine("booldirectionY : 1");
            }
            else
            {
                this.booldirectionY = 0;
                //Console.WriteLine("booldirectionY : 0");
            }

            Console.WriteLine("Debug: directionX: " + this.directionX);
            Console.WriteLine("Debug: directionY: " + this.directionY);
        }
    }
}
