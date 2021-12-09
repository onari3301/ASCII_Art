using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ASCII_Art
{
    internal class Program
    {
        //public static Image resizeImage(Image image, int width, int height)
        //{
        //    var destinationRect = new Rectangle(0, 0, width, height);
        //    var destinationImage = new Bitmap(width, height);

        //    destinationImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    using (var graphics = Graphics.FromImage(destinationImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(image, destinationRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    return (Image)destinationImage;
        //}

        [STAThread]
        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\source\repos\ASCII_Art\ASCII_Art\bin\Debug\60576733_p0.png";

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = @"C:\\";
            //    openFileDialog.Filter = "Image Files|*.jpg; *jpeg; *png;";
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        path = openFileDialog.FileName;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            Bitmap img = new Bitmap(path);


            //Bitmap img = new Bitmap(resizeImage(image,50,50));

            Console.WriteLine(img.Width + "x" + img.Height);

            string ascii_map = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
            string ascii_map_inverted = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~i!lI;:,'\\^`";

            Color[,] argb = new Color[img.Width, img.Height];
            int[,] brightness = new int[img.Width, img.Height];

            int red, green, blue, value, index;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    argb[x, y] = img.GetPixel(x, y);
                    //Console.WriteLine(x + "x" + y);
                }
            }

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    red = argb[x, y].R;
                    green = argb[x, y].G;
                    blue = argb[x, y].B;

                    brightness[x, y] = (red + green + blue) / 3;
                }
            }

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    value = brightness[x, y];
                    index = (int)Math.Floor(value / 3.95);

                    if (x == img.Width - 1)
                    {
                        Console.Write(ascii_map[index]);
                        Console.WriteLine(ascii_map[index]);
                    }
                    else
                    {
                        Console.Write(ascii_map[index]);
                        Console.Write(ascii_map[index]);
                    }
                }
            }

            Console.Write("Press enter to close...");
            Console.ReadLine();
        }
    }
}
