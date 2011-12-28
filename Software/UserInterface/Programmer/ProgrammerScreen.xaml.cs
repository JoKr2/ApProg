using System.ComponentModel;
using System.Text;
using ApProg.UserInterface.Shell;

namespace ApProg.UserInterface.Programmer
{
    /// <summary>
    /// Interaction logic for ProgrammerScreen.xaml
    /// </summary>
    public partial class ProgrammerScreen : IScreen
    {
        public ProgrammerScreen()
        {
            InitializeComponent();
        }

        object IScreen.DataContext
        {
            set
            {
                RegisterDataContext(false);
                DataContext = value;
                RegisterDataContext(true);
            }
        }

        private void RegisterDataContext(bool register)
        {
            var propChanged = DataContext as INotifyPropertyChanged;
            if(propChanged == null)
                return;

            if (register)
                propChanged.PropertyChanged += OnDcPropertyChanged;
            else
                propChanged.PropertyChanged -= OnDcPropertyChanged;
        }

        // ToDo: This method is just quick hack. Remove it.
        void OnDcPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName != "Document")
                return;

            Document.Text = null;
            ProgrammerModel model = DataContext as ProgrammerModel;
            if(model == null)
                return;

            var builder = new StringBuilder();
            int count = 0;
            uint address = 0;
            foreach (uint instr in model.Document)
            {
                if (count <= 0)
                {
                    count = 4;
                    builder.AppendFormat(" {0:X6}: -->", address);
                }
                builder.AppendFormat("  {0:X8}", instr);
                count--;
                if(count <= 0)
                    builder.AppendLine();
                address += 2;
            }
            Document.Text = builder.ToString();
        }
    }
}
