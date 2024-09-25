using System.Security.Cryptography.X509Certificates;
using System;
using GuessGame;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Diagnostics;

internal class Program
{

    private static void Main(string[] args)
    {
        while (true)
        {
            Random rnd = new Random();
            int kullaniciSayisi;
            string sayi;
            int rastgeleSayi = rnd.Next(1 + 99);
            int denemeSayisi = 1;



            Console.WriteLine("Do you want to play as english or turkis/bu oyunu türkçe mi oynamak istersin yoksa ingilizce mi");
            string language = Console.ReadLine();
            while (true)
            {

                if (language.ToLower() == "türkçe" || language.ToLower() == "turkish")
                {
                    Console.WriteLine("Aklımdan 0 ile 100 arasında bir tam sayı  tuttum. Bu sayıyı bulabilir misin ?(tutulan sayı =" + rastgeleSayi + ")");
                    while (true)
                    {
                        Console.WriteLine("\nTahmininizi yapınız: ");
                        while (true)
                        {
                            while (true)
                            {
                                sayi = Console.ReadLine();
                                sayi = sayi.Replace(" ", "");

                                if (IsAlphabetic(sayi))
                                {
                                    kullaniciSayisi = SayiyaDonusturme.SayiyaCevirme(sayi);
                                    if (kullaniciSayisi == 0)
                                    {
                                        Console.WriteLine("Geçersiz bir sayı girdiniz lütfen tekrar deneyin");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (!int.TryParse(sayi, out kullaniciSayisi))
                                    {
                                        Console.WriteLine("\nLütfen sadece tam sayı girinizin.");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if (rastgeleSayi != kullaniciSayisi)
                            {
                                if (rastgeleSayi < kullaniciSayisi)
                                {
                                    Console.WriteLine("Tahmininiz tuttuğum sayıdan büyük. Tahmininizi azaltın.");
                                }
                                else if (rastgeleSayi > kullaniciSayisi)
                                {
                                    Console.WriteLine("Tahmininiz tuttuğum sayıdan küçük. Tahmininizi arttırın.");
                                }
                                denemeSayisi++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (denemeSayisi == 1)
                        {
                            Console.WriteLine("Tebrikler tuttuğum sayıyı ilk denemede buldunuz. Tuttuğum sayı: " + rastgeleSayi);

                        }
                        else
                        {
                            Console.WriteLine("Tebrikler tuttuğum sayıyı buldunuz. Tuttuğum sayı: " + rastgeleSayi + " tuttuğum sayıyı " + denemeSayisi + " başarılı deneme sonucunda buldunuz.");
                        }
                        break;

                    }

                    Console.WriteLine("Tekrar oynamak isterseniz Enter'a basın oynamak istemiyorsanız Çıkış yazın");
                    string cevap = Console.ReadLine();
                    if (cevap == null)
                    {
                        Console.WriteLine("Oyun yeniden başlatılıyor");
                    }
                    else if (cevap.ToLower() == "Çıkış")
                    {
                        Console.WriteLine("Oynadığınız için teşekkür ederiz");
                        break;
                    }
                    break;
                }
                else if (language.ToLower() == "english" || language.ToLower() == "ingilizce")
                {
                    Console.WriteLine("I kept an integer number between 0 and 100 in my mind. Can you find this number? (number stored =" + rastgeleSayi + ")");
                    while (true)
                    {
                        Console.WriteLine("\nEnter your guess : ");
                        while (true)
                        {
                            while (true)
                            {
                                sayi = Console.ReadLine();
                                sayi = sayi.Replace(" ", "");

                                if (IsAlphabetic(sayi))
                                {
                                    kullaniciSayisi = SayiyaDonusturme.SayiyaCevirme(sayi);
                                    if (kullaniciSayisi == 0)
                                    {
                                        Console.WriteLine("You entered an invalid number please try again");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (!int.TryParse(sayi, out kullaniciSayisi))
                                    {
                                        Console.WriteLine("\n Please enter integers only.");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            if (rastgeleSayi != kullaniciSayisi)
                            {
                                if (rastgeleSayi < kullaniciSayisi)
                                {
                                    Console.WriteLine("Your guess is bigger than the number I got. Lower your estimate.");
                                }
                                else if (rastgeleSayi > kullaniciSayisi)
                                {
                                    Console.WriteLine("Your guess is smaller than my number. Increase your guess.");
                                }
                                denemeSayisi++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (denemeSayisi == 1)
                        {
                            Console.WriteLine("Congratulations, you found the number I chose on the first try. Number I keep: " + rastgeleSayi);

                        }
                        else
                        {
                            Console.WriteLine("Congratulations, you found the number I kept. The number I kept: " + rastgeleSayi + " you found the number I kept as a result of " + denemeSayisi + " successful trials");
                        }
                        break;
                    }

                    Console.WriteLine("If you want to play again, press Enter.If you do not want to play, type Exit");
                    string cevap = Console.ReadLine();
                    if (cevap.ToLower() == null)
                    {
                        Console.WriteLine("The game is restarting");
                    }
                    else if (cevap.ToLower() == "exit")
                    {
                        Console.WriteLine("Thank you for playing");
                        break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz bir yanıt girdiniz tekrar deneyin/You entered an invalid response, try again");
                    break;
                }
            }
        }
        static bool IsAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}