using smarttrack.Cloud;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //async void OnSignUpButtonClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SignUpPage());
        //}

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var user = new User
                {
                    Username = usernameEntry.Text,
                    Password = passwordEntry.Text
                };

                var isValid = AreCredentialsCorrectAsync(user);
                if (await isValid)
                {
                    App.IsUserLoggedIn = true;
                    await Navigation.PushAsync(new MainMenu());
                }
                else
                {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
            }
        }

        async Task<bool> AreCredentialsCorrectAsync(User user)
        {
            CloudConnectorOwe cco = new CloudConnectorOwe();
            bool validLogin = await cco.GetUserTokenAsync(user);
            return validLogin;
        }

        public void ShowPass(object sender, EventArgs args)
        {
            passwordEntry.IsPassword = passwordEntry.IsPassword ? false : true;
        }
    }
}
