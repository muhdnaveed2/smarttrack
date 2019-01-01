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
    public partial class GenerateLabel : ContentPage
    {
        public GenerateLabel()
        {
            InitializeComponent();
        }
        async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var label = new ShippingLabel
                {
                    address_line_1 = addressline1Entry.Text,
                    address_line_2 = addressline2Entry.Text,
                    address_line_3 = addressline3Entry.Text,
                    city = cityEntry.Text,
                    company = companyEntry.Text,
                    contact = contactEntry.Text,
                    countryIso = countryisoEntry.Text,
                    currency = currencyEntry.Text,
                    description = descriptionEntry.Text,
                    email = emailEntry.Text,
                    sender_name = sendernameEntry.Text,
                    state = stateEntry.Text,
                    value = Convert.ToInt32(valueEntry.Text),
                    weight = Convert.ToInt32(weightEntry.Text)
                };

                var isValid = LabelGenerate(label);
                if (!await isValid)
                {

                }
                else
                {
                    messageLabel.Text = "Label creation failed";
                    //passwordEntry.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async Task<bool> LabelGenerate(ShippingLabel label)
        {
            CloudConnectorOwe cco = new CloudConnectorOwe();
            bool validLogin = await cco.LabelGenerate(label);
            return validLogin;
        }
    }
}
