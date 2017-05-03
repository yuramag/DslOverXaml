using System;

namespace DslOverXamlDemo.Engine.Context
{
    public static class ContextExtensions
    {
        public static void AddService(this IContext context, Type type, object service)
        {
            context.AddService(type, () => service);
        }

        public static void AddService<T>(this IContext context, T service)
        {
            context.AddService(typeof(T), () => service);
        }

        public static void AddService<T>(this IContext context, Func<T> factory)
        {
            context.AddService(typeof(T), factory);
        }

        public static bool HasService<T>(this IContext context)
        {
            return context.HasService(typeof(T));
        }

        public static T GetService<T>(this IContext context)
        {
            return (T) context.GetService(typeof(T));
        }
    }
}