using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathfinding
{
    class Program
    {
        static void Main(string[] args)
        {

            var env = new char[,]
            {
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','x','0','0','0','0'},
                {'0','x','x','x','x','0','0','0','0'},
                {'0','0','0','0','x','0','0','0','0'},
                {'x','x','x','0','x','0','0','0','0'},
                {'0','0','0','0','x','0','0','0','0'},
                {'0','0','0','0','x','0','0','0','0'},
                {'0','x','0','0','x','0','0','0','0'},
                {'0','x','0','0','x','0','0','0','0'},
                {'0','x','0','0','x','0','0','0','0'},
                {'0','x','0','0','x','0','0','0','0'},
                {'0','x','0','0','x','0','0','0','0'},
            };

            for (int y = 0; y < env.GetLength(0); y++)
            {
                for (int x = 0; x < env.GetLength(1); x++)
                {
                    if (env[y, x] == '0')
                        Console.ForegroundColor = ConsoleColor.White;
                    else if (env[y, x] == 'x')
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(env[y, x]);
                    
                }
                Console.Write('\n');
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('\n'); Console.Write('\n');
            List<Node> rsl = new List<Node>();
           AStar astar = new AStar();
            rsl = astar.Start(new Node(0, 11), new Node(8, 11), env);

            for (int y = 0; y < env.GetLength(0); y++)
            {
                for (int x = 0; x < env.GetLength(1); x++)
                {
                    if (env[y, x] == '0')
                        Console.ForegroundColor = ConsoleColor.White;
                    else if (env[y, x] == 'x')
                        Console.ForegroundColor = ConsoleColor.Red;

                    if (rsl.Contains(new Node(x, y)))
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('1');
                    }
                    else
                        Console.Write(env[y, x]);

                }
                Console.Write('\n');
            }

            Console.ReadLine();



        }
    }
}
