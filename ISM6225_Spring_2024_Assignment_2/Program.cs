using System.Data;
using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0) // It will returns 0 if there are no elements in array nums
                    return 0;
                int k = 1; // k will hold index of last unique element. It starts from 1 because the first number in the list is always considered unique
                for (int i = 1; i < nums.Length; i++) // Code goes through each number in the list from second one (i = 1) because we've already considered the first one
                {
                    if (nums[i] != nums[i - 1]) // Current value compares with previous one and decides if it is unique or not
                    {
                        nums[k] = nums[i]; // The unique value will be moved front
                        k++; // Increases K value to compare remaining values
                    }
                }
                return k; // Returns the total no of unique elements
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - This method removes duplicates from input array by shifting unique elements to front and keeps track of the count of unique elements.
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int n = 0;// Variable n to keep track of the position where next non-zero element will be placed.
                for (int i = 0; i < nums.Length; i++) 
                {
                    if (nums[i] != 0) //It checks if the current element at index i in nums array is not equal to zero.
                    {
                        int temp = nums[i]; //If the current element is not zero, it swaps the current element with element at position indicated by variable n
                        nums[i] = nums[n];
                        nums[n] = temp;
                        n++;
                    }
                }
                return nums; // Since the array nums is modified directly within the method, there's no need to return anything.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - The code implements the "two-pointer technique" to efficiently move zeroes to the end of an array while preserving the order of non-zero elements. It iterates through the array once, swapping elements as necessary, resulting in a time complexity of O(n)
         
        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>();
                Array.Sort(nums); // Array nums is sorted in ascending order. Sorting makes it easier to identify duplicates and also helps in enhance the solution
                int n = nums.Length;
                for (int i = 0; i < n - 2; i++) //It iterates up to second last element because the last two elements will be covered by the left and right pointers in the nested loop
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // If the current element is the same as the previous one, it skips to the next iteration.
                        continue;
                    int left = i + 1; // Initializes two pointers, left and right, which will be used to find the other two elements in the triplet.
                    int right = n - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right]; // Sum of the current triplet is calculated
                        if (sum == 0) // Sum added to result if the triplet sum is zero
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) // These two lines ensure that the added triplet is unique by skipping over any duplicate values of nums[left] and nums[right] before adding them to the result list
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;
                            left++; // Any duplicate elements are skipped by incrementing left and decrementing right
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++; // Current triplet's sum is too small, so left is incremented.
                        }
                        else
                        {
                            right--; // Current triplet's sum is too large, so right is decremented.
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - Method provided solution to the ThreeSum problem using sorting and a two-pointer approach, with careful consideration given to handle duplicates and edge cases.

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int mconescount = 0; // These two variable are defined to hold count of consecutive one's
                int conescount = 0;
                foreach (int i in nums) // Repeat through each element in the array nums
                {
                    if (i == 1) // If current element is 1, it means we encountered another consecutive one, so we increment the conecount variable.
                    {
                        conescount++;
                    }
                    else // Update mconecount variable if current count of consecutive ones (conecount) is greater than previous mconecount. Then, resets the count to 0 to start counting consecutive ones again.
                    {
                        mconescount = Math.Max(mconescount, conescount);
                        conescount = 0;
                    }
                }
                mconescount = Math.Max(mconescount, conescount);
                return mconescount; // returns max count of consecutive ones
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - Method effectively finds maximum count of consecutive ones in the input array. Also learned array traversal, counting elements, and returning results from methods in a structured manner.

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int dNum = 0; //Variable to store the decimal equivalent of the binary number
                int basenum = 1; //Variable to keep track of the current base value (power of 2)
                while (binary > 0)
                {
                    int lastDigit = binary % 10; // It calculates last digit of binary number by taking remainder of binary divided by 10 (binary % 10)
                    binary = binary / 10; // Updates binary number by dividing it to 10 (binary / 10), effectively removs the last digit
                    dNum += lastDigit * basenum; //Calculates the decimal value of current digit by multiplying last digit by basenum and adds it to dNum.
                    basenum = basenum * 2; //Updates basenum by multiplying it by 2, as the base value increases by a power of 2 with each digit processed.
                }
                return dNum; //After processing all digits of binary number, the method returns the final dNum value, which represents the decimal equivalent of the input binary number.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - The method tells process of converting binary number to its decimal equivalent using iterative computation. It also tells concept of positional notation, where the position of digit determines its value. it highlights the use of basic arithmetic operations such as division, modulus, and multiplication in binary to decimal conversion.

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2) // Checks for atleast two numbers in the array nums beacuse the ask is between two successive numbers
                    return 0;
                int minnum = int.MaxValue; // variables to hold minimum and maximum value 
                int maxnum = int.MinValue;
                foreach (int num in nums) // checks for every element in array nums
                {
                    if (num < minnum) // Update minnum if the current number is smaller
                        minnum = num;
                    if (num > maxnum) // Update maxnum if the current number is larger
                        maxnum = num;
                }
                int bucketSize = Math.Max(1, (maxnum - minnum) / (nums.Length - 1)); // Defines size of each bucket based on range of numbers in the array
                int numBuckets = (maxnum - minnum) / bucketSize + 1; // 
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                for (int i = 0; i < numBuckets; i++) // Creates array to store min and max numbers in each bucket
                {
                    minBucket[i] = int.MaxValue; // starts with largest possible integer
                    maxBucket[i] = int.MinValue; // starts with smallest possible integer
                }
                foreach (int num in nums) // Allocates numbers into buckets based on value
                {
                    int bucketIndex = (num - minnum) / bucketSize; // Calculates index of the bucket for current number
                    if (num < minBucket[bucketIndex]) // Updates minimum and maximum values in the bucket
                        minBucket[bucketIndex] = num;
                    if (num > maxBucket[bucketIndex])
                        maxBucket[bucketIndex] = num;
                }
                int maxGap = 0;// variable to keep track of maximum gap and previous maximum number
                int prevMax = minnum;
                for (int i = 0; i < numBuckets; i++) // Iterate through the buckets to find the maximum gap
                {
                    if (minBucket[i] != int.MaxValue && maxBucket[i] != int.MinValue) // Checks for non empty bucket
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - prevMax); // updates maxgap if the current gap is high
                        prevMax = maxBucket[i]; //updates previpos max number to current max number in current bucket
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - I have learned to find smallest and largest elements in an array by iterating through array and updating variables for minimum and maximum numbers. Also learned a technique for organizing data to simplify calculations, especially when dealing with a wide range of values by dividing the range of numbers into buckets and assigning each number to its corresponding bucket

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sorts the elements of num array
                Array.Reverse(nums); // Reverses the elemenets of num array
                for (int i = 0; i < nums.Length - 2; i++) //iterates on elements of nums array, starting from first element up to third-to-last element (nums.Length - 2). Its used to check if it's possible to form a triangle with the current element and the two subsequent elements.
                {
                    if (nums[i] < nums[i + 1] + nums[i + 2]) //Checks if current triplet forms a valid triangle (a + b > c)
                    {
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }
                return 0; // Returns 0 if no triangle founds
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Self reflection - Method efficiently finds the largest possible perimeter of a triangle that can be formed using three elements from the given array of integers.
         
        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part)) // loop continues till input s contains the defined input part
                {
                    int index = s.IndexOf(part); // gives the index of leftmost occurance of part
                    s = s.Remove(index, part.Length); // removes the part from input s
                }

                return s; // Return modified string after removing all occurrences of part
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

// Self reflection - Using while loop and string manipulation, the RemoveOccurrences method eliminates every instance of a given substring from a given string. ConvertIListToNestedList creates a string representation of a nested list from a list of lists of integers. ConvertIListToArray loops through a list of integers, producing a string for each member before converting the list to an array string representation. The parts are encased in the proper brackets and joined together with commas in both conversion procedures.