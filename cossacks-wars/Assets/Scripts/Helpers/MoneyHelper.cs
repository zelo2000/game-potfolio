namespace Assets.Scripts.Helpers
{
    public class MoneyHelper
    {
        public static string AddHryvnyaSign(string value)
        {
            return $"₴{value}";
        }

        public static string AddHryvnyaSign(int value)
        {
            return $"₴{value}";
        }
    }
}
