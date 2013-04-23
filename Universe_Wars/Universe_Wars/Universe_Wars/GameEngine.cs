using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class GameEngine
    {
        private static GameEngine instance;

        private static Game _game;  

        //lijst met enemy's
        public List<Enemy> enemyList = new List<Enemy>();

        //lijst met bullets.
        public List<Bullet> bulletList = new List<Bullet>();

        //lijst met bommen.
        public List<Bullet> bombList = new List<Bullet>();

        //lijst met chures (om bommen te gooien).
        public List<Enemy> chureList = new List<Enemy>();

        //lijst met upgrades.
        public List<Upgrade> upgradeList = new List<Upgrade>();

        //timer om enemy's niet tegenlijk de spawnen.
        private Timer timer = new Timer(2000);

        //hoeveel upgrades heeft de player.
        public int upgraded {get; set;}      

        //timer om enemy's random te spawnen.
        private int timerCount = 0;

        //het huidige level.
        public int currentLevel {get; set;}

        //aantal levens van de player.
        public int lives { get; set; }

        //aantal enemy's die gedood zijn.
        public int score { get; set; }

        //Hoeveel enemy's moeten er spawnen?
        public int enemyNumber { get; set; }

        //tekst om status aan te geven(gewonnen/verloren).
        public string gameText { get; set; }

        //aantal bullet die een enemy gehit hebben.
        public int bulletHits { get; set; }

        //gameengine constructor.
        private GameEngine()
        {
            lives = 3;
            score = 0;
            upgraded = 0;
            bulletHits = 0;
            enemyNumber = 5;
        }

        //haal game op.
        public static void initialize(Game game)
        {
            _game = game;          
        }

        //SINGLETON
        public static GameEngine getInstance()
        {
            if (instance == null)
            {
                instance = new GameEngine();
            }

            return instance;
        }

        //update functie, wordt constant uitgevoerd.
        public void update()
        {
            CleanUp();
            HitTestBullet();
            HitTestSpaceship();
        }


        //De levelprocessor, handel het levelsysteem af.
        public void levelProcessor()
        {
            //Zet de timer uit om het level te stoppen.
            timer.Enabled = false;
            //Leeg alle lijsten.
            enemyList.Clear();
            bulletList.Clear();
            bombList.Clear();
            chureList.Clear();

            //verwijder alle game components
            _game.Components.Clear();

            //Maak spaceship(speler) opnieuw aan.
            _game.Components.Add(Game1.spaceship);

            //Upgrade het spaceship met de upgrades van voor de processor.
            Game1.spaceship.upgrade(upgraded);

            //Kijk aan de hand van currentlevel welk lever gestart moet worden en set het aantal enemy's voor het level.
            if (currentLevel == 1)
            {
                level1();
            }
            if (currentLevel == 2)
            {
                enemyNumber = 10;
                level2();
            }
            if (currentLevel == 3)
            {
                enemyNumber = 20;
                level3();
            }
            if (currentLevel > 3)
            {
                currentLevel = 3;
                gameText = "You won with "+ score + " points!";
                
            }

            //Zet de timer weer op 0.
            timerCount = 0;

            //Trek een leven van lives af.
            lives--;

            //kijk of de speler dood is.
            checkDead();
        }

        //Voer level 1 uit.
        public void level1()
        {         
            currentLevel = 1;

            timer.Elapsed -= count;
            timer.Elapsed += count;

            timer.Enabled = true;
        }

        //Voer level2 uit.
        public void level2()
        {
            currentLevel = 2;

            timer.Elapsed -= count;
            timer.Elapsed += count;

            timer.Enabled = true;
        }

        //Voer level3 uit.
        public void level3()
        {
            currentLevel = 3;

            timer.Elapsed -= count;
            timer.Elapsed += count;

            timer.Enabled = true;
        }

        //functie om enemy's random te spawnen (10 stuks)
        public void count(object sender, ElapsedEventArgs e)
        {

            //Maak enemyNumber(aantal) enemy's
            if (timerCount++ <= enemyNumber)
            {
                //voer create enemy uit voor een random gekozen soort.
                Enemy enemy = createEnemy(Game1.random.Next(0, 3));

                //voeg de enemy toe aan de game en de enemylist
                if (enemy != null)
                {
                    enemyList.Add(enemy);
                    _game.Components.Add(enemy);
                }
            }
            
            //Wanneer geen enemy's zijn.
            if (enemyList.Count() == 0)
            {
                //zet timer uit(geen nieuwe enemy's)
                timer.Enabled = false;
                //Voer het huidige level op.
                currentLevel++;
                //Voer de levelprocessor uit.
                levelProcessor();
                //Voeg een leven toe (er wordt standaard 1 afgetrokken door levelprocessor).
                lives++;
            }
        }

        //geef een bepaalde enemy terug aan de hand van ingegeven nummer. (uitgevoerd in count();).
        public Enemy createEnemy(int r)
        {
            if (r == 0)
            {
                return new Sinode(_game);
            }
            else if (r == 1)
            {
                return new Thege(_game);
            }
            else if (r == 2)
            {
                return new Chure(_game);
            }
            else
            {
                return null;
            }
        }

        //Functie om een random gekozen enemy uit de enemylist te geven.
        public Enemy getRandomEnemy()
        {
            Random random = new Random();
            if (enemyList.Count > 0)
            {
                return enemyList[random.Next(enemyList.Count)];
            }
            else return null;
        }

        //Functie om een random gekozen chure uit de churelist te geven.
        public Enemy getRandomChure()
        {
            Random random = new Random();
            if (chureList.Count > 0)
            {
                return chureList[random.Next(chureList.Count)];
            }
            else return null;
        }

        //Voeg gemaakte bullet toe aan de bulletlist.
        public void addBullet(Bullet bullet)
        {
            bulletList.Add(bullet);
        }
        
        //Verwijder de gevraagde bullet uit de bulletlist.
        public void removeBullet(Bullet bullet)
        {
            _game.Components.Remove(bullet);
            bulletList.Remove(bullet);        
        }

        //Wanneer uitgevoerd maak/drop nieuwe upgrade (kans 1/3).
        public void dropRandomUpgrade()
        {
            if (Game1.random.Next(0, 2) == 0)
            {
                Upgrade upgrade = new Upgrade(_game);
                if (upgrade != null)
                {
                    upgradeList.Add(upgrade);
                    _game.Components.Add(upgrade);
                }
            }

        }

        //opruimfunctie wanneer elementen uit het beeld zijn.
        public void CleanUp()
        {
            //Verwijder enemy wanneer uit het scherm
            if (enemyList.Count > 0)
            {
                for (int i = enemyList.Count - 1; i >= 0; i--)
                {
                    if (enemyList[i].onScreen() == true)
                    {
                        _game.Components.Remove(enemyList[i]);
                        enemyList.Remove(enemyList[i]);
                    }
                }
            }

            //Verwijder bullets wanneer uit het scherm
            if (bulletList.Count > 0)
            {
                for (int i = bulletList.Count - 1; i >= 0; i--)
                {
                    if (bulletList[i].onScreen() == true)
                    {
                        _game.Components.Remove(bulletList[i]);
                        bulletList.Remove(bulletList[i]);
                    }
                }
            }

            //Verwijder bommen wanneer uit het scherm
            if (bombList.Count > 0)
            {
                for (int i = bombList.Count - 1; i >= 0; i--)
                {
                    if (bombList[i].onScreen() == true)
                    {
                        _game.Components.Remove(bombList[i]);
                        bombList.Remove(bombList[i]);
                    }
                }
            }

            //Verwijder upgrades wanneer uit het scherm
            if (upgradeList.Count > 0)
            {
                for (int i = upgradeList.Count - 1; i >= 0; i--)
                {
                    if (upgradeList[i].onScreen() == true)
                    {
                        _game.Components.Remove(upgradeList[i]);
                        upgradeList.Remove(upgradeList[i]);
                    }
                }
            }

           
        }

        //Hittest, kijk of de bullet de enemy's raken.
        public void HitTestBullet()
        {
            //voer uit wanneer de in ieder geval 1 bullet en 1 enemy is.
            if (enemyList.Count() > 0
                && bulletList.Count() > 0)
            {
                //loop door de gehele enemylist.
                for (int e = enemyList.Count() - 1; e >= 0; e--)
                {
                    //loop door de gehele bulletlist.
                    for (int b = bulletList.Count() - 1; b >= 0; b--)
                    {
                            //kijk of de bullet en enemy zich in elkaars boundbox bevinden.
                            if (enemyList[e].BoundingBox.Contains((int)bulletList[b].position.X, (int)bulletList[b].position.Y))
                            {
                                //Voeg een bullet hit toe.
                                bulletHits++;
                                //Wanneer de enemy geen hitpoinst over heeft na aftrek.
                                if (enemyList[e].HitPoints - bulletList[b].bulletPower <= 0)
                                {
                                    //Haal de enemy van het scherm.
                                    _game.Components.Remove(enemyList[e]);

                                    //Voer de randomupgradedrop uit.
                                    dropRandomUpgrade();

                                    //Verwijder enemy van de enemylist.
                                    enemyList.Remove(enemyList[e]);

                                    //Verwijder enemy van de churelist.
                                    if (chureList.Count < e && chureList.Count > 0)
                                    {
                                        chureList.Remove(enemyList[e]);
                                    }
                                    //Voeg een punt toe aan de score.
                                    score++;
                                }
                                //Wanneer er nog wel genoeg hitpoinst zijn, trek deze er dan af.
                                else
                                {
                                    enemyList[e].HitPoints = enemyList[e].HitPoints - bulletList[b].bulletPower;
                                }
                                
                                //verwijder de bullet die geraakt heeft uit de game en uit de bulletlist.
                                _game.Components.Remove(bulletList[b]);
                                bulletList.Remove(bulletList[b]);
                                
                                //
                                break;                          
                        }
                    }
                }
            }
        }

        //Kijk of het spaceship(player) is geraakt door enemy/bomb/upgrade.
        public void HitTestSpaceship()
        {
            //Kijk of geraakt door enemy wanneer er op zijn minst 1 enemy is.
            if (enemyList.Count() >= 1)
            {
                //loop door de enemy's
                for (int e = enemyList.Count() - 1; e >= 0; e--)
                {
                    //Wanneer de speler geraakt is door een enemy, voer de leverprocessor uit.
                    if (Game1.spaceship.BoundingBox.Intersects(enemyList[e].BoundingBox))
                    {                       
                        levelProcessor();
                        break;
                    }
                }
            }

            //Kijk of geraakt door bomb wanneer er op zijn minst 1 bomb is.
            if (bombList.Count() >= 1)
            {
                //loop door de bomblist
                for (int e = bombList.Count() - 1; e >= 0; e--)
                {
                    //Wanneer spaceship is geraakt door bom, voer de levelprocessor uit.
                    if (Game1.spaceship.BoundingBox.Intersects(bombList[e].BoundingBox))
                    {
                        levelProcessor();
                        break;
                    }
                }
            }

            //Kijk of geraakt door upgrade wanneer er op zijn minst 1 upgrade is.
            if (upgradeList.Count() >= 1)
            {
                //loop door de lijst met upgrades
                for (int e = upgradeList.Count() - 1; e >= 0; e--)
                {
                    //Wanner spaceship is geraakt door een upgrade, verwijder de uitgrade van scherm en list en voeg een upgrade toe.
                    if (Game1.spaceship.BoundingBox.Intersects(upgradeList[e].BoundingBox))
                    {
                        _game.Components.Remove(upgradeList[e]);
                        upgradeList.Remove(upgradeList[e]);
                        
                        upgraded++;
                        Game1.spaceship.upgrade(upgraded);
                        break;
                    }

                }
            }
        }

        //Check of de speler game over is.
        public void checkDead()
        {
            if (lives < 0)
            {
                timer.Enabled = false;
                gameText = "You lost with " + score + " point(s)!";
            }
        }
    }
}
