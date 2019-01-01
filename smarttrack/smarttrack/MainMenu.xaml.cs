using smarttrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace smarttrack
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Generate Label", Icon = "barcode.png", TargetType = typeof(GenerateLabel) },
                new MainMenuItem() { Title = "Add Tracking", Icon = "barcode.png", TargetType = typeof(GenerateLabel) }
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new GenerateLabel());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Generate Label"))
                {
                    Detail = new NavigationPage(new GenerateLabel());
                }
                else if (item.Title.Equals("Add Tracking"))
                {
                    Detail = new NavigationPage(new GenerateLabel());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
