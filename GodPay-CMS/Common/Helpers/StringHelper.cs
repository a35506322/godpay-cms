namespace GodPay_CMS.Common.Helpers
{
    public static class StringHelper
    {
        public static  string ToUpperForFirst(this string word) 
        {
            var firstWord = word.Substring(0, 1);
            var firstWordUpper = word.Substring(0, 1).ToUpper();
            word = word.Replace(firstWord, firstWordUpper);
            return word;
        }

        public static string ToLowerForFirst(this string word)
        {
            var firstWord = word.Substring(0, 1);
            var firstWordUpper = word.Substring(0, 1).ToLower();
            word = word.Replace(firstWord, firstWordUpper);
            return word;
        }
    }
}
