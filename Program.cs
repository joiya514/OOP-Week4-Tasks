using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4OceanNavigation.BL;
using System.IO;

namespace Week4OceanNavigation
{
    class Program
    {
              //   2022-CS-16

        static void Main(string[] args)
        {
            List<angle> addShips = new List<angle>();
            while (true)
            {
                writeData(addShips);
                Console.Clear();
                readShipData(addShips);
                char choice = mainMenu();
                if (choice == '1')
                {
                    angle addShip = new angle();
                    addShips.Add(addShipFunction(addShip));
                }
                if(choice == '2')
                {
                    string number = viewShipPosition();
                    showPosition(number, addShips);
                }
                if(choice == '3')
                {
                    checkNumber(addShips);
                }
                if(choice == '4')
                {
                    changePosition(addShips);
                }
                Console.ReadKey();
            }
        }
        static char mainMenu()
        {
            Console.WriteLine(" 1: Add Ship");
            Console.WriteLine(" 2: View Ship Position");
            Console.WriteLine(" 3: View Ship's Serial Number");
            Console.WriteLine(" 4: Change Ship Position");
            Console.WriteLine(" 5: Exit");
            Console.Write("  Enter Your Choice: ");
            char choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static angle addShipFunction(angle addShip)
        {
            Console.Write(" Enter Ship Number: ");
            addShip.shipNumber = Console.ReadLine();
            Console.WriteLine("     (LATITUDE INFORMATION)");
            Console.Write(" Enter Latitude's Degree: ");
            addShip.Latdegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Minute: ");
            addShip.Latminute = float.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Direction: ");
            addShip.Latdirection = char.Parse(Console.ReadLine());
            Console.WriteLine("     (LONGITUDE INFORMATION)");
            Console.Write(" Enter Longitude's Degree: ");
            addShip.Longdegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Minute: ");
            addShip.Longminute = float.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Direction: ");
            addShip.Longdirection = char.Parse(Console.ReadLine());
            addData(addShip);
            return addShip;
        }
        static void addData(angle addShip)
        {
            string path = "E:\\OOP\\Week 4\\Week4OceanNavigation\\Week4OceanNavigation\\shipData.txt";
            if (File.Exists(path))
            {
                StreamWriter data = new StreamWriter(path, true);
                data.WriteLine(addShip.shipNumber + "," + addShip.Latdegree + "," + addShip.Latminute + "," + addShip.Latdirection + "," + addShip.Longdegree + "," + addShip.Longminute + "," + addShip.Longdirection);
                data.Flush();
                data.Close();
            }
        }
        static void writeData(List<angle> addShip)
        {
            string path = "E:\\OOP\\Week 4\\Week4OceanNavigation\\Week4OceanNavigation\\shipData.txt";
            if (File.Exists(path))
            {
                StreamWriter data = new StreamWriter(path, false);
                for (int x = 0; x < addShip.Count; x++)
                {
                    data.WriteLine(addShip[x].shipNumber + "," + addShip[x].Latdegree + "," + addShip[x].Latminute + "," + addShip[x].Latdirection + "," + addShip[x].Longdegree + "," + addShip[x].Longminute + "," + addShip[x].Longdirection);
                }
                data.Flush();
                data.Close();
            }
        }
        static void readShipData(List<angle> addShips)
        {
            string record;
            string path = "E:\\OOP\\Week 4\\Week4OceanNavigation\\Week4OceanNavigation\\shipData.txt";
            if (File.Exists(path))
            {
                StreamReader data = new StreamReader(path);
                while ((record = data.ReadLine()) != null)
                {
                    angle addShip = new angle();
                    addShip.shipNumber = parseData(record, 1);
                    addShip.Latdegree = int.Parse(parseData(record, 2));
                    addShip.Latminute = float.Parse(parseData(record, 3));
                    addShip.Latdirection = char.Parse(parseData(record, 4));
                    addShip.Longdegree = int.Parse(parseData(record, 5));
                    addShip.Longminute = float.Parse(parseData(record, 6));
                    addShip.Longdirection = char.Parse(parseData(record, 7));
                    addShips.Add(addShip);
                    //Console.WriteLine(record);
                }
                data.Close();
            }
            else
            {
                Console.WriteLine(" File Not Exists!");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        static string viewShipPosition()
        {
            string number;
            Console.Write(" Enter Ship Number to Find its Position: ");
            number = Console.ReadLine();
            return number;
        }
        static void showPosition(string number, List<angle> addShips)
        {
            for(int x = 0; x < addShips.Count; x++)
            {
                if(addShips[x].shipNumber == number)
                {
                    Console.Write("Ship is at " + addShips[x].Latdegree + "°" + addShips[x].Latminute + "'" + addShips[x].Latdirection);
                    Console.WriteLine("  and " + addShips[x].Longdegree + "°" + addShips[x].Longminute + "'" + addShips[x].Longdirection);
                    break;
                }
            }
        }
        static void checkNumber(List<angle> shipData)
        {
            Console.Write(" Enter Ship Latitude Angle: ");
            string latAngle = Console.ReadLine();
            Console.Write(" Enter Ship Longitude Angle: ");
            string longAngle = Console.ReadLine();

            int Latdegree = int.Parse(parseAngleData(latAngle, 1));
            float Latminute = float.Parse(parseAngleData(latAngle, 2));
            char Latdirection = char.Parse(parseAngleData(latAngle, 3));
            int Longdegree = int.Parse(parseAngleData(longAngle, 1));
            float Longminute = float.Parse(parseAngleData(longAngle, 2));
            char Longdirection = char.Parse(parseAngleData(longAngle, 3));
            showNumber(shipData, Latdegree, Latminute, Latdirection, Longdegree, Longminute, Longdirection);
        }

        static string parseAngleData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',' || record[x] == '°')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void showNumber(List<angle> shipData, int Latdegree, float Latminute, char Latdirection, int Longdegree, float Longminute, char Longdirection)
        {
            int count = 0;
            for(int x = 0; x < shipData.Count; x++)
            {
                if(shipData[x].Latdegree == Latdegree && shipData[x].Latminute == Latminute && shipData[x].Latdirection == Latdirection)
                {
                    Console.WriteLine(shipData[x].shipNumber);
                    break;
                }
                else
                {
                    count++;
                }
            }
            if(count == shipData.Count)
            {
                Console.WriteLine(" Invalid Ship Information!");
            }
        }
        static void changePosition(List<angle> shipData)
        {
            Console.Write(" Enter Serial Number of Ship Whose Position You want to Change: ");
            string number = Console.ReadLine();
            int index = findShip(number, shipData);
            if(index == -1)
            {
                Console.WriteLine(" No Ship Found!");
            }
            else
            {
                Console.WriteLine("      (ENTER NEW POSITION)");
                Console.WriteLine("     (LATITUDE INFORMATION)");
                Console.Write(" Enter Latitude's Degree: ");
                shipData[index].Latdegree = int.Parse(Console.ReadLine());
                Console.Write(" Enter Latitude's Minute: ");
                shipData[index].Latminute = float.Parse(Console.ReadLine());
                Console.Write(" Enter Latitude's Direction: ");
                shipData[index].Latdirection = char.Parse(Console.ReadLine());
                Console.WriteLine("     (LONGITUDE INFORMATION)");
                Console.Write(" Enter Longitude's Degree: ");
                shipData[index].Longdegree = int.Parse(Console.ReadLine());
                Console.Write(" Enter Longitude's Minute: ");
                shipData[index].Longminute = float.Parse(Console.ReadLine());
                Console.Write(" Enter Longitude's Direction: ");
                shipData[index].Longdirection = char.Parse(Console.ReadLine());
            }
        }
        static int findShip(string number, List<angle> shipData)
        {
            for(int x = 0; x < shipData.Count; x++)
            {
                if(shipData[x].shipNumber == number)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}