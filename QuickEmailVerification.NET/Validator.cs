using System.Text.RegularExpressions;

namespace QuickEmailVerification.NET
{
    public static class Validator
    {
        /// <summary>
        /// Email address: RFC 2822 Format 
        /// Matches a normal email address. Does not check the top-level domain.
        /// Requires the "case insensitive" option to be ON.
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>T/F</returns>
        /// <remarks>
        /// http://stackoverflow.com/questions/16167983/best-regular-expression-for-email-validation-in-c-sharp
        /// </remarks>
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
