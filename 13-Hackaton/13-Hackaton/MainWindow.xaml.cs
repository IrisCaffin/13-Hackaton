﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpeechDictionary.Core.Services;
using SpeechDictionary.Domain;

namespace _13_Hackaton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            // The user click the findButton to generate a definition
            string userWord = findWordTextBox.Text;

            Definition definition = DictionaryService.GetDefinition(userWord);

            definitionTextBlock.Text = definition.text + Environment.NewLine + Environment.NewLine + definition.attribution;
        }


        private void randomWordButton_Click(object sender, RoutedEventArgs e)
        {
            // For educational purposes the user can click on the randomWordButton to learn more
            // The results of the randomWordButton will be displayed in the findWordTextBox and the user clicks FIND, etc.

        }

        private void talkButton_Click(object sender, RoutedEventArgs e)
        {
           // The user can click on the talkButton so that whatever is displayed in the definitionTextBlock is read out loud
           // Not sure if DictionaryService and RandomWordService need to be dealt with separately for display purposes
            SpeechService.Speak(findWordTextBox.Text);
            SpeechService.Speak(definitionTextBlock.Text);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // If the user wants to try another word s/he can click the clearButton to reset
        }

    }
}
