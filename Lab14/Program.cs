using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle("red", 29);
            Console.WriteLine("Task1");
            Console.WriteLine("\nBinary");
            // создаем объект BinaryFormatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"D:/circle.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, circle);

                Console.WriteLine("Объект сериализован");
            }
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(@"D:/circle.dat", FileMode.Open))
            {
                Circle newCircle = (Circle)binaryFormatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Цвет: {newCircle.Color} --- Радиус: {newCircle.Radius}");
            }

            //работа с json файлом
            Console.WriteLine("\nJson");
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Circle));
            using (FileStream fs = new FileStream(@"D:/circle.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, circle);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream(@"D:/circle.json", FileMode.Open))
            {
                Circle newCircle = (Circle)jsonSerializer.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Цвет: {newCircle.Color} --- Радиус: {newCircle.Radius}");
            }

            //работа с xml файлом
            Console.WriteLine("\nXML");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Circle));
            using (FileStream fs = new FileStream(@"D:/circle.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, circle);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream(@"D:/circle.xml", FileMode.Open))
            {
                Circle newCircle = (Circle)xmlSerializer.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Цвет: {newCircle.Color} --- Радиус: {newCircle.Radius}");
            }

            //работа с soap файлом
            Console.WriteLine("\nSoap");
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream(@"D:/circle.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, circle);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream(@"D:/circle.soap", FileMode.Open))
            {
                Circle newCircle = (Circle)soapFormatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Цвет: {newCircle.Color} --- Радиус: {newCircle.Radius}");
            }

            Console.WriteLine("\nTask2");
            XmlSerializer serializer = new XmlSerializer(typeof(Circle[]));
            Circle circle1 = new Circle("white", 3);
            Circle circle2 = new Circle("black", 4);
            Circle[] circles = new Circle[] { circle1, circle2 };
            using (FileStream fs = new FileStream(@"D:/circlemas.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, circles);
                Console.WriteLine("Массив объект сериализован");
            }
            using (FileStream fs = new FileStream(@"D:/circlemas.xml", FileMode.Open))
            {
                Circle[] newCircles = (Circle[])serializer.Deserialize(fs);
                Console.WriteLine("Массив объект десериализован");
                foreach (Circle c in newCircles)
                {
                    Console.WriteLine($"Цвет: {c.Color} --- Радиус: {c.Radius}");
                }
            }

            Console.WriteLine("\nTask3");
            XmlDocument xDoc = new XmlDocument();
            //загрузка xml документа
            xDoc.Load(@"D:/circlemas2.xml");
            //получение корневого элемента
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine("выбор всех дочерних узлов");
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            Console.WriteLine("выбор дочернего узла по имени");
            XmlNode childnode = xRoot.SelectSingleNode("Circle[@name='circle2']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);

            Console.WriteLine("выбор по цвету");
            XmlNodeList childnodes2 = xRoot.SelectNodes("//Circle//Color");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);

            Console.WriteLine("\nTask4");

            XDocument xdoc = new XDocument(new XElement("circles",
                                    new XElement("circle",
                                            new XAttribute("name", "circle1"),
                                            new XElement("color", "green"),
                                            new XElement("radius", "23")),
                                    new XElement("circle",
                                            new XAttribute("name", "circle2"),
                                            new XElement("color", "blue"),
                                            new XElement("radius", "44"))));
            xdoc.Save("D://circles4.xml");
            Console.WriteLine("Документ создан");

            XDocument xdoc1 = XDocument.Load("D://circles4.xml");
            var items = from xe in xdoc.Element("circles").Elements("circle")
                        where xe.Attribute("name").Value == "circle2"
                        select new Circle
                        {
                            Color = xe.Element("color").Value,
                            Radius = Convert.ToInt32(xe.Element("radius").Value)
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Color} - {item.Radius}");

        }
    }

}
