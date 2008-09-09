using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;

namespace AjaxIntroCodeSamples
{
    public static class ObjectHelper
    {
        public static IList<myObject>GetAllMyObjects()
        {
            var myList = new List<myObject>
                             {
                                 new myObject {Name = "Bronson Arroyo", Number = 61, Sport = Sports.Baseball},
                                 new myObject {Name = "Brian Urlacher", Number = 54, Sport = Sports.Football},
                                 new myObject {Name = "Rick Nash", Number = 61, Sport = Sports.Hockey},
                                 new myObject {Name = "Ryan Freel", Number = 6, Sport = Sports.Baseball},
                                 new myObject {Name = "Walter Payton", Number = 34, Sport = Sports.Football},
                                 new myObject {Name = "Alexander Ovechkin", Number = 8, Sport = Sports.Hockey},
                                 new myObject {Name = "Johnny Bench", Number = 5, Sport = Sports.Baseball},
                                 new myObject {Name = "Mike Vrabel", Number = 50, Sport = Sports.Football},
                                 new myObject {Name = "Mike Modano", Number = 9, Sport = Sports.Hockey}
                             };

            return myList;
        }
    }

    [TestFixture]
    public class ObjectHelperTests
    {
        [Test]
        public void GetTwoHockeyPlayers()
        {
            var hockeyPlayers = ObjectHelper.GetAllMyObjects().Where(p => p.Sport == Sports.Hockey).Take(2).ToList();

            Assert.IsNotNull(hockeyPlayers);
            Assert.GreaterThan(hockeyPlayers.Count, 0);
            Assert.AreEqual(2, hockeyPlayers.Count);
            Assert.AreEqual("Rick Nash", hockeyPlayers.ToList()[0].Name);
        }

        [Test]
        public void GetNextTwoPlayers()
        {
            var players = ObjectHelper.GetAllMyObjects().Skip(2).Take(2).ToList();

            Assert.IsNotNull(players);
            Assert.AreEqual(2, players.Count);
            Assert.AreEqual("Rick Nash", players[0].Name);
        }
    }
}