using Newtonsoft.Json;


namespace PlinxPlanner.Common.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Extension method to allow objects to be checked by value without the need for overloading hashcode.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="comparisonObj"></param>
        /// <returns></returns>
        public static bool CompareByValue(this object expected, object result) => 
            string.Equals(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
    }
}
