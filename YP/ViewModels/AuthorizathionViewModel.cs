using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Threading;
using ReactiveUI;
using YP.Models;
using YP.Views;
using static System.Net.Mime.MediaTypeNames;

namespace YP.ViewModels
{
	public class AuthorizathionViewModel : ReactiveObject
	{
        string _idNumber;
		string _password;
        Canvas _capcha;
        string _strCapchaGererated;
        string _tbCapcha;
        int _countWrong;
        bool _wrongCapchaInput = false;
        bool _wrongAuthDateInput = false;
        bool _blockSystem = false;
        bool _wrongIdUserInput = false;
        public string IdNumber { get => _idNumber; set => this.RaiseAndSetIfChanged(ref _idNumber, value); }
        public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }
        public Canvas Capcha { get => _capcha; set => this.RaiseAndSetIfChanged(ref _capcha, value); }
        public string StrCapchaGererated { get => _strCapchaGererated; set => _strCapchaGererated = value; }
        public string TbCapcha { get => _tbCapcha; set => this.RaiseAndSetIfChanged(ref _tbCapcha, value); }
        public bool WrongCapchaInput { get => _wrongCapchaInput; set => this.RaiseAndSetIfChanged(ref _wrongCapchaInput, value); }
        public bool WrongAuthDateInput { get => _wrongAuthDateInput; set => this.RaiseAndSetIfChanged(ref _wrongAuthDateInput, value); }
        public bool BlockSystem { get => _blockSystem; set { this.RaiseAndSetIfChanged(ref _blockSystem, value); Dispatcher.UIThread.Post(() => 
        { 
            Thread.Sleep(5000); 
            WrongAuthDateInput = false;
            WrongIdUserInput = false; 
            WrongCapchaInput = false;
            if (BlockSystem != false)
            {
                BlockSystem = false;
            }
             });
            } 
        }
        public bool WrongIdUserInput { get => _wrongIdUserInput; set => this.RaiseAndSetIfChanged(ref _wrongIdUserInput, value); }

        public AuthorizathionViewModel()
        {
            //FileInfo fileWithUserDate = new FileInfo("date_user.txt");
            //if (fileWithUserDate.Exists)
            //{
            //    using (FileStream fstream = File.OpenRead("date_user.txt"))
            //    {
            //        // выделяем массив для считывания данных из файла
            //        byte[] buffer = new byte[fstream.Length];
            //        // считываем данные
            //        fstream.Read(buffer, 0, buffer.Length);
            //        // декодируем байты в строку
            //        string textFromFile = Encoding.Default.GetString(buffer);
            //        List<string> parseDateUser = textFromFile.Split(" ").ToList();
            //        AuthMethod(parseDateUser[0], parseDateUser[1]);

            //    }
            //}
            //else
            //{
                CreateCapcha();
            //}
        }
        public void AuthMethod(string idNumber, string password)
        {
            try
            {
                User currentUser = MainWindowViewModel.Instance.Dbcontext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(idNumber) && x.Password == password);
                switch (currentUser)
                {
                    case null:
                        WrongCapchaInput = false;
                        WrongIdUserInput = false;
                        WrongAuthDateInput = true;
                        IdNumber = "";
                        Password = "";
                        break;
                    default:
                        switch (currentUser.IdRole)
                        {
                            case 3:
                                FileInfo fileWithUserDate = new FileInfo("date_user.txt");
                                if (!fileWithUserDate.Exists)
                                {
                                    string path = "date_user.txt";
                                    using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                                    {
                                        byte[] buffer = Encoding.Default.GetBytes($"{idNumber} {password}");
                                        fstream.Write(buffer);
                                    }
                                }
                                MainWindowViewModel.Instance.Uc = new Manager(currentUser);
                                break;
                        }
                        break;
                }
            }
             catch (Exception e)
            {
                WrongIdUserInput = true;
            }
        }
        public void AuthorizathionInSystem()
        {
            switch (TbCapcha == StrCapchaGererated)
            {
                case true:
                    AuthMethod(IdNumber, Password);
                    break;
                    
                case false:
                    _countWrong++;
                    if (_countWrong == 3)
                    {
                        BlockSystem = true;
                        TbCapcha = "";
                        _countWrong = 0;
                    }
                    TbCapcha = "";
                    WrongIdUserInput = false;
                    WrongAuthDateInput = false;
                    WrongCapchaInput = true;
                    break;
            }
            
        }
        public void CreateCapcha()
        {
            Random rnd = new Random();
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int lenth = 4;
            StrCapchaGererated = "";

            Canvas cap = new Canvas()
            {
                Width = 200,
                Height = 100,
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
            };

            double startX = rnd.Next(10, 20); 

            for (int i = 0; i < lenth; i++)
            {
                TextBlock symbol = new TextBlock();
                symbol.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                symbol.FontSize = 25;
                symbol.Foreground = new SolidColorBrush(Colors.Black);
                if (rnd.Next(10) % 2 == rnd.Next(0, 1))
                {
                    int resultNumb = rnd.Next(10);
                    symbol.Text = resultNumb.ToString();
                    StrCapchaGererated += Convert.ToString(resultNumb);
                }
                else
                {

                    int index = rnd.Next(alphabet.Length);
                    char result = alphabet[index];
                    symbol.Text = result.ToString();
                    StrCapchaGererated += Convert.ToString(result);
                }
                if (rnd.Next(9) % 3 == 0) symbol.FontWeight = FontWeight.Bold;
                else if (rnd.Next(9) % 3 == 2) symbol.FontStyle = FontStyle.Italic;
                else
                {
                    symbol.FontWeight = FontWeight.Bold;
                    symbol.FontStyle = FontStyle.Italic;
                }


                Canvas.SetLeft(symbol, startX + (i * 35)); 
                Canvas.SetTop(symbol, rnd.Next(25, 40)); 

                cap.Children.Add(symbol);
            }
            for (int i = 0; i < rnd.Next(20, 30); i++)
            {
                Line line = new Line()
                {
                    StartPoint = new Avalonia.Point(rnd.Next(140), rnd.Next(90)),
                    EndPoint = new Avalonia.Point(rnd.Next(240), rnd.Next(90)),
                    Stroke = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rnd.Next(256)), Convert.ToByte(rnd.Next(255)), Convert.ToByte(rnd.Next(255)))),
                    StrokeThickness = rnd.Next(3),

                };
                cap.Children.Add(line);

            }
            Capcha = cap;
        }
    }
}