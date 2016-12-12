using System;
using System.Collections.Generic;

namespace ConsoleApp2015
{
    static class LinkedList
    {
        #region   LinkedListsAlgorithms

        public static void SubtractTwoLinkedLists()
        {
            LinkedList<int> list1 = CreateLinkedList();
            LinkedList<int> list2 = CreateLinkedList();

            int number1 = GetLinkedListNumber(list1);
            int number2 = GetLinkedListNumber(list2);

            int difference = 0;
            int addextra=0;
            checked
            {
                difference = number1 >= number2 ? number1 - number2 : number2 - number1;
            }

            Console.WriteLine(string.Format("The difference in LinkedList numbers are {0}", difference));
            Console.Read();
        }

        public static void SortLinkedList()
        {
            LinkedList<int> sortedList = CreateAndSortLinkedList();

            PrintLinkedList(sortedList);
        }

        #endregion

        #region   HelperMethods

        private static LinkedList<int> CreateLinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            Console.Write("Enter number of nodes in List1:");
            int numberOfNodesInList = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < numberOfNodesInList; i++)
            {
                Console.Write(string.Format("Enter node {0} value", i));

                int nodeValue = Convert.ToInt16(Console.ReadLine());

                if (nodeValue > Constants.MaxValueInLinkedListNode)
                {
                    Console.WriteLine("Can not enter number more than 9 , Enter number again:");
                    nodeValue = Convert.ToInt16(Console.ReadLine());
                }
                LinkedListNode<int> nodeOfList = new LinkedListNode<int>(nodeValue);

                if (list.Count == 0)
                {
                    list.AddFirst(nodeOfList);
                }
                else
                {
                    list.AddLast(nodeOfList);
                }
            }

            return list;
        }

        private static int GetLinkedListNumber(LinkedList<int> list)
        {
            int number = 0;
            int counter = 1;
            LinkedListNode<int> node = list.First;

            while (node != null)
            {
                number = number + node.Value * (int)Math.Pow(10, list.Count - counter);
                node = node.Next;
                counter++;
            }

            return number;
        }

        private static LinkedList<int> CreateLinkedList(int number)
        {
            LinkedList<int> list = new LinkedList<int>();

            //fill List

            return list;
        }

        private static void PrintLinkedList(LinkedList<int> linkedList)
        {
            LinkedListNode<int> node = linkedList.First;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        private static LinkedList<int> CreateAndSortLinkedList()
        {
            LinkedList<int> linkedList1 = null;
            LinkedList<int> sortedList = null;
            List<int> listFromLinkedList = null;

            linkedList1 = CreateLinkedList();
            listFromLinkedList = new List<int>(linkedList1);
            listFromLinkedList.Sort();
            sortedList = new LinkedList<int>(listFromLinkedList);

            return sortedList;
        }

        #endregion
    }
}
