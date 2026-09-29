using System.Text;

namespace BPOAmericas.TestDeveloper.Common.Services
{
    public class GeneralServices
    {
        public static string Decode(string encoded)
        {
            var bytes = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
