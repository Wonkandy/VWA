using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNISTNeuralNetwork
{
    static class Helper
    {

        // ---------------------------------------------------------------------------------------
        /// <summary>
        /// Reads data from a MNIST file into the arrays inputs and targets
        /// </summary>
        /// <param name="filename">MNIST data file</param>
        /// <param name="inputs">array, for storing the neural network input data</param>
        /// <param name="targets">array, for storing the correspondig training target values</param>
        /// <returns>status message</returns>

        public static string ReadData(string filename, out double[][] inputs, out double[][] targets)
        {
            // Datensätze zeilenweise einlesen:
            string[] allLines;
            string[] line;
            try
            {
                allLines = File.ReadAllLines(filename);
                int numLines = allLines.Length;
                line = allLines[0].Split(',');
                int numValues = line.Length;
                // Alle Datensätze durchlaufen und aufsplitten.
                // Den ersten Wert (target) im targets-Array und alle übrigen
                // Werte im inputs-Array speichern. Im targets-Array wird an der
                // Stelle des targets 0.99 gespeichert, ansonsten 0.01. 
                // Alle Werte des inputs-Arrays werden mit (0.99/255 + 0.01) skaliert:
                int targetValue;
                inputs = new double[numLines][];
                targets = new double[numLines][];
                for (int i = 0; i < numLines; i++)
                {
                    line = allLines[i].Split(',');

                    targets[i] = new double[10];
                    for (int j = 0; j < 10; j++)
                        targets[i][j] = 0.01;
                    targetValue = Convert.ToInt32(line[0]);
                    targets[i][targetValue] = 0.99;

                    inputs[i] = new double[numValues - 1];
                    for (int j = 1; j < numValues; j++)
                        inputs[i][j - 1] = 0.99 / 255.0 * Convert.ToByte(line[j]) + 0.01;
                }

                // Arrays zum Überschreiben freigeben:
                allLines = null;
                line = null;
                GC.Collect();
                return "File loaded successfully!";
            }
            catch
            {
                allLines = null;
                line = null;
                GC.Collect();
                inputs = null;
                targets = null;
                return "Loading file failed!";
            }
        }

        // ---------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a bitmap into a MNIST data instance
        /// </summary>
        /// <param name="bitmap">bitmap to convert</param>
        /// <param name="target">optional target value</param>
        /// <returns>MNIST data instance (array with 785 elements)</returns>
        public static int[] ConvertBitmap(Bitmap bitmap, int? target = null)
        {
            // "Leere Ränder" des Bildes entfernen
            int top, bottom, left, right;
            int x, y;
            Graphics g;
            bool aborted;

            aborted = false;
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        aborted = true;
                        break;
                    }
                }
                if (aborted) break;
            }
            top = y;
            aborted = false;
            for (y = bitmap.Height - 1; y >= 0; y--)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        aborted = true;
                        break;
                    }
                }
                if (aborted) break;
            }
            bottom = y;
            aborted = false;
            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        aborted = true;
                        break;
                    }
                }
                if (aborted) break;
            }
            left = x;
            aborted = false;
            for (x = bitmap.Width - 1; x >= 0; x--)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        aborted = true;
                        break;
                    }
                }
                if (aborted) break;
            }
            right = x;

            int widthClipped = right - left + 1;
            int heightClipped = bottom - top + 1;

            Bitmap bitmapClipped;
            int offset;
            if (heightClipped >= widthClipped)
            {
                bitmapClipped = new Bitmap(heightClipped, heightClipped);
                g = Graphics.FromImage(bitmapClipped);
                offset = (heightClipped - widthClipped) / 2;
                g.DrawImage(bitmap, offset, 0,
                    new Rectangle(left, top, widthClipped, heightClipped),
                    GraphicsUnit.Pixel);
            }
            else
            {
                bitmapClipped = new Bitmap(widthClipped, widthClipped);
                g = Graphics.FromImage(bitmapClipped);
                offset = (widthClipped - heightClipped) / 2;
                g.DrawImage(bitmap, 0, offset,
                    new Rectangle(left, top, widthClipped, heightClipped),
                    GraphicsUnit.Pixel);
            }

            // In 20x20 Bild umwandeln:
            Bitmap bitmap20 = new Bitmap(20, 20);
            g = Graphics.FromImage(bitmap20);
            g.DrawImage(bitmapClipped, 0, 0, 20, 20);

            // Schwerpunkt des Bildes berechnen
            int xSum = 0;
            int ySum = 0;
            int points = 0;
            for (y = 0; y < bitmap20.Height; y++)
            {
                for (x = 0; x < bitmap20.Width; x++)
                {
                    if (bitmap20.GetPixel(x, y).A != 0)
                    {
                        xSum += x;
                        ySum += y;
                        points++;
                    }
                }
            }
            int xm = xSum / points;
            int ym = ySum / points;
            int xk = xm - 9;
            int yk = ym - 9;

            // 20x20 Bild in 28x28 Bild mit zentriertem Schwerpunkt einpassen:
            Bitmap bitmap28 = new Bitmap(28, 28);
            g = Graphics.FromImage(bitmap28);
            g.DrawImage(bitmap20, new Rectangle(4 - xk, 4 - yk, 20, 20),
                new Rectangle(0, 0, 20, 20), GraphicsUnit.Pixel);

            // Bildinformationen in Array übertragen:
            int[] array = new int[28 * 28 ]; // +1
            /*if (target != null)
            {
                array[0] = Convert.ToInt32(target);
            }
            else
            {
                array[0] = -1;
            }*/
            Color color;
            int i = 0   ;
            for (y = 0; y < bitmap28.Height; y++)
            {
                for (x = 0; x < bitmap28.Width; x++)
                {
                    color = bitmap28.GetPixel(x, y);
                    array[i++] = color.A;
                }
            }
            return array;
        }
        // ---------------------------------------------------------------------------------------
    }
}
