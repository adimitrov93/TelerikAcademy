namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mine
    {
        private const int MAX_CLEARED_FIELDS = 35;

        private const char BOMB_SYMBOL = '*';
        private const char NO_BOMB_SYMBOL = '-';
        private const char EMPTY_SYMBOL = '?';

        private const string HELLO_MESSAGE = "Lets play some \"Mines\". Test your luck, try to find all fields without mines. " +
            "Command \"top\" show Top scores, \"restart\" restarts the game, \"exit\" exits the game and says \"Bye bye!\"";
        private const string BYE_MESSAGE = "Bye bye!";
        private const string INVALID_COMMAND_MESSAGE = "\nError! Invalid command!\n";
        private const string LOSE_FORMAT_MESSAGE = "{0}Grrrr! You died with {1} points. Enter nickname: ";
        private const string WON_FORMAT_MESSAGE = "{0}Congrats! You opened {1} fields without spilling even a drop of blood.";
        private const string ENTER_NICKNAME_MESSAGE = "Enter your nickname, mate: ";
        private const string MADE_IN_BULGARIA_MESSAGE = "Made in Bulgaria - Uauahahahahaha!";
        private const string TOP_PLAYERS_MESSAGE = "\nTop players:";
        private const string NO_SCORES_MESSAGE = "No scores!\n";
        private const string ENTER_POSITION_MESSAGE = "Enter row and column: ";

        private const string TURN_COMMAND = "turn";
        private const string TOP_SCORES_COMMAND = "top";
        private const string EXIT_COMMAND = "exit";
        private const string RESTART_COMMAND = "restart";

        private const string TOP_SCORES_FORMAT = "{0}. {1} --> {2} fields";
        private const string COL_INDEXES = "\n    0 1 2 3 4 5 6 7 8 9";
        private const string DASHES = "   ---------------------";
        private const string VERTICAL_LINE = "|";
        private const string PLAYFIELD_FIRST_COLUMN_FORMAT = "{0} {1} ";
        private const string PLAYFIELD_FORMAT = "{0} ";

        public class Player
        {
            public Player()
            {
            }

            public Player(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }

            public string Name { get; set; }

            public int Score { get; set; }
        }

        public static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayfield();
            char[,] bombs = InsertBombs();
            int count = 0;
            bool hasBombExploded = false;
            List<Player> topScorers = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool hasJustStarted = true;
            bool hasPlayerWon = false;

            do
            {
                if (hasJustStarted)
                {
                    Console.WriteLine(HELLO_MESSAGE);

                    PrintPlayfield(field);
                    hasJustStarted = false;
                }

                Console.Write(ENTER_POSITION_MESSAGE);
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column) && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = TURN_COMMAND;
                    }
                }

                switch (command)
                {
                    case TOP_SCORES_COMMAND:
                        TopScores(topScorers);
                        break;
                    case RESTART_COMMAND:
                        field = CreatePlayfield();
                        bombs = InsertBombs();
                        PrintPlayfield(field);
                        hasBombExploded = false;
                        hasJustStarted = false;
                        break;
                    case EXIT_COMMAND:
                        Console.WriteLine(BYE_MESSAGE);
                        break;
                    case TURN_COMMAND:
                        if (bombs[row, column] != BOMB_SYMBOL)
                        {
                            if (bombs[row, column] == NO_BOMB_SYMBOL)
                            {
                                InsertBombsCount(field, bombs, row, column);
                                count++;
                            }

                            if (count == MAX_CLEARED_FIELDS)
                            {
                                hasPlayerWon = true;
                            }
                            else
                            {
                                PrintPlayfield(field);
                            }
                        }
                        else
                        {
                            hasBombExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine(INVALID_COMMAND_MESSAGE);
                        break;
                }

                if (hasBombExploded)
                {
                    PrintPlayfield(bombs);

                    Console.Write(LOSE_FORMAT_MESSAGE, Environment.NewLine, count);
                    string nickname = Console.ReadLine();

                    Player newPlayer = new Player(nickname, count);

                    if (topScorers.Count < 5)
                    {
                        topScorers.Add(newPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < topScorers.Count; i++)
                        {
                            if (topScorers[i].Score < newPlayer.Score)
                            {
                                topScorers.Insert(i, newPlayer);
                                topScorers.RemoveAt(topScorers.Count - 1);
                                break;
                            }
                        }
                    }

                    topScorers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    topScorers.Sort((Player r1, Player r2) => r2.Score.CompareTo(r1.Score));
                    TopScores(topScorers);

                    field = CreatePlayfield();
                    bombs = InsertBombs();
                    count = 0;
                    hasBombExploded = false;
                    hasJustStarted = true;
                }

                if (hasPlayerWon)
                {
                    Console.WriteLine(WON_FORMAT_MESSAGE, Environment.NewLine, MAX_CLEARED_FIELDS);

                    PrintPlayfield(bombs);

                    Console.WriteLine(ENTER_NICKNAME_MESSAGE);
                    string nickname = Console.ReadLine();

                    Player newPlayer = new Player(nickname, count);
                    topScorers.Add(newPlayer);

                    TopScores(topScorers);

                    field = CreatePlayfield();
                    bombs = InsertBombs();
                    count = 0;
                    hasPlayerWon = false;
                    hasJustStarted = true;
                }
            }
            while (command != EXIT_COMMAND);

            Console.WriteLine(MADE_IN_BULGARIA_MESSAGE);
            Console.Read();
        }

        private static void TopScores(List<Player> players)
        {
            Console.WriteLine(TOP_PLAYERS_MESSAGE);

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(TOP_SCORES_FORMAT, i + 1, players[i].Name, players[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(NO_SCORES_MESSAGE);
            }
        }

        private static void InsertBombsCount(char[,] playfield, char[,] bombs, int row, int column)
        {
            char bombCount = CountBombs(bombs, row, column);

            bombs[row, column] = bombCount;
            playfield[row, column] = bombCount;
        }

        private static void PrintPlayfield(char[,] playfield)
        {
            int fieldHeight = playfield.GetLength(0);
            int fieldWidth = playfield.GetLength(1);

            Console.WriteLine(COL_INDEXES);
            Console.WriteLine(DASHES);

            for (int i = 0; i < fieldHeight; i++)
            {
                Console.Write(PLAYFIELD_FIRST_COLUMN_FORMAT, i, VERTICAL_LINE);

                for (int j = 0; j < fieldWidth; j++)
                {
                    Console.Write(PLAYFIELD_FORMAT, playfield[i, j]);
                }

                Console.Write(VERTICAL_LINE);
                Console.WriteLine();
            }

            Console.WriteLine(DASHES);
            Console.WriteLine();
        }

        private static char[,] CreatePlayfield()
        {
            int playfieldRows = 5;
            int playfieldColumns = 10;
            char[,] field = new char[playfieldRows, playfieldColumns];

            for (int i = 0; i < playfieldRows; i++)
            {
                for (int j = 0; j < playfieldColumns; j++)
                {
                    field[i, j] = EMPTY_SYMBOL;
                }
            }

            return field;
        }

        private static char[,] InsertBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] playfield = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playfield[i, j] = NO_BOMB_SYMBOL;
                }
            }

            List<int> bombs = new List<int>();

            while (bombs.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!bombs.Contains(randomNumber))
                {
                    bombs.Add(randomNumber);
                }
            }

            foreach (int bomb in bombs)
            {
                int row = bomb / columns;
                int column = bomb % columns;

                if (column == 0 && bomb != 0)
                {
                    row--;
                    column = columns;
                }
                else
                {
                    column++;
                }

                playfield[row, column - 1] = BOMB_SYMBOL;
            }

            return playfield;
        }

        private static char CountBombs(char[,] bombs, int row, int col)
        {
            int count = 0;
            int rows = bombs.GetLength(0);
            int columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, col] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, col] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if (col + 1 < columns)
            {
                if (bombs[row, col + 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < columns))
            {
                if (bombs[row - 1, col + 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < columns))
            {
                if (bombs[row + 1, col + 1] == BOMB_SYMBOL)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
