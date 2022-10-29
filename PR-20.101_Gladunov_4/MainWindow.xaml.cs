using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PR_20._101_Gladunov_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_result_Click(object sender, RoutedEventArgs e)
        {
            TextBox_output.Clear();
            if (Regex.IsMatch(TextBox_input.Text, "^[a-zA-Z0-9. -_?]*$")) // Проверка на ввод английского языка + пробелы и прочие символы
            {
                string str = Convert.ToString(TextBox_input.Text);

                string pattern = @"\s+";   // шаблон для поиска подряд идущих пробелов

                string probel = " ";  // пробел, на который мы будем заменять наши длинные пробелы

                Regex regex = new Regex(pattern); // по какому шаблону должно действовать регулярное выражение

                string result_str = regex.Replace(str, probel); // поиск и замена пробелов

                string STR = " \r\n\t";
                var sb = new StringBuilder(result_str);
                if (sb.Length > 0 && char.IsLetter(sb[0])) 
                { 
                    sb[0] = char.ToUpper(sb[0]);                
                }                    
                for (int i = 1; i < sb.Length; i++)
                {
                    char ch = sb[i];
                    if (STR.Contains(sb[i - 1]) && char.IsLetter(ch))
                    {
                        sb[i] = char.ToUpper(ch);
                    }  
                    else if (i > sb.Length && char.IsLetter(ch))
                    {
                        sb[i] = char.ToUpper(ch);
                    }
                   
                }
                TextBox_output.Text = Convert.ToString(sb);               
            }
            else
            {
                TextBox_output.Text = "Введите предложение на английском языке";
            }
        }
    }
}
