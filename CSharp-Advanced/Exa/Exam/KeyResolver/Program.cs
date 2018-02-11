using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var locks = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int intelligenceValue = int.Parse(Console.ReadLine());
            int originalBulletAmount = bullets.Count;
            int counter = 0;
            bool safeBroke = true;
            for (int bul = (bullets.Count - 1); bul >=0 ; bul--)
            {
                if (bullets.Count == 0)
                {
                    safeBroke = false;
                    break;
                }
                for (int lockk = 0; lockk < locks.Count; lockk++)
                {

                    if (bullets[bul] <= locks[lockk])
                    {
                        Console.WriteLine($"Bang!");
                        locks.RemoveAt(lockk);
                        bullets.RemoveAt(bul);
                        lockk--;
                        bul--;
                    }
                    else 
                    {
                        Console.WriteLine($"Ping!");
                        bullets.RemoveAt(bul);
                        bul--;
                        lockk--;

                    }

                    counter++;
                    if (bullets.Count==0)
                    {
                        safeBroke = false;
                        break;
                    }
                    if (counter == gunBarrelSize && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        counter = 0;
                    }
                }
                
            }

            
            if (!safeBroke && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = intelligenceValue - (bulletPrice * (originalBulletAmount - bullets.Count));
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
