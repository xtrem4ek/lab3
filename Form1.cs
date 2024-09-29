using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PalindromeApp
{
    public partial class Form1 : Form
    {
        PalindromeChecker palindromeChecker;

        public Form1()
        {
            InitializeComponent();
            palindromeChecker = new PalindromeChecker();
        }

        private void checkPalindromeButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;

            // Обробка помилок
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Будь ласка, введіть слово для перевірки.");
                return;
            }

            bool isPalindrome = palindromeChecker.IsPalindrome(input);

            if (isPalindrome)
            {
                resultLabel.Text = "Це паліндром!";
            }
            else
            {
                resultLabel.Text = "Це не паліндром.";
            }
        }
    }

    public class PalindromeChecker
    {
        public bool IsPalindrome(string input)
        {
            // Перетворюємо всі символи в нижній регістр і видаляємо всі символи, окрім літер і цифр
            string processedInput = Regex.Replace(input.ToLower(), @"[^a-z0-9]", "");

            // Перевіряємо, чи є рядок паліндромом
            char[] reversedInput = processedInput.ToCharArray();
            Array.Reverse(reversedInput);
            string reversedString = new string(reversedInput);

            return processedInput == reversedString;
        }
    }
}

