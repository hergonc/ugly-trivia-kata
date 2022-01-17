using System;
using System.IO;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
    public class GameTestShould
    {
        private const string Folder = @"../../../Output";

        [Fact(Skip = "true")]
        public void create_golden_master_files()
        {
            Directory.CreateDirectory(Folder);

            for (var i = 1; i <= 1000; i++)
            {
                var file = $"trivialPlay.{i}.txt";
                using var fileStream = new FileStream(Path.Combine(Folder, file), FileMode.Create);
                using var outputStream = new StreamWriter(fileStream);
                Console.SetOut(outputStream);
                GameRunner.PlayGame(new Random(i));
            }
        }

        [Fact]
        public void verify_output_for_three_players_for_1000_games()
        {
            for (var i = 1; i <= 1000; i++)
            {
                var file = $"trivialPlay.{i}.txt";
                var expectedContent = new StringBuilder();
                Console.SetOut(new StringWriter(expectedContent));

                GameRunner.PlayGame(new Random(i));
                Assert.Equal(expectedContent.ToString(), File.ReadAllText(Path.Combine(Folder, file)));
            }
        }
    }
}