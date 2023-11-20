// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;



string[] lines = {
    "Hi, I'm Carter",
    "My name is rod Stewart",
    "Nice to meet you, im dixon...",
    "I am smith walker it's nice to meet you",
    "im Carter Stewart Smith, how are you doing?",
    "There's no name here",
    "Hi I'm late for an interview",
    "I am a retail manager",
    "I'm Dixon marshall and I have a question.",
    "Where is Rod Stewart and his dog?",
    "Hi my name is Dixon Walker, where can I buy these shoes?",
    "I am hungry but I want to see Marshall first."
};

foreach (string s in lines)
{
    Console.WriteLine(string.Format("{0} => {1}", s, GetName(s)));
}

string? GetName(string text)
{
    var expectingNames = new string[] {"rod", "stewart", "carter", "dixon", "marshall", "smith", "walker" };
    var pattern = @"(?i)(?:i'm|im|my name is|i am)";
    var result = "";
    if (Regex.Match(text, pattern).Success)
    {
        var textByWords = text.Split(new char[] {' ', ',', '.', ':', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var matchWords = new string[] {"i'm", "im", "is", "am"};

        foreach (var word in textByWords)
        {
            if (matchWords.Contains(word.ToLower()))
            {
                var index = Array.IndexOf(textByWords, word);
                for (int i = index + 1; i < index + 4 && i < textByWords.Length; i++)
                {
                    if (expectingNames.Contains(textByWords[i].ToLower()))
                        result += (result == "" ? textByWords[i] : $" {textByWords[i]}");
                }
            }
        }
    }

    return result;
}