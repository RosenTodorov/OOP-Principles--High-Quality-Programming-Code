using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class StartMines
    {
        static void Main()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] minesPositions = PlaceMines();
            int pointsCounter = 0;
            bool mineExploded = false;
            List<PlayerDetails> championsList = new List<PlayerDetails>(6);
            int row = 0;
            int column = 0;
            bool newGame = true;
            const int MaxMines = 35;
            bool finishedGame = false;

            do
            {
                if (newGame)
                {
                    Console.WriteLine("Let's play Minesweeper. Try to find all cells without mines inside." +
                    " \nCommands: \n'top' shows champion's list, \n'restart' starts new game, \n'exit' exits and Bye Bye!");
                    UpdateField(gameField);
                    newGame = false;
                }

                Console.Write("Row and Column of cell to open : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        {
                            ShowScore(championsList);
                            break;
                        }

                    case "restart":
                        {
                            gameField = CreateGameField();
                            minesPositions = PlaceMines();
                            UpdateField(gameField);
                            mineExploded = false;
                            newGame = false;
                            break;
                        }

                    case "exit":
                        {
                            Console.WriteLine("Bye Bye!");
                            break;
                        }

                    case "turn":
                        {
                            if (minesPositions[row, column] != '*')
                            {
                                if (minesPositions[row, column] == '-')
                                {
                                    OpenCell(gameField, minesPositions, row, column);
                                    pointsCounter++;
                                }

                                if (MaxMines == pointsCounter)
                                {
                                    finishedGame = true;
                                }
                                else
                                {
                                    UpdateField(gameField);
                                }
                            }
                            else
                            {
                                mineExploded = true;
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nError. Invalid command input\n");
                            break;
                        }
                }

                if (mineExploded)
                {
                    UpdateField(minesPositions);

                    Console.Write("\nHrrrrrr! Died a hero with {0} points. " +
                        "Nickname: ", pointsCounter);
                    string nickName = Console.ReadLine();
                    PlayerDetails t = new PlayerDetails(nickName, pointsCounter);

                    if (championsList.Count < 5)
                    {
                        championsList.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < championsList.Count; i++)
                        {
                            if (championsList[i].PointsField < t.PointsField)
                            {
                                championsList.Insert(i, t);
                                championsList.RemoveAt(championsList.Count - 1);
                                break;
                            }
                        }
                    }

                    championsList.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    championsList.Sort((Score r1, Score r2) => r2.PointsField.CompareTo(r1.PointsField));
                    ShowScore(championsList);

                    gameField = CreateGameField();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    mineExploded = false;
                    newGame = true;
                }

                if (finishedGame)
                {
                    Console.WriteLine("\nBRAVOOO! Opened all 35 cells and no blood was shed!");
                    UpdateField(minesPositions);
                    Console.WriteLine("Nickname: ");
                    string name = Console.ReadLine();
                    Score points = new Score(name, pointsCounter);
                    championsList.Add(points);
                    ShowScore(championsList);
                    gameField = CreateGameField();
                    minesPositions = PlaceMines();
                    pointsCounter = 0;
                    finishedGame = false;
                    newGame = true;
                }
            } while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowScore(List<PlayerDetails> scoreList)
        {
            Console.WriteLine("\nPoints:");
            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells",
                        i + 1, scoreList[i].Name, scoreList[i].Score);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoreboard!\n");
            }
        }

        private static void OpenCell(char[,] gameField,
            char[,] minesLocations, int row, int col)
        {
            char mineChar = CountMines(minesLocations, row, col);
            minesLocations[row, col] = mineChar;
            gameField[row, col] = mineChar;
        }

        private static void UpdateField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            Random randomGenerator = new Random();

            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> randomPositions = new List<int>();
            while (randomPositions.Count < 15)
            {
                int randomNumber = randomGenerator.Next(50);
                if (!randomPositions.Contains(randomNumber))
                {
                    randomPositions.Add(randomNumber);
                }
            }

            foreach (int position in randomPositions)
            {
                int col = (position / cols);
                int row = (position % cols);
                if (row == 0 && position != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void Calculations(char[,] field)
        {
            int gamefieldColumns = field.GetLength(0);
            int gamefieldRows = field.GetLength(1);

            for (int column = 0; column < gamefieldColumns; column++)
            {
                for (int row = 0; row < gamefieldRows; row++)
                {
                    if (field[column, row] != '*')
                    {
                        char bombsCount = CountMines(field, column, row);
                        field[column, row] = bombsCount;
                    }
                }
            }
        }
        private static char CountMines(char[,] field, int positionRow, int positionCol)
        {
            int counter = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (positionRow - 1 >= 0)
            {
                if (field[positionRow - 1, positionCol] == '*')
                {
                    counter++;
                }
            }

            if (positionRow + 1 < rows)
            {
                if (field[positionRow + 1, positionCol] == '*')
                {
                    counter++;
                }
            }

            if (positionCol - 1 >= 0)
            {
                if (field[positionRow, positionCol - 1] == '*')
                {
                    counter++;
                }
            }

            if (positionCol + 1 < cols)
            {
                if (field[positionRow, positionCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((positionRow - 1 >= 0) && (positionCol - 1 >= 0))
            {
                if (field[positionRow - 1, positionCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((positionRow - 1 >= 0) && (positionCol + 1 < cols))
            {
                if (field[positionRow - 1, positionCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((positionRow + 1 < rows) && (positionCol - 1 >= 0))
            {
                if (field[positionRow + 1, positionCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((positionRow + 1 < rows) && (positionCol + 1 < cols))
            {
                if (field[positionRow + 1, positionCol + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}