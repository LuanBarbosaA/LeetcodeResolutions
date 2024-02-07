using static MyHashSet;

namespace StudyAlgorithms
{
    public static class TestSolutions
    {
        public static HashMapQuestions HashMapQuestions = new HashMapQuestions();
        public static HashSetQuestions hashSetQuestions = new HashSetQuestions();

        static void Main(string[] args)
        {
            TestSolutionsConsole();
        }

        public static void TestSolutionsConsole()
        {
            // var result = SingleNumberSolution.SingleNumber([4,1,2,1,2]);
            // var result = IntersectionTwoArrays.Intersection([4, 9, 5], [9, 4, 9, 8, 4]);
            // var result = SolutionHappyNumber.IsHappy(19);
            // var result = SolutionTwoSum.TwoSum([3, 2, 4], 6);
            // var result = HashMapQuestions.IsIsomorphic("egcd", "adfd");
            // var result = HashMapQuestions.FindRestaurant(["Shogun", "Tapioca Express", "Burger King", "KFC"], ["KFC", "Shogun", "Burger King"]);
            // Console.WriteLine("[{0}]", string.Join(", ", result));
            // var result = HashMapQuestions.FirstUniqChar("aadadaad");
            var result = HashMapQuestions.GroupAnagrams(["cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc"]);
            Console.WriteLine(result);
        }
    }
}
