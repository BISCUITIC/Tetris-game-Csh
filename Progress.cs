using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_game
{
    internal class Progress
    {
        private string currentDirectory = Directory.GetCurrentDirectory();
        private string fileName = "Progress.txt";
        private string filePath;

        FileInfo fileInfo;      
        public Progress() {
            
            filePath = currentDirectory + "\\" + fileName;
            fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
                fileInfo.Create();  
            
        }

        public void Save(int score)
        {
            if (GetSavedScore() < score)
            {
                File.WriteAllText(filePath, score.ToString());
            }
        }

        public int GetSavedScore()
        {
            string text = File.ReadAllText(filePath);

            try
            {
                return Convert.ToInt32(text);
            }
            catch
            {
                return 0;
            }
           
        }
    }
}
