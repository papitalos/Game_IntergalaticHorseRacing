using HorseProject;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace HorseProject
{
    public static class Save
    {
        public static void SaveGameData(string gameData, string filePath)
        {
            using (StreamWriter file = new StreamWriter(File.Open(filePath, FileMode.Create)))
            {
                file.Write(gameData);
            }
            Console.WriteLine("Informações do jogo salvas com sucesso em: " + filePath);
        }
    }
}