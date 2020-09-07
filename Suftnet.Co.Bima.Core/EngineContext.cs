namespace Suftnet.Co.Bima.Core
{
    public class EngineContext
    {
        public static IEngine Create()
        {
            if (Singleton<IEngine>.Instance == null)
                Singleton<IEngine>.Instance = new Engine();

            return Singleton<IEngine>.Instance;
        }

        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    return Singleton<IEngine>.Instance = new Engine();
                }

                return Singleton<IEngine>.Instance;
            }
        }
    }
}
