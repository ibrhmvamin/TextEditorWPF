using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            if (txtbox.Text!=string.Empty && File.Exists(txtbox.Text)) 
            {
            string filename=txtbox.Text;
            string text =  File.ReadAllText(filename);
            richtb.AppendText(text);
            }
            else MessageBox.Show("File does not exist or you are not entered any text");
        }

        private void EnteredMouse(object sender, MouseEventArgs e)
        {
            if (txtbox.Text=="Enter file name...")
                txtbox.Text = string.Empty;
                
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (!txtbox.Text.EndsWith(".txt"))
            {
                MessageBox.Show("Please Enter TXT File !");
                return;
            }
            else
            {
                TextRange textRange = new(richtb.Document.ContentStart, richtb.Document.ContentEnd);
                string text = textRange.Text;
                File.WriteAllText(txtbox.Text, text);
                MessageBox.Show("Save successfully");
            }
        }

        private void AutoSaveClick(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new(richtb.Document.ContentStart, richtb.Document.ContentEnd);
            string text = textRange.Text;
            if (autoSave.IsEnabled)
            {
                if (!string.IsNullOrWhiteSpace(txtbox.Text))
                {
                    File.WriteAllText(txtbox.Text, text);
                }
            }
        }

        private void CutClick(object sender, RoutedEventArgs e)
        {
            richtb.Cut();
            richtb.Focus();
        }

        private void CpyClick(object sender, RoutedEventArgs e)
        {
            richtb.Copy(); richtb.Focus();
        }

        private void PasteClick(object sender, RoutedEventArgs e)
        {
            richtb.Paste(); 
        }

        private void SelectAllClick(object sender, RoutedEventArgs e)
        {
            richtb.SelectAll(); richtb.Focus();
        }
    }
}
