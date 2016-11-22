using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace ConsoleApp2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
             
            ITest abc = t;


            List<Test> lst = new List<Test>() { new Test() };

            ReadOnlyCollection<Test> rdColltion = new ReadOnlyCollection<Test>(lst);

            MemoryStream stream = new MemoryStream();
            DataContractSerializerSettings set = new DataContractSerializerSettings();
            set.KnownTypes = new List<Type>() { typeof(ReadOnlyCollection<Test>) };
            DataContractSerializer serializer = new DataContractSerializer(rdColltion.GetType(), set);

            serializer.WriteObject(stream, rdColltion);
            byte[] serializedObjectAsBytes = stream.ToArray();


        }
    }

    enum Months
    {
        Jan = 1,
        Feb,
        March
    }

    interface ITest
    {
        int test();
    }

    [DataContract]
    class Test : ITest
    {
        [DataMember]
        public int MyProperty { get; set; }
        public virtual void handler()
        {
            Console.WriteLine("Handler");
        }

        public int test()
        {
            return 1;
        }
    }
}