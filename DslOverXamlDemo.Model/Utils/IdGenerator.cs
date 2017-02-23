namespace DslOverXamlDemo.Model.Utils
{
    public static class IdGenerator
    {
        private static int s_autoInc;

        public static int AutoInc()
        {
            return ++s_autoInc;
        }
    }
}