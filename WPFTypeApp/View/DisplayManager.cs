using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPFTypeApp.View;

public class DisplayManager
{
    private TextBlock txtDisplay;
    private GameState gameState;

    public DisplayManager(TextBlock txtDisplay, GameState gameState)
    {
        this.txtDisplay = txtDisplay;
        this.gameState = gameState;
    }

    public void UpdateDisplay()
    {
        txtDisplay.Inlines.Clear();

        for (int i = 0; i < gameState.CurrentText.Length; i++)
        {
            var background = Brushes.Transparent;
            if (i < gameState.CurrentPosition)
            {
                background = gameState.IncorrectPositions.Contains(i) ? Brushes.Red : Brushes.LightGreen;
            }
            else if (i == gameState.CurrentPosition)
            {
                background = Brushes.Yellow;
            }

            txtDisplay.Inlines.Add(new Run(gameState.CurrentText[i].ToString()) { Background = background });
        }
    }
}
