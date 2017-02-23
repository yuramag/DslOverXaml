using System;
using System.Collections.Generic;
using System.Linq;

namespace DslOverXamlDemo.Contracts.Lib
{
    public sealed class MessageEvent
    {
        private static IEnumerable<Exception> Flatten(Exception exception)
        {
            if (exception == null)
                return Enumerable.Empty<Exception>();

            var aex = exception as AggregateException;
            if (aex != null)
                return aex.Flatten().InnerExceptions;

            if (exception.InnerException == null)
                return Enumerable.Repeat(exception, 1);

            return Enumerable.Repeat(exception, 1).Concat(Flatten(exception.InnerException));
        }

        private static string Combine(IEnumerable<Exception> exceptions)
        {
            return string.Join("\n>> ", exceptions.Select(ex => ex.Message));
        }

        public MessageEvent(Exception exception)
            : this(MessageEventType.Exception, Combine(Flatten(exception))) { }

        public MessageEvent(MessageEventType type, string message, params object[] args)
            : this(type, string.Format(message, args)) { }

        public MessageEvent(MessageEventType type, string message)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; private set; }
        public MessageEventType Type { get; private set; }
    }
}