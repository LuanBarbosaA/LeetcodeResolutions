public class MyHashSet
{
    private const int maxBuckets = 1000001;
    private readonly bool[] _buckets = new bool[maxBuckets];
    
    public MyHashSet()
    {
    }

    private int calculateHash(int key)
        => key % maxBuckets;

    public void Add(int key)
    {
        var hash = calculateHash(key);
        _buckets[hash] = true;
    }

    public void Remove(int key)
    {
        var hash = calculateHash(key);
        if (_buckets[hash])
            _buckets[hash] = false;
    }

    public bool Contains(int key)
    {
        var hash = calculateHash(key);
        return _buckets[hash];
    }

    public class ContainsDuplicateSolution
    {
        
    }

    public class HashSetQuestions
    {
        public bool ContainsDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //public bool ContainsDuplicate(int[] nums) DIFFERENT SOLUTION PROVIDE FOR ANOTHER PERSON
        //{
        //    return new HashSet<int>(nums).Count != nums.Length;
        //}

        public int SingleNumber(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res ^= nums[i];
            }
            return res;
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var equalNums = new HashSet<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        equalNums.Add(nums1[i]);
                        nums2.ToList().RemoveAt(j);
                    }
                }
            }

            return equalNums.ToArray();
        }

        public bool IsHappy(int n)
        {
            HashSet<double> nums = new HashSet<double>();
            char[] digits = n.ToString().ToCharArray();
            int result = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                result += int.Parse(digits[i].ToString()) * int.Parse(digits[i].ToString());
            }
            if (result == 1)
            {
                return true;
            }
            if (result > 1 && !nums.Contains(result))
            {
                nums.Add(result);
                return IsHappy(result);
            }
            if (result > 1 && nums.Contains(result))
            {
                return false;
            }
            return false;
        }
    }
}