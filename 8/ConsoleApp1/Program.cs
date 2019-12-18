// Advent of Code - 8
// Image processing
// Image = 25px x 6px

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private const int LAYER_WIDTH = 25;
        private const int LAYER_HEIGHT = 6;
        private const int LAYER_SIZE = LAYER_WIDTH * LAYER_HEIGHT;

        private const string DATA_FILE = "data.dat";

        static void Main(string[] args)
        {
            var fileData = File.ReadAllText(DATA_FILE);

            var rawPixels = fileData.ToCharArray();
            var pixels = Array.ConvertAll(rawPixels, c => (int)char.GetNumericValue(c));

            // get number of layers
            var layerCount = pixels.Length / LAYER_SIZE;

            List<int[]> layers = new List<int[]>();

            for (int i = 0; i < layerCount; i++)
            {
                layers.Add(pixels.Skip(i * LAYER_SIZE).Take(LAYER_SIZE).ToArray());
            }

            PerformCheckSum(layers);

            DecodeImage(layers);
        }

        private static void PerformCheckSum(List<int[]> layers)
        {
            var sortedLayers = layers
                .OrderBy(o => o.Where(x => x == 0)
                    .ToList()
                    .Count())
                .ToList();

            var ones = sortedLayers[0].Where(o => o == 1).Count();
            var twos = sortedLayers[0].Where(o => o == 2).Count();

            Console.WriteLine($"The number of 1 digits times the number of 2 digits in the layer with the fewest 0 digits is: {ones * twos}");
        }

        private static void DecodeImage(List<int[]> layers)
        {
            var image = new int[LAYER_SIZE];

            Array.Fill(image, 3); // Fill with dummy values 

            for(int i = 0; i < layers.Count(); i++)
            {
                for(int k = 0; k < LAYER_SIZE; k++)
                {
                    if(layers[i][k] != 2 && image[k] == 3) // Ensure we're not overwriting set image values
                    {
                        image[k] = layers[i][k];  
                    }
                }
            }

            for (int i = 0; i < LAYER_HEIGHT; i++)
            {
                var rowData = image.Skip(i * LAYER_WIDTH).Take(LAYER_WIDTH);
                var row = string.Join(" ", rowData)
                    .Replace('0', ' ')
                    .Replace('1', '#');
                Console.WriteLine(row);
            }
        }
    }
}
