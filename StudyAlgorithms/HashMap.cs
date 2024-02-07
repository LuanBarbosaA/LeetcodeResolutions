
using System.Collections;

namespace StudyAlgorithms
{
    public class MyHashMap
    {
        int[] map;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            map = new int[1000001];
            for (int i = 0; i < map.Length; i++)
                map[i] = -1;
        }

        public int CalculateHash(int key)
            => key % map.Length;

        public void Put(int key, int value)
        {
            map[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return map[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            map[key] = -1;
        }
    }

    public class HashMapQuestions
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int numberToDiscover = 0;
            List<int> sumArray = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numberToDiscover = target - nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > target)
                    {
                        nums.ToList().RemoveAt(i);
                    }

                    if (numberToDiscover == nums[j])
                    {
                        sumArray.Add(i);
                        sumArray.Add(j);
                        nums.ToList().RemoveAt(i);
                        nums.ToList().RemoveAt(j);
                    }
                }   
            }
            return sumArray.ToArray();
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            int[] sumArray = new int[1];
            Dictionary<int, int> indexes = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var numberToDiscover = target - nums[i];
                if (indexes.ContainsKey(numberToDiscover))
                {
                    Array.Resize(ref sumArray, sumArray.Length + 1);
                    sumArray[i] = i;
                }
            }
            return sumArray;
        }
        //public int[] TwoSum3(int[] nums, int target) BEST SOLUTION FOR MEMORY USAGE AND RUNTIME 
        //{
        //    var indexes = new Dictionary<int, int>();
        //    for (var i = 0; i < nums.Length; i++)
        //    {
        //        var num = nums[i];

        //        var other = target - num;
        //        if (indexes.ContainsKey(other))
        //        {
        //            var otherIndex = indexes[other];
        //            return new int[] { i, otherIndex };
        //        }

        //        indexes[num] = i;
        //    }

        //    return new int[] { };
        //}

        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            char[]? sArray = s.ToCharArray();
            char[]? tArray = t.ToCharArray();
            char[] isomorphicResult = new char[sArray.Length];

            var conversionTable = new Dictionary<char, char>();

            for (int i = 0; i < sArray.Length; i++)
            {
                if (conversionTable.ContainsKey(sArray[i]))
                {
                    isomorphicResult[i] = conversionTable[sArray[i]];
                }
                else if (conversionTable.ContainsValue(tArray[i]))
                {
                    conversionTable.Remove(tArray[i]);
                }
                else
                {
                    conversionTable.Add(sArray[i], tArray[i]);
                    isomorphicResult[i] = tArray[i];
                }
            }

            if (String.Join("", isomorphicResult) == t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool IsIsomorphic2(string s, string t) DIFFERENT SOLUTION PROVIDE FOR ANOTHER PERSON
        //{
        //    int len = s.Length;
        //    var arr1 = new int[256];
        //    var arr2 = new int[256];
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (arr1[(int)s[i]] != arr2[(int)t[i]])
        //            return false;
        //        arr1[(int)s[i]] = i + 1;
        //        arr2[(int)t[i]] = i + 1;
        //    }

        //    return true;
        //}

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            string[] result = new string[0];
            int lastIndexSum = 0;
            int lastArrayPosition = 0;

            for (int i = 0; i < list1.Length; i++)
            {
                var equalIndex = list2.ToList().IndexOf(list1[i]);
                if (equalIndex != -1)
                {
                    if (result.Length == 0)
                    {
                        Array.Resize(ref result, 1);
                        result[0] = list1[i];
                        lastIndexSum = i + equalIndex;
                    }
                    else if (i + equalIndex < lastIndexSum)
                    {
                        result[lastArrayPosition] = list1[i];
                        lastIndexSum = i + equalIndex;
                    }
                    else if (i + equalIndex == lastIndexSum)
                    {
                        Array.Resize(ref result, result.Length + 1);
                        lastArrayPosition = result.Length - 1;
                        result[lastArrayPosition] = list1[i];
                        lastIndexSum = i + equalIndex;
                    }
                }
            }

            return result;
        }

        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> sHashtable = new Dictionary<char, int>();
            char[] sArray = s.ToCharArray();
            char[] repeatedValues = new char[sArray.Length];
            int lastRepeatedValuesIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (sHashtable.ContainsKey(s[i]) == false 
                    && repeatedValues.Contains(s[i]) == false)
                {
                    sHashtable.Add(s[i], i);
                }
                else
                {
                    repeatedValues[lastRepeatedValuesIndex] = s[i];
                    sHashtable.Remove(s[i]);
                    lastRepeatedValuesIndex++;
                }
            }

            if (sHashtable.Values.Count > 0)
            {
                return sHashtable.Values.Min();
            }
            else
            { 
                return -1;
            }
        }
    }
}

