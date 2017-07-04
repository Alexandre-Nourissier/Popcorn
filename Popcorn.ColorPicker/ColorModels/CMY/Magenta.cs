﻿namespace Popcorn.ColorPicker.ColorModels.CMY
{
    internal class Magenta : ColorComponent
    {
        public static CMYModel sModel = new CMYModel();

        public override int MinValue
        {
            get { return 0; }
        }

        public override int MaxValue
        {
            get { return 100; }
        }

        public override int Value(System.Windows.Media.Color color)
        {
            return (int)sModel.MComponent(color);
        }

        public override string Name
        {
            get { return "CMY_magenta"; }
        }
    }
}