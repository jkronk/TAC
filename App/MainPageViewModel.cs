using Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace App
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly WebClient _client;

        public MainPageViewModel()
        {
            _client = new WebClient();
            TitanPlayers = new ObservableCollection<PlayerExtract>();

            NotifyTaskCompletion.Create(PopulateTitans);
        }

        public ObservableCollection<PlayerExtract> TitanPlayers { get; set; }

        private Visibility _showBusyIcon;
        public Visibility ShowBusyIcon
        {
            get { return _showBusyIcon; }
            set
            {
                _showBusyIcon = value;
                OnPropertyChanged();
            }
        }

        public async Task PopulateTitans()
        {
            ShowBusyIcon = Visibility.Visible;

            TitanPlayers.Clear();

            try
            {
                var titans =
                    JsonConvert.DeserializeObject<IEnumerable<PlayerExtract>>(await _client.GetContent("api/player"));

                foreach (var titan in titans)
                    TitanPlayers.Add(titan);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                ShowBusyIcon = Visibility.Collapsed;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}