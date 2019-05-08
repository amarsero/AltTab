using System;
using System.IO;

namespace Altab
{
    [Serializable]
    public class Persistence
    { 
        [NonSerialized]
        private readonly Deposit _deposit;
        private readonly string startupPath;

        public Persistence(Deposit deposit, string startupPath)
        {
            this._deposit = deposit;
            this.startupPath = startupPath;
        }

        public void Save()
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream fileStream = new FileStream(startupPath + "save.sav", FileMode.Create);
            formatter.Serialize(fileStream, this);
            fileStream.Close();
            fileStream = new FileStream(startupPath + "save.sav", FileMode.Open);
            string text = new StreamReader(fileStream).ReadToEnd();
            fileStream.Position = 0;
            Persistence per = (Persistence)formatter.Deserialize(fileStream);
        }
    }
}