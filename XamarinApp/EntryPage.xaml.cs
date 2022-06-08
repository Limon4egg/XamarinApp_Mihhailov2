using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        Entry line;
        ImageButton home, back, favorite;
        String link;
        string[] lehed = new string[] { "https://www.google.com", "https://moodle.edu.ee", "https://tthk.ee", "https://tahvel.edu.ee", "https://www.youtube.com" };

        public EntryPage()
        {
            picker = new Picker
            {
                Title = "---> VEEBILEHED <---",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                TitleColor = Color.Violet,
            };
            picker.Items.Add("Google");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Tahvel");
            picker.Items.Add("YouTube");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            webView = new WebView { };

            //SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            //swipe.Swiped += Swipe_Swiped;
            //swipe.Direction = SwipeDirection.Right;

            home = new ImageButton
            {
                Source = "home_btn.jpg"
            };
            home.Clicked += Home_Clicked;

            back = new ImageButton
            {
                Source = "back_btn.png"
            };
            back.Clicked += Back_Clicked;

            favorite = new ImageButton
            {
                Source = "fav_btn.png"
            };
            favorite.Clicked += Favorite_Clicked;

            line = new Entry
            {
                Placeholder = "Sisesta veebiaadress:",
                PlaceholderColor = Color.Violet,
                BackgroundColor = Color.Black,
                //TextColor = Color.GhostWhite
            };
            line.Completed += Line_Completed;

            StackLayout buttons = new StackLayout
            {
                Children = { line, home, back, favorite },
                Orientation = StackOrientation.Horizontal
            };

            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.Black,
                CornerRadius = 20,
                HeightRequest = 40,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            st = new StackLayout { Children = { picker, frame } };
            //frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void Favorite_Clicked(object sender, EventArgs e)
        {
            int arlenght;
            link = "https://" + line.Text;
            arlenght = lehed.Length;
            //await DisplayAlert("arlenght ", "Ans "+arlenght, "OK");
            //Array.Resize(ref lehed, arlenght+1);
            lehed = lehed.Concat(new string[] { link }).ToArray();
            picker.Items.Add(link);
            Title = "Veebiaadress on salvestatud!";
            //await DisplayAlert("link "+link, "arlenght "+ arlenght + "lehed " + lehed, "OK");
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void Line_Completed(object sender, EventArgs e)
        {
            webView.Source = "https://" + line.Text;
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
        }

        //private void Swipe_Swiped(object sender, SwipedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (true)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
    }
}