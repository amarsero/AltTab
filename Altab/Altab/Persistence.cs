using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Altab
{
    [Serializable]
    public class Persistence
    {
        private Deposit _deposit;
        private readonly string startupPath;
        private string SavePath => startupPath + "\\save.sav";
        public Persistence(Deposit deposit, string startupPath)
        {
            this._deposit = deposit;
            this.startupPath = startupPath;
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using FileStream fileStream = new FileStream(SavePath, FileMode.Create);
            formatter.Serialize(fileStream, _deposit);
            fileStream.Close();
        }

        public void Load()
        {
            if (!File.Exists(SavePath))
                return;
            BinaryFormatter formatter = new BinaryFormatter();
            using FileStream fileStream = new FileStream(SavePath, FileMode.Open);
            _deposit.Update((Deposit)formatter.Deserialize(fileStream));
        }
    }
}