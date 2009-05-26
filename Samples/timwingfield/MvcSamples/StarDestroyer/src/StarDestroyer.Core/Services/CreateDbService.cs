using System.Collections.Generic;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Core.Services
{
    public class CreateDbService
    {
        const string dbFile = "StarDestroyerCLAIMS.db";

        public int CreateDb()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    #region trooplist
                    var troopList = new List<AssaultItem>
                                        {
                                            new AssaultItem
                                                {
                                                    Description = "2 Shock Troopers, 6 Stormtroopers",
                                                    LoadValue = 4,
                                                    Type = "Shock Trooper Support Squad"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "5 Dark Troopers",
                                                    LoadValue = 4,
                                                    Type = "Dark Trooper Sqaud"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "8 Scout Troopers",
                                                    LoadValue = 4,
                                                    Type = "Scout Trooper Sqaud"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "Speeder Bike and 1 Scout Trooper",
                                                    LoadValue = 2,
                                                    Type = "Speeder Bike"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "Heavy Blaster and 2 Stormtroopers",
                                                    LoadValue = 1,
                                                    Type = "Heavy Blaster"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "AT-ST and pilot",
                                                    LoadValue = 6,
                                                    Type = "AT-ST"
                                                }
                                        };

                    var shockTroopers = new AssaultItem
                                            {
                                                Description = "6 Shock Troopers",
                                                LoadValue = 4,
                                                Type = "Shock Trooper Sqaud"
                                            };
                    var stormtroopers = new AssaultItem
                                            {
                                                Description = "9 Stormtroopers",
                                                LoadValue = 4,
                                                Type = "Standard Stormtrooper Sqaud"
                                            };
                    #endregion

                    foreach (var item in troopList)
                    {
                        session.SaveOrUpdate(item);
                    }

                    for (int i = 0; i < 11; i++)
                    {
                        var s = new LandingShip {Designation = string.Format("LS11{0}", i), Deployed = false};
                        session.SaveOrUpdate(s);
			        }

                    var landingShip = new LandingShip {Deployed = true, Designation = "LS1138"};
                    landingShip.AddAssaultItem(shockTroopers);
                    landingShip.AddAssaultItem(stormtroopers);

                    session.SaveOrUpdate(landingShip);
                    
                    trx.Commit();
                }
            }

            int count;

            using (var session = sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var items = session.CreateCriteria(typeof (AssaultItem)).List<AssaultItem>();
                    count = items.Count;
                }
            }

            return count;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(dbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                    .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(dbFile))
                File.Delete(dbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}