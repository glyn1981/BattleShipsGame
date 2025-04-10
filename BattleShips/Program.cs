﻿
using BattleShips.Helpers;
using BattleShips.Objects;

namespace BattleShips
{
    class BattleShipsGame
    {
        static void Main()
        {
 
            
            //create the dependencies.
            IUtils utils = new Utils();
            List<Ship> ships = new List<Ship>();
            List<string> guesses = new List<string>();
            Random random = new Random();
            IInputHandler inputHandler = new InputHandler();
            IInputValidator inputValidator = new InputValidator();
            IShipStrikeChecker shipStrikeChecker = new ShipStrikeChecker();
            IBoardInitialiser boardInitialiser = new BoardInitialiser();
            IShipInitialiser shipInitialiser = new ShipInitialiser();
            IGameDisplay gameDisplay = new GameDisplay();

            // create a new game with dependency injection
            Game game = new Game(ships, guesses, random, inputValidator, utils, inputHandler, shipStrikeChecker,shipInitialiser, boardInitialiser,gameDisplay);
            // start the game
            game.Start();

            while (game.CheckGameOver() == false)
            {
                game.NextTurn();
            }

            //the game is over, you won !.
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Restart to play again.");
            Thread.Sleep(5000);
                
        }

    }
}