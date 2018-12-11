using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PatientApp.Service
{
    public class MyNavigationService : IMyNavigationService, INotifyPropertyChanged
    {
        /// <summary>
        /// Zmienna przechowująca informacje o stronach do ktorych można się skierować w aplikacji
        /// </summary>
        private readonly Dictionary<string, Uri> _pagesByKey;

        /// <summary>
        /// Zmienna przechowująca historię przejść międyz oknami i stronami
        /// </summary>
        private readonly List<string> _historic;

        /// <summary>
        /// Zmienna przechowujaca aktualną nazwę strony
        /// </summary>
        private string _currentPageKey;

        /// <summary>
        /// Event jako zmienna informująca o zmianie właściwości
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Oraz zmienne z właściwościami get oraz set służące do ustanawiania aktualnego klucza strony
        /// </summary>
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                if (_currentPageKey == value)
                {
                    return;
                }

                _currentPageKey = value;
                OnPropertyChanged("CurrentPageKey");
            }
        }
        public object Parameter { get; private set; }




        /// <summary>
        /// Konstruktor klasy tworzący obiekty pozwalające przechowywać klucze klasy oraz historię przejść
        /// </summary>
        public MyNavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<string>();
        }

        /// <summary>
        /// Metoda pozwalająca wrócić do poprzedniego okna/widoku
        /// </summary>
        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);
                NavigateTo(_historic.Last(), null);
            }
        }

        public bool GoBackToMenu()
        {
            if (_historic.Count > 1 && _historic[_historic.Count-2]!="ChoiceView")
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Metoda której zadaniem jest przechowywanie wszystkich widoków danego okna/okna main
        /// </summary>
        /// <param name="key">Nazwa widoku</param>
        /// <param name="pageType">Typ widoku</param>
        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }

        /// <summary>
        /// Metoda służaca do nawigowania do strony z podanym kluczem jako parametrem
        /// </summary>
        /// <param name="pageKey"> parametr który jest stringiem i przechowuje nazwe strony do której chcemy przeskoczyć</param>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Metoda przeciążona, służąca do nawigowania jednak można przekezać przez nią jakieś dane
        /// Które zostaną przekazane do kolejnego widoku
        /// Metoda ustanawia aktualna stronę
        /// </summary>
        /// <param name="pageKey">parametr który jest stringiem i przechowuje nazwe strony do której chcemy przeskoczyć</param>
        /// <param name="parameter">Dane które można przekazać do kolejnego widoku</param>
        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

                if (frame != null)
                {
                    frame.Source = _pagesByKey[pageKey];
                }
                Parameter = parameter;
                _historic.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        /// <summary>
        /// Metoda poszukujaca "potomka danego elementu w UI. Potomek wuszykiwnay według przekazanej nazwy
        /// </summary>
        /// <param name="parent">Przekazywany rodzic którego potomek będzie wyszukiwany</param>
        /// <param name="name">Nazwa potomka w danym obiekcie którego chcemy znaleźć</param>
        /// <returns></returns>
        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Wirtualna metoda ustanawiająca uchwyt do obiektu , tzn ustawianie identyfikatora obiektu
        /// </summary>
        /// <param name="propertyName">Nazwa uchwytu jako string</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NavigateTo(string pageKey, object parameter, bool refreshPage = false)
        {
           
        }
    }
}
