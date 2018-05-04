using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CyberVet10._1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WellnessProtocol : Page
    {
        public WellnessProtocol()
        {
            this.InitializeComponent();
            cbSpecies.Items.Add("Cat");
            cbSpecies.Items.Add("Dog");
            cbRabiesDuration.Items.Add("1 year");
            cbRabiesDuration.Items.Add("3 year");
            cbCoreDuration.Items.Add("4 week");
            cbCoreDuration.Items.Add("1 year");
            cbCoreDuration.Items.Add("3 year");
            //String buttonText = "";
            //CalculateAge(buttonText);
            //btnBirthdate = buttonText;
            ///Makes sure that the page is not erased when navigated away from
            ///If this line is deleted then a new instance of the page is loaded when ever it is navigated to.
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void chbRabies_Click(object sender, RoutedEventArgs e)
        {
            if (chbRabies.IsChecked == true)
            {
                spRabies.Visibility = Visibility.Visible;
            }
            else
            {
                spRabies.Visibility = Visibility.Collapsed;
            }
        }

        private void chbCore_Click(object sender, RoutedEventArgs e)
        {
            if (chbCore.IsChecked == true)
            {
                spCore.Visibility = Visibility.Visible;
            }
            else
            {
                spCore.Visibility = Visibility.Collapsed;
            }
        }

        private void cbSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((String)cbSpecies.SelectedItem == "Cat")
            {
                chbCore.Content = "FVRCP Given";
            }
            else if ((String)cbSpecies.SelectedItem == "Dog")
            {
                chbCore.Content = "DHLPP Given";
            }
            spCoreGiven.Visibility = Visibility.Visible;
        }

        private void dpfBirthdate_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            btnBirthdate.Content = CalculateAge();
        }
        private String CalculateAge()
        {
            TimeSpan Age;
            Single AgeInDays;
            Age = DateTime.Now - dpfBirthdate.Date.Date;
            AgeInDays = Convert.ToInt16(Age.TotalDays - 0.5);
            if (AgeInDays <= 0)
            {
                spAge.Visibility = Visibility.Collapsed;
                dpfBirthdate.Date = DateTime.Now;
                return "pick date";
            }
            else
            {
                spAge.Visibility = Visibility.Visible;
                if (AgeInDays < 28)
                {
                    tbkAge.Text = AgeInDays.ToString() + " days";
                }
                else if(AgeInDays < 141)
                {
                    tbkAge.Text = (AgeInDays / 7).ToString("#.0") + " weeks";
                }
                else if (AgeInDays<365)
                {
                    tbkAge.Text = (AgeInDays / (365.25 / 12)).ToString("#.0") + " months";
                }
                else
                {
                    tbkAge.Text = (AgeInDays / 365.25).ToString("#.0") + " years";
                }
                return dpfBirthdate.Date.Date.ToShortDateString();
            }
            
        }

        private void dpfRabiesDate_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            btnRabiesDate.Content = dpfRabiesDate.Date.Date.ToShortDateString();
        }

        private void dpfCoreDate_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            btnCoreDate.Content = dpfCoreDate.Date.Date.ToShortDateString();
        }
    }
}
