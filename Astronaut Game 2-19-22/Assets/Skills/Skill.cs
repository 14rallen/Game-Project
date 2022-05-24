using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillType SkillType;
    public float Level;

    /// <summary>
    /// Increase or decrease skill level
    /// </summary>
    /// <param name="i">Amount change level by. Positive or negative value</param>
    public void IncreaseSkill(float i)
    {
        bool isIncrease = i >= 0;

        if (isIncrease && Level != GlobalValues.max_skill_level)
        {
            Level += i;
        }
        else if (!isIncrease && Level != GlobalValues.min_skill_level)
        {
            Level += i;
        }
    }
    /// <summary>
    /// Increase or decrease skill level. Makes sure player cannot decrease level value by current value
    /// as this function is for the level up screen
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <param name="i">Amount change level by. Positive or negative value</param>
    public void IncreaseSkillOnLevelUp(float currentLevel, float i)
    {
        bool isIncrease = i >= 0;

        if (isIncrease && Level != GlobalValues.max_skill_level)
        {
            Level += i;
        }
        else if (!isIncrease && Level != GlobalValues.min_skill_level && currentLevel != Level)
        {
            Level += i;
        }
    }
}
