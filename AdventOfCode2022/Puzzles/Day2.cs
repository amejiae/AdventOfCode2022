namespace AdventOfCode2022.Puzzles
{
    internal class Day2 : Puzzlebase
    {
        private readonly List<Tuple<string, string>> _allThrows;

        public Day2()
        {
            _allThrows = GetInput();
        }

        public override void SolvePart1()
        {
            int totalScore = 0;
            foreach (var handThrow in _allThrows)
            {
                var theirHand = GetHandThrow(char.Parse(handThrow.Item1));
                var myHand = GetHandThrow(char.Parse(handThrow.Item2));

                totalScore += GetThrowScore(theirHand, myHand);
            }

            Console.WriteLine(totalScore);
        }

        public override void SolvePart2()
        {
            int totalScore = 0;
            foreach (var game in _allThrows)
            {
                var theirHand = GetHandThrow(char.Parse(game.Item1));
                var expectedOutcome = GetExpectedOutcomeForThrow(char.Parse(game.Item2));

                switch (expectedOutcome)
                {
                    case GameResult.Draw:
                        totalScore += GetThrowScore(theirHand, theirHand);
                        break;
                    case GameResult.Win:
                    {
                        switch (theirHand)
                        {
                            case HandThrow.Paper:
                                totalScore += GetThrowScore(theirHand, HandThrow.Scissors);
                                break;
                            case HandThrow.Scissors:
                                totalScore += GetThrowScore(theirHand, HandThrow.Rock);
                                break;
                            case HandThrow.Rock:
                                totalScore += GetThrowScore(theirHand, HandThrow.Paper);
                                break;
                        }

                        break;
                    }
                    case GameResult.Loose:
                    {
                        switch (theirHand)
                        {
                            case HandThrow.Paper:
                                totalScore += GetThrowScore(theirHand, HandThrow.Rock);
                                break;
                            case HandThrow.Scissors:
                                totalScore += GetThrowScore(theirHand, HandThrow.Paper);
                                break;
                            case HandThrow.Rock:
                                totalScore += GetThrowScore(theirHand, HandThrow.Scissors);
                                break;
                        }

                        break;
                    }
                }
            }
            Console.WriteLine(totalScore);
        }

        private int GetThrowScore(HandThrow theirGame, HandThrow myHandThrow)
        {
            int myScore = GetBasicScore(myHandThrow);

            if (theirGame == myHandThrow)
            {
                //Throw
                return myScore + 3;
            }

            if (myHandThrow == HandThrow.Paper && theirGame == HandThrow.Rock)
            {
                return myScore + 6;
            }

            if (myHandThrow == HandThrow.Scissors && theirGame == HandThrow.Paper)
            {
                return myScore + 6;
            }

            if (myHandThrow == HandThrow.Rock && theirGame == HandThrow.Scissors)
            {
                return myScore + 6;
            }

            if (myHandThrow == HandThrow.Paper && theirGame == HandThrow.Scissors)
            {
                return myScore;
            }

            if (myHandThrow == HandThrow.Scissors && theirGame == HandThrow.Rock)
            {
                return myScore;
            }

            if (myHandThrow == HandThrow.Rock && theirGame == HandThrow.Paper)
            {
                return myScore;
            }

            return myScore;
        }

        private int GetBasicScore(HandThrow game)
        {
            return game switch
            {
                HandThrow.Rock => 1,
                HandThrow.Paper => 2,
                HandThrow.Scissors => 3,
                _ => 0
            };
        }

        private GameResult GetExpectedOutcomeForThrow(char game)
        {
            if (game == 'X')
                return GameResult.Loose;

            if (game == 'Y')
                return GameResult.Draw;

            if (game == 'Z')
                return GameResult.Win;

            return GameResult.None;
        }

        private HandThrow GetHandThrow(char play)
        {
            if (play == 'A' || play == 'X')
                return HandThrow.Rock;
            
            if (play == 'B' || play == 'Y')
                return HandThrow.Paper;

            if (play == 'C' || play == 'Z')
                return HandThrow.Scissors;

            return HandThrow.None;
        }

        private List<Tuple<string, string>> GetInput()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day2.txt");
            return inputFile.Select(line => line.Split(' ')).Select(game => new Tuple<string, string>(game[0], game[1])).ToList();
        }
    }

    internal enum HandThrow
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
