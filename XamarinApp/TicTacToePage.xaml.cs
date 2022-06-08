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
    public partial class TicTacToePage : ContentPage
    {
        public TicTacToePage()
        {
            InitializeComponent();
            AddigToDicData();
        }

        public Dictionary<int, Image> images = new Dictionary<int, Image>();

        public bool botOnOff = false;//Значение включения или выключения бота
        public string botmark = "";
        public int botClickAmount = 0;

        public string currentmark = "X.png";

        private void ResetButton(object sender, EventArgs e)
        {
            resetall();
        }

        private async void NumPlayersButton(object sender, EventArgs e)
        {
            var buttonText = (Button)sender;

            if (botOnOff)
            {
                botOnOff = false;
                buttonText.Text = "2 игрока";
            }
            else
            {
                botOnOff = true;
                buttonText.Text = "1 игрок";
            }
            resetall();
        }

        private async void RulesButton(object sender, EventArgs e)
        {
            await DisplayAlert("Крестики - Нолики \nПРАВИЛА", "1. Игра происходит на поле размером 3x3 клетки.\n2. Перед стартом игры вы можете выбрать свою метку, X или 0.\n3. Игрок, первым получивший 3 метки в ряд(по диагонали, горизонтали или вертикали) выигрывает.\n4. Если все 9 клеток будут заполнены без победителей, игра заканчивается ничьёй.", "Ок");
        }

        private void ChangeYourMark(object sender, EventArgs e)
        {
            var imageSource = (Image)sender;
            var selectedImage = imageSource.Source as FileImageSource;
            resetall();
            if (selectedImage.File == "X.png")
            {
                currentmark = "O.png";
                imageSource.Source = currentmark;
                botmark = "X.png";
            }
            else
            {
                currentmark = "X.png";
                imageSource.Source = currentmark;
                botmark = "O.png";
            }
        }

        private async void SetMark(object sender, EventArgs e)
        {
            var imageSource = (Image)sender;
            var selectedImage = imageSource.Source as FileImageSource;

            if (currentmark == "X.png" && selectedImage.File == "blank.png")
            {
                imageSource.Source = "X.png";
                if (botOnOff)
                {
                    botmark = "O.png";
                    botmove(imageSource);
                }
                else
                {
                    currentmark = "O.png";
                    playerturn.Source = currentmark;
                }
                gameovercheck("X.png");
            }
            else if (currentmark == "O.png" && selectedImage.File == "blank.png")
            {
                imageSource.Source = "O.png";
                if (botOnOff)
                {
                    botmark = "X.png";
                    botmove(imageSource);
                }
                else
                {
                    currentmark = "X.png";
                    playerturn.Source = currentmark;
                }
                gameovercheck("O.png");
            }
            else
            {
                await DisplayAlert("Внимание!", "Данная клетка уже занята!", "Ок");
            }
        }

        public async void gameovercheck(string win_win)
        {
            if (img1.Source.ToString().Substring(6) == win_win && img2.Source.ToString().Substring(6) == win_win && img3.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img1.Source.ToString().Substring(6) == win_win && img4.Source.ToString().Substring(6) == win_win && img7.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img2.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img8.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img3.Source.ToString().Substring(6) == win_win && img6.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img4.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img6.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img7.Source.ToString().Substring(6) == win_win && img8.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img1.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img9.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img3.Source.ToString().Substring(6) == win_win && img5.Source.ToString().Substring(6) == win_win && img7.Source.ToString().Substring(6) == win_win)
            {
                gameover();
            }
            else if (img1.Source.ToString().Substring(6) != "blank.png" && img2.Source.ToString().Substring(6) != "blank.png" && img3.Source.ToString().Substring(6) != "blank.png" && img4.Source.ToString().Substring(6) != "blank.png" && img5.Source.ToString().Substring(6) != "blank.png" && img6.Source.ToString().Substring(6) != "blank.png" && img7.Source.ToString().Substring(6) != "blank.png" && img8.Source.ToString().Substring(6) != "blank.png" && img9.Source.ToString().Substring(6) != "blank.png")
            {
                await DisplayAlert("Игра окончена!", "Ничья", "Ок");
                resetall();
            }
        }

        public async void gameover()
        {
            if (botOnOff)
            {
                if (botmark != "X.png")
                {
                    await DisplayAlert("Игра окончена!", "Выиграли крестики!", "Ок");
                }
                else
                {
                    await DisplayAlert("Игра окончена!", "Выиграли нолики!", "Ок");
                }
            }
            else
            {
                if (currentmark != "X.png")
                {
                    await DisplayAlert("Игра окончена!", "Выиграли крестики!", "Ок");
                }
                else
                {
                    await DisplayAlert("Игра окончена!", "Выиграли нолики!", "Ок");
                }
            }
            resetall();
        }

        public void resetall()
        {
            foreach (var keyValuePair in images)
            {
                Image image = keyValuePair.Value;
                image.Source = "blank.png";
            }
            botClickAmount = 0;
        }

        public async void botmove(Image DelFromDic)
        {
            botClickAmount++;
            Random rnd = new Random();
            int DicCount = images.Count();
            int rndBotClick = rnd.Next(0, DicCount);

            while (images[rndBotClick].Source.ToString().Substring(6) != "blank.png")
            {
                rndBotClick = rnd.Next(0, DicCount);
                if (botClickAmount == 5)
                {
                    botClickAmount = 0;
                    break;
                }
            }
            if (botClickAmount != 0)
            {
                images[rndBotClick].Source = botmark;
            }
        }

        public void AddigToDicData()
        {
            images.Add(0, img1);
            images.Add(1, img2);
            images.Add(2, img3);
            images.Add(3, img4);
            images.Add(4, img5);
            images.Add(5, img6);
            images.Add(6, img7);
            images.Add(7, img8);
            images.Add(8, img9);
        }
    }
}