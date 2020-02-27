using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;
using System.Xml;


namespace KettedikPA
{
    [Serializable()]
    class FileManager
    {
        public List<Game> _listOfGames{ get; set; }
        public FileManager()
        {
            LoadFromXML();
        }
        public List<Game> LoadFromXML(string fileName = "fbay.xml")
        {
            _listOfGames = new List<Game>();
            XElement element = XElement.Load(fileName);
            var partNodes = element.Elements("Game");
            foreach (var node in partNodes)
            {
                Game game = new Game();
                
                game._name = node.Element("_name").Value;
                game._releaseYear = Convert.ToInt32(node.Element("_releaseYear").Value);
                game._price = Convert.ToInt32(node.Element("_price").Value);
                game._finished = Convert.ToBoolean(node.Element("_finished").Value);
                _listOfGames.Add(game);

            }
            return _listOfGames;
        }
        public void MakeTheGames()
        {
            Game game = new Game("Undertale",2015,(3500));
            _listOfGames.Add(game);
            game = new Game("Minecraft", 2009, (7000));
            _listOfGames.Add(game);
            game = new Game("GTA V", 2015, (12000));
            _listOfGames.Add(game);
            game = new Game("The Elder Scrolls: Skyrim", 2011, (12500));
            _listOfGames.Add(game);
            game = new Game("Tom Clancy's: The Division", 2016, (12500));
            _listOfGames.Add(game);
            game = new Game("Final Fantasy XV", 2016, (12500));
            _listOfGames.Add(game);
            game = new Game("Overwatch", 2015, (7000));
            _listOfGames.Add(game);
            game = new Game("ARK: Survival Evolved", 2015, (16000));
            _listOfGames.Add(game);
            game = new Game("Assassin's Creed Odyssey", 2018, (20000));
            _listOfGames.Add(game);
            game = new Game("Enter the Gungeon", 2016, (11500));
            _listOfGames.Add(game);
            game = new Game("Diablo III", 2012, (6000));
            _listOfGames.Add(game);
            game = new Game("Rocket League", 2015, (7000));
            _listOfGames.Add(game);
            game = new Game("Red Dead Redemption 2", 2018, (20000));
            _listOfGames.Add(game);
            game = new Game("MONSTER HUNTER: WORLD", 2018, (11500));
            _listOfGames.Add(game);
            game = new Game("The Witcher 3: Wild Hunt", 2015, (14000));
            _listOfGames.Add(game);

        }
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));
            
            using (Stream tw = new FileStream("fbay.xml", FileMode.Open, 
                FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(tw, _listOfGames);
            }
        }
        
    }
}
