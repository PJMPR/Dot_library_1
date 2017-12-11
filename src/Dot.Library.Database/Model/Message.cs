using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    
    class Message : IExtensibleDataObject
    {

        private ExtensionDataObject extensionDataObjectValue;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObjectValue;
            }
            set
            {
                extensionDataObjectValue = value;
            }
        }

        [DataMessage(Name = "1")]
        internal int Id;

        [DataMessage(Name = "Powitanie")]
        internal string Title;

        [DataMessage(Name = "Witam serdecznie")]
        internal string Content;

        [DataMessage(Name = new User())]
        internal User Target;

        [DataMessage(Name = DateTime.Now.AddDays())]
        internal DateTime SentTime;

        public Message(int Id, string Title, string Content, User Target, DateTime SentTime)
        {
            Id = newId;
            Title = newTitle;
            Content = newContent;
            Target = new User();
            DateTime = DateTime.Now.AddDays(); 
        }

    }

    public class Message
    {
        
        public int Id{get;set;}
        public string Title{get;set;}
        public string Content{get;set;}
        public User Target{get;set;}
        public DateTime SentTime{get;set;}

        public static void Main()
        {
            try
            {
                WriteObject("DataContractExample.xml");
                ReadObject("DataContractExample.xml");
                Console.WriteLine("Press Enter to end");
                Console.ReadLine();
            }
            catch (SerializationException se)
            {
                Console.WriteLine
                ("Seralizacja nie powiod³a siê. Powód: {0}",
                  se.Message);
                Console.WriteLine(se.Data);
                Console.ReadLine();
            }
        }

        public static void WriteObject(string path)
        {
            Message message1 = new Message(1, "Pieni¹dze", "Gdzie jest moje trzysta baniek?", new User(), DateTime.Now.AddDays());
            FileStream fs = new FileStream(path,
            FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Message));
            ser.WriteObject(writer, message1);
            writer.Close();
            fs.Close();
        }

        public static void ReadObject(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            DataContractSerializer ser =
                new DataContractSerializer(typeof(Message));

            Message newMessage = (Message)ser.ReadObject(reader);
            Console.WriteLine("Nowy obiekt:");
            Console.WriteLine(String.Format("ID: {0}, Tytu³: {1}, Treœæ: {2}, Do: {3}, Czas: {4}",
            newMessage.Id, newMessage.Title, newMessage.Content, newMessage.Target, newMessage.SentTime));
            fs.Close();
        }

    }
}
