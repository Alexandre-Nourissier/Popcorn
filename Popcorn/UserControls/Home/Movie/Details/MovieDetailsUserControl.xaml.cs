using Popcorn.Controls;
using System;
using System.Windows;

namespace Popcorn.UserControls.Home.Movie.Details
{
    /// <summary>
    /// Interaction logic for Movie.xaml
    /// </summary>
    public partial class MovieDetailsUserControl
    {
        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        public MovieDetailsUserControl()
        {
            InitializeComponent();
        }

        private void OnPreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var scv = (AnimatedScrollViewer)sender;
            if (scv.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                return;

            if (scv.TargetHorizontalOffset + e.Delta > -Math.Abs(e.Delta) &&
                scv.TargetHorizontalOffset + e.Delta < scv.ScrollableWidth + Math.Abs(e.Delta))
            {
                scv.TargetHorizontalOffset += e.Delta;
            }
        }
    }
}