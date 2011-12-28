using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Win32;

namespace ApProg.UserInterface.Shell
{
    /// <summary>
    /// Did not want to use nasty FrameworkElement with lot of public members
    /// so this interface just enables data binding. 
    /// </summary>
    public interface IScreen
    {
        object DataContext { set; }
    }

    /// <summary>
    /// Provides basic shell services
    /// </summary>
    public interface IShell : IScreen
    {
        IScreen NavigationScreen { get; }

        void InformUser(string message);
        string AskUserForFileName(bool open);
        
        void ShowProgressBar(bool show);
        void UpdateProgress(int value, string message);

        void AddScreen(IScreen screen, string caption);
        void RemoveScreen(IScreen screen);
        void Close();
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml... 
    /// When logic gets complicated, move it to presenter class
    /// </summary>
    public partial class MainWindow : IShell
    {
        private ProgressDialog myProgress;
        public IScreen NavigationScreen
        {
            get { return NavPanel; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public string AskUserForFileName(bool open)
        {
            if(open)
            {
                var dialog = new OpenFileDialog {DefaultExt = ".hex", Filter = "Hex Files (.hex)|*.hex"};
                if(dialog.ShowDialog() == true)
                {
                    return dialog.FileName;
                }
            }
            else
            {
                var dialog = new SaveFileDialog { DefaultExt = ".hex", Filter = "Hex Files (.hex)|*.hex" };
                if (dialog.ShowDialog() == true)
                {
                    return dialog.FileName;
                }
            }
            return null;
        }

        public void ShowProgressBar(bool show)
        {
            if(myProgress != null)
                myProgress.Close();
            
            myProgress = new ProgressDialog();
            myProgress.Owner = this;
            if (show)
            {
                myProgress.Show();
                IsEnabled = false;
            }
            else
            {
                IsEnabled = true;
                myProgress.Close();
                myProgress = null;
            }
        }

        public void UpdateProgress(int value, string message)
        {
            if(myProgress == null)
                return;

            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                                           {
                                               myProgress.myProgressBar.Value = value;
                                               myProgress.myMessage.Inlines.Clear();
                                               myProgress.myMessage.Inlines.Add(message);
                                           }));
            
        }

        protected TabItem GetTabByScreen(IScreen screen)
        {
            return myTabContainer.Items.OfType<TabItem>().FirstOrDefault(tab => tab.Content == screen);
        }

        public void InformUser(string message)
        {
            MessageBox.Show(message);
        }

        public void AddScreen(IScreen screen, string caption)
        {
            TabItem tab = GetTabByScreen(screen);
            if (tab == null)
            {
                tab = new TabItem {Content = screen, Header = caption};
                myTabContainer.Items.Add(tab);
            }
               
            myTabContainer.SelectedItem = tab;
        }

        public void RemoveScreen(IScreen screen)
        {
            TabItem tab = GetTabByScreen(screen);
            if (tab != null)
            {
                myTabContainer.Items.Remove(tab);
                tab.Content = null;
            }
        }
    }
}
