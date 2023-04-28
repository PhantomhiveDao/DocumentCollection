/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++)
        {//定义第一个循环.
            for(int j = i+1; j < nums.Length; j++)
            {//定义第二个循环，得出所有答案，在得到正确答案进行return输出.
                if(nums[i] + nums[j] == target)
                {//判断正确答案，输出.
                    return new int[]{i, j};
                }
            }
        }
        throw new System.Exception("Failure");//无法找到正确答案的错误输出.
    }  
}
// @lc code=end

