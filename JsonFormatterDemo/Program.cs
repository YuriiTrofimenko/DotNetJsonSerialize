using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace JsonFormatterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.name = "John";
            p.age = 42;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser =
                new DataContractJsonSerializer(typeof(Person));

            ser.WriteObject(stream1, p);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());

            stream1.Position = 0;
            sr = new StreamReader(stream1);
            var json = sr.ReadToEnd();

            /*stream1.Position = 0;
            Person p2 = (Person)ser.ReadObject(stream1);
            Console.WriteLine($"Deserialized back, got name={p2.name}, age={p2.age}");*/

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Person p2 = ser.ReadObject(ms) as Person;
            Console.WriteLine($"Deserialized back, got name={p2.name}, age={p2.age}");
            ms.Close();
        }
    }
}
