namespace Utils
{
    public class Utils
    {
        private Utils()
        {
        }

        private static Utils singleton = null;

        public static Utils CreateInstance()
        {
            if (singleton == null)
            {
                singleton = new Utils();
            }

            return singleton;
        }
    }
}