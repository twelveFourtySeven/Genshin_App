using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddCharWindow.xaml
    /// </summary>
    public partial class AddCharWindow : Window
    {
        List<string> characters_input = new List<string>();
        List<Characters> _characters = new List<Characters>();
        public AddCharWindow()
        {
            InitializeComponent();
            OpenFileDialog readFile = new OpenFileDialog();
            var path = "Character_List.txt";//location
            readFile.FileName = path;
            var lines = File.ReadLines(path);//amount of lines
            File.OpenRead(path);//opens the character list
            var temp = File.ReadAllLines(path);//makes every line into a string, every character has a ddifferent number
            int count = 0;
            foreach (var line in lines)
            {
                var splittedChars= temp[count].Split(' ');//split spaces to correctly input the info into a list
                if (splittedChars.Length == 4)//characters with spacing in the name
                {
                    _characters.Add(new Characters($"{splittedChars[0]} {splittedChars[1]}", splittedChars[2], splittedChars[3]));
                }
                else
                {
                    _characters.Add(new Characters(splittedChars[0], splittedChars[1], splittedChars[2]));
                }
                count++;
            }
            foreach(Characters characters in _characters)
            {
                var temp_path = $"Pictures\\{characters.Name}.png";
                CharacterDisplay.Children.Add(GridCreator(temp_path, characters.Name));
            }
            
        }
        private Border GridCreator(string CharacterPicture, string CharacterName)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(1);
            border.Margin = new Thickness(5);
            border.BorderBrush = Brushes.Black;
            Grid grid = new Grid();//creating grid
            grid.Margin = new Thickness(5);           
            grid.Visibility = Visibility.Visible;
            RowDefinition row1 = new RowDefinition();//rows for the grid
            RowDefinition row2 = new RowDefinition();
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            Image characterImage = new Image();//input images
            var charImage = new ImageSourceConverter().ConvertFromString(CharacterPicture) as ImageSource;//converting string with location into the source
            characterImage.Source = charImage;//image settings
            characterImage.Height = 60;
            characterImage.Width = 60;
            characterImage.Stretch = Stretch.Fill;
            characterImage.VerticalAlignment = VerticalAlignment.Center;
            characterImage.HorizontalAlignment = HorizontalAlignment.Center;
            characterImage.Margin = new Thickness(5);
            characterImage.Visibility = Visibility.Visible;
            Grid.SetRow(characterImage, 0);//put iamges in place
            TextBlock charName = new TextBlock();
            charName.Text = CharacterName;
            charName.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(charName, 1);
            grid.Children.Add(characterImage);
            grid.Children.Add(charName);
            border.Child = grid;
            return border;

        }
    }
}
