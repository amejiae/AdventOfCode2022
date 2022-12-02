namespace AdventOfCode2022.Puzzles
{
    internal class Day2 : Puzzlebase
    {
        public override void SolvePart1()
        {
            var input = GetInput();
            int totalScore = 0;
            foreach (Tuple<string, string> game in input)
            {
                var theirGame = GetPlayerGame(char.Parse(game.Item1));
                var myGame = GetPlayerGame(char.Parse(game.Item2));
                totalScore += GetMyGameScore(theirGame, myGame);
            }

            Console.WriteLine(totalScore);
        }

        public override void SolvePart2()
        {
            var input = GetInput();
            int totalScore = 0;
            foreach (Tuple<string, string> game in input)
            {
                var theirGame = GetPlayerGame(char.Parse(game.Item1));
                var expectedResult = GetGameResultFromGame(char.Parse(game.Item2));

                if (expectedResult == GameResult.Draw)
                {
                    totalScore += GetMyGameScore(theirGame, theirGame);
                }
                if (expectedResult == GameResult.Win)
                {
                    if (theirGame == RPS.Paper) 
                        totalScore += GetMyGameScore(theirGame, RPS.Scissors);
                    if (theirGame == RPS.Scissors)
                        totalScore += GetMyGameScore(theirGame, RPS.Rock);
                    if (theirGame == RPS.Rock)
                        totalScore += GetMyGameScore(theirGame, RPS.Paper);
                }
                if (expectedResult == GameResult.Loose)
                {
                    if (theirGame == RPS.Paper)
                        totalScore += GetMyGameScore(theirGame, RPS.Rock);
                    if (theirGame == RPS.Scissors)
                        totalScore += GetMyGameScore(theirGame, RPS.Paper);
                    if (theirGame == RPS.Rock)
                        totalScore += GetMyGameScore(theirGame, RPS.Scissors);
                }
            }
            Console.WriteLine(totalScore);
        }

        private int GetMyGameScore(RPS theirGame, RPS myGame)
        {
            int myScore = GetBasicScore(myGame);

            if (theirGame == myGame)
            {
                //draw
                return myScore + 3;
            }

            if (myGame == RPS.Paper && theirGame == RPS.Rock)
            {
                return myScore + 6;
            }

            if (myGame == RPS.Scissors && theirGame == RPS.Paper)
            {
                return myScore + 6;
            }

            if (myGame == RPS.Rock && theirGame == RPS.Scissors)
            {
                return myScore + 6;
            }

            if (myGame == RPS.Paper && theirGame == RPS.Scissors)
            {
                return myScore;
            }

            if (myGame == RPS.Scissors && theirGame == RPS.Rock)
            {
                return myScore;
            }

            if (myGame == RPS.Rock && theirGame == RPS.Paper)
            {
                return myScore;
            }

            return myScore;
        }

        private int GetBasicScore(RPS game)
        {
            return game switch
            {
                RPS.Rock => 1,
                RPS.Paper => 2,
                RPS.Scissors => 3,
                _ => 0
            };
        }

        private GameResult GetGameResultFromGame(char game)
        {
            if (game == 'X')
                return GameResult.Loose;

            if (game == 'Y')
                return GameResult.Draw;

            if (game == 'Z')
                return GameResult.Win;

            return GameResult.None;
        }

        private RPS GetPlayerGame(char play)
        {
            if (play == 'A' || play == 'X')
                return RPS.Rock;
            
            if (play == 'B' || play == 'Y')
                return RPS.Paper;

            if (play == 'C' || play == 'Z')
                return RPS.Scissors;

            return RPS.None;
        }

        private List<Tuple<string, string>> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day2.txt");
            return inputFile.Select(line => line.Split(' ')).Select(game => new Tuple<string, string>(game[0], game[1])).ToList();
        }
    }

    internal enum RPS
    {
        Rock,
        Paper,
        Scissors,
        None
    }

    internal enum GameResult
    {
        Win,
        Draw,
        Loose,
        None
    }
}
