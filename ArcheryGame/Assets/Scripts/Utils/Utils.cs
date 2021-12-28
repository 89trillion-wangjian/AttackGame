namespace Utils
{
    public class Utils
    {
        private Utils()
        {
        }

        private static Utils _singleton = null;

        public static Utils CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new Utils();
            }

            return _singleton;
        }
    }
}