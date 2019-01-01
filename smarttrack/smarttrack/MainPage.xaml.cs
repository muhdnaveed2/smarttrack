using smarttrack.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace smarttrack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var label = new ShippingLabel
                {
                    AddressLine1 = addressline1Entry.Text,
                    AddressLine2 = addressline2Entry.Text,
                    AddressLine3 = addressline3Entry.Text,
                    City = cityEntry.Text,
                    Company = companyEntry.Text,
                    Contact = contactEntry.Text,
                    CountryIso = countryisoEntry.Text,
                    Currency = currencyEntry.Text,
                    Description = descriptionEntry.Text,
                    Email = emailEntry.Text,
                    SenderName = sendernameEntry.Text,
                    State = stateEntry.Text,
                    Value = Convert.ToInt32(valueEntry.Text),
                    Weight = Convert.ToInt32(weightEntry.Text)
                };

                var isValid = GenerateLabel(label);
                if (!await isValid)
                {

                }
                else
                {
                    messageLabel.Text = "Label creation failed";
                    //passwordEntry.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                messageLabel.Text = ex.Message;
            }
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async Task<bool> GenerateLabel(ShippingLabel label)
        {
            CloudConnectorOwe cco = new CloudConnectorOwe();
            bool validLogin = await cco.GenerateLabel(label);
            return validLogin;
        }
    }
}
