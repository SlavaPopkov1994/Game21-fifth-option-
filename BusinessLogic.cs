using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.Models;
using ConsoleApplication1.Views;

namespace ConsoleApplication1.Controllers
{
    class BusinessLogic
    {
        public static int maximumOfPoints = 21;
        public static void Game()
        {
            bool _yet = false;
            Player player1 = new Player();
            View.EnterNamePlayer1();
            player1.Name = View.ReadData();
            Player player2 = new Player();
            View.EnterNamePlayer2();
            player2.Name = View.ReadData();
            do
            {
                ReplayGame(player1, player2);
                CorrectInput(ref _yet);
            }
            while (_yet == true);
        }

        public static void ReplayGame(Player player1, Player player2)
        {
            player1.Points = 0;
            player2.Points = 0;
            bool _lot = false;

            List<Card> cardList = new List<Card>();
            GenerationDeckOfCards(cardList);

            View.OutputName(player1);
            _lot = CheckOnTheOverkill(player1, cardList, _lot);
            View.PlayerPoints(player1);

            View.OutputName(player2);
            _lot = CheckOnTheOverkill(player2, cardList, _lot);
            View.PlayerPoints(player2);

            if (_lot)
            { DetermineTheLoser(player1, player2); }
            if(!_lot)
            { DetermineTheWinner(player1, player2); }

            View.RepeatTheGame();
        }

        public static void CorrectInput(ref bool _yet)
        {
            bool correctInput = true;
            string _input = "";
            do
            {
                _input = View.ReadData();
                if ((_input.Equals("1")) || (_input.Equals("0")))
                {
                    correctInput = false;
                }
                else { View.RetypeInput(); }
            }
            while (correctInput);
            if (_input.Equals("1")) { _yet = true; }
            if (_input.Equals("0")) { _yet = false; }
        }

        public static bool CheckOnTheOverkill(Player player, List<Card> cardList, bool _lot)
        {
            player.Points = 0;

            DealTheCards(cardList, player);
            if (player.Points > maximumOfPoints) { _lot = true; }
            return _lot;
        }

        public static void GenerationDeckOfCards(List<Card> cardList)
        {
            int suit = 4;
            int juniorCardOfTheDeck = 6;
            int highestCardWithoutAPicture = 10;
            int lowCardWithAPicture = 2;
            int highCardWithAPicture = 4;
            for (int i = 0; i < suit; i++)
            {
                for (int j = juniorCardOfTheDeck; j <= highestCardWithoutAPicture; j++)
                {
                    var card = new Card
                    {
                        Color = Convert.ToString((CardEnumeration.colorsCards)i),
                        Value = Convert.ToString(j),
                        Cost = j
                    };
                    cardList.Add(card);
                }
                for (int j = lowCardWithAPicture; j <= highCardWithAPicture; j++)
                {
                    var card = new Card
                    {
                        Color = Convert.ToString((CardEnumeration.colorsCards)i),
                        Value = Convert.ToString((CardEnumeration.valuesCasrds)(j - 2)),
                        Cost = j
                    };
                    cardList.Add(card);
                }
                var ace = new Card
                {
                    Color = Convert.ToString((CardEnumeration.colorsCards)i),
                    Value = Convert.ToString((CardEnumeration.valuesCasrds)3),
                    Cost = 11
                };
                cardList.Add(ace);
            }
        }

        public static void DealTheCards(List<Card> cardList, Player player)
        {
            int cardCost = 0;
            int startDealingCards = 2;
            for (int i = startDealingCards; i > 0; i--)
            {
                cardCost = ShuffleTheCards(cardList);
                player.Points = player.Points + cardCost;

                if ((i == 1) && (player.Points < maximumOfPoints))
                {
                    View.PlayerPoints(player);
                    LayACard(ref i);
                }
            }
        }

        public static int ShuffleTheCards(List<Card> cardList)
        {
            Card card = new Card();
            Random rand = new Random();
            card = cardList[rand.Next(cardList.Count)];
            cardList.Remove(card);
            View.DisplayTheCard(card);
            return card.Cost;
        }

        public static void LayACard(ref int theNumberOfCardsToPutDown)
        {
            bool _yet = false;
            View.MoreCard();
            CorrectInput(ref _yet);
            if (_yet == true) { theNumberOfCardsToPutDown++; }
        }

        public static void DetermineTheLoser(Player player1, Player player2)
        {
            if ((player1.Points > maximumOfPoints) && (player2.Points > maximumOfPoints)) { View.LossOfBothPlayers(); }
            else
            {
                if (player1.Points <= maximumOfPoints) { View.Winning(player1); }
                if (player2.Points <= maximumOfPoints) { View.Winning(player2); }
            }
        }

        public static void DetermineTheWinner(Player player1, Player player2)
        {
            if (player1.Points == player2.Points)
            {
                do
                {
                    PointsAreEqual(player1, player2);
                }
                while (player1.Points == player2.Points);
            }
            if (player1.Points > player2.Points) { View.Winning(player1); }
            if (player1.Points < player2.Points) { View.Winning(player2); }
        }

        public static void PointsAreEqual(Player player1, Player player2)
        {
            player1.Points = 0;
            player2.Points = 0;
            List<Card> cardList = new List<Card>();
            GenerationDeckOfCards(cardList);
            do
            {
                player1.Points = ShuffleTheCards(cardList);
                player2.Points = ShuffleTheCards(cardList);
            }
            while (player1.Points == player2.Points);
        }
    }
}
