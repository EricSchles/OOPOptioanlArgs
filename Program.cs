using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPOptioanlArgs
{

    class Alpha
    {
        private string name;
        private int age;
        private string bio;
        private string weapon;
        private int weapon_power;
        private int hp;

        public Alpha()
        {
            this.name = "Alpha";
            this.age = 27;
            this.bio = "Alpha comes from nowhere";
            this.weapon = "sword of time";
            this.weapon_power = 5;
            this.hp = 42;
        }

        public Alpha(string name,string bio) : this()
        {
            this.name = name;
            this.bio = bio;
        }
        
        public Alpha(string savedGame = "c:\\users\\eric\\documents\\visual studio 2012\\Projects\\OOPOptionalArgs\\OOPOptionalArgs\\progress.txt")
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(savedGame);
            while ((line = file.ReadLine()) != null)
            {
                string[] parsedLine = line.Split(':');
                if (parsedLine[0] == "name")
                {
                    this.name = parsedLine[1];
                }
                else if (parsedLine[0] == "age")
                {
                    this.age = int.Parse(parsedLine[1]);
                }
                else if (parsedLine[0] == "bio")
                {
                    this.bio = parsedLine[1];
                }
                else if (parsedLine[0] == "weapon")
                {
                    this.weapon = parsedLine[1];
                }
                else if (parsedLine[0] == "weapon_power")
                {
                    this.weapon_power = int.Parse(parsedLine[1]);
                }
                else if (parsedLine[0] == "hp")
                {
                    this.hp = int.Parse(parsedLine[1]);
                }
                else
                {
                    file.Close();
                }

            }
        }
        
        public int WeaponPower{
            get { return weapon_power; }
        }

        public int HP
        {
            get { return hp; }
            set
            {
                if (this.hp == 0)
                {
                    Console.WriteLine("You died!!");
                }
                this.hp -= value;
            }
        }

        ~Alpha(){
            
            string path = Directory.GetCurrentDirectory();
            string[] cwd = path.Split('\\');
            string final_path = "";
            for (int i = 0; i < 8; i++)
            {
                final_path += cwd[i] + "\\";
            }
            StreamWriter writer = new StreamWriter(final_path + "progress.txt");
            writer.WriteLine("name:" + this.name);
            writer.WriteLine("age:" + this.age);
            writer.WriteLine("bio:" + this.bio);
            writer.WriteLine("weapon:" + this.weapon);
            writer.WriteLine("weapon_power:" + this.weapon_power);
            writer.WriteLine("hp:" + this.hp);
            writer.Close();

        }
     }
    

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the game of Alpha");
            Console.WriteLine("Our story begins with Alpha in a battle!!");
            int enemy_life = 10;
            int enemy_power = 2;
            Alpha a = new Alpha();
            Console.WriteLine("A goblin looms toward you bearing it's teeth menancingly.");
            Console.WriteLine("menacle laughter spills from the goblins crazed eyes as it howls, 'I'm gunna eat you one piece at a time'");
            
            while (enemy_life > 0)
            {
                
                Console.WriteLine("What do you do? (strike,defend,run away)");
                string move = Console.ReadLine();
                if (move == "strike")
                {
                    Random rnd = new Random();
                    int critical_attack = rnd.Next(1, 100);
                    if (critical_attack < 25)
                    {
                        enemy_life -= a.WeaponPower * 2;
                    }
                    else
                    {
                        enemy_life -= a.WeaponPower;
                    }
                    Console.WriteLine("the goblin howls, 'you cut me!!!', I will make you pay in blood");
                    if (enemy_life <= 0)
                    {
                        Console.WriteLine("Looks like you defeated the goblin, now it's time to wake up young one.  Wake up.");
                    }
                    else
                    {
                        Console.WriteLine("the goblin lunges at you with all it's might");
                        a.HP -= 1;
                        Console.WriteLine("Your remaining hit points are" + a.HP);
                    }
                    a.HP -= enemy_power;
                   
                }
                else if (move == "defend")
                {
                    Console.WriteLine("The goblin laughs, 'coward, I will crush you'");
                    a.HP -= (enemy_power - 1);
                    Console.WriteLine("The goblin cackles, 'you are weak'");
                }
                else
                {
                    Console.WriteLine("The world is not ready yet, by running away the dream breaks and the game ends...");
                    break;
                }

                
            }
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
    }
}
