using System;
using System.Linq;

namespace WPFTypeApp.View;

public class TextGenerator
{
    private static readonly string[] Words = { "attachment", "field", "nuance", "oral", "health", "force", "quota" };

    public static string GenerateRandomText(int wordCount)
    {
        Random rnd = new Random();
        return string.Join(" ", Enumerable.Range(0, wordCount).Select(i => Words[rnd.Next(Words.Length)]));
    }
}