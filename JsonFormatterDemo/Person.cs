using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormatterDemo
{
    [Serializable]
    //[DataContract]
    public class Person : ISerializable
    {
        //[DataMember]
        public string name;
        //[DataMember]
        public int age;

        public Person() {}

        private Person(SerializationInfo info, StreamingContext context) {
            name = info.GetString("user_name");
            age = info.GetInt32("user_age");
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("user_name", name);
            info.AddValue("user_age", age);
        }
    }
}
