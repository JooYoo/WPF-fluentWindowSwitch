// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypedCommandBase.cs" company="artiso solutions GmbH">
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
    /// <summary>Base class for a typed <see cref="ICommand"/> implementation.</summary>
    /// <typeparam name="T">Type of the parameter of the command.</typeparam>
    public abstract class TypedCommandBase<T> : ICommand
    {
        #region ICommand Members

        /// <summary>Occurs when changes occur that affect whether or not the command should execute.</summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecute(parameter is T ? (T)parameter : default(T));
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            Execute(parameter is T ? (T)parameter : default(T));
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public virtual bool CanExecute(T parameter)
        {
            return true;
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public abstract void Execute(T parameter);

        #endregion
    }
}