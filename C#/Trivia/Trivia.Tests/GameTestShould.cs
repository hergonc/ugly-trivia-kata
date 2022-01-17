using System;
using System.IO;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
    public class GameTestShould
    {
        private const string folder = @"../../../Output";

        [Fact]
        public void create_golden_master_files()
        {
            Directory.CreateDirectory(folder);

            for (var i = 1; i <= 1000; i++)
            {
                var file = $"trivialPlay.{i}.txt";
                using var fileStream = new FileStream(Path.Combine(folder, file), FileMode.Create);
                using var outputStream = new StreamWriter(fileStream);
                Console.SetOut(outputStream);
                GameRunner.PlayGame(new Random(i));
            }
        }
    }
}