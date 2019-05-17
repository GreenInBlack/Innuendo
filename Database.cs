using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innuendo
{
    [Serializable]
    class Database
    {
        // public ArrayList characterList = new ArrayList();

        public List<Character> characterList = new List<Character>();

        public void AddCharacter(string type, bool test)
        {
            if (type.ToLower().Equals("mortal"))
            {
                Mortal mortal = new Mortal(test);
                characterList.Add(mortal);
            }
            else if (type.ToLower().Equals("vampire"))
            {
                Vampire vampire = new Vampire(test);
                characterList.Add(vampire);
            }
        }

        public void DeleteCharacter(int index)
        {
                try { characterList.RemoveAt(index); }
                catch (IndexOutOfRangeException) { MessageBox.Show("No such entry found.", "ERROR", MessageBoxButtons.OK); }
        }

        public void ReadDatabase(string fileName)
        {
            if (characterList.Count == 0)
            {
                try
                {
                    characterList = ReadFromFile<List<Character>>(fileName);
                    
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK);
                }
            }
            else if (characterList.Count > 0)
            {
                DialogResult overwrite = MessageBox.Show("There is a database already open, do you wish to open the new database anyway?", "ACTIVE DATABASE", MessageBoxButtons.YesNo);
                if (overwrite == DialogResult.Yes)
                {
                    characterList = ReadFromFile<List<Character>>(fileName);
                }
            }
        }

        public T ReadFromFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public void WriteDatabase(string filename)
        {
            try
            {
                WriteToFile<List<Character>>(filename, this.characterList);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK);
            }
        }

        public void WriteToFile<T>(string filePath, T file, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, file);
            }
        }

        public string FindStatInfo(string name, int index)
        {
            string result = null;
            foreach (Character c in characterList)
            {
                if (characterList.LastIndexOf(c).Equals(index))
                {
                    result = c.DisplayStatInfo(name);
                }
            }

            return result;
        }

        public string FindStatName(string name, int index)
        {
            string result = null;
            foreach (Character c in characterList)
            {
                if (characterList.LastIndexOf(c).Equals(index))
                {
                    result = c.DisplayStatName(name);
                }
            }

            return result;
        }

        public string FindGenre(int index)
        {
            string result = null;
            foreach (Character c in characterList)
            {
                if (characterList.LastIndexOf(c).Equals(index))
                { result = c.DisplayStatName("Genre"); }
            }
            return result;
        }

    }
}
