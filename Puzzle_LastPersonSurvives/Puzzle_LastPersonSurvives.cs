using System;

namespace Puzzles
{
    /// <summary>
    /// 100 people standing in a circle in an order 1 to 100. 
    /// No.1 has a sword. He kills next person(i.e No.2) and gives sword to next to next (i.e No.3). 
    /// All person does the same until only 1 survives at the last.
    /// Which number survives at the last?
    /// </summary>
    class Puzzle_LastPersonSurvives
    {
        const int PEOPLESIZE=100;
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client serClient = new ServiceReference1.Service1Client();
            Puzzles.ServiceReference1.CompositeType servReturn = serClient.GetDataUsingDataContract(new Puzzles.ServiceReference1.CompositeType() { BoolValue = true, StringValue = "Hello;;;" });
            Console.Write(servReturn.StringValue);

            int k, l = 0, peopleCount = 0;
            bool isLastPersonInArray = false;
            int[] arrayPeople = new int[PEOPLESIZE];
            int[] temparrayPeople = new int[PEOPLESIZE];

            for (int i = 0; i < arrayPeople.Length; i++)
            {
                arrayPeople[i] = i + 1;
            }

            while (peopleCount != 1)
            {
                peopleCount = 0;
                k = 0;
                for (int j = 0; j <= arrayPeople.Length; j++)
                {
                    if (j + 1 < arrayPeople.Length && arrayPeople[j + 1] != 0 && l == 0)
                        arrayPeople[++j] = 0;
                    else if (j < arrayPeople.Length && arrayPeople[j] != 0 && l == 1)
                        arrayPeople[j++] = 0;
                }

                for (int s = 0; s < arrayPeople.Length; s++)
                {
                    if (arrayPeople[s] != 0)
                    {
                        peopleCount++;
                    }
                }
                temparrayPeople = new int[peopleCount];

                for (int s = 0; s < arrayPeople.Length; s++)
                {
                    if (arrayPeople[s] != 0)
                    {
                        temparrayPeople[k++] = arrayPeople[s];
                        if (s == arrayPeople.Length - 1)
                            isLastPersonInArray = true;
                    }
                }
                arrayPeople = temparrayPeople;

                if (isLastPersonInArray) l = 1; else l = 0;
            }

            foreach (int res in temparrayPeople)
            {
                Console.Write(res + "\t");
            }
            Console.Read();
        }
    }
}
