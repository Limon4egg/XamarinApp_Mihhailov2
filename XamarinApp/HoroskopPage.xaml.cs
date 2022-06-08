using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoroskopPage : ContentPage
    {
        Entry zodiacEntry;
        Picker chooseZodiacSign;
        DatePicker zodiacDatePicker;
        Image zodiacImage;
        Label header, zodiacDescribe;
        ScrollView scrollView;
        public char[] charsToTrim = { '$', '*', ' ', '\'', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', ':', ';', '-', '+', '#', '!', '/', '¤', '%', '&', '(', ')', '=', '?', '`', '[', ']', '{', '}', '<', '>' };
        public HoroskopPage()
        {
            // DatePicker
            zodiacDatePicker = new DatePicker
            {
                //Format = "dd/MM/YYYY",
                //Date = DateTime.Now,
                WidthRequest = 10,
                //BackgroundColor = Color.Black,
                TextColor = Color.Violet
                //MaximumDate = DateTime.Now.AddDays(5), // +5 days
                //MinimumDate = DateTime.Now.AddDays(-5) // +5 days
            };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            // First Picker
            chooseZodiacSign = new Picker
            {
                Title = "Выберите знак:",
                TextColor = Color.Violet,
                HorizontalTextAlignment = TextAlignment.Center

            };
            addingDataToPicker();
            chooseZodiacSign.SelectedIndexChanged += ChooseZodiacSign_SelectedIndexChanged;

            // Image
            zodiacImage = new Image
            {
                Source = ""
            };

            // Describe
            zodiacDescribe = new Label
            {
                Text = "Чтобы найти информацию, выберите день или выполните поиск по знаку зодиака.",
                TextColor = Color.Violet,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            // Zodiaac signs Picker
            zodiacEntry = new Entry
            {
                Placeholder = "Поиск знака Зодиака:",
                //PlaceholderColor = Color.LightGray,
                WidthRequest = 10,
                MaxLength = 10,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing, // кнопка полной очистки поля // field clear button
                //Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence), // Заглавные буквы // Capital letters
                Keyboard = Keyboard.Text, // клавиатура только для поля // field-only keyboard
                ReturnType = ReturnType.Search, // отображает в клавиатуре иконку лупы // displays a magnifying glass icon in the keyboard
                //BackgroundColor = Color.Black,
                TextColor = Color.Violet,
            };
            zodiacEntry.Completed += Entry_Completed;

            //grid
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            // 1 row
            grid.Children.Add
                (
                    header = new Label
                    {
                        Text = "Знаки Зодиака",
                        TextColor = Color.Gold,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 // column, row
                ); ;
            Grid.SetColumnSpan(header, 2);

            // 2 column, 2+3+4 row
            grid.Children.Add
                (
                    zodiacImage, 1, 1 // column, row
                );
            Grid.SetRowSpan(zodiacImage, 3);

            // 2 row
            grid.Children.Add
                (
                    zodiacDatePicker, 0, 1 // column, row
                );

            // 3 row
            grid.Children.Add
                (
                    zodiacEntry, 0, 2 // column, row
                );

            // 4 row
            grid.Children.Add
                (
                    chooseZodiacSign, 0, 3 // column, row
                );

            // 5 row
            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = zodiacDescribe }, 0, 4 // column, row
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private void ChooseZodiacSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            zodiacEntry.Text = chooseZodiacSign.SelectedItem.ToString();
            zodiacEntry.TextColor= Color.Violet;
            zodiacEntry.HorizontalTextAlignment = TextAlignment.Center;
            Entry_Completed(sender, e);
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var year = e.NewDate.Year; // year
            //string i = zodiacDatePicker.Date.ToString();
            if (new DateTime(year, 03, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 04, 20)) //YYYY MM DD - вне зависимости, какой год поставят // no matter what year
            {
                jaarZodiac();
            }
            else if (new DateTime(year, 04, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 05, 20))
            {
                sonnZodiac();
            }
            else if (new DateTime(year, 05, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 06, 21))
            {
                kaksikudZodiac();
            }
            else if (new DateTime(year, 06, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 07, 22))
            {
                vahkZodiac();
            }
            else if (new DateTime(year, 07, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 08, 22))
            {
                loviZodiac();
            }
            else if (new DateTime(year, 08, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 09, 22))
            {
                neitsiZodiac();
            }
            else if (new DateTime(year, 09, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 10, 22))
            {
                kaaludZodiac();
            }
            else if (new DateTime(year, 10, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 11, 21))
            {
                skorpionZodiac();
            }
            else if (new DateTime(year, 11, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 12, 21))
            {
                amburZodiac();
            }
            else if (new DateTime(year, 12, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 01, 19)) // Вывод козерога ошибка
            {
                kaljukitsZodiac();
            }
            else if (new DateTime(year, 01, 20) <= e.NewDate && e.NewDate <= new DateTime(year, 02, 19))
            {
                veevalajaZodiac();
            }
            else if (new DateTime(year, 02, 20) <= e.NewDate && e.NewDate <= new DateTime(year, 03, 20))
            {
                kaladZodiac();
            }
            else
            {
                tyhiZodiac();
            }

            header.Text = "Вы выбрали: " + e.NewDate.ToString("dd/MM/yyyy");  //HorizontalTextAlignment="Center" VerticalTextAlignment="Start"  TextColor="#e8d97d"
            header.TextColor = Color.Gold;
            header.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim(charsToTrim);

            if (zodiacEntryText == "Овен" || zodiacEntryText == "овен")
            {
                //jaarZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 03, 21);
            }
            else if (zodiacEntryText == "Телец" || zodiacEntryText == "телец")
            {
                //sonnZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 04, 21);
            }
            else if (zodiacEntryText == "Близнецы" || zodiacEntryText == "близнецы")
            {
                //kaksikudZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 05, 21);
            }
            else if (zodiacEntryText == "Рак" || zodiacEntryText == "рак")
            {
                //vahkZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 06, 22);
            }
            else if (zodiacEntryText == "Лев" || zodiacEntryText == "лев")
            {
                //loviZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 07, 23); //
            }
            else if (zodiacEntryText == "Дева" || zodiacEntryText == "дева")
            {
                //neitsiZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 08, 22);
            }
            else if (zodiacEntryText == "Весы" || zodiacEntryText == "весы")
            {
                //kaaludZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 09, 23);
            }
            else if (zodiacEntryText == "Скорпион" || zodiacEntryText == "скорпион")
            {
                //skorpionZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 10, 23);
            }
            else if (zodiacEntryText == "Стрелец" || zodiacEntryText == "стрелец")
            {
                //amburZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 11, 22);
            }
            else if (zodiacEntryText == "Козерог" || zodiacEntryText == "козерог")
            {
                //kaljukitsZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 12, 22);
            }
            else if (zodiacEntryText == "Водолей" || zodiacEntryText == "водолей")
            {
                //veevalajaZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 01, 20);
            }
            else if (zodiacEntryText == "Рыбы" || zodiacEntryText == "рыбы")
            {
                //kaladZodiac();
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 02, 20);
            }
            else
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                tyhiZodiac();
            }

            header.Text = "Вы искали: " + zodiacEntryText; //zodiacEntry.Text
            header.HorizontalTextAlignment = TextAlignment.Center;
        }
        
        public void jaarZodiac() // Овен // Aries
        {
            zodiacEntry.Text = "Овен";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Aries.png";
            zodiacDescribe.Text = "Символика знака Овна связана с тем, что " +
                "это первый знак зодиака. Человек со знаком Солнечного Овна на карте рождения считается смелым, " +
                "часто безумен (не принимает во внимание предыдущий опыт или чужое мнение), ориентирован на действия, " +
                "прямолинейный и сердечный. Его слабостью является отсутствие сотрудничества и дипломатии. " +
                "Заранее планировать свои действия и думать о последствиях — тоже не самая сильная черта Овна.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 0;
        }

        public void sonnZodiac() // Телец // Taurus
        {
            zodiacEntry.Text = "Телец";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Taurus.png";
            zodiacDescribe.Text = "Телец — символ изначальной жизненной силы, самосохранения, призванный продолжить начатое Овном. " +
                "Солнце в тельце указывает на то, что он спокойный, терпеливый тип человека, который упорно придерживается своих привычек и не спешит бежать к новым. " +
                "Собирает и вещи, и эмоции, преданно хранит ценные для него человеческие отношения. Как знак земного элемента, он способен хорошо обращаться с материальными вещами, " +
                "уметь вести бизнес, ценить свое тело, любить комфорт и преуспевать в выращивании растений. " +
                "Часто с очень нежным чувством осязания и искусства. С отрицательной стороны Телец упрям, ленив и очень зол.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 1;
        }

        public void kaksikudZodiac() // Близнецы // Twins
        {
            zodiacEntry.Text = "Близнецы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Gemini.png";
            zodiacDescribe.Text = "Информационно-ориентированный знак Близнецы является первым ментальным знаком зодиака. " +
                "Личность Близнецов объективно передает мысли и факты, не отдавая предпочтения ни одному из них и не привязываясь к своим взглядам." +
                "Он гибок и способен при необходимости изменить свое мнение, часто вообще его не формулирует, предпочитая опосредовать другие мнения. " +
                "Личность Близнецов любознательна, рациональна, объективна, способна без эмоций анализировать ситуации. " +
                "Обычно он хороший оратор и писатель, много читает, часто за свою жизнь осваивая несколько профессий. " +
                "Вербальные способности часто дополняются ловкостью рук. С другой стороны, Близнецы могут быть слишком непостоянными. " +
                "Часто им бывает скучно и они не в состоянии завершить свои дела. Они также могут использовать свое красноречие в корыстных целях.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 2;
        }

        public void vahkZodiac() // Рак // Cancer
        {
            zodiacEntry.Text = "Рак";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Cancer.png";
            zodiacDescribe.Text = "Рак так же энергичен и предприимчив, как и любой знак солнцестояния. " +
                "но самый осторожный и консервативный из них. Человек со знаком Рак обладает глубоким сочувствием, " +
                "и устрашающие, и нуждающиеся в безопасности, и очень эмоциональные. Он экономичен, коллекционирует, часто собирает старые вещи. " +
                "проявляет заботу о других как эмоционально, так и практически. Ему важны семейные традиции и воспоминания, " +
                "эмоциональная память хорошо развита. С отрицательной стороны человек капризный, субъективный, очень ранимый и долго помнит обиды.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 3;
        }

        public void loviZodiac() // Лев // Lion
        {
            zodiacEntry.Text = "Лев";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Leo.png";
            zodiacDescribe.Text = "Символ знака Льва полный радости, имеет страсть к творчеству. " +
                "веселый, нуждается в комплиментах и ​​может сделать то же самое для других. " +
                "Лев привык всегда светиться в центре внимания, запросто может проявлять свои ораторские способности. " +
                "Он часто увлекается детьми, работой и развлечениями, будь то профессионально или в свободное время. " +
                "Лев — величайший романтик из всех знаков зодиака. С другой стороны, есть постоянная склонность к аплодисментам, обладает высокомерием, очень гордый, " +
                "жесткий в своих принципах и легко уязвимый знак.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 4;
        }

        public void neitsiZodiac() // Дева // Virgo
        {
            zodiacEntry.Text = "Дева";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Virgo.png";
            zodiacDescribe.Text = "Дева – последнее мгновение лета, она символически обобщает, упорядочивает, выносит важное из полученного опыта." +
                "Человек Дева также аналитичен, критичен, в высшей степени рационален и систематичен, способен сосредотачиваться на деталях. " +
                "Он трудолюбив и терпелив, и его основная потребность — быть полезным. Как и у Близнецов, у Дев часто умелые руки. " +
                "В качестве меняющегося ориентира именно Дева лучше всего умеет устранять материальные несоответствия: ухаживать за больными, чинить сломанные предметы и так далее. " +
                "Он также уделяет много внимания своему здоровью и питанию. С другой стороны, педантичность Девы может стать крайне критической, " +
                "что, в свою очередь, снижает его уверенность в себе и ухудшает его здоровье. Дева может быть довольно жадной, как и все знаки земной стихии.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 5;
        }

        public void kaaludZodiac() // Весы // Libra
        {
            zodiacEntry.Text = "Весы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Libra.png";
            zodiacDescribe.Text = "Весы, которые начинаются с середины осени, олицетворяют чувство гармонии, дипломатичность, коммуникабельность, " +
                "будучи столь же предприимчивыми, как и все знаки. Человек, имеющий во внимание Солнце, обычно обладает художественными талантами или, по крайней мере, хорошим чувством стиля, " +
                "любит общение и компанию. Он объективен и умеет откладывать чувства при принятии решений, как и другие знаки воздушной стихии (Близнецы и Водолей)." +
                "Поскольку он не хочет быть один, он может иногда общаться с неподходящими компаньонами. Еще одна отрицательная черта – нерешительность:" +
                "Весы всегда стараются принять наилучшее возможное решение, поэтому взвешивание может занять много времени.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 6;
        }

        public void skorpionZodiac() // Скорпион // Scorpion
        {
            zodiacEntry.Text = "Скорпион";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Scorpio.png";
            zodiacDescribe.Text = "Знак Скорпиона ориентирован на душу и на то, что находится под поверхностью, невидимое невооруженным глазом." +
                "Тот, кто носит знак Скорпиона, интересуется тайнами рождения и смерти, человеческими энергетическими процессами и большими денежными потоками. " +
                "Также он часто работает в сфере психологии, спецслужб или полиции, где может использовать свою проницательность и расследовать скрытое. " +
                "Он волевой и прямой, но чувствует себя в большей безопасности, когда может скрыть свои действия. Как очень жизненный знак, Скорпион не может жить сам по себе, " +
                "но должен жить в обществе. В противном случае он может быть слишком подозрительным к окружающим и искать скрытые мотивы, " +
                "чрезмерный инстинкт собственности и стремление к власти также могут быть проблемой.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 7;
        }

        public void amburZodiac() // Стрелец // Sagittarius
        {
            zodiacEntry.Text = "Стрелец";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Sagittarius.png";
            zodiacDescribe.Text = "Знак Стрельца связан с общим мышлением, основными религиями и философиями." +
                "Ценит знания, как и противоположный знак Близнецы, но при этом добавляет измерение коллективизма. Стрелец много читает, обсуждает, " +
                "путешествует с удовольствием, его сопровождает неизгладимое стремление просвещать себя и других. Он может быть связан с туристическими агентствами, туризмом, правоохранительными органами, " +
                "высшее образование, иностранные языки, богословие. Часто предпочитает жить в сельской местности, потому что там больше места. " +
                "Его взгляд устремлен далеко в будущее, и он может не замечать житейских подробностей, но спотыкание поможет ему поднять свой оптимизм. " +
                "и желание продолжать. Стрелец любит правду и поэтому может быть откровенным до бестактности.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 8;
        }

        public void kaljukitsZodiac() // Козерог // Capricorn
        {
            zodiacEntry.Text = "Козерог";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Capricorn.png";
            zodiacDescribe.Text = "Во время зимнего солнцестояния в начале зимы Солнце астрологически отмечает знак Козерога. " +
                "Козерог энергичен и предприимчив, как и все знаки, начинающиеся в период солнцестояния, он амбициозен, " +
                "Прекрасно создает себе фундамент в жизни. Козерог лучше других знаков умеет планировать свою деятельность " +
                "и постоянно ожидает результатов своих усилий. Он трудолюбив и ценит только свой личный труд. " +
                "Козерог может чувствовать себя лучше с возрастом, так как характеристики этого знака лучше подходят для более зрелого возраста. " +
                "С другой стороны, он может сомневаться в себе и думать, что любовь нужно заслужить трудом. ";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 9;
        }

        public void veevalajaZodiac() // Водолей // Aquarius
        {
            zodiacEntry.Text = "Водолей";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Aquarius.png";
            zodiacDescribe.Text = "Знак Водолея связан с общими энергетическими полями, как с общими действиями, так и с мыслями. " +
                "Человек Водолей обычно рационален и объективен, способен оценивать ситуации со стороны и очень быстро реагировать в кризисные моменты." +
                "Друзья и единомышленники могут быть для него важнее семьи, и он часто очень активен в обществе. " +
                "Он чрезвычайно сообразителен, выступает за инновации и обычно не ценит традиции. " +
                "Водолей часто воспринимается как образ революционера. С другой стороны, он часто недееспособен. " +
                "Он также довольно строг в мышлении, считая свои идеи уникальными.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 10;
        }

        public void kaladZodiac() // Рыбы // Pisces
        {
            zodiacEntry.Text = "Рыбы";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Pisces.png";
            zodiacDescribe.Text = "Последний знак зодиака суммирует опыт всех предыдущих знаков. Рыбы обладают более сильным чувством целостности, чем другие знаки. " +
                "Они не придает слишком большого значения деталям, в худшем случае они могут даже уделять им слишком мало внимания. " +
                "Рыбы отличаются хорошим воображением, чувствительностью, альтруизмом, часто дружат с животными и природой или обладают художественными талантами. Их интуиция сильна. " +
                "У них может быть не так много энергии, потому что они также склонны брать на себя иностранные проблемы, часто глобальные." +
                "Из-за сильного чувства целостности им сложнее воспринимать границу между собой и другими. С другой стороны, Рыбы склонны потреблять больше, чем другие. " +
                "Предпочитают постоянно бежать от бед";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 11;
        }

        public void tyhiZodiac() // nothing
        {
            zodiacEntry.Text = "";
            zodiacImage.Source = "blank2.png";
            zodiacDescribe.Text = "Данные отсутствуют";
            zodiacDescribe.HorizontalTextAlignment = TextAlignment.Center;
            zodiacDescribe.TextColor = Color.Red;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            //chooseZodiacSign.Items.Clear();
            //addingDataToPicker();
            //chooseZodiacSign.SelectedIndex = 0;
            // https://localcoder.org/how-to-clear-picker-if-it-is-selected-in-xamarin-forms
        }

        public void addingDataToPicker()
        {
            chooseZodiacSign.Items.Add("Овен");
            chooseZodiacSign.Items.Add("Телец");
            chooseZodiacSign.Items.Add("Близнецы");
            chooseZodiacSign.Items.Add("Рак");
            chooseZodiacSign.Items.Add("Лев");
            chooseZodiacSign.Items.Add("Дева");
            chooseZodiacSign.Items.Add("Весы");
            chooseZodiacSign.Items.Add("Скорпион");
            chooseZodiacSign.Items.Add("Стрелец");
            chooseZodiacSign.Items.Add("Козерог");
            chooseZodiacSign.Items.Add("Водолей");
            chooseZodiacSign.Items.Add("Рыбы");
        }
    }
}
