using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WPFTypeApp.View;

namespace WPFTypeApp
{
    public partial class MainWindow : Window
    {
        private GameState gameState;
        private DisplayManager displayManager;

        public MainWindow()
        {
            InitializeComponent();
            gameState = new GameState();
            displayManager = new DisplayManager(txtDisplay, gameState);
        }

        private void StartGame()
        {
            gameState.StartNewGame();
            displayManager.UpdateDisplay();
            txtStatus.Text = "Ćwiczenie rozpoczęte!";
            btnStart.IsHitTestVisible = false;
            btnStart.Focusable = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            gameState.StartNewGame(); // Resetujemy stan gry
            displayManager.UpdateDisplay(); // Aktualizujemy wyświetlacz
            txtStatus.Text = "Gotowy do rozpoczęcia";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Back)
            {
                gameState.CorrectMistake();
                displayManager.UpdateDisplay();
                e.Handled = true;
                return;
            }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift ||
                e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl ||
                e.Key == Key.LeftAlt || e.Key == Key.RightAlt ||
                e.Key == Key.System || e.Key == Key.CapsLock)
            {
                return;
            }
            
            if (gameState.CurrentPosition < gameState.CurrentText.Length)
            {
                char expectedChar = char.ToLower(gameState.CurrentText[gameState.CurrentPosition]);
                char actualChar = e.Key == Key.Space ? ' ' : char.ToLower(ConvertToChar(e.Key));

                gameState.ProcessKey(actualChar, expectedChar);
                displayManager.UpdateDisplay();

                if (gameState.CurrentPosition >= gameState.CurrentText.Length)
                {
                    EndGame();
                }
            }
        }

        private char ConvertToChar(Key key)
        { 
            int virtualKey = KeyInterop.VirtualKeyFromKey(key);
            return Convert.ToChar(virtualKey);
        }

        private void EndGame()
        {
            btnStart.IsHitTestVisible = true;
            btnStart.Focusable = true;
            txtStatus.Text = "Zakończono!";
            MessageBoxResult result = MessageBox.Show(
                "Zakończono. Chcesz zaczac od nowa?",
                "Wynik",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information
            );

            if (result == MessageBoxResult.Yes)
            {
                StartGame();
            }
        }
    }
}

