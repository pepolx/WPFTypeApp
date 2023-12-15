using System.Collections.Generic;

namespace WPFTypeApp.View;

public class GameState
{
    public string CurrentText { get; private set; } = "";
    public int CurrentPosition { get; private set; } = 0;
    public List<int> IncorrectPositions { get; private set; } = new List<int>();

    public void StartNewGame()
    {
        CurrentText = TextGenerator.GenerateRandomText(12);
        CurrentPosition = 0;
        IncorrectPositions.Clear();
    }

    public void ProcessKey(char actualChar, char expectedChar)
    {
        if (actualChar == expectedChar)
        {
            IncorrectPositions.Remove(CurrentPosition);
        }
        else
        {
            if (!IncorrectPositions.Contains(CurrentPosition))
            {
                IncorrectPositions.Add(CurrentPosition);
            }
        }

        CurrentPosition++;
    }

    public void CorrectMistake()
    {
        if (CurrentPosition > 0)
        {
            CurrentPosition--;
            IncorrectPositions.Remove(CurrentPosition);
        }
    }
}
