// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterlessCommandBase.cs" company="artiso solutions GmbH">
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
    /// <summary>Base class for a <see cref="ICommand"/> implementation without a parameter.</summary>
    public abstract class ParameterlessCommandBase : ICommand
    {
        #region ICommand Members

        /// <summary>The can execute changed.</summary>
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

        /// <summary>Provides if this command could be executed.</summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The can execute state of this command.</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>Executes this command.</summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Provides if this command could be executed.</summary>
        /// <returns>The can execute state of this command.</returns>
        public virtual bool CanExecute()
        {
            return true;
        }

        /// <summary>Executes this command.</summary>
        public abstract void Execute();

        #endregion
    }
}