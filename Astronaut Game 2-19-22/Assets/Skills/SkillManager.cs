using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skill Science;
    public Skill Speech;
    public Skill CheeseMaking;

    private float SkillPointsOnLevelUp = GlobalValues.default_skill_points_per_level;
    public float CurrentSkillPoints;

    private Skill[] allSkills = new Skill[3];
    
    void Start()
    {
        CurrentSkillPoints = SkillPointsOnLevelUp;
        allSkills[0] = Science;
        allSkills[1] = Speech;
        allSkills[2] = CheeseMaking;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp()
    {
        CurrentSkillPoints += SkillPointsOnLevelUp;
    }

    public void IncrementSkillPoints(float points)
    {
        CurrentSkillPoints = CurrentSkillPoints + points;
    }

    public void IncreaseSkill(float i)
    {

    }

    public Skill FindSkill(SkillType type)
    {
        Skill skill = gameObject.AddComponent<Skill>();
        int length = allSkills.Length;
        for (int i = 0; i < length; i++)
        {
            if (allSkills[i].SkillType == type)
            {
                skill = allSkills[i];
            }
        }
        return skill;
    }
    
}
