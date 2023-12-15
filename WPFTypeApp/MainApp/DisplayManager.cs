using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Effects;

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

            var run = new Run(gameState.CurrentText[i].ToString()) { Background = background };
            var border = new Border
            {
                Child = new TextBlock(run),
                Background = background,
                Effect = new DropShadowEffect
                {
                    Color = Colors.Wheat,
                    Direction = 340,
                    ShadowDepth = 2,
                    Opacity = 0.8
                }
            };

            txtDisplay.Inlines.Add(new InlineUIContainer(border));
        }
            //txtDisplay.Inlines.Add(new Run(gameState.CurrentText[i].ToString()) { Background = background });
        
    }
    
}
