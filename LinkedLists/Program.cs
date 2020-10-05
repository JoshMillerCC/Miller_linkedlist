using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList newLinked = new LinkList();

            string userInput = "";
            while(userInput != "6")
            {
                Console.WriteLine("1. Show Head");
                Console.WriteLine("2. Add Item");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Search for Item");
                Console.WriteLine("5. Print");
                Console.WriteLine("6. Exit\n");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // show first item in list
                        if(newLinked.getFirst() == null)
                        { Console.WriteLine("Empty List\n"); }
                        else
                        { Console.WriteLine(newLinked.getFirst().data); }
                        break;

                    case "2":
                        // add item to list
                        Console.WriteLine("What would you like to add?\n");
                        string addedLink = Console.ReadLine();

                        Console.WriteLine("Would you like to add to the front or back of the list? 'F'= Front/'B' = Back\n");
                        string frontBack = Console.ReadLine().ToUpper();
                        while(!frontBack.Equals("B") && !frontBack.Equals("F"))
                        {
                            Console.WriteLine("Pick a valid option\n");
                            frontBack = Console.ReadLine().ToUpper();
                        }
                        if (frontBack.Equals("F"))
                            { newLinked.addFirst(addedLink); }
                        else
                            { newLinked.Add(addedLink); } 
                        break;

                    case "3":
                        // remove item from list
                        Console.WriteLine("What would you like to remove?\n");
                        string removedLink = Console.ReadLine();
                        if(newLinked.Contains(removedLink) == null)
                        { Console.WriteLine(removedLink + " does not exist in the list.\n"); }
                        else
                        {
                            newLinked.Remove(removedLink);
                            Console.WriteLine(removedLink + " removed from the list.\n");
                        }
                        break;

                    case "4":
                        // search for specific item in list
                        Console.WriteLine("What would you like to look for?\n");
                        string searchedLink = Console.ReadLine();
                        if(newLinked.Contains(searchedLink) == null)
                        { Console.WriteLine(searchedLink + " does not exist in the list.\n"); }
                        else
                        { Console.WriteLine(searchedLink + " exists in the list.\n"); }
                        
                        break;

                    case "5":
                        // list all items
                        Console.WriteLine("Items in list are:");
                        Console.WriteLine(newLinked.PrintAllNodes());
                        break;

                    case "6":
                        // exit program
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please pick a valid option.\n");
                        break;
                }
            }
        }
    }
    public class Node
        {
            public string data;
            public Node next;

            public Node(string d)
            {
                data = d;
                next = null;
            }
        }
    public class LinkList
    {
        Node head;

        public Node getFirst()
        {
            // if there is nothing in head, return null, there is no linked list
            if(head == null)
            {
                return null;
            }
            // else return whatever is in the first position
            else
            {
                return head;
            }
        }
        public void addFirst(string d)     // add a new node to the front of the list
        {
            Node newNode = new Node(d);
            newNode.next = head;
            head = newNode;
        }

        public void Add(string d)      // add a node to the end of the list
        {
            // if head is null, there is nothing in the list so add to it.
            Node newNode = new Node(d);
            if(head == null)
            {
                head = newNode;
            }
            // if head is not null, there is something in the list.
            // loop through the list until you find a null reference and add there.
            else
            {
                Node current = head;
                while(current.next != null)
                { current = current.next; }
                current.next = newNode;
            }
        }

        //PrintAllNodes       Prints the entire list front to back. Breaking encapsulation here is permitted
        public string PrintAllNodes()
        {
            // check to see if head is null, if so, print out "empty"
            Node tempNode = head;
            string result = "";
            if(head == null)
            {
                return "Empty List\n";
            }
            else
            {
                while (tempNode != null)
                {
                    result = result + tempNode.data + "\n";
                    tempNode = tempNode.next;
                }
                return result;
            }
        }

        // Contains(item)      Returns a node with a matching item; if no match, return null
        public Node Contains(string d)
        {
            // if head is null return null since there is nothing in the list
            if(head == null)
            {
                return null;
            }
            else
            {
                // create temp node. loop through the list checking the data of each  node until you find a match, return that node.
                Node tempNode = head;
                while (tempNode.data != d)
                {
                    tempNode = tempNode.next;
                    if(tempNode == null)
                    { return null; }
                }
                return tempNode;
            }
        }
        
        // Remove(item)    Removes an item from the list
        public void Remove(string d)
        {
            Node tempNode = head;
            while(tempNode != null)
            {
                if(tempNode.data == d)
                {
                    head = tempNode.next;
                    break;
                }
                if(tempNode.next.data == d)
                {
                    tempNode.next = tempNode.next.next;
                    break;
                }
                tempNode = tempNode.next;   
            }
        }
    }
}
