using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.Models;

namespace ConsoleApplication1.Views
{
    public static class View
    {
        public static void PlayerPoints(Player player)
        { Console.WriteLine(player.Name + " очки: " + player.Points); }

        public static void MoreCard()
        { Console.WriteLine("Нажмите 1 если хотите еще карту, нажмите 0, если готовы вскрыть карты."); }

        public static void Winning(Player player)
        { Console.WriteLine(player.Name + " вы победили!!!"); }

        public static void LossOfBothPlayers()
        { Console.WriteLine("Поражение обоих игроков"); }

        public static void OutputName(Player player)
        { Console.WriteLine("Играет: " + player.Name); }

        public static void EnterNamePlayer1()
        { Console.WriteLine("Введите имя первого игрока:"); }

        public static void EnterNamePlayer2()
        { Console.WriteLine("Введите имя второго игрока:"); }

        public static void RetypeInput()
        { Console.WriteLine("Неверный ввод. Повторите."); }

        public static void RepeatTheGame()
        { Console.WriteLine("Хотите сыграть еще раз? Если да - нажмите 1, нет - 0."); }

        public static string ReadData()
        {
            string _data = Console.ReadLine();
            return _data;
        }
        public static void DisplayTheCard(Card card)
        { Console.WriteLine(card.Value + " " + card.Color); }
    }
}
