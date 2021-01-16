/**
 *      FILE            :       CustomCommands.cs
 *      PROJECT         :       Assignment 2
 *      PROGRAMMER      :       NGHIA NGUYEN 8616831
 *      DESCRIPTION     :       The purpose of this class is to custom commands
 *      FIRST VERSION   :       2020-09-27
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nnguyen6831_A2
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand SaveAs = new RoutedUICommand
            (
                "Save As",
                "Save As",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );

        public static readonly RoutedUICommand Close = new RoutedUICommand
            (
                "Close",
                "Close",
                typeof(CustomCommands)
            );
    }
}
