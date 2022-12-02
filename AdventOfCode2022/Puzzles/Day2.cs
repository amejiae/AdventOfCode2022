namespace AdventOfCode2022.Puzzles
{
    internal class Day2 : Puzzlebase
    {
        public override void SolvePart1()
        {
            var input = GetInput();
            int totalScore = 0;
            
            foreach (var game in input)
            {
                var theirHand = GetPlayerHandDraw(char.Parse(game.Item1));
                var myHand = GetPlayerHandDraw(char.Parse(game.Item2));

                totalScore += GetGameScore(theirHand, myHand);
            }

            Console.WriteLine(totalScore);
        }

        public override void SolvePart2()
        {
            var input = GetInput();
            int totalScore = 0;
            foreach (var game in input)
            {
                var theirHand = GetPlayerHandDraw(char.Parse(game.Item1));
                var expectedGameOutcome = GetGameResultFromGame(char.Parse(game.Item2));

                switch (expectedGameOutcome)
                {
                    case GameResult.Draw:
                        totalScore += GetGameScore(theirHand, theirHand);
                        break;
                    case GameResult.Win:
                    {
                        if (theirHand == HandDraw.Paper) 
                            totalScore += GetGameScore(theirHand, HandDraw.Scissors);
                        if (theirHand == HandDraw.Scissors)
                            totalScore += GetGameScore(theirHand, HandDraw.Rock);
                        if (theirHand == HandDraw.Rock)
                            totalScore += GetGameScore(theirHand, HandDraw.Paper);
                        break;
                    }
                    case GameResult.Loose:
                    {
                        if (theirHand == HandDraw.Paper)
                            totalScore += GetGameScore(theirHand, HandDraw.Rock);
                        if (theirHand == HandDraw.Scissors)
                            totalScore += GetGameScore(theirHand, HandDraw.Paper);
                        if (theirHand == HandDraw.Rock)
                            totalScore += GetGameScore(theirHand, HandDraw.Scissors);
                        break;
                    }
                }
            }
            Console.WriteLine(totalScore);
        }

        private int GetGameScore(HandDraw theirGame, HandDraw myHandDraw)
        {
            int myScore = GetBasicScore(myHandDraw);

            if (theirGame == myHandDraw)
            {
                //draw
                return myScore + 3;
            }

            if (myHandDraw == HandDraw.Paper && theirGame == HandDraw.Rock)
            {
                return myScore + 6;
            }

            if (myHandDraw == HandDraw.Scissors && theirGame == HandDraw.Paper)
            {
                return myScore + 6;
            }

            if (myHandDraw == HandDraw.Rock && theirGame == HandDraw.Scissors)
            {
                return myScore + 6;
            }

            if (myHandDraw == HandDraw.Paper && theirGame == HandDraw.Scissors)
            {
                return myScore;
            }

            if (myHandDraw == HandDraw.Scissors && theirGame == HandDraw.Rock)
            {
                return myScore;
            }

            if (myHandDraw == HandDraw.Rock && theirGame == HandDraw.Paper)
            {
                return myScore;
            }

            return myScore;
        }

        private int GetBasicScore(HandDraw game)
        {
            return game switch
            {
                HandDraw.Rock => 1,
                HandDraw.Paper => 2,
                HandDraw.Scissors => 3,
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

        private HandDraw GetPlayerHandDraw(char play)
        {
            if (play == 'A' || play == 'X')
                return HandDraw.Rock;
            
            if (play == 'B' || play == 'Y')
                return HandDraw.Paper;

            if (play == 'C' || play == 'Z')
                return HandDraw.Scissors;

            return HandDraw.None;
        }

        private List<Tuple<string, string>> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day2.txt");
            return inputFile.Select(line => line.Split(' ')).Select(game => new Tuple<string, string>(game[0], game[1])).ToList();
        }
    }

    internal enum HandDraw
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
