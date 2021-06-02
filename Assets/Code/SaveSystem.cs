using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Code
{
    public class SaveSystem : MonoBehaviour
    {
        private readonly string fileName = "HighScores.txt";
        protected string LocalFilePath;

        private void Start()
        {
            LocalFilePath = Application.dataPath + "\\" + fileName;
            CheckFile();
            ReadFile();
        }

        #region dont read this bitch please u will break it

        public Dictionary<string, string> SaveList = new Dictionary<string, string>();

        public void CheckFile()
        {
            if (!File.Exists(LocalFilePath))
            {
                var fileWriter = new StreamWriter(LocalFilePath);
                Debug.Log("The file " + fileName + " does not exist. Makeing a new one!", this);
            }
        }

        public void WriteData(string name, double tscore)
        {
            if (name == "NULL")
                return;
            var score = tscore.ToString();
            if (!SaveList.ContainsKey(name))
                SaveList.Add(name, "1000000");
            if (SaveList.ContainsKey(name) && double.Parse(SaveList[name]) >= tscore)
                SaveList[name] = score;
            var fileWriter = new StreamWriter(LocalFilePath);
            fileWriter.Write($"{SaveList.Count.ToString()}+\n");
            foreach (var entry in SaveList)
            {
                fileWriter.Write($"{entry.Key}:{entry.Value}\n");
                Debug.Log($"{entry.Key}:{entry.Value}\n");
            }

            fileWriter.Close();
        }

        public void ReadFile()
        {
            var str = new StreamReader(LocalFilePath);
            var count = str.ReadToEnd().Split('+');
            for (var i = 2; i <= int.Parse(count[0]) + 1; i++)
            {
                var info = ReadSpecificLine(LocalFilePath, i).Split(':');
                SaveList.Add(info[0], info[1]);
            }

            str.Close();
        }

        private static string ReadSpecificLine(string filePath, int lineNumber)
        {
            string content = null;
            try
            {
                using (var file = new StreamReader(filePath))
                {
                    for (var i = 1; i < lineNumber; i++)
                    {
                        file.ReadLine();

                        if (file.EndOfStream) break;
                    }

                    content = file.ReadLine();
                }
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
            }

            return content;
        }

        #endregion
    }
}