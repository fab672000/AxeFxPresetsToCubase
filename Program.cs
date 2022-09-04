// 
// Cubase Script generator for Fractal Audio Designs devices
// 
// by Fabien (fab672000)
//
// GPL License
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AFXPC2CUBASE
{
    class Program
    {
        private static void SyntaxError(string msg)
        {
            Console.WriteLine(msg);
            Environment.Exit(-1);
        }

        const string FasDeviceName = "AxeFX3"; // change this for other patches names
        
        // Do not change the header below unless you know what you're doing as Cubase is very sensitive to the formatting in the script
        static readonly string[] HeaderLines = new []
        {
            "[cubase parse file]",
            "[parser version 0001]\r\n",
            "[creators first name]fab672000",
            "[creators last name] GM",
            "[device manufacturer]Fractal Audio Systems",
            "[device name]Axe FX III",  
           $"[script name]{FasDeviceName}",
            "[script version]version 1.00\r\n",
            "[define patchnames]\r\n",
        };

        /// <summary>
        /// This program will generate from an AxeEdit exported preset file a cubase script that can be directly imported to Cubase
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length < 1)  SyntaxError(@"Syntax error, expected command is: AFXPC2CUBASE <inputFilePath>\r\n\t Where <inputFilePath> is your AxeEdit exported text file path");

            var inputFile = args[0];
            var outputFileName = $"{FasDeviceName }.txt";
            var outputFile = Path.Combine(Path.GetFullPath(Path.GetDirectoryName(inputFile)), outputFileName);

            
            var lines = File.ReadAllLines(inputFile);
            var outputLines = new List<string>();
            foreach (var line in HeaderLines) outputLines.Add(line + "\r\n");
            foreach (var line in lines)
            {
                var input = line.Split('\t').Select(x => x.Trim()).ToArray();
                if (input.Length<2) continue;
                if (!int.TryParse(input[0], out int inPcNum)) continue;
                var bankNum = inPcNum / 128;
                if (inPcNum % 128 == 0)  outputLines.Add($"[g1]\t\tPatches {inPcNum:0000}-{(inPcNum+127):0000}\r\n");
                var oLine = $"[p2, {(inPcNum%128)}, {bankNum}, 0]\t{input[1]}\r\n";
                outputLines.Add(oLine);
            }

            outputLines.Add("[end]\r\n");

            foreach (var line in outputLines)
            {
                Console.WriteLine(line);
            }

            File.WriteAllLines(outputFile,outputLines.ToArray());
        }
    }
}
