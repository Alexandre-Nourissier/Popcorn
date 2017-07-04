using Popcorn.Events;
using Popcorn.Models.Episode;
using Popcorn.ViewModels.Pages.Home.Show.Details;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Popcorn.UserControls.Home.Show.Details
{
    /// <summary>
    /// Logique d'interaction pour ShowDetailsUserControl.xaml
    /// </summary>
    public partial class ShowDetailsUserControl : UserControl
    {
        public ShowDetailsUserControl()
        {
            InitializeComponent();
        }

        private void OnSelectedSeasonChanged(object sender, SelectedSeasonChangedEventArgs e)
        {
            var vm = DataContext as ShowDetailsViewModel;
            if (vm == null) return;

            var episodes = vm.Show.Episodes.Where(a => a.Season == e.SelectedSeasonNumber);
            EpisodesDetails.ItemsSource = new ObservableCollection<EpisodeShowJson>(episodes.OrderBy(a => a.EpisodeNumber));
        }
    }
}