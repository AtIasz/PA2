using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace KettedikPA 
{
    [Serializable()]
    public class Game : ISerializable
    {
        public string _name { get; set; }
        public int _releaseYear { get; set; }
        public double _price { get; set; }
        public bool _finished { get; set; }
        public bool _owned { get; set; }
        public Game()
        {

        }
        public Game(string name, int rYear, double price, bool f = false, bool o=false)
        {
            _name = name;
            _releaseYear = rYear;
            _price = price;
            _finished = f;
            _owned = o;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _name = (string)info.GetValue("Name", typeof(string));
            _releaseYear = (int)info.GetValue("Release year", typeof(int));
            _price = (double)info.GetValue("Price", typeof(double));
            _finished = (bool)info.GetValue("Finished", typeof(bool));
        }
    }
}
