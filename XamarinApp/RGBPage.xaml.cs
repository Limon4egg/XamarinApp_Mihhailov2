using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGBPage : ContentPage
    {
        Random rnd = new Random();
        public RGBPage()
        {
            InitializeComponent();
        }

        int _sliderRed, _sliderGreen, _sliderBlue;

        private void SliderRed_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderRed = Convert.ToInt32(SliderRed.Value);
            GenerateRgbColors(_sliderRed, _sliderGreen, _sliderBlue);

            RedValue.Text = _sliderRed.ToString();
        }


        private void SliderGreen_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderGreen = Convert.ToInt32(SliderGreen.Value);
            GenerateRgbColors(_sliderRed, _sliderGreen, _sliderBlue);

            GreenValue.Text = _sliderGreen.ToString();
        }

        private void SliderBlue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _sliderBlue = Convert.ToInt32(SliderBlue.Value);
            GenerateRgbColors(_sliderRed, _sliderGreen, _sliderBlue);

            BlueValue.Text = _sliderBlue.ToString();
        }

        private void GenerateRgbColors(int sliderRed, int sliderGreen, int sliderBlue)
        {
            TxtColorPreviewer.BackgroundColor = Color.FromRgb(sliderRed, sliderGreen, sliderBlue);
        }

        private void RandButton_Clicked(object sender, EventArgs e)
        {
            //Назначение рандомных значений цветов при нажатии на кнопку
            int value1 = rnd.Next(0, 255);//Красный
            int value2 = rnd.Next(0, 255);//Зелёныйй
            int value3 = rnd.Next(0, 255);//Синий

            //Назначение параметров цветам
            SliderRed.Value = value1;
            SliderGreen.Value = value2;
            SliderBlue.Value = value3;

            //Отображение значений цветов
            RedValue.Text = value1.ToString();
            GreenValue.Text = value2.ToString();
            BlueValue.Text = value3.ToString();

            //Смена цвета при передвигании ползунка
            GenerateRgbColors(value1, value2, value3);
        }
    }
}
