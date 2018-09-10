using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        private Bitmap Original_Bitmap;//원본
        private Bitmap Rayleigh_Bitmap;
        private Bitmap Ruffy_Bitmap;
        private Bitmap Shanks_Bitmap;
        private Bitmap Ace_Bitmap;
        private Color color;

        private int[][] input_bitmap = new int[4][];
        public Form1(){
            InitializeComponent();
            Rayleigh_Bitmap = new Bitmap(Image.FromFile("실버즈레일리.jpg"));
            Ruffy_Bitmap = new Bitmap(Image.FromFile("루피.jpg"));
            Shanks_Bitmap = new Bitmap(Image.FromFile("샹크스.jpg"));
            Ace_Bitmap = new Bitmap(Image.FromFile("에이스1.png"));
        }
        private int area(Bitmap setBitmap) {
            return setBitmap.Width * setBitmap.Height;

        }

        private void Form1_Load(object sender, EventArgs e) {
            Binary(Rayleigh_Bitmap);
            Binary(Ruffy_Bitmap);
            Binary(Shanks_Bitmap);
            Binary(Ace_Bitmap);
            int val = area(Rayleigh_Bitmap);
            input_bitmap[0] = new int[val];
            val = area(Ruffy_Bitmap);
            input_bitmap[1] = new int[val];
            val = area(Shanks_Bitmap);
            input_bitmap[2] = new int[val];
            val = area(Ace_Bitmap);
            input_bitmap[3] = new int[val];
          //  Console.WriteLine(val);


            int ss = 0;
            for (int i = 0; i < input_bitmap.Length; i++)
                    for (int x = 0; x < Rayleigh_Bitmap.Width; x++)
                        for (int y = 0; y < Rayleigh_Bitmap.Height; y++){
                            color = Rayleigh_Bitmap.GetPixel(x, y);
                        input_bitmap[i][(x * Rayleigh_Bitmap.Width) + y] =color.R;
                        }
                
            

            Perceptron_init perceptron = new Perceptron_init(input_bitmap);
            pictureBox1.Image = Rayleigh_Bitmap;
            pictureBox2.Image = Ruffy_Bitmap;
            pictureBox3.Image = Shanks_Bitmap;
            pictureBox4.Image = Ace_Bitmap;
        }
        private void Binary(Bitmap Set_Bitmap) {
            int max=0;
            int bright;
            for (int x = 0; x < Set_Bitmap.Width; x++)
                for (int y = 0; y < Set_Bitmap.Height; y++) { 
                    color = Set_Bitmap.GetPixel(x , y );
                    max =max+color.R;
                         }
                max = max / (Set_Bitmap.Width * Set_Bitmap.Height);
                for (int x = 0; x<Set_Bitmap.Width; x++)
                for (int y = 0; y<Set_Bitmap.Height; y++){
                    color = Set_Bitmap.GetPixel(x, y);
                    
                    bright = color.R < max ? 255 : 0;
                    Set_Bitmap.SetPixel(x, y,Color.FromArgb(bright, bright, bright));
                }

}
        

    }
}
