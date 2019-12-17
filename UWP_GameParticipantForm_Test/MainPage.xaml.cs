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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

/// <summary>
/// Author: Hannah Seccia
/// Date: December 16, 2019
/// Description: A .NET C# (UWP) application that simulates a registration page for a video game tournament
/// </summary>

namespace UWP_GameParticipantForm_Test
{
    
    public sealed partial class MainPage : Page
    {
        private string tempUsername;                                //declared as "global" variables
        private string tempPlayerName;
        private string tempMainGame;
        private int tempAge;
        private int personIndex = 0;
        public List<Person> participants = new List<Person>();
        private ListView participantsListView = new ListView();

        public class Person
        {
            public Person()
            {

            }

            private string username;
            private string playerName;
            private string mainGame;
            private int age;


            public void setUsername(string n)
            {
                username = n;
            }

            public string getUsername()
            {
                return username;
            }

            public void setPlayerName(string n)
            {
                playerName = n;
            }

            public string getPlayerName()
            {
                return playerName;
            }

            public void setMainGame(string g)
            {
                mainGame = g;
            }

            public string getMainGame()
            {
                return mainGame;
            }
            public void setAge(int a)
            {
                age = a;
            }

            public int getAge()
            {
                return age;
            }
        }


        public void usernameFilled(object sender, TextChangedEventArgs e)           //attached to a TextChanged event handler in the XAML code
        {
            tempUsername = Username.Text;

        }

        public void playerNameFilled(object sender, TextChangedEventArgs e)      //attached to a TextChanged event handler in the XAML code
        {
            tempPlayerName = PlayerLastName.Text;
        }


        public async void GameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)  //attached to a SelectionChanged event handler in the XAML code
        {
            string gameSelection = MainGame.SelectedItem.ToString();
            switch (gameSelection)
            {
                case "Super Smash Bros Ultimate":
                    tempMainGame = "Super Smash Bros Ultimate";
                    break;
                case "Mortal Kombat X":
                    tempMainGame = "Mortal Kombat X";
                    break;
                case "King of Fighters XIV":
                    tempMainGame = "King of Fighters XIV";
                    break;
                case "Street Fighter IV":
                    tempMainGame = "Street Fighter IV";
                    break;
            }
        }

        public async void ageFilled(object sender, TextChangedEventArgs e)           //attached to a TextChanged event handler in the XAML code
        {
            if (Age.Text != "")         //prevents crashing from an empty field
            {
                tempAge = Convert.ToInt32(Age.Text);
            }

        }

        public void initUserInfo(string tempUN, string tempPN, string tempMG, int age)
        {
            Person newUser = new Person();                                      //create a new user
            newUser.setUsername(tempUsername);
            newUser.setPlayerName(tempPlayerName);
            newUser.setMainGame(tempMainGame);
            newUser.setAge(tempAge);
            participants.Add(newUser);                                          //add user to list
            participantsListView.Items.Add(participants[personIndex].getUsername() + ", " + participants[personIndex].getPlayerName() + ", " + participants[personIndex].getMainGame() + ", " + participants[personIndex].getAge().ToString()); //concatonate to display on the listView
           

            //Debug.WriteLine(participants[personIndex].getUsername());
            //Debug.WriteLine(participants[personIndex].getPlayerName());
            //Debug.WriteLine(participants[personIndex].getMainGame());
            //Debug.WriteLine(participants[personIndex].getAge().ToString());

            personIndex++;                                                     

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();                                 //code for speech
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Profile saved!");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();                                                            //
            initUserInfo(tempUsername, tempPlayerName, tempMainGame, tempAge);              

        }

        public MainPage()
        {
            this.InitializeComponent();
            List.Children.Add(participantsListView);                                        //attach the participant list to the listView
        }
    }
}
