/**
 *      FILE            :       MainWindow.xaml.cs
 *      PROJECT         :       Assignment 2
 *      PROGRAMMER      :       NGHIA NGUYEN 8616831
 *      DESCRIPTION     :       The purpose of this application is to mimic the behaviour of the notepad application
 *      FIRST VERSION   :       2020-09-27
 */
using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.ComponentModel;

namespace nnguyen6831_A2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute_New(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_New(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                string sMessage = "Do you want to save changes?";
                string sCaption = "A2_Notepad";
                MessageBoxButton mbbButton = MessageBoxButton.YesNoCancel;
                MessageBoxResult mbrMessageBox = System.Windows.MessageBox.Show(sMessage, sCaption, mbbButton); /// Display message box to confirm whether user wants to save file

                /// Check whether the button that is pressed is Yes/No/Cancel
                if (mbrMessageBox == MessageBoxResult.Yes)
                {
                    SaveFileDialog sfdFileSave = new SaveFileDialog();
                    sfdFileSave.Filter = "Text File (*.txt)|*.txt";

                    DialogResult dlgResult = sfdFileSave.ShowDialog();

                    if (dlgResult == System.Windows.Forms.DialogResult.OK) /// check whether the user wants to save file
                    {
                        string sFileName = sfdFileSave.FileName;
                        System.IO.File.WriteAllText(sFileName, txtInput.Text);
                        App.Current.Shutdown();
                    }

                }
                else if (mbrMessageBox == MessageBoxResult.No)
                {
                    txtInput.Text = "";
                }
                else
                {
                    return;
                }
            }
        }

        private void CommandBinding_CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Open(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                string sMessage = "Do you want to save changes?";
                string sCaption = "A2_Notepad";
                MessageBoxButton mbbButton = MessageBoxButton.YesNoCancel;
                MessageBoxResult mbrMessageBox = System.Windows.MessageBox.Show(sMessage, sCaption, mbbButton); /// Display message box to confirm whether user wants to save file

                /// Check whether the button that is pressed is Yes/No/Cancel
                if (mbrMessageBox == MessageBoxResult.Yes)
                {
                    SaveFileDialog sfdFileSave = new SaveFileDialog();
                    sfdFileSave.Filter = "Text File (*.txt)|*.txt";

                    DialogResult dlgFileResult = sfdFileSave.ShowDialog();

                    if (dlgFileResult == System.Windows.Forms.DialogResult.OK) /// check whether the user wants to save file
                    {
                        string sFileName = sfdFileSave.FileName;
                        System.IO.File.WriteAllText(sFileName, txtInput.Text);
                        App.Current.Shutdown();
                    }

                }
                else if (mbrMessageBox == MessageBoxResult.No)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Text File (*.txt)|*.txt";
                    DialogResult dlgResult = ofd.ShowDialog();


                    if (dlgResult == System.Windows.Forms.DialogResult.OK) /// Check whether the file should be read
                    {
                        string sFileName = ofd.FileName;
                        txtInput.Text = System.IO.File.ReadAllText(sFileName);
                    }
                }
                else
                {
                    return;
                }
            }

        }

        private void CommandBinding_CanExecute_SaveAs(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_SaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfdFileSave = new SaveFileDialog();
            sfdFileSave.Filter = "Text File (*.txt)|*.txt";
            DialogResult dlgResult = sfdFileSave.ShowDialog();

            if(dlgResult == System.Windows.Forms.DialogResult.OK)
            {
                string sFileName = sfdFileSave.FileName;
                System.IO.File.WriteAllText(sFileName, txtInput.Text);
            }
        }

        private void CommandBinding_CanExecute_Close(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            if (txtInput.Text.Length == 0)
            {
                App.Current.Shutdown();
            }
            else
            {
                string sMessage = "Do you want to save changes?";
                string sCaption = "A2_Notepad";
                MessageBoxButton mbbButton = MessageBoxButton.YesNoCancel;
                MessageBoxResult mbrMessageBox = System.Windows.MessageBox.Show(sMessage, sCaption, mbbButton); /// Display message box to confirm whether user wants to save file

                /// Check whether the button that is pressed is Yes/No/Cancel
                if (mbrMessageBox == MessageBoxResult.Yes)
                {
                    SaveFileDialog sfdFileSave = new SaveFileDialog();
                    sfdFileSave.Filter = "Text File (*.txt)|*.txt";

                    DialogResult dlgResult = sfdFileSave.ShowDialog();

                    if (dlgResult == System.Windows.Forms.DialogResult.OK) /// check whether the user wants to save file
                    {
                        string sFileName = sfdFileSave.FileName;
                        System.IO.File.WriteAllText(sFileName, txtInput.Text);
                        App.Current.Shutdown();
                    }

                }
                else if (mbrMessageBox == MessageBoxResult.No)
                {
                    App.Current.Shutdown();
                }
                else
                {
                    return;
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (txtInput.Text.Length == 0) /// check whether there is unsaved data in the work area
            {
                App.Current.Shutdown();
            }
            else
            {
                string sMessage = "Do you want to save changes?";
                string sCaption = "A2_Notepad";
                MessageBoxButton mbbButton = MessageBoxButton.YesNoCancel;
                MessageBoxResult mbrMessageBox = System.Windows.MessageBox.Show(sMessage, sCaption, mbbButton); /// Display message box to confirm whether user wants to save file

                /// Check whether the button that is pressed is Yes/No/Cancel
                switch (mbrMessageBox)
                {
                    case MessageBoxResult.Yes:
                        SaveFileDialog sfdFileSave = new SaveFileDialog();
                        sfdFileSave.Filter = "Text File (*.txt)|*.txt";

                        DialogResult dlgResult = sfdFileSave.ShowDialog();

                        if (dlgResult == System.Windows.Forms.DialogResult.OK) /// check whether the user wants to save file
                        {
                            string sFileName = sfdFileSave.FileName;
                            System.IO.File.WriteAllText(sFileName, txtInput.Text);
                            App.Current.Shutdown();
                        }
                        else
                        {
                            e.Cancel = true;
                        }


                        break;
                    case MessageBoxResult.No:
                        App.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void meiAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutBox = new About();
            aboutBox.Owner = this;
            aboutBox.ShowDialog();
        }

        private void txtInput_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txtBlock.Text = $"Characters: {txtInput.Text.Length.ToString()}";
        }

        
    }

}
