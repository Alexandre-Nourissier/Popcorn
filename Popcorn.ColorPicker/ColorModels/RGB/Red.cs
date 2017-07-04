﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Popcorn.ColorPicker.ColorModels.RGB
{
    public class Red : NormalComponent
    {
        public override int MinValue
        {
            get { return 0; }
        }

        public override int MaxValue
        {
            get { return 255; }
        }

        public override void UpdateNormalBitmap(WriteableBitmap bitmap, Color color)
        {
            unsafe
            {
                bitmap.Lock();
                int currentPixel = -1;
                byte* pStart = (byte*)(void*)bitmap.BackBuffer;
                for (int iRow = 0; iRow < bitmap.PixelHeight; iRow++)
                {
                    for (int iCol = 0; iCol < bitmap.PixelWidth; iCol++)
                    {
                        currentPixel++;
                        *(pStart + currentPixel * 3 + 0) = color.B; //Blue
                        *(pStart + currentPixel * 3 + 1) = color.G; //Green
                        *(pStart + currentPixel * 3 + 2) = (byte)(255 - iRow); //red
                    }
                }

                bitmap.AddDirtyRect(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
                bitmap.Unlock();
            }
        }

        public override void UpdateColorPlaneBitmap(WriteableBitmap bitmap, int normalComponentValue)
        {
            unsafe
            {
                bitmap.Lock();
                int currentPixel = -1;
                byte* pStart = (byte*)(void*)bitmap.BackBuffer;
                for (int iRow = 0; iRow < bitmap.PixelHeight; iRow++)
                {
                    for (int iCol = 0; iCol < bitmap.PixelWidth; iCol++)
                    {
                        currentPixel++;
                        *(pStart + currentPixel * 3 + 0) = (byte)(iCol); //Blue
                        *(pStart + currentPixel * 3 + 1) = (byte)(255 - iRow); //Green
                        *(pStart + currentPixel * 3 + 2) = (byte)normalComponentValue; //red
                    }
                }
                bitmap.AddDirtyRect(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
                bitmap.Unlock();
            }
        }

        public override Color ColorAtPoint(Point selectionPoint, int colorComponentValue)
        {
            var blue = (byte)Math.Round(selectionPoint.X);
            var green = (byte)Math.Round(255 - selectionPoint.Y);
            var red = (byte)colorComponentValue;
            return Color.FromRgb(red, green, blue);
        }

        public override Point PointFromColor(Color color)
        {
            return new Point(color.B, 255 - color.G);
        }

        public override int Value(Color color)
        {
            return color.R;
        }

        public override string Name
        {
            get { return "RGB_Red"; }
        }

        public override bool IsNormalIndependantOfColor
        {
            get { return false; }
        }
    }
}