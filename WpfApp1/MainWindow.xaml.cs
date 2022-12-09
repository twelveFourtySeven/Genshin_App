using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Characters> _savedCharacters = new List<Characters>();
        AddCharWindow myWindow = new AddCharWindow();
        public MainWindow()
        {
            
            InitializeComponent();
            characterList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myWindow.Show();
        }

        private void characterList()
        {
            
            var path = "C:\\Users\\User 1\\Desktop\\Genshin\\WpfApp1\\WpfApp1\\bin\\Debug\\net6.0-windows\\Saves.txt";
            System.IO.File.OpenRead(path);//opens the character list
            var lines = System.IO.File.ReadLines(path);//amount of lines
            var temp = System.IO.File.ReadAllLines(path);
            int count = 0;
            foreach(var line in lines)
            {
                var splittedChars = temp[count].Split(' ');//split spaces to correctly input the info into a list
                if (splittedChars.Length == 4)//characters with spacing in the name
                {
                    _savedCharacters.Add(new Characters($"{splittedChars[0]} {splittedChars[1]}", splittedChars[2], splittedChars[3]));
                }
                else
                {
                    _savedCharacters.Add(new Characters(splittedChars[0], splittedChars[1], splittedChars[2]));
                }
                count++;
            }
            foreach(Characters characters in _savedCharacters)
            {
                var temp_path = $"C:\\Users\\User 1\\Desktop\\Genshin\\WpfApp1\\WpfApp1\\bin\\Debug\\net6.0-windows\\Pictures\\{characters.Name}.png";
                characterListStackPanel.Children.Add(characterGridCreator(temp_path, characters.Name));
                
            }
        }

        private Grid characterGridCreator(string characterPicture, string characterName)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(3);
            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            Image characterImage = new Image();//input images
            var charImage = new ImageSourceConverter().ConvertFromString(characterPicture) as ImageSource;//converting string with location into the source
            characterImage.Source = charImage;
            Grid.SetColumn(characterImage,0);
            Button button = new Button();//button creation
            button.Click += (sender, EventArgs) => { Button_Click(sender, EventArgs, characterName); };
            button.Foreground = null;
            button.Background = null;
            button.BorderBrush = Brushes.LightGray;
            Grid.SetColumnSpan(button, 2);
            TextBlock charName = new TextBlock();
            charName.Text = characterName;
            charName.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(charName, 1);
            grid.Children.Add(characterImage);
            grid.Children.Add(charName);
            grid.Children.Add(button);
            return grid;
        }
        private void Button_Click(object sender, EventArgs e, string characterName)
        {

        }
    }
}
