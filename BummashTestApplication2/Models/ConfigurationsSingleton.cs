namespace BummashTestApplication
{
    public sealed class ConfigurationsSingleton
    {
        static ConfigurationsSingleton instance;

        public float SteelDensity { get; private set; }

        public float Pi { get; private set; }

        public ToleranceDataModel ToleranceData { get; private set; }

        public static ConfigurationsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationsSingleton();
                    instance.Pi = 3.14f;
                    instance.SteelDensity = 0.78f / 100000000;
                    instance.ToleranceData = new ToleranceDataModel();
                }
                return instance;
            }
        }
    }
}
