using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController.Navigation.Implementation;
using RobotControllerTest.Mocks.Control;
using RobotControllerTest.Mocks.Navigation;
using RobotControllerTest.Mocks.Topography;
using RobotControllerTest.Utils;

namespace RobotControllerTest
{
    [TestClass]
    public class ControllerIntegration
    {
        AcceptanceNavigationManager testingNavManager;

        MockRuleSet mockRuleSet;
        MockUpdatableActor mockRoboManager;
        MockCoordinateSystem mockTileMap; //Mocks a symmetrical tile map

        private Queue<string> simulationQueue;

        const int mapSize = 10;

        const string testInput = "LFRFFFFFFFFFFFFFF";

        void Setup()
        {
            mockRuleSet = new MockRuleSet();

            XmlRuleParser.LoadRules("rules.xml", ref mockRuleSet);

            byte[,] mapLayout = CSVReader.GetSymmetrical("map.csv");
            mockTileMap = MapBuilder.BuildSymmetrical(mapLayout, mockRuleSet);

            mockRoboManager = new MockUpdatableActor();
            testingNavManager = new AcceptanceNavigationManager(mockRoboManager, mockRuleSet, mockTileMap);
            simulationQueue = Parsers.TokenizeToFIFOQueue(testInput);

        }

        void PopulateResults()
        {
            while(simulationQueue.Count > 0)
            {
                string nextMove = simulationQueue.Dequeue();
                InputInterpreter.NextMove(nextMove, ref testingNavManager);
            }
        }

        bool MatchResultOutcome(string input, string markerExpectation, string resultExpectation)
        {
            string[] tokens = input.Split(':');

            bool markerOutcome = tokens[0].Equals(markerExpectation);
            bool resultOutcome = tokens[1].Equals(resultExpectation);

            return markerOutcome && resultOutcome;
        }

        [TestMethod]
        public void TraversalTest()
        {
            //Tested input command list:
            //LFRFFFF FFFFFFFFFF

            Setup();
            PopulateResults();
            List <string> results = Results.GetResults();

            //First row X axis traversals: LFRFFFF    result   xy coordinates moved to
            Assert.IsTrue(MatchResultOutcome(results[0], "m", "10"));
            Assert.IsTrue(MatchResultOutcome(results[1], "r", "1"));
            Assert.IsTrue(MatchResultOutcome(results[2], "m", "20"));
            Assert.IsTrue(MatchResultOutcome(results[3], "m", "30"));
            Assert.IsTrue(MatchResultOutcome(results[4], "m", "40"));
            Assert.IsTrue(MatchResultOutcome(results[5], "m", "50"));
            Assert.IsTrue(MatchResultOutcome(results[6], "r", "1"));

            //Sixth column Y axis traversals: FFFFFFFFFF
            Assert.IsTrue(MatchResultOutcome(results[7], "m", "51"));
            Assert.IsTrue(MatchResultOutcome(results[8], "m", "52"));
            Assert.IsTrue(MatchResultOutcome(results[9], "m", "53"));
            Assert.IsTrue(MatchResultOutcome(results[10], "m", "54"));
            Assert.IsTrue(MatchResultOutcome(results[11], "m", "55"));
            Assert.IsTrue(MatchResultOutcome(results[12], "m", "56"));
            Assert.IsTrue(MatchResultOutcome(results[13], "m", "57"));
            Assert.IsTrue(MatchResultOutcome(results[14], "m", "58"));
            Assert.IsTrue(MatchResultOutcome(results[15], "m", "59"));
        }
    }
}
