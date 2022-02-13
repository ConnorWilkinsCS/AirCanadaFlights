// AirCanada Simulator
// Written by: Karim Alftih, Connor Wilkins, Lindsay Sarson
// Last modified: 02/08/2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCanadaFlights;

AirportNode Toronto = new AirportNode("Toronto Pearson International Airport", "YYZ");
AirportNode Calgary = new AirportNode("Calgary International Airport", "YYC");
AirportNode Edmonton = new AirportNode("Edmonton International Airport", "YEG");
AirportNode Fredericton = new AirportNode("Fredericton International Airport", "YFC");
AirportNode Gander = new AirportNode("Gander International Airport", "YHZ");
AirportNode Halifax = new AirportNode("Halifax Stanfield International Airport", "YQX");
AirportNode GreaterMoncton = new AirportNode("Greater Moncton Roméo LeBlanc International Airport", "YQM");
AirportNode Montreal = new AirportNode("Montréal–Trudeau International Airport", "YUL");
AirportNode Ottawa = new AirportNode("Ottawa Macdonald–Cartier International Airport", "YOW");
AirportNode Quebec = new AirportNode("Québec/Jean Lesage International Airport", "YQB");
AirportNode Johns = new AirportNode("St. John's International Airport", "YYT");
AirportNode Vancouver = new AirportNode("Vancouver International Airport", "YVR");
AirportNode Winnipeg = new AirportNode("Winnipeg International Airport", "YWG");

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

AirportNode[] AirportArray = { Toronto, Calgary, Edmonton, Fredericton, Halifax, Gander, GreaterMoncton, Montreal, Ottawa, Quebec, Johns, Vancouver, Winnipeg };

RouteMap routeMap1 = new RouteMap();

foreach (AirportNode airport in AirportArray)
{
    routeMap1.AddAirport(airport);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Toronto YYZ RouteMap --> YFC, YOW, YQM, YUL
routeMap1.AddRoute(Toronto, Fredericton);
routeMap1.AddRoute(Toronto, Ottawa);
routeMap1.AddRoute(Toronto, GreaterMoncton);
routeMap1.AddRoute(Toronto, Montreal);

//Calgary YYC RouteMap --> YEG, YQX
routeMap1.AddRoute(Calgary, Edmonton);
routeMap1.AddRoute(Calgary, Gander);

//Edmonton YEG RouteMap --> YQM, YQB
routeMap1.AddRoute(Edmonton, GreaterMoncton);
routeMap1.AddRoute(Edmonton, Quebec);

//Fredericton YFC RouteMap --> YYZ, YQM, YEG
routeMap1.AddRoute(Fredericton, Toronto);
routeMap1.AddRoute(Fredericton, GreaterMoncton);
routeMap1.AddRoute(Fredericton, Edmonton);

//Halifax YHZ RouteMap -->  YUL, YOW, YYT
routeMap1.AddRoute(Halifax, Montreal);
routeMap1.AddRoute(Halifax, Ottawa);
routeMap1.AddRoute(Halifax, Johns);

//GreaterMoncton YQM RouteMap --> YYC, YUL, YQB, YWG
routeMap1.AddRoute(GreaterMoncton, Calgary);
routeMap1.AddRoute(GreaterMoncton, Montreal);
routeMap1.AddRoute(GreaterMoncton, Quebec);
routeMap1.AddRoute(GreaterMoncton, Winnipeg);

//Montreal YUL RouteMap --> YQB,YOW
routeMap1.AddRoute(Montreal, Quebec);
routeMap1.AddRoute(Montreal, Ottawa);

//Ottawa YOW RouteMap --> YUL, YYT
routeMap1.AddRoute(Ottawa, Montreal);
routeMap1.AddRoute(Ottawa, Johns);

//Quebec YQB RouteMap --> YQM, YUL
routeMap1.AddRoute(Quebec, GreaterMoncton);
routeMap1.AddRoute(Quebec, Montreal);

//St. John's YYT RouteMap --> YOW, YHZ
routeMap1.AddRoute(Johns, Ottawa);
routeMap1.AddRoute(Johns, Halifax);

//Vancouver YVR RouteMap --> YYC, YEG
routeMap1.AddRoute(Vancouver, Calgary);
routeMap1.AddRoute(Vancouver, Edmonton);

//Winnipeg YWG RouteMap --> YQX, YFC
routeMap1.AddRoute(Winnipeg, Gander);
routeMap1.AddRoute(Winnipeg, Fredericton);

//Gander YQX RouteMap --> YFC, YYC, YVR
routeMap1.AddRoute(Gander, Fredericton);
routeMap1.AddRoute(Gander, Winnipeg);
routeMap1.AddRoute(Gander, Vancouver);

Console.WriteLine(routeMap1.ToString());



Console.WriteLine(routeMap1.FastestRoute(Toronto, Vancouver));





////Toronto YYZ Destinations --> YFC, YOW, YQM, YUL
//Toronto.AddDestination(Fredericton);
//Toronto.AddDestination(Ottawa);
//Toronto.AddDestination(GreaterMoncton);
//Toronto.AddDestination(Montreal);

////Calgary YYC Destinations --> YEG, YQX
//Calgary.AddDestination(Edmonton); //YEG
//Calgary.AddDestination(Halifax); //YQX

////Edmonton YEG Destinations --> YQM, YQB
//Edmonton.AddDestination(GreaterMoncton);
//Edmonton.AddDestination(Quebec);

////Fredericton YFC Destinations --> YYZ, YQM, YWG
//Fredericton.AddDestination(Toronto);
//Fredericton.AddDestination(GreaterMoncton);
//Fredericton.AddDestination(Winnipeg);

////Halifax YHZ Destination -->  YUL, YOW, YYT
//Halifax.AddDestination(Montreal);
//Halifax.AddDestination(Ottawa);
//Halifax.AddDestination(Johns);

////GreaterMoncton YQM Destinations --> YYC, YUL, YQB, YWG
//GreaterMoncton.AddDestination(Calgary);
//GreaterMoncton.AddDestination(Montreal);
//GreaterMoncton.AddDestination(Quebec);
//GreaterMoncton.AddDestination(Winnipeg);

////Montreal YUL Destinations --> YQB,YOW
//Montreal.AddDestination(Quebec);
//Montreal.AddDestination(Ottawa);

////Ottawa YOW Destinations --> YUL, YYT
//Ottawa.AddDestination(Montreal);
//Ottawa.AddDestination(Johns);

////Quebec YQB Destination --> YQM, YUL
//Quebec.AddDestination(GreaterMoncton);
//Quebec.AddDestination(Montreal);

////St. John's YYT Destinations --> YOW, YHZ
//Johns.AddDestination(Ottawa);
//Johns.AddDestination(Halifax);

////Vancouver YVR Destination --> YYC, YEG
//Vancouver.AddDestination(Calgary); 
//Vancouver.AddDestination(Edmonton); 

////Winnipeg YWG Destination --> YQX, YFC
//Winnipeg.AddDestination(Gander);
//Winnipeg.AddDestination(Fredericton);