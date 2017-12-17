﻿using System;
namespace tictactoe
{
    public class Game
    {
        bool _endOfGame;
        char _currentPlayer;
        char _winner;
        Board _board;

        public Game()
        {
            _board = new Board();
            _currentPlayer = Fields.X;
            _endOfGame = false;
            _winner = Fields.Empty;
        }

        public bool IsFinished()
        {
            return _endOfGame;
        }

        public char GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public Board GetBoard()
        {
            return _board;
        }

        public void PrintBoard()
        {
            _board.Print();
        }

        public bool MakeMove(int field)
        {
            Console.WriteLine("if end of game");
            if (_endOfGame)
                return false;

            Console.WriteLine($"puting player {_currentPlayer} in field {field}");
            if (!(_board.Put(field, _currentPlayer)))
                return false;

            Console.WriteLine("checking winner");
            if (CheckWinner())
            {
                _winner = _currentPlayer;
                _endOfGame = true;
                return true;
            }

            Console.WriteLine("checking move available");
            if (!(_board.IsMoveAvailable()))
            {
                _winner = Fields.Empty;
                _endOfGame = true;
                return true;
            }

            Console.WriteLine("swaping players");
            if (_currentPlayer == Fields.X)
                _currentPlayer = Fields.O;
            else
                _currentPlayer = Fields.X;

            return true;
        }

        public bool CheckWinner()
        {
            int[,] winningFields = {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            for (int i = 0; i < 8; i++)
            {
                if (_board.Get()[winningFields[i, 0]] == _board.Get()[winningFields[i, 1]] &&
                    _board.Get()[winningFields[i, 0]] == _board.Get()[winningFields[i, 2]] &&
                    _board.Get()[winningFields[i, 0]] != Fields.Empty)
                    return true;
            }
            return false;
        }
    }
}