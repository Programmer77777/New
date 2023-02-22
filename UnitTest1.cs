using NUnit.Framework;
using static homework2.Program;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var arr = new int[6] { 1, 43, 65, 4, 54, 3};
            var new_arr = new int[] { 1, 43, 65, 3};
            Assert.That(FilterByPredicate(arr, x => x % 2 == 0), Is.EqualTo(new_arr));

            var arr1 = new int[6] { 1, 43, 65, 4, 54, 3 };
            var new_arr1 = new int[] { 1, 4, 3 };
            Assert.That(FilterByPredicate(arr1, x => x > 23), Is.EqualTo(new_arr1));

            var arr2 = new int[0];
            Assert.That(FilterByPredicate(arr2, x => x % 2 != 0), Is.EqualTo(null));
        }

        [Test]
        public void Test2()
        {
            var arr = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var new_arr = new int[8] { 5, 6, 7, 8, 1, 2, 3, 4 };
            Assert.That(SwapArrays(arr), Is.EqualTo(new_arr));

            var arr1 = new int[0];
            Assert.That(SwapArrays(arr1), Is.EqualTo(null));

        }

        [Test]
        public void Test3()
        {
            var arr = new int[4, 5] { { 1, 2, 3, 4, 5 }, { -1, -3, -4, -5, 2 }, { 100, -10, -30, -40, 80}, { -32, 43, 323, -4342, 4} };
            (var maxSum, var row) = (0, 0);
            Assert.That(FindMaxRow(arr), Is.EqualTo((89, 2)));


        }
    }
}