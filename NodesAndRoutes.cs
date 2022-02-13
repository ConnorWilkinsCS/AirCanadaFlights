﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCanadaFlights
{
    //Shouldn't we have the second else if in AddRoute as (node1.Destinations.Contains(node2) || node2.Destinations.Contains(node1)) ???????
    //Same idea with RemoveRoute() --> //(!node1.Destinations.Contains(node2) || !node2.Destinations.Contains(node1)) ???????
    //We need to DM Alaadin on MS Teams in regards to FindAirport and whether our Find approach is accepted
   
    //no i do not think so bc this is a directed graph, not bi directional
    class AirportNode
    {
        //Karim's test
        private string name;
        private string code;
        private List<AirportNode> destinations;


        /// <summary>
        /// Name:AirportNode
        /// Constructor
        /// </summary>
        /// Parameters:
        /// <param name="Name"> name of airport </param>
        /// <param name="Code">name of airport </param>
        public AirportNode(string Name, string Code) //constructor
        {
            this.name = Name;
            this.code = Code;

            this.destinations = new List<AirportNode>();
        }
        public AirportNode(string Name, string Code, List<AirportNode> dests) //constructor
        {
            this.name = Name;
            this.code = Code;

            this.destinations = dests;
        }

        //properties

        /// <summary>
        /// Name:Name
        /// Property  for name field.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = Name;
            }
        } //property for name field.

        /// <summary>
        /// Name:Code
        /// Property for code field.
        /// </summary>
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                this.code = Code;
            }
        }

        /// <summary>
        /// Name:Destinations
        /// Property for destinations.
        /// </summary>
        public List<AirportNode> Destinations
        { //property for list of destinations.
            get { return destinations; }
            set { this.destinations = Destinations; }
        }

        /// <summary>
        /// Add destination to airport
        /// </summary>
        /// <param name="destAirport"> airport node to be addedd</param>
        /// <returns>bool true if destination was added, false otherwise</returns>
        public bool AddDestination(AirportNode destAirport)
        {
            if (destinations.Contains(destAirport))
            {
                return false;
            }
            else
            {
                destinations.Add(destAirport);
                return true;
            }
        }


        /// <summary>
        /// Remove destination from airport 
        /// </summary>
        /// <param name="destAirport">airport node to be removed</param>
        /// <returns>bool true if destination was removed, false otherwise</returns>
        public bool RemoveDestination(AirportNode destAirport)
        {
            if (destinations.Contains(destAirport))
            {
                return destinations.Remove(destAirport);
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Places all airport information into one string to print
        ///Overrides the ToString() method
        /// </summary>
        /// <returns>string which prints airport name, code
        /// destination airports and their names/codes</returns>
        public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
        {
            string destString = "";
            destString += "  Airport Name: " + Name + " || Airport Code: " + Code + "\n Destinations:  ";
            for (int i = 0; i < destinations.Count; i++)
            {
                destString += "\n Name: " + destinations[i].Name + " || Airport Code: " + destinations[i].Code + " ";

            }
            return destString;
            //  return "Airport Name: " + Name + " || Airport Code: " + Code + " || Destination List: " + Destinations.ToString();
        }

    }
    class RouteMap
    {
        private List<AirportNode> A = new List<AirportNode>(); //List of airport nodes.


        /// <summary>
        /// RouteMap constructor.
        /// </summary>
        public RouteMap() { } //RouteMap constructor. 5%

        /// <summary>
        /// keep track of the number 
        /// </summary>
        public int Count { get { return A.Count; } }

        /// <summary>
        /// method to call FindAirportName or FindAirportCode
        /// depending on what the length of the parameter
        /// </summary>
        /// <param name="something">either a name or code to of airport to find</param>
        /// <returns>airport node found or null if none found</returns>
        public AirportNode findAirport(string something)
        {
            //if code is entered i.e YYZ
            if (something.Length == 3)
            {
                return FindAirportCode(something);
                //otherwise it must be a name
            }
            else

                return FindAirportName(something);
        }

        /// <summary>
        /// method to call Find Airport by Name
        /// depending on what the length of the parameter
        /// </summary>
        /// <param name="something">either a name or code to of airport to find</param>
        /// <returns>airport node found or null if none found</returns>
        public AirportNode FindAirportName(string name) //Method to find airport by name.
        {
            if (A != null)
            {


                foreach (AirportNode node in A)
                {
                    if (node.Name.Equals(name))
                    {
                        Console.WriteLine("\nFound the airport {0}", name);
                        return node;
                    }
                }
            }
            else

                Console.WriteLine("\nCould not find the airport {0}", name);
            return null;

        }

        /// <summary>
        /// method to call  Find Airport by Code
        /// depending on what the length of the parameter
        /// </summary>
        /// <param name="something">either a name or code to of airport to find</param>
        /// <returns>airport node found or null if none found</returns>
        public AirportNode FindAirportCode(string code)
        {
            if (A != null)
            {


                foreach (AirportNode node in A)
                {
                    if (node.Code.Equals(code))
                    {
                        Console.WriteLine("\nFound the airport {0}", code);
                        return node;
                    }
                }
            }
            else

                Console.WriteLine("\nCould not find the airport {0}", code);
            return null;
        } //Method to find airport by code. 5%


        /// <summary>
        /// 
        /// Add airport to route map
        /// </summary>
        /// <param name="something">airport to be added</param>
        /// <returns> true if airport was added, false otherwise</returns>
        public bool AddAirport(AirportNode something)  //Method to add airport node. Duplicates not allowed. 5% public
        {
            if (findAirport(something.Name) != (null)) // //make sure the airport does not exists
            {
                return false;
            }
            else
            {
                A.Add(new AirportNode(something.Name, something.Code, something.Destinations)); //add airport to list
                Console.WriteLine(something.Name + " was added");
                return true;
            }
        }
        //like removeNode

        /// <summary>
        /// remove airport from  route map
        /// </summary>
        /// <param name="something">airport to be removed</param>
        /// <returns>true if airport was removed, false otherwise</returns>
        public bool RemoveAirport(AirportNode something)  //Method to remove airport node. Node must exist. 5% public bool
        {

            //make sure the airport exists
            AirportNode nodeToRemove = findAirport(something.Name); //declare airport node with data a

            if (nodeToRemove == null) // node must not be empty
            {
                return false;
            }

            else
            {
                A.Remove(nodeToRemove); //remove node from list

                //we need to remove the node from destination list in each airport node
                foreach (AirportNode node in A)
                {
                    node.RemoveDestination(nodeToRemove);
                }
                Console.WriteLine(something.Name + " was removed");
                return true;

            }
        }
        //same as addEdge




        /// <summary>
        /// add path from one airport to another airport (directed)
        /// </summary>
        /// <param name="origin">airport origin to be added to route</param>
        /// <param name="dest">airport destination to be added to route</param>
        /// <returns>true if route was added, false otherwise</returns>
        public bool AddRoute(AirportNode origin, AirportNode dest) //method to add route.
        {


            //make sure the airport exists
            AirportNode node1 = findAirport(origin.Name); //declare airport node with origin
            AirportNode node2 = findAirport(dest.Name); //declare airport node with destination



            if (node1 == null || node2 == null || node1.Equals(node2)) // nodes must contain data, if no data or origin = dest, return false
            {
                return false;
            }
            else if (node1.Destinations.Contains(node2)) // if origin = dest, return false 
            {
                return false;
            }
            else
            {
                node1.AddDestination(node2); //use AddDestination method to add destination node to the airports destination list
                                             // node2.AddDestination(node1); //use AddDestination method to add origin node to the airports destination list
                return true;
            }
        }
        //same as remove edge


        /// <summary>
        /// remove path from one airport to another airport (directed)
        /// </summary>
        /// <param name="origin">airport origin to be removed to route</param>
        /// <param name="dest">airport destination to be removed to route</param>
        /// <returns>true if route was removed, false otherwise</returns>
        public bool RemoveRoute(AirportNode origin, AirportNode dest) //method to remove route
        {

            //make sure the airport exists
            AirportNode node1 = findAirport(origin.Name); //declare airport node with origin
            AirportNode node2 = findAirport(dest.Name); //declare airport node with destination



            if (node1 == null || node2 == null) // nodes must contain data, if no data, return false
            {
                return false;
            }
            else if (!node1.Destinations.Contains(node2)) // if origin = dest, return false 
            {
                return false;
            }
            else
            {
                node1.RemoveDestination(node2); //use RemoveDestination method to remove destination node from the airports destination list
                node2.RemoveDestination(node1); //use RemoveDestination method to remove origin node from the airports destination list
                return true; //end
            }

        }
        /// <summary>
        /// string format of routemap showing each airport and each airport destinations
        /// overrides ToString()
        /// </summary>
        /// <returns>string format of routemap</returns>
        public override string ToString()
        {
            string map = "\n ";

            foreach (AirportNode node in A)
            {

                if (A != null)
                {
                    map += " \n\n Airport Name: " + node.Name + " || Airport Code: " + node.Code + "\n Destinations:  ";
                    for (int i = 0; i < node.Destinations.Count; i++)
                    {
                        map += "\n Name: " + node.Destinations[i].Name + " || Airport Code: " + node.Destinations[i].Code + " ";

                    }

                    //  return "Airport Name: " + Name + " || Airport Code: " + Code + " || Destination List: " + Destinations.ToString();
                }

            }
            return map;


        }

        public string FastestRoute(AirportNode origin, AirportNode dest)
        {
            LinkedList<AirportNode> searchList = new LinkedList<AirportNode>();
            if (origin == dest)
            {
                return origin.ToString();
            }
            else if (findAirport(origin.Name) == null || findAirport(dest.Name) == null)
            {
                return "";
            }
            else
            {
                //add origin node to the dictionary
                AirportNode originNode = findAirport(origin.Name);
                Dictionary<AirportNode, PathNodeInfo<AirportNode>> pathNodes = new Dictionary<AirportNode, PathNodeInfo<AirportNode>>();
                pathNodes.Add(originNode, new PathNodeInfo<AirportNode>(null));
                searchList.AddFirst(originNode);

                while (searchList.Count > 0)
                {
                    //extract front of search list
                    AirportNode currentNode = searchList.First.Value;
                    searchList.RemoveFirst();

                    //explore each neighbour of this node
                    foreach (AirportNode neighbor in currentNode.Destinations)
                    {
                        if (neighbor.Code == dest.Code)
                        {
                            pathNodes.Add(neighbor, new PathNodeInfo<AirportNode>(currentNode));
                            return "\nFastest Path between" + origin.Name + " and " + dest.Name + " is: " + CovertPathToString(neighbor, pathNodes);
                        }
                        else if (pathNodes.ContainsKey(neighbor))
                        {
                            //check for cycle, skip this neighbour
                            continue;
                        }
                        else
                        {
                            pathNodes.Add(neighbor, new PathNodeInfo<AirportNode>(currentNode));

                            searchList.AddLast(neighbor);

                            Console.WriteLine("\nJust Added " + neighbor.Name + " to search list");
                        }
                    }
                }
                //didn't find a path from origin to destination
                return "";
            }
        }

        static string CovertPathToString(AirportNode endNode, Dictionary<AirportNode, PathNodeInfo<AirportNode>> pathNodes)
        {
            //build ll for path in the correct order
            LinkedList<AirportNode> path = new LinkedList<AirportNode>();
            path.AddFirst(endNode);
            AirportNode previous = pathNodes[endNode].Previous;
            while (previous != null)
            {
                path.AddFirst(previous);
                previous = pathNodes[previous].Previous;
            }

            //build and return string
            StringBuilder pathString = new StringBuilder();
            LinkedListNode<AirportNode> currentNode = path.First;
            int nodeCount = 0;
            while (currentNode != null)
            {
                nodeCount++;
                //should add code too? .value.value
                pathString.Append(currentNode.Value.Name);
                if (nodeCount < path.Count)
                {
                    pathString.Append(" , ");

                }
                currentNode = currentNode.Next;
            }
            return pathString.ToString();
        }



    }

    public class PathNodeInfo<AirportNode>
    {
        //Graph: internal previous node variabl
        // e
        AirportNode previous;
        //Graph: constructor to initialize the previous node
        public PathNodeInfo(AirportNode previous)
        {
            this.previous = previous;
        }
        //Graph: Readonly return previous node prop
        public AirportNode Previous
        {
            get
            {
                return previous;
            }
        }
    }



}

//ignore for now.
//public string FastestRoute(AirportNode origin, AirportNode dest, RouteMap graph)
//{
//    LinkedList<AirportNode> searchList = new LinkedList<AirportNode>();
//    if (origin == dest)
//    {
//        return origin.ToString();
//    }
//    else if (graph.findAirport(origin.Name) == null || graph.findAirport(dest.Name) == null)
//    {
//        return "";
//    }
//    else
//    {
//        //add origin node to the dictionary
//        AirportNode originNode = graph.findAirport(origin.Name);
//        Dictionary<AirportNode, PathNodeInfo<AirportNode>> pathNodes = new Dictionary<AirportNode, PathNodeInfo<AirportNode>>();
//        pathNodes.Add(originNode, new PathNodeInfo<AirportNode>(null));
//        searchList.AddFirst(originNode);

//        while (searchList.Count > 0)
//        {
//            //extract front of search list
//            AirportNode currentNode = searchList.First.Value;
//            searchList.RemoveFirst();

//            //explore each neighbour of this node
//            foreach (AirportNode neighbor in currentNode.Destinations)
//            {
//                if (neighbor.Code == dest.Code)
//                {
//                    pathNodes.Add(neighbor, new PathNodeInfo<AirportNode>(currentNode));
//                    return "\nFinal Path is " + CovertPathToString(neighbor, pathNodes);
//                }
//                else if (pathNodes.ContainsKey(neighbor))
//                {
//                    //check for cycle, skip this neighbour
//                    continue;
//                }
//                else
//                {
//                    pathNodes.Add(neighbor, new PathNodeInfo<AirportNode>(currentNode));

//                    searchList.AddLast(neighbor);

//                    Console.WriteLine("\nJust Added " + neighbor.Name + " to search list");
//                }
//            }
//        }
//        //didn't find a path from origin to destination
//        return "";
//    }
//}

