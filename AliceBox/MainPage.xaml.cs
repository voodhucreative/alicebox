using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AliceBox.Helpers;
using AliceBox.Services;
using Plugin.SimpleAudioPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AliceBox
{
    public partial class MainPage : ContentPage
    {
        List<string> Dictionary;

        Grid PageContent;

        Label CurrentWord;
        Label TypeWriterWords;

        Image BackgroundImage;
        Image BackgroundImage2;
        Image AliceWordBig;
        Image AliceWordMedium;
        Image AliceWordSmall;
        Image TypeWriter;
        Image MainOnOffSwitch;
        Image LogOnOffSwitch;
        Image ViewOnOffSwitch;
        Image SpeechOnOffSwitch;
        //Image LogLabel;
        //Image ViewLabel;
        //Image TopPanel;
        Image BottomPanel;

        Image GreenLight;
        Image RedLight;
        Image OrangeLight;

        int LightStatus;
        int LightTickLimit;
        const int LIGHTS_OFF = 0;
        const int LIGHTS_ON = 1;
        const int GREEN_LIGHT_ON = 2;
        const int ORANGE_LIGHT_ON = 3;

        int CurrentEvent;
        int NextEvent;
        int LastEvent;
        int CurrentRoutine;
        DateTime StartTime;
        DateTime NextEventTime;
        DateTime CurrentTime;
        DateTime NextFogTime;

        StoppableTimer BrainTimer;
        StoppableTimer FogAnimTimer;
        StoppableTimer QuoteTimer;

        bool PerformingEvent;

        bool AliceOn;
        bool SpeechOn;
        bool LogOn;
        //bool ViewOn;

        //StackLayout ControlsLayout;
        Grid ControlsLayout;
        Grid TypeWriterContainer;
        Grid PanelLayout;
        StackLayout LogOnOffLayout;
        StackLayout ViewOnOffLayout;
        StackLayout PowerOnOffLayout;
        StackLayout SpeechOnOffLayout;

        ISimpleAudioPlayer AudioPlayer;

        bool FirstClick;

        int LightTick = 0;
        bool UseBeeper = false;

        List<string> LoggedWordsList;

        int WordMemory = 3;

        bool TypeWriterView;

        Image FogImage;
        int CurrentFogFrame = 0;
        bool FogStarted = false;
        float FogMaxOpacity = 0.5f;

        int FogFade = 0;
        int FOG_FADE_IN = 0;
        int FOG_FADE_OUT = 1;

        List<string> AliceQuotes = new List<string>();
        Label AliceQuote;
        int CurrentQuote = 0;
        bool QuotesStarted = false;
        float QuotesMaxOpacity = 0.25f;

        int QuoteFade = 0;
        int QUOTE_FADE_IN = 0;
        int QUOTE_FADE_OUT = 1;

        Label LogLabel;
        Label ViewLabel;
        Label PowerLabel;
        Label SpeechLabel;
        Label StatusLabel;


        int initialDelay = 12000;
        int decisionDelay = 1400;
        int aliceBrainDelay = 100;
        int fogAnimDelay = 50;
        int quoteDelay = 50;
        int beginDelay = 1700;

        int startDelay = 0;


        int statusFadeState = 0;

        bool Initialised = false;


        public enum AliceEvents
        {
            AliceLoad,
            AliceStartUp,
            AliceStandBy,
            AliceSwitchOn,
            AliceBegin,
            AliceEvent,
            AliceSplit,
            AliceRoutine,
            AliceRepeat,
            AliceFastLoop,
            AliceRestart,
            AliceSwitchOff
        };

        public string[] AliceEventNames =
        {
            "AliceLoad",
            "AliceStartUp",
            "AliceStandBy",
            "AliceSwitchOn",
            "AliceBegin",
            "AliceEvent",
            "AliceSplit",
            "AliceRoutine",
            "AliceRepeat",
            "AliceFastLoop",
            "AliceRestart",
            "AliceSwitchOff"
        };

        public Color[] Tints = 
        {
            Color.DarkBlue,
            Color.Purple,
            Color.DarkGreen,
            Color.DarkRed,
            Color.DarkOrchid
        };

        Grid BackgroundTint;

        public MainPage()
        {
            CurrentEvent = (int)AliceEvents.AliceLoad;
            Dictionary = PopulateDictionary();
            AliceQuotes = PopulateQuotes();
            
            CurrentRoutine = 0;

            LightStatus = LIGHTS_OFF;
            LightTickLimit = 1;
            startDelay = GetNextRandom(10000, 30000);

            AliceOn = false;
            LogOn = false;
            //ViewOn = true;
            SpeechOn = true;
            FirstClick = true;
            TypeWriterView = false;
            Initialised = false;

            AudioPlayer = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            MessagingCenter.Subscribe<object, string>(this, "WakeUp", (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    WakeyWakey();
                });
            });

            AliceQuote = new Label
            {
                Text = AliceQuotes[CurrentQuote],
                TextColor = Color.White,
                WidthRequest = Units.ScreenWidth*0.75,
                FontFamily= Fonts.GetBoldAppFont(),
                FontSize = Units.ScreenUnitL,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Opacity = 0
            };

            if (AliceQuote.FontSize > 32)
            {
                AliceQuote.FontSize = 32;
            }


            /*TopPanel = new Image
            {
                Source = "panel.png",
                WidthRequest = Units.ScreenWidth,
                HeightRequest = 200,
                Aspect = Aspect.Fill
            };*/

            BottomPanel = new Image
            {
                Source = "panel.png",
                WidthRequest = Units.ScreenWidth,
                HeightRequest = 140,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Aspect = Aspect.Fill
            };



            FogImage = new Image
            {
                Source = "fog_" + CurrentFogFrame + ".png",
                WidthRequest = Units.ScreenWidth,
                HeightRequest = Units.ScreenHeight,
                Aspect = Aspect.AspectFill

            };

            PageContent = new Grid
            {
                BackgroundColor = Color.FromHex("#0e1f2c"),
                WidthRequest = Units.ScreenWidth,
                HeightRequest = Units.ScreenHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            ControlsLayout = new Grid
            {
                WidthRequest = Units.ScreenWidth,
                HeightRequest = 92,
                ColumnSpacing = 16,
                Padding = new Thickness(24, 40, 24, 0),
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            TypeWriterContainer = new Grid
            {
                WidthRequest = 480,
                HeightRequest = 480,
                
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            LogOnOffLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Padding = new Thickness(0, 36, 0, 0)

            };

            ViewOnOffLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Padding = new Thickness(0, 36, 0, 0)
            };

            PowerOnOffLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Padding = new Thickness(0, 36, 0, 0)
            };

            SpeechOnOffLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Padding = new Thickness(0, 36, 0, 0)
            };

            BackgroundImage = new Image
            {
                Source = "alicebg1.png",
                WidthRequest = Units.ScreenWidth,
                HeightRequest = Units.ScreenHeight,
                Aspect = Aspect.AspectFill
            };

            int maxWidth = Units.ScreenWidth;
            int maxHeight = Units.ScreenHeight;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                maxWidth = Units.ThirdScreenWidth;
                maxHeight = Units.ScreenWidth;
            }

            BackgroundImage2 = new Image
            {
                Source = "book2.png",
                WidthRequest = maxWidth,
                HeightRequest = maxHeight,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Aspect = Aspect.AspectFit,
                Opacity = 0
            };


           

            AliceWordBig = new Image
            {
                Source = "alicebig.png",
                Aspect = Aspect.AspectFit,
                Opacity = 0,
                WidthRequest = 340,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            AliceWordMedium = new Image
            {
                Source = "alicemedium.png",
                //Aspect = Aspect.AspectFit,
                Opacity = 0,
                WidthRequest = 240,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            AliceWordSmall = new Image
            {
                Source = "alicesmall.png",
                Aspect = Aspect.AspectFit,
                Opacity = 0.5,
                WidthRequest = 64,
                //HeightRequest = 32,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TypeWriter = new Image
            {
                Source = "typewriter5.png",
                Aspect = Aspect.AspectFit,
                Opacity = 0,
                WidthRequest = 480,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            MainOnOffSwitch = new Image
            { 
                Source = "off.png",
                HeightRequest = 64,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Opacity = 0.8
            };

            SpeechOnOffSwitch = new Image
            {
                Source = "off.png",
                HeightRequest = 64,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Opacity = 0.8
            };

            LogOnOffSwitch = new Image
            {
                Source = "off.png",
                HeightRequest = 64,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Opacity = 0.8
            };

            ViewOnOffSwitch = new Image
            {
                Source = "off.png",
                HeightRequest = 64,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Opacity = 0.8
            };

            ViewLabel = new Label
            {
                Text = "VIEW",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 16,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.LightGray
            };

            LogLabel = new Label
            {
                Text = "LOG",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 16,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.LightGray
            };

            StatusLabel = new Label
            {
                Text = "        ",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.Start,
                FontSize = 13,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.LightGray
            };

            SpeechLabel = new Label
            {
                Text = "TALK",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 16,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.LightGray
            };


            PowerLabel = new Label
            {
                Text = "POWER",
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 16,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.LightGray
            };

            /*
            LogLabel = new Image
            {
                Source = "loglabel.png",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            ViewLabel = new Image
            {
                Source = "viewlabel.png",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };*/

            GreenLight = new Image
            {
                Source = "greylight1.png",
                Opacity = 0.75,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 48,
                HeightRequest = 48
            };

            RedLight = new Image
            {
                Source = "greylight1.png",
                Opacity = 0.75,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 48,
                HeightRequest = 48
            };

            OrangeLight = new Image
            {
                Source = "greylight1.png",
                Opacity = 0.75,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = 48,
                HeightRequest = 48
            };

            MainOnOffSwitch.GestureRecognizers.Add(
                   new TapGestureRecognizer()
                   {
                       Command = new Command(() =>
                       {
                           Device.BeginInvokeOnMainThread(async () =>
                           {
                               ToggleMainOnOff();
                           });
                       })
                   }
               );

            LogOnOffSwitch.GestureRecognizers.Add(
                   new TapGestureRecognizer()
                   {
                       Command = new Command(() =>
                       {
                           Device.BeginInvokeOnMainThread(async () =>
                           {
                               ToggleLogOnOff();
                           });
                       })
                   }
               );

            ViewOnOffSwitch.GestureRecognizers.Add(
                   new TapGestureRecognizer()
                   {
                       Command = new Command(() =>
                       {
                           Device.BeginInvokeOnMainThread(async () =>
                           {
                               ToggleViewOnOff();
                           });
                       })
                   }
               );

            SpeechOnOffSwitch.GestureRecognizers.Add(
                   new TapGestureRecognizer()
                   {
                       Command = new Command(() =>
                       {
                           Device.BeginInvokeOnMainThread(async () =>
                           {
                               ToggleSpeechOnOff();
                           });
                       })
                   }
               );

            CurrentWord = new Label
            {
                Text = "",
                FontSize = 28,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.White,
                Opacity = 0.75,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment =  TextAlignment.Center,
                VerticalOptions = LayoutOptions.End,
                VerticalTextAlignment = TextAlignment.End
            };

            TypeWriterWords = new Label
            {
                Text = "",
                FontSize = 24,
                FontFamily = Fonts.GetBoldAppFont(),
                TextColor = Color.Black,
                Opacity = 0.75,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.End,
                VerticalTextAlignment = TextAlignment.End
            };


            LogOnOffLayout.Children.Add(LogOnOffSwitch);
            LogOnOffLayout.Children.Add(LogLabel);

            ViewOnOffLayout.Children.Add(ViewOnOffSwitch);
            ViewOnOffLayout.Children.Add(ViewLabel);

            PowerOnOffLayout.Children.Add(MainOnOffSwitch);
            PowerOnOffLayout.Children.Add(PowerLabel);

            SpeechOnOffLayout.Children.Add(SpeechOnOffSwitch);
            SpeechOnOffLayout.Children.Add(SpeechLabel);

            ControlsLayout.Children.Add(new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                WidthRequest = 80,
                HeightRequest = 32,
                HorizontalOptions = LayoutOptions.Start,
                Spacing = 0,
                Padding = 0,//new Thickness(0, 8),
                Children =
                {
                    //OrangeLight,
                    //GreenLight
                }
            }, 0, 0);
            //ControlsLayout.Children.Add(MainOnOffSwitch, 5, 0);

            TypeWriterContainer.Children.Add(TypeWriter, 0, 0);
            TypeWriterContainer.Children.Add(TypeWriterWords, 0, 0);
            TypeWriterWords.TranslateTo(0, -280, 0, null);


            Grid ControlsPanel = new Grid
            {
                Padding = new Thickness(0, 16, 0, 32)
            };

            StackLayout switches = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.End,
                WidthRequest = Units.ThirdScreenWidth,
                Children =
                {
                    LogOnOffLayout,
                    ViewOnOffLayout
                }

            };

            StackLayout power = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.End,
                WidthRequest = Units.ThirdScreenWidth,
                Children =
                {
                    SpeechOnOffLayout,
                    PowerOnOffLayout
                }
            };

            StackLayout lightsPanel = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Padding = new Thickness(0, 4, 0, 0),
                Children =
                {
                    AliceWordSmall,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            OrangeLight,
                            GreenLight
                        }
                    },
                    StatusLabel
                }
            };

            StackLayout lights = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                WidthRequest = Units.ThirdScreenWidth,
                Padding = new Thickness(0, 32, 0, 0),
                //BackgroundColor = Color.Black,

                Children =
                {
                    lightsPanel
                }
            };

            

            ControlsPanel.Children.Add(switches, 0, 0);
            ControlsPanel.Children.Add(lights, 1, 0);
            ControlsPanel.Children.Add(power, 2, 0);
            

            StackLayout ContentContainer = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                Padding = new Thickness(0, 16),
                Children =
                {
                    ControlsLayout,
                    CurrentWord,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        HeightRequest = 132,
                        Padding = 16,
                        Children =
                        {
                            ControlsPanel
                        }
                    }
                   
                }
            };

            PanelLayout = new Grid
            {
                WidthRequest = Units.ScreenWidth,
                HeightRequest = Units.ScreenHeight,
                Opacity = 1
            };

            //PanelLayout.Children.Add(TopPanel, 0, 0);
            PanelLayout.Children.Add(BottomPanel, 0, 5);


            BackgroundTint = new Grid
            {
                BackgroundColor = Tints[(int)GetNextRandom(Tints.Length - 1)],
                WidthRequest = Units.ScreenWidth,
                HeightRequest = Units.ScreenHeight,
                Opacity = 0.15
            };

            PageContent.VerticalOptions = LayoutOptions.EndAndExpand;
            PageContent.Children.Add(BackgroundImage, 0, 0);
            PageContent.Children.Add(BackgroundTint, 0, 0);

            PageContent.Children.Add(FogImage, 0, 0);
            PageContent.Children.Add(BackgroundImage2, 0, 0);
            PageContent.Children.Add(AliceWordMedium, 0, 0);

            PageContent.Children.Add(PanelLayout, 0, 0);
            

            PageContent.Children.Add(TypeWriterContainer, 0, 0);
            PageContent.Children.Add(AliceQuote, 0, 0);
            PageContent.Children.Add(ContentContainer, 0, 0);



            //AliceWordMedium.TranslateTo(0, -272, 0, Easing.Linear);
            TypeWriter.TranslateTo(0, 24, 0, Easing.Linear);
           

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                AliceWordMedium.TranslateTo(0, -346, 0, Easing.Linear);
                BackgroundImage2.TranslateTo(0, -280, 0, Easing.Linear);
            }
            else
            {
                AliceWordMedium.TranslateTo(0, -296, 0, Easing.Linear);
                BackgroundImage2.TranslateTo(0, -100, 0, Easing.Linear);
            }

            BrainTimer = new StoppableTimer(TimeSpan.FromMilliseconds(aliceBrainDelay), TimedUpdate, true);
            FogAnimTimer = new StoppableTimer(TimeSpan.FromMilliseconds(fogAnimDelay), FogUpdate, true);
            QuoteTimer = new StoppableTimer(TimeSpan.FromMilliseconds(quoteDelay), QuoteUpdate, true);

            StatusLabel.TranslateTo(0, -6, 0, null);
            StopFog();
            StartQuotes();
            StartFog();
            UpdateElements();

            BackgroundImage.Source = "alicebg3.png";

            this.Content = PageContent;
        }

        public void SetAliceState(int aliceState)
        {
            CurrentEvent = (int)aliceState;
            Console.WriteLine("ALICE STATE: " + AliceEventNames[CurrentEvent]);
        }

        public void SkipIntro()
        {

        }

        public void StartQuotes()
        {
            if (!QuotesStarted)
            {
                Console.WriteLine("QUOTES STARTED");
                QuotesMaxOpacity = 0.25f;
                QuoteTimer.Start();
                QuotesStarted = true;
                CurrentQuote = 0;
            }
        }

        public void StopQuotes()
        {
            QuoteTimer.Stop();
            QuotesStarted = false;
            CurrentQuote = 0;
            AliceQuote.Opacity = 0;
        }


        public void StartFog()
        {
            if (!FogStarted)
            {
                Console.WriteLine("FOG STARTED");
                FogMaxOpacity = (float)GetRandomFogOpacity();
                FogAnimTimer.Start();
                FogStarted = true;
            }
        }

        public void StopFog()
        {
            FogAnimTimer.Stop();
            FogStarted = false;
            CurrentFogFrame = 0;
            FogImage.Opacity = 0;
        }

        public void SwitchOn()
        {
            //PlaySound("switch");
            BackgroundTint.BackgroundColor = Tints[(int)GetNextRandom(Tints.Length - 1)];
            StopQuotes();
            SwitchOnLights();

            TypeWriterView = true;

            if (GetNextRandom(10) > 5)
            {
                TypeWriterView = false;
            }

            if (TypeWriterView)
            {
                SetTypewriterBackground(true);
            }
            else
            {
                SetAliceBackground(true);
            }

            LightTickLimit = 10;


            startDelay = startDelay = GetNextRandom(10000, 30000);
            StartTime = DateTime.Now;
            CurrentTime = DateTime.Now;
            NextEventTime = StartTime.AddMilliseconds(initialDelay + startDelay);
            NextFogTime = DateTime.Now.AddSeconds(10);


            Console.WriteLine("StartTime: " + StartTime.ToLongTimeString());
            Console.WriteLine("NextEventTime: " + NextEventTime.ToLongTimeString());

            BrainTimer.Start();
            SetAliceState((int)AliceEvents.AliceStartUp);

            Restart();
        }

        public void SwitchOff()
        {
            if (FirstClick)
            {
                FirstClick = false;
            }
            else
            {
                //PlaySound("switch");
            }

            AliceWordMedium.Opacity = 0;

            

            if (LogOn)
            {
                CreateLog();
                DisplayAlert("Session Logged", "Your session has been saved to your device's clipboard. You can now paste this into an email, message, document or wherever you choose. Simply open up the app you'd like to use, then press and hold in a text area to bring up the option to paste your session.", "Ok");
            }

            StatusLabel.Text = "        ";
            CurrentWord.Text = "";

            if (LoggedWordsList != null)
            {
                LoggedWordsList.Clear();
            }

            TypeWriterWords.Text = CurrentWord.Text;
            SwitchOffLights();

            if (TypeWriterView)
            {
                SetTypewriterBackground(false);
            }
            else
            {
                SetAliceBackground(false);
            }

            BrainTimer.Stop();
            Initialised = false;
            //FogAnimTimer.
            //QuoteTimer
            StopFog();
            StartQuotes();
            
        }

        public void AlternateLights()
        {
            if (LightStatus == ORANGE_LIGHT_ON)
            {
                LightStatus = GREEN_LIGHT_ON;
            }
        }

        public void SwitchOnLights()
        {
            LightStatus = LIGHTS_ON;

            UpdateLights();
        }

        public void SwitchOffLights()
        {
            LightStatus = LIGHTS_OFF;
            UpdateLights();
        }

        public List<string> PopulateQuotes()
        {
            List<string> quotes = new List<string>();

            quotes.Add("WHY, SOMETIMES I'VE BELIEVED AS MANY AS SIX IMPOSSIBLE THINGS BEFORE BREAKFAST...");
            quotes.Add("WHY IS A RAVEN LIKE A WRITING DESK?");
            quotes.Add("WHO'S THERE?");
            quotes.Add("IT'S A POOR SORT OF MEMORY THAT ONLY WORKS BACKWARDS");
            quotes.Add("WHO IN THE WORLD AM I? AH, THAT'S THE GREAT PUZZLE");
            quotes.Add("CURIOUSER AND CURIOUSER!");
            quotes.Add("SWEET DISCOURSE MAKES SHORT DAYS AND NIGHTS");
            quotes.Add("WE'RE ALL MAD HERE...");
            quotes.Add("GOODBYE");

            return quotes;
        }

        public List<string> PopulateDictionary()
        {
            List<string> dictionary = new List<string>();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("words.txt") || res.Contains("words1.txt"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);

                    using (var reader = new StreamReader(stream))
                    {
                        string data = "";
                        while ((data = reader.ReadLine()) != null)
                        {
                            dictionary.Add(data);
                        }
                    }
                }
            }
            return dictionary;
        }

        public double GetNextRandom(int num)
        {
            Random rand = new Random();

            return rand.Next(0, num);
        }

        public float GetRandomFogOpacity()
        {
            var randFogOpacity = new Random().NextDouble() * 1;

            if (randFogOpacity > 0.6)
            {
                randFogOpacity = 0.6;
            }
            else
            {
                randFogOpacity = 0.2;
            }
            return (float)randFogOpacity;
        }

        public int GetNextRandom(int min, int max)
        {
            Random rand = new Random();

            return (int)rand.Next(min, max);
        }

        public void TimedUpdate()
        {
            Tick();
        }

        public void FogUpdate()
        {
            if (FogFade == FOG_FADE_IN)
            {
                if (FogImage.Opacity < FogMaxOpacity)
                {
                    FogImage.Opacity += 0.005;
                }
                else
                {
                    FogMaxOpacity = (float)GetRandomFogOpacity();
                    if (GetNextRandom(10) < 5)
                    {
                        FogFade = FOG_FADE_OUT;
                    }
                }
            }
            else
            {
                if (FogImage.Opacity > 0)
                {
                    FogImage.Opacity -= 0.005;
                }
                else
                {
                    FogFade = FOG_FADE_IN;

                    if (GetNextRandom(10) < 8)
                    {
                        StopFog();
                        return;
                    }
                }
            }
            
            if (CurrentFogFrame < 59)
            {
                CurrentFogFrame++;
            }
            else
            {
                CurrentFogFrame = 0;
                
            }
            FogImage.Source = "fog_" + CurrentFogFrame + ".png";
        }

        public void QuoteUpdate()
        {
            if (QuoteFade == QUOTE_FADE_IN)
            {
                if (AliceQuote.Opacity < QuotesMaxOpacity)
                {
                    AliceQuote.Opacity += 0.0025;
                }
                else
                {
                    //QuotesMaxOpacity = (float)GetRandomFogOpacity();
                    if (GetNextRandom(100) > 95)
                    {
                        QuoteFade = QUOTE_FADE_OUT;
                    }
                }
            }
            else
            {
                if (AliceQuote.Opacity > 0)
                {
                    AliceQuote.Opacity -= 0.01;
                }
                else
                {
                    if (GetNextRandom(100) > 95)
                    {
                        if (CurrentQuote < AliceQuotes.Count - 2)
                        {
                            CurrentQuote++;
                        }
                        else
                        {
                            CurrentQuote = 0;
                        }
                        AliceQuote.Text = AliceQuotes[CurrentQuote];
                        QuoteFade = QUOTE_FADE_IN;
                        StartFog();
                    }

                    //if (GetNextRandom(10) < 8)
                    //{
                    //    StopQuotes();
                    //    return;
                    //}
                }
            }

            
        }

        public void Restart()
        {
            // BACK TO THE BEGINNING
            Console.WriteLine("BACK TO THE BEGINNING");
            SetAliceState((int)AliceEvents.AliceBegin);
        }

        
        public bool Tick()
        {
            CurrentTime = DateTime.Now;

            if (!FogStarted)
            {
                if (CurrentTime > NextFogTime)
                {
                    StartFog();
                    NextFogTime = CurrentTime.AddSeconds(GetNextRandom(30));
                }
            }
      
             
            if ((CurrentTime > NextEventTime) && CurrentTime > StartTime.AddMilliseconds(initialDelay))
            {
                Console.WriteLine("NextEventTime: " + DateTime.Now);
                switch (CurrentEvent)
                {
                    case (int)AliceEvents.AliceLoad:
                        break;
                    case (int)AliceEvents.AliceStartUp:

                        break;
                    case (int)AliceEvents.AliceStandBy:
                        break;
                    case (int)AliceEvents.AliceSwitchOn:

                        break;
                    case (int)AliceEvents.AliceBegin:
                        NextEventTime = CurrentTime.AddMilliseconds(beginDelay);
                        SetAliceState((int)AliceEvents.AliceEvent);
                        break;
                    case (int)AliceEvents.AliceEvent:
                        if (GetNextRandom(50) > 47)
                        {
                            SetAliceState((int)AliceEvents.AliceSplit);
                        }
                        else
                        {
                            SetAliceState((int)AliceEvents.AliceBegin);
                        }
                        break;  
                    case (int)AliceEvents.AliceSplit:
                        if (GetNextRandom(10) > 5)
                        {
                            CurrentRoutine = 1;
                        }
                        else
                        {
                            CurrentRoutine = 0;
                        }
                        NextEventTime = CurrentTime.AddMilliseconds(decisionDelay);
                        SetAliceState((int)AliceEvents.AliceRoutine);
                        break;
                    case (int)AliceEvents.AliceRoutine:
                        Speak(GetWord());

                        if (GetNextRandom(10) > 7)
                        {
                            SetAliceState((int)AliceEvents.AliceFastLoop);
                        }
                        else
                        {
                            SetAliceState((int)AliceEvents.AliceRepeat);
                        }
                        break;
                    case (int)AliceEvents.AliceRepeat:
                        SetAliceState((int)AliceEvents.AliceBegin);
                        break;
                    case (int)AliceEvents.AliceFastLoop:
                        if (GetNextRandom(10) > 5)
                        {
                            CurrentRoutine = 1;
                        }
                        else
                        {
                            CurrentRoutine = 0;
                        }
                        NextEventTime = CurrentTime.AddMilliseconds(decisionDelay);
                        SetAliceState((int)AliceEvents.AliceRoutine);
                        break;
                    case (int)AliceEvents.AliceRestart:
                        break;
                    case (int)AliceEvents.AliceSwitchOff:
                        break;
                }
            }

            if (LightStatus == LIGHTS_ON)
            {
                if (Initialised)
                {
                    LightTickLimit = 30;
                    StatusLabel.Text = "connected";
                }
                else
                {
                    //StatusLabel.Text = "preparing";
                    //StatusLabel.Text = "settling";
                    LightTickLimit = 90;
                    StatusLabel.Text = "settling";
                }
                StatusLabel.Opacity = 0.8;
            }
            else
            {
                Initialised = true;
                StatusLabel.Text = "seeking";
                if (statusFadeState == 0) // fade in
                {
                    if (StatusLabel.Opacity < 0.8)
                    {
                        StatusLabel.Opacity += 0.1;
                    }
                    else
                    {
                        statusFadeState = 1;
                    }
                }
                else
                {
                    if (StatusLabel.Opacity > 0.0)
                    {
                        StatusLabel.Opacity -= 0.1;
                    }
                    else
                    {
                        statusFadeState = 0;
                    }
                }
                LightTickLimit = 3;
            }

            LightTick++;

            if (LightTickLimit == 90)
            {
                if (LightTick > 30)
                {
                    StatusLabel.Text = "settling";
                    //StatusLabel.Text = "seeking";
                }
            }

            if(LightTick > LightTickLimit)
            {
                LightTick = 0;

                if (LightStatus == LIGHTS_ON)
                {
                    LightStatus = ORANGE_LIGHT_ON;
                }

                UpdateLights();
            }

            return true;
        }

        public string GetWord()
        {
            int min = 0;
            int max = Dictionary.Count;

            if (CurrentRoutine == 0)
            {
                min = 0;
                max = Dictionary.Count / 2;
            }
            else
            {
                min = Dictionary.Count / 2;
                max = Dictionary.Count;
            }
            return Dictionary[GetNextRandom(min, max)];
        }

        public string GetLoggedWords(int limit)
        {
            string loggedWords = "";
            int start = 0;
            int end = 0;

            if (LoggedWordsList.Count <= limit)
            {
                foreach (string word in LoggedWordsList)
                {
                    loggedWords += word + "\n";
                }
            }
            else
            {
                end = LoggedWordsList.Count-1;
                start = end - (limit-1);

                int count = 0;
                foreach (string word in LoggedWordsList)
                {
                    if (count >= start && count <= end)
                    {
                        loggedWords += word + "\n";
                    }
                    count++;
                }
            }
            
            return loggedWords;
        }

        public void WakeyWakey()
        {
            //Speak("Wakey Wakey");
        }

        public void Speak(string word)
        {
            if (LoggedWordsList == null)
            {
                LoggedWordsList = new List<string>();
            }
            string toSpeak = word.ToUpper();
            LoggedWordsList.Add(toSpeak);


            SwitchOnLights();
            UpdateLights();

            Device.BeginInvokeOnMainThread(async () =>
            {

                PlaySound("beep");

                await Task.Delay(1750);

                CurrentWord.Text = GetLoggedWords(WordMemory);
                TypeWriterWords.Text = CurrentWord.Text;

                if (SpeechOn)
                {
                    await TextToSpeech.SpeakAsync(toSpeak);

                }

                Console.WriteLine(toSpeak);


            });
        }

        public void ToggleMainOnOff()
        {
            AliceOn = !AliceOn;
            PlaySound("switch");
            if (AliceOn)
            {
                SwitchOn();
            }
            else
            {
                SwitchOff();
            }
            UpdateElements();
        }

        public void ToggleLogOnOff()
        {
            if (AliceOn)
            {
                PlaySound("switch_light");
                LogOn = !LogOn;

                if (LogOn)
                {
                    DisplayAlert("Logging Enabled", "The session will now be logged.", "Ok");

                }
                else
                {
                    if (LoggedWordsList != null)
                    {
                        LoggedWordsList.Clear();
                        DisplayAlert("Logging Disabled", "The log has been cleared.", "Ok");
                    }
                }

                UpdateElements();
            }
        }

        public void ToggleViewOnOff()
        {
            if (AliceOn)
            {
                PlaySound("switch_light");
                TypeWriterView = !TypeWriterView;

                UpdateElements();

                if (TypeWriterView)
                {
                    SetAliceBackground(false);
                    SetTypewriterBackground(false);
                    SetTypewriterBackground(true);
                }
                else
                {
                    SetTypewriterBackground(false);
                    SetAliceBackground(false);
                    SetAliceBackground(true); 
                }

                
            }
        }

        public void ToggleSpeechOnOff()
        {
            if (AliceOn)
            {
                PlaySound("switch_light");
                SpeechOn = !SpeechOn;

                UpdateElements();
            }
        }


        public void UpdateElements()
        {
            if (AliceOn)
            {
                MainOnOffSwitch.Source = "on.png";
                PowerLabel.Opacity = 0.8;
                StatusLabel.Opacity = 0.8;
                ViewLabel.Opacity = 0.8;
                LogOnOffSwitch.Opacity = 0.8;

                ViewOnOffSwitch.Opacity = 0.8;

                SpeechOnOffSwitch.Opacity = 0.8;

                if (LogOn)
                {
                    LogOnOffSwitch.Source = "on.png";
                    LogLabel.Opacity = 0.8;
                }
                else
                {
                    LogOnOffSwitch.Source = "off.png";
                    LogLabel.Opacity = 0.25;
                }

                if (TypeWriterView)
                {
                    ViewOnOffSwitch.Source = "on.png";
                    //ViewLabel.Opacity = 0.8;

                }
                else
                {
                    ViewOnOffSwitch.Source = "off.png";
                    //ViewLabel.Opacity = 0.25;
                }

                if (SpeechOn)
                {
                    SpeechOnOffSwitch.Source = "on.png";
                    SpeechLabel.Opacity = 0.8;
                }
                else
                {
                    SpeechOnOffSwitch.Source = "off.png";
                    SpeechLabel.Opacity = 0.25;
                }
            }
            else
            {
                MainOnOffSwitch.Source = "off.png";

                PowerLabel.Opacity = 0.25;
                StatusLabel.Opacity = 0.25;

                LogOnOffSwitch.Opacity = 0.25;
                LogLabel.Opacity = 0.25;

                ViewOnOffSwitch.Opacity = 0.25;
                ViewLabel.Opacity = 0.25;

                SpeechOnOffSwitch.Opacity = 0.25;
                SpeechLabel.Opacity = 0.25;
            }

            
        }

        public void UpdateLights()
        {
            switch (LightStatus)
            {
                case LIGHTS_ON:
                    OrangeLight.Source = "orangelight1.png";
                    GreenLight.Source = "greenlight1.png";
                    break;
                case LIGHTS_OFF:
                    OrangeLight.Source = "greylight1.png";
                    GreenLight.Source = "greylight1.png";
                    break;
                case GREEN_LIGHT_ON:
                    OrangeLight.Source = "greylight1.png";
                    GreenLight.Source = "greenlight1.png";
                    LightStatus = ORANGE_LIGHT_ON;
                    break;
                case ORANGE_LIGHT_ON:
                    OrangeLight.Source = "orangelight1.png";
                    GreenLight.Source = "greylight1.png";
                    LightStatus = GREEN_LIGHT_ON;
                    break;
            }
        }

        public void PlaySound(string file)
        {
            try
            {
                AudioPlayer.Load(file + ".mp3");

                AudioPlayer.Play();
            }
            catch (Exception e)
            {

            }
        }

        public void SetAliceBackground(bool show)
        {
            TypeWriterContainer.Opacity = 0;
            CurrentWord.Opacity = 1;
            WordMemory = 3;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (show)
                {
                    await AliceWordMedium.FadeTo(0.125, 250, Easing.Linear);
                    await BackgroundImage2.FadeTo(0.125, 250, Easing.Linear);
                }
                else
                {
                    await BackgroundImage2.FadeTo(0, 250, Easing.Linear);
                    //await AliceWordMedium.FadeTo(0, 250, Easing.Linear);
                }
            });

        }

        public void SetTypewriterBackground(bool show)
        {
            TypeWriterContainer.Opacity = 1;
            CurrentWord.Opacity = 0;
            WordMemory = 3;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (show)
                {
                    await AliceWordMedium.FadeTo(0.125, 250, Easing.Linear);
                    await TypeWriter.FadeTo(0.35, 250, Easing.Linear);
                }
                else
                {
                    await TypeWriter.FadeTo(0, 250, Easing.Linear);
                    //await AliceWordMedium.FadeTo(0, 250, Easing.Linear);
                }
            });

        }




        public void CreateLog()
        {
            string wordList = "";

            wordList +=
                "Alice Session Log\n\n" +
                "Date: " +
                DateTime.Now.ToLongDateString() +
                "\n" +
                "Time: " +
                DateTime.Now.ToShortTimeString() +
                "\n\n" + "Alice received the following:\n";


            if (LoggedWordsList != null)
            {
                foreach (string word in this.LoggedWordsList)
                {
                    wordList += word + "\n";
                }
            }
            Clipboard.SetTextAsync(wordList);


            /*
            if (ClipBoardListNameOnly != null)
            {
                ClipBoardListNameOnly.Clear();
            }

            ClipBoardListNameOnly = new List<string>();

            string ingredientsList = "";

            int sublistid = 0;

            foreach (List<Ingredient> sublist in OrderedList)
            {
                if (sublist.Count > 0)
                {
                    if (includeHeading)
                    {
                        ingredientsList += OrderedTypes[sublistid].ToUpper() + "\n";
                    }
                    foreach (Ingredient i in sublist)
                    {
                        ingredientsList += i.getDisplayName(false, copyAmounts, true, false) + "\n";
                    }
                }
                sublistid++;
            }

            sublistid = 0;
            string substring = "";
            string substring2 = "";

            if (ActiveStockCupboardList.Count > 0)
            {
                foreach (List<Ingredient> sublist in CupboardOrderedList)
                {
                    substring = "";
                    substring2 = "";
                    if (sublist.Count > 0)
                    {
                        if (includeHeading)
                        {
                            substring = CupboardOrderedTypes[sublistid].ToUpper() + "\n";
                        }
                        foreach (Ingredient i in sublist)
                        {
                            if (i.Bought || i.StockItemState == Constants.STOCK_ITEM_STATE_ONLIST)
                            {
                                substring2 = i.getDisplayName(false, copyAmounts, true, false) + "\n";
                            }
                        }
                        if (substring2 != "" && includeHeading)
                        {
                            ingredientsList += (substring + substring2);
                        }
                        else
                        {
                            ingredientsList += substring2;
                        }
                    }
                    sublistid++;
                }
            }

            if (ExtrasList.Count > 0)
            {
                ingredientsList += "\n EXTRA ITEMS LIST \n";
                foreach (Ingredient ingredient in ExtrasList)
                {
                    ClipBoardListNameOnly.Add(ingredient.Name);

                    ingredientsList += ingredient.getDisplayName(false, copyAmounts, false, false) + "\n";
                }
            }

            Clipboard.SetTextAsync(ingredientsList);
            */
        }

    }
}
