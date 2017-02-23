using System;

namespace DslOverXamlDemo.Contracts
{
    public sealed class CommandException
    {
        public CommandException(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}