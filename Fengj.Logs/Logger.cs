using System;

namespace Fengj.Logs
{
    public static class Logger
    {
        private static Action<string> _info;
        private static Action<string> _warin;
        private static Action<string> _error;

        public static void Init(Action<string> info, Action<string> warin, Action<string> error)
        {
            _info = info;
            _error = error;
            _warin = warin;
        }

        public static void Info(string str)
        {
            _info?.Invoke(str);
        }

        public static void Warn(string str)
        {
            _warin?.Invoke(str);
        }

        public static void Erro(string str)
        {
            _error?.Invoke(str);
        }
    }

}
