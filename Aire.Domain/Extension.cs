using System.Linq;

namespace Aire.Domain
{
    public static    class Extension
    {
        public static int EmploymentLength(this string empLength)
        {
            // not fast but easy
            string clean = new string(empLength.Where(char.IsDigit).ToArray());
            int.TryParse(clean, out int i);
            return i;
        }
    }
}
