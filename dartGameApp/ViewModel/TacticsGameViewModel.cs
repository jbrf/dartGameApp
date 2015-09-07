using BusinessFlowModelEngine;
using BusinessFlowModelEngine.ViewModel;
using dartGameApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dartGameApp.Model
{
    class TacticsGameViewModel : BindableBase
    {
        public TacticsGameViewModel()
        {
            P1Twenty = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 20 };
            P1Nineteen = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 19 };
            P1Eighteen = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 18 };
            P1Seventeen = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 17 };
            P1Sixteen = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 16 };
            P1Fifteen = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 15 };
            P1Bull = new DartboardNumber { PlayerId = "P1", NumberClosed = false, NumberValue = 25 };

            P2Twenty = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 20 };
            P2Nineteen = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 19 };
            P2Eighteen = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 18 };
            P2Seventeen = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 17 };
            P2Sixteen = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 16 };
            P2Fifteen = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 15 };
            P2Bull = new DartboardNumber { PlayerId = "P2", NumberClosed = false, NumberValue = 25 };

            PlayerTurnVis = true;
        }
      
        private int _turnCounter;
        public int TurnCounter
        {
            get
            {
                return _turnCounter;
            }
            set
            {
                ChangeProperty(ref _turnCounter, value);
            }
        }

        private bool _playerTurnVis;
        public bool PlayerTurnVis
        {
            get { return _playerTurnVis; }
            set { ChangeProperty(ref _playerTurnVis, value); }
        }
        
        private bool _playerTurn;
        /// <summary>
        /// !PlayerTurn = Player 1, PlayerTurn = Player 2
        /// </summary>
        public bool PlayerTurn
        {
            get
            {
                return _playerTurn;
            }
            set
            {
                ChangeProperty(ref _playerTurn, value);
            }
        }

        private void CheckWhosTurnItIs()
        {
            if (TurnCounter < 2)
            {
                TurnCounter++;
            }
            else if (TurnCounter >= 2)
            {
                TurnCounter = 0;
                PlayerTurn = !PlayerTurn;
                PlayerTurnVis = !PlayerTurnVis;
            }
        }

        private void PointsLadder(int val, string playerId)
        {
            if (playerId=="P1")
            {
                if (PlayerOneScore != null)
                {
                    if (PlayerOneScoreTwo != null)
                    {
                        if (PlayerOneScoreThree != null)
                        {
                            if (PlayerOneScoreFour != null)
                            {
                                PlayerOneScoreFive = PlayerOneScoreFour;
                                PlayerOneScoreFour = PlayerOneScoreThree;
                                PlayerOneScoreThree = PlayerOneScoreTwo;
                                PlayerOneScoreTwo = PlayerOneScore;
                                PlayerOneScore += val;
                            }

                            if (PlayerOneScoreFour == null)
                            {
                                PlayerOneScoreFour = PlayerOneScoreThree;
                                PlayerOneScoreThree = PlayerOneScoreTwo;
                                PlayerOneScoreTwo = PlayerOneScore;
                                PlayerOneScore += val;
                            }
                        }

                        if (PlayerOneScoreThree == null)
                        {
                            PlayerOneScoreThree = PlayerOneScoreTwo;
                            PlayerOneScoreTwo = PlayerOneScore;
                            PlayerOneScore += val;
                        }
                    }

                    if (PlayerOneScoreTwo == null)
                    {
                        PlayerOneScoreTwo = PlayerOneScore;
                        PlayerOneScore += val;
                    }
                }

                if (PlayerOneScore == null)
                {
                    PlayerOneScore = val;

                }
            }
            else if (playerId == "P2")
            {
                if (PlayerTwoScore != null)
                {
                    if (PlayerTwoScoreTwo != null)
                    {
                        if (PlayerTwoScoreThree != null)
                        {
                            if (PlayerTwoScoreFour != null)
                            {
                                PlayerTwoScoreFive = PlayerTwoScoreFour;
                                PlayerTwoScoreFour = PlayerTwoScoreThree;
                                PlayerTwoScoreThree = PlayerTwoScoreTwo;
                                PlayerTwoScoreTwo = PlayerTwoScore;
                                PlayerTwoScore += val;
                            }

                            if (PlayerTwoScoreFour == null)
                            {
                                PlayerTwoScoreFour = PlayerTwoScoreThree;
                                PlayerTwoScoreThree = PlayerTwoScoreTwo;
                                PlayerTwoScoreTwo = PlayerTwoScore;
                                PlayerTwoScore += val;
                            }
                        }

                        if (PlayerTwoScoreThree == null)
                        {
                            PlayerTwoScoreThree = PlayerTwoScoreTwo;
                            PlayerTwoScoreTwo = PlayerTwoScore;
                            PlayerTwoScore += val;
                        }
                    }

                    if (PlayerTwoScoreTwo == null)
                    {
                        PlayerTwoScoreTwo = PlayerTwoScore;
                        PlayerTwoScore += val;
                    }
                }

                if (PlayerTwoScore == null)
                {
                    PlayerTwoScore = val;

                }
            }
        }

        private void ScoreboardWriterOpponentClosed(DartboardNumber dbNumber, int doubleOrTriple)
        {
            for (int i = 0; i < doubleOrTriple; i++)
            {
                ChalkDrawer(dbNumber);
            }
        }
        private void ScoreboardWriter(DartboardNumber dbNumber, int doubleOrTriple)
        {
            int points = doubleOrTriple * dbNumber.NumberValue;

            if (dbNumber.DashCrossOrRing == "O")
            {
                PointsLadder(points, dbNumber.PlayerId);
            }

            for (int i = 0; i < doubleOrTriple; i++)
            {
                if (dbNumber.DashCrossOrRing == "O")
                {
                    doubleOrTriple -= i;
                    break;
                }

                ChalkDrawer(dbNumber);
            }
        }
        private void ChalkDrawer(DartboardNumber dbNumber)
        {
            switch (dbNumber.DashCrossOrRing)
            {
                case null:
                    dbNumber.DashCrossOrRing = "/";
                    break;
                case "/":
                    dbNumber.DashCrossOrRing = "X";
                    break;
                case "X":
                    dbNumber.DashCrossOrRing = "O";
                    dbNumber.NumberClosed = true;
                    break;
                default:
                    break;
            }
        }


        #region Commands for scoreboard
        private DelegateCommand _tripleTwenty;
        public DelegateCommand TripleTwenty
        {
            get
            {
                return _tripleTwenty ?? (_tripleTwenty = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Twenty, 3);
                            }
                            else if (!P2Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P1Twenty, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Twenty, 3);
                            }
                            else if (!P1Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P2Twenty, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleTwenty;
        public DelegateCommand DoubleTwenty
        {
            get
            {
                return _doubleTwenty ?? (_doubleTwenty = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Twenty, 2);
                            }
                            else if (!P2Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P1Twenty, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Twenty, 2);
                            }
                            else if (!P1Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P2Twenty, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleTwenty;
        public DelegateCommand SingleTwenty
        {
            get
            {
                return _singleTwenty ?? (_singleTwenty = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Twenty, 1);
                            }
                            else if (!P2Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P1Twenty, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Twenty.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Twenty, 1);
                            }
                            else if (!P1Twenty.NumberClosed)
                            {
                                ScoreboardWriter(P2Twenty, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _tripleNineteen;
        public DelegateCommand TripleNineteen
        {
            get
            {
                return _tripleNineteen ?? (_tripleNineteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Nineteen, 3);
                            }
                            else if (!P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Nineteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Nineteen, 3);
                            }
                            else if (!P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Nineteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleNineteen;
        public DelegateCommand DoubleNineteen
        {
            get
            {
                return _doubleNineteen ?? (_doubleNineteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Nineteen, 2);
                            }
                            else if (!P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Nineteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Nineteen, 2);
                            }
                            else if (!P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Nineteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleNineteen;
        public DelegateCommand SingleNineteen
        {
            get
            {
                return _singleNineteen ?? (_singleNineteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Nineteen, 1);
                            }
                            else if (!P2Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Nineteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Nineteen, 1);
                            }
                            else if (!P1Nineteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Nineteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _tripleEighteen;
        public DelegateCommand TripleEighteen
        {
            get
            {
                return _tripleEighteen ?? (_tripleEighteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Eighteen, 3);
                            }
                            else if (!P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Eighteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Eighteen, 3);
                            }
                            else if (!P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Eighteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleEighteen;
        public DelegateCommand DoubleEighteen
        {
            get
            {
                return _doubleEighteen ?? (_doubleEighteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Eighteen, 2);
                            }
                            else if (!P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Eighteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Eighteen, 2);
                            }
                            else if (!P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Eighteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleEighteen;
        public DelegateCommand SingleEighteen
        {
            get
            {
                return _singleEighteen ?? (_singleEighteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Eighteen, 1);
                            }
                            else if (!P2Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Eighteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Eighteen, 1);
                            }
                            else if (!P1Eighteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Eighteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _tripleSeventeen;
        public DelegateCommand TripleSeventeen
        {
            get
            {
                return _tripleSeventeen ?? (_tripleSeventeen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Seventeen, 3);
                            }
                            else if (!P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P1Seventeen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Seventeen, 3);
                            }
                            else if (!P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P2Seventeen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleSeventeen;
        public DelegateCommand DoubleSeventeen
        {
            get
            {
                return _doubleSeventeen ?? (_doubleSeventeen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Seventeen, 2);
                            }
                            else if (!P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P1Seventeen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Seventeen, 2);
                            }
                            else if (!P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P2Seventeen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleSeventeen;
        public DelegateCommand SingleSeventeen
        {
            get
            {
                return _singleSeventeen ?? (_singleSeventeen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Seventeen, 1);
                            }
                            else if (!P2Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P1Seventeen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Seventeen, 1);
                            }
                            else if (!P1Seventeen.NumberClosed)
                            {
                                ScoreboardWriter(P2Seventeen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _tripleSixteen;
        public DelegateCommand TripleSixteen
        {
            get
            {
                return _tripleSixteen ?? (_tripleSixteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Sixteen, 3);
                            }
                            else if (!P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Sixteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Sixteen, 3);
                            }
                            else if (!P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Sixteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleSixteen;
        public DelegateCommand DoubleSixteen
        {
            get
            {
                return _doubleSixteen ?? (_doubleSixteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Sixteen, 2);
                            }
                            else if (!P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Sixteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Sixteen, 2);
                            }
                            else if (!P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Sixteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleSixteen;
        public DelegateCommand SingleSixteen
        {
            get
            {
                return _singleSixteen ?? (_singleSixteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Sixteen, 1);
                            }
                            else if (!P2Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Sixteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Sixteen, 1);
                            }
                            else if (!P1Sixteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Sixteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _tripleFifteen;
        public DelegateCommand TripleFifteen
        {
            get
            {
                return _tripleFifteen ?? (_tripleFifteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Fifteen, 3);
                            }
                            else if (!P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Fifteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Fifteen, 3);
                            }
                            else if (!P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Fifteen, 3);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _doubleFifteen;
        public DelegateCommand DoubleFifteen
        {
            get
            {
                return _doubleFifteen ?? (_doubleFifteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Fifteen, 2);
                            }
                            else if (!P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Fifteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Fifteen, 2);
                            }
                            else if (!P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Fifteen, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _singleFifteen;
        public DelegateCommand SingleFifteen
        {
            get
            {
                return _singleFifteen ?? (_singleFifteen = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Fifteen, 1);
                            }
                            else if (!P2Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P1Fifteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Fifteen, 1);
                            }
                            else if (!P1Fifteen.NumberClosed)
                            {
                                ScoreboardWriter(P2Fifteen, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _bull;
        public DelegateCommand Bull
        {
            get
            {
                return _bull ?? (_bull = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Bull.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Bull, 1);
                            }
                            else if (!P2Bull.NumberClosed)
                            {
                                ScoreboardWriter(P1Bull, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Bull.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Bull, 1);
                            }
                            else if (!P1Bull.NumberClosed)
                            {
                                ScoreboardWriter(P2Bull, 1);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _redBull;
        public DelegateCommand RedBull
        {
            get
            {
                return _redBull ?? (_redBull = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (!PlayerTurn)
                        {
                            if (P2Bull.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P1Bull, 2);
                            }
                            else if (!P2Bull.NumberClosed)
                            {
                                ScoreboardWriter(P1Bull, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                        else if (PlayerTurn)
                        {
                            if (P1Bull.NumberClosed)
                            {
                                ScoreboardWriterOpponentClosed(P2Bull, 2);
                            }
                            else if (!P1Bull.NumberClosed)
                            {
                                ScoreboardWriter(P2Bull, 2);
                            }
                            CheckWhosTurnItIs();
                        }
                    }
                });
            }
        }

        private DelegateCommand _backToMainMenu;
        public DelegateCommand BackToMainMenu
        {
            get
            {
                return _backToMainMenu ?? (_backToMainMenu = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Switcher.Switch(new MainMenu());
                    }
                });
            }
        }
        #endregion

        #region Scoreboard for points

        // Player One
        private int? _playerOneScore;
        public int? PlayerOneScore
        {
            get { return _playerOneScore; }
            set { ChangeProperty(ref _playerOneScore, value); }
        }

        private int? _playerOneScoreTwo;
        public int? PlayerOneScoreTwo
        {
            get { return _playerOneScoreTwo; }
            set { ChangeProperty(ref _playerOneScoreTwo, value); }
        }

        private int? _playerOneScoreThree;
        public int? PlayerOneScoreThree
        {
            get { return _playerOneScoreThree; }
            set { ChangeProperty(ref _playerOneScoreThree, value); }
        }

        private int? _playerOneScoreFour;
        public int? PlayerOneScoreFour
        {
            get { return _playerOneScoreFour; }
            set { ChangeProperty(ref _playerOneScoreFour, value); }
        }

        private int? _playerOneScoreFive;
        public int? PlayerOneScoreFive
        {
            get { return _playerOneScoreFive; }
            set { ChangeProperty(ref _playerOneScoreFive, value); }
        }

        // Player Two
        private int? _playerTwoScore;
        public int? PlayerTwoScore
        {
            get { return _playerTwoScore; }
            set { ChangeProperty(ref _playerTwoScore, value); }
        }

        private int? _playerTwoScoreTwo;
        public int? PlayerTwoScoreTwo
        {
            get { return _playerTwoScoreTwo; }
            set { ChangeProperty(ref _playerTwoScoreTwo, value); }
        }

        private int? _playerTwoScoreThree;
        public int? PlayerTwoScoreThree
        {
            get { return _playerTwoScoreThree; }
            set { ChangeProperty(ref _playerTwoScoreThree, value); }
        }

        private int? _playerTwoScoreFour;
        public int? PlayerTwoScoreFour
        {
            get { return _playerTwoScoreFour; }
            set { ChangeProperty(ref _playerTwoScoreFour, value); }
        }

        private int? _playerTwoScoreFive;
        public int? PlayerTwoScoreFive
        {
            get { return _playerTwoScoreFive; }
            set { ChangeProperty(ref _playerTwoScoreFive, value); }
        }


        #endregion

        #region Player names
        private string _p1name;
        public string P1Name
        {
            get { return _p1name; }
            set { ChangeProperty(ref _p1name, value); }
        }
        private string _p2name;
        public string P2Name
        {
            get { return _p2name; }
            set { ChangeProperty(ref _p2name, value); }
        }
        #endregion

        //#region Player1 bool for closed numbers

        //private bool _p1TwentyClosed;
        //public bool P1TwentyClosed
        //{
        //    get { return _p1TwentyClosed; }
        //    set { ChangeProperty(ref _p1TwentyClosed, value); }
        //}
        //private bool _p1NineteenClosed;
        //public bool P1NineteenClosed
        //{
        //    get { return _p1NineteenClosed; }
        //    set { ChangeProperty(ref _p1NineteenClosed, value); }
        //}
        //private bool _p1EighteenClosed;
        //public bool P1EighteenClosed
        //{
        //    get { return _p1EighteenClosed; }
        //    set { ChangeProperty(ref _p1EighteenClosed, value); }
        //}
        //private bool _p1SeventeenClosed;
        //public bool P1SeventeenClosed
        //{
        //    get { return _p1SeventeenClosed; }
        //    set { ChangeProperty(ref _p1SeventeenClosed, value); }
        //}
        //private bool _p1SixteenClosed;
        //public bool P1SixteenClosed
        //{
        //    get { return _p1SixteenClosed; }
        //    set { ChangeProperty(ref _p1SixteenClosed, value); }
        //}
        //private bool _p1FifteenClosed;
        //public bool P1FifteenClosed
        //{
        //    get { return _p1FifteenClosed; }
        //    set { ChangeProperty(ref _p1FifteenClosed, value); }
        //}
        //private bool _p1BullClosed;
        //public bool P1BullClosed
        //{
        //    get { return _p1BullClosed; }
        //    set { ChangeProperty(ref _p1BullClosed, value); }
        //}
        //#endregion

        //#region Player2 bool for closed numbers

        //private bool _p2TwentyClosed;
        //public bool P2TwentyClosed
        //{
        //    get { return _p2TwentyClosed; }
        //    set { ChangeProperty(ref _p2TwentyClosed, value); }
        //}

        //private bool _p2NineteenClosed;
        //public bool P2NineteenClosed
        //{
        //    get { return _p2NineteenClosed; }
        //    set { ChangeProperty(ref _p2NineteenClosed, value); }
        //}

        //private bool _p2EighteenClosed;
        //public bool P2EighteenClosed
        //{
        //    get { return _p2EighteenClosed; }
        //    set { ChangeProperty(ref _p2EighteenClosed, value); }
        //}

        //private bool _p2SeventeenClosed;
        //public bool P2SeventeenClosed
        //{
        //    get { return _p2SeventeenClosed; }
        //    set { ChangeProperty(ref _p2SeventeenClosed, value); }
        //}

        //private bool _p2SixteenClosed;
        //public bool P2SixteenClosed
        //{
        //    get { return _p2SixteenClosed; }
        //    set { ChangeProperty(ref _p2SixteenClosed, value); }
        //}

        //private bool _p2FifteenClosed;
        //public bool P2FifteenClosed
        //{
        //    get { return _p2FifteenClosed; }
        //    set { ChangeProperty(ref _p2FifteenClosed, value); }
        //}

        //private bool _p2BullClosed;
        //public bool P2BullClosed
        //{
        //    get { return _p2BullClosed; }
        //    set { ChangeProperty(ref _p2BullClosed, value); }
        //}

        //#endregion

        #region Player One scoreboard
        private DartboardNumber _p1Twenty;
        public DartboardNumber P1Twenty
        {
            get { return _p1Twenty; }
            set { ChangeProperty(ref _p1Twenty, value); }
        }

        private DartboardNumber _p1Nineteen;
        public DartboardNumber P1Nineteen
        {
            get { return _p1Nineteen; }
            set { ChangeProperty(ref _p1Nineteen, value); }
        }

        private DartboardNumber _p1Eighteen;
        public DartboardNumber P1Eighteen
        {
            get { return _p1Eighteen; }
            set { ChangeProperty(ref _p1Eighteen, value); }
        }

        private DartboardNumber _p1Seventeen;
        public DartboardNumber P1Seventeen
        {
            get { return _p1Seventeen; }
            set { ChangeProperty(ref _p1Seventeen, value); }
        }

        private DartboardNumber _p1Sixteen;
        public DartboardNumber P1Sixteen
        {
            get { return _p1Sixteen; }
            set { ChangeProperty(ref _p1Sixteen, value); }
        }

        private DartboardNumber _p1Fifteen;
        public DartboardNumber P1Fifteen
        {
            get { return _p1Fifteen; }
            set { ChangeProperty(ref _p1Fifteen, value); }
        }

        private DartboardNumber _p1Bull;
        public DartboardNumber P1Bull
        {
            get { return _p1Bull; }
            set { ChangeProperty(ref _p1Bull, value); }
        }

        #endregion

        #region Player Two scoreboard
        private DartboardNumber _p2Twenty;
        public DartboardNumber P2Twenty
        {
            get { return _p2Twenty; }
            set { ChangeProperty(ref _p2Twenty, value); }
        }

        private DartboardNumber _p2Nineteen;
        public DartboardNumber P2Nineteen
        {
            get { return _p2Nineteen; }
            set { ChangeProperty(ref _p2Nineteen, value); }
        }

        private DartboardNumber _p2Eighteen;
        public DartboardNumber P2Eighteen
        {
            get { return _p2Eighteen; }
            set { ChangeProperty(ref _p2Eighteen, value); }
        }

        private DartboardNumber _p2Seventeen;
        public DartboardNumber P2Seventeen
        {
            get { return _p2Seventeen; }
            set { ChangeProperty(ref _p2Seventeen, value); }
        }

        private DartboardNumber _p2Sixteen;
        public DartboardNumber P2Sixteen
        {
            get { return _p2Sixteen; }
            set { ChangeProperty(ref _p2Sixteen, value); }
        }

        private DartboardNumber _p2Fifteen;
        public DartboardNumber P2Fifteen
        {
            get { return _p2Fifteen; }
            set { ChangeProperty(ref _p2Fifteen, value); }
        }

        private DartboardNumber _p2Bull;
        public DartboardNumber P2Bull
        {
            get { return _p2Bull; }
            set { ChangeProperty(ref _p2Bull, value); }
        }
        #endregion
    }
}
