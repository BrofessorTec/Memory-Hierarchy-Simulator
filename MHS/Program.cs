﻿namespace MHS
{
    internal class Program
    {
        public static void Main()
        {
            MemoryHierarchySimulator mhs = new MemoryHierarchySimulator();

            bool isRunning = true;
            //This should likely be put in as one of the options able to be changed with 0. Edit Configuration alongside the capacityOfCache.
            string pathOfTrace = "trunc_12.dat";

            while (isRunning)
            {
                mhs.ParseMemoryAddress(mhs.ReadMemoryTrace(pathOfTrace));

                Console.Clear();
                Console.WriteLine($"Memory Hierarchy Simulator for {pathOfTrace} with cache size {mhs.capacityOfCache}");
                Console.WriteLine("\nChoose algorithm to simulate:");
                Console.WriteLine("0. Edit Configuration");
                Console.WriteLine("1. FIFO Algorithm");
                Console.WriteLine("2. Furthest in Future Algorithm");
                Console.WriteLine("3. LRU Algorithm");
                Console.WriteLine("4. Random Algorithm");
                Console.WriteLine("Q. Quit the program\n");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "q":
                        Console.WriteLine("\nThanks for using the program, exiting now..");
                        Thread.Sleep(1000);
                        isRunning = false;
                        Environment.Exit(0);
                        break;
                    case "0":
                        // TODO enter config options here
                        Console.Clear();
                        Console.WriteLine("What option would you like to change?" +
                            "\n1. Use trunc_12.dat" +
                            "\n2. Use trace.dat" +
                            "\n3. Use real_tr.dat" +
                            "\n4. Change Cache Size");
                        string choice2 = Console.ReadLine();
                        if (choice2 == "1")
                        {
                            pathOfTrace = "trunc_12.dat";
                        }
                        else if (choice2 == "2")
                        {
                            pathOfTrace = "trace.dat";
                        }
                        else if (choice2 == "3")
                        {
                            pathOfTrace = "real_tr.dat";
                        } 
                        else if (choice2 == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("What cache size would you like to use?");
                            mhs.capacityOfCache = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Invalid Entry..");
                        }
                        break;
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Trace, Virtual Page Number, Virtual Page Offset, Physical Page Number, Physical Page Offset, hit/miss\n");
                        mhs.algoName = "FIFO";
                        FIFO.Run(mhs);
                        Console.WriteLine(mhs.DisplaySummaryStatistics());
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Trace, Virtual Page Number, Virtual Page Offset, Physical Page Number, Physical Page Offset, hit/miss\n");
                        mhs.algoName = "FIF";
                        FIF.Run(mhs);
                        Console.WriteLine(mhs.DisplaySummaryStatistics());
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Trace, Virtual Page Number, Virtual Page Offset, Physical Page Number, Physical Page Offset, hit/miss\n");
                        mhs.algoName = "LRU";
                        LRU.Run(mhs);
                        Console.WriteLine(mhs.DisplaySummaryStatistics());
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Trace, Virtual Page Number, Virtual Page Offset, Physical Page Number, Physical Page Offset, hit/miss\n");
                        mhs.algoName = "Random";
                        Random.Run(mhs);
                        Console.WriteLine(mhs.DisplaySummaryStatistics());
                        break;
                    default:
                        Console.WriteLine("Invalid Entry...");
                        break;
                }

                Console.WriteLine("\nPress enter to continue.");
                Console.ReadLine();
                Console.Clear();

                mhs.ResetValues();
            }
        }
    }   
}

