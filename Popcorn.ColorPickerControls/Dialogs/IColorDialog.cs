using System.Windows.Media;

namespace Popcorn.ColorPickerControls.Dialogs
{
    internal interface IColorDialog
    {
        Color SelectedColor { get; set; }
        Color InitialColor { get; set; }

        bool? ShowDialog();
    }
}