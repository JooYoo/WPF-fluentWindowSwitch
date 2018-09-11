// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="artiso solutions GmbH">
//   Copyright (c) artiso solutions GmbH
// </copyright>
// <author>
//   Maximilian Koepf
//</author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace DockTest.Base
{
    public class RelayCommand : ICommand
   {
      private readonly Predicate<object> canExecute;
      private readonly Action<object> execute;

      public RelayCommand(Action<object> execute)
         : this(execute, null)
      {
      }

      public RelayCommand(Action<object> execute, Predicate<object> canExecute)
      {
         if (execute == null)
            throw new ArgumentNullException("execute");

         this.execute = execute;
         this.canExecute = canExecute;
      }

      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      public void RaiseCanExecuteChanged()
      {
         CommandManager.InvalidateRequerySuggested();
      }

      public bool CanExecute(object parameter)
      {
         return canExecute == null ? true : canExecute(parameter);
      }

      public void Execute(object parameter)
      {
         execute(parameter);
      }
   }
}