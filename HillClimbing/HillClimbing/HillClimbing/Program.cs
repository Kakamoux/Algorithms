using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillClimbing
{
    /// <summary>
    /// Search maximum utility of a node with hill climbing algotithm
    /// In this case the graph can be assimilated to a double chain list but it will work for all type of graph
    /// In this exemple the evaluation function just return the value of a node, can be chang wit hat you want
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int minValue = 1;
            int maxValue = 10;
            int graphLength = 50;
            List<Node> graph = new List<Node>();
            // initialize random graph with the given length and random value
            for (int i = 0; i < graphLength; i+=2)
            {
                Node n = new Node();
                n.Value = rnd.Next(minValue, maxValue);
                if (i != 0)
                {

                    n.Childs.Add(graph[i - 1]);
                    graph[i - 1].Childs.Add(n); ;
                }
                graph.Add(n);

                Node nxt = new Node();
                nxt.Value = rnd.Next(minValue, maxValue);
                graph.Add(nxt);
                nxt.Childs.Add(n);
                n.Childs.Add(nxt);

            }

            // the graph look like : N => node, <-> : bidirectional link
            // N0 <-> N1 <-> N2 <-> N3 <-> N4 <-> N5 <-> ... etc

            //display graph
            foreach (var item in graph)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    Console.Write('#');
                }
                Console.Write('\n');
            }


            // select random start node for hill climbing research
            int selectedNode = rnd.Next(graph.Count);
            HillClimbing hc = new HillClimbing();
            Node resultMax =  hc.Start(graph[selectedNode], true);
            Node resultMin =  hc.Start(graph[selectedNode], false);





            Console.Write('\n'); Console.Write('\n');
            //display result
            Console.WriteLine("Start yellow, result red, blue : start and end equals");

            Console.Write('\n'); Console.Write('\n');
            Console.WriteLine("/****** RESULT MAXIMISE ******/");

            for (int j = 0; j < graph.Count; j++)
            {
                if (j == selectedNode && graph[j] == resultMax)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (j == selectedNode)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                else if (graph[j] == resultMax)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < graph[j].Value; i++)
                {

                    Console.Write('#');
                }
                Console.Write('\n');
            }

            Console.WriteLine("/****** RESULT Minimise ******/");

            for (int j = 0; j < graph.Count; j++)
            {
                if (j == selectedNode && graph[j] == resultMin)
                    Console.ForegroundColor = ConsoleColor.Blue;
                if (j == selectedNode)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                
                else if (graph[j] == resultMin)
                    Console.ForegroundColor = ConsoleColor.Red;

                else
                    Console.ForegroundColor = ConsoleColor.White;


                for (int i = 0; i < graph[j].Value; i++)
                {

                    Console.Write('#');
                }
                Console.Write('\n');
            }
            
                
            


            Console.ReadLine();

           
        }
    }
}
