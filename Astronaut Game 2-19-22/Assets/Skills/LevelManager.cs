using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float Level = 1;
    private float experience = 0;
    private SkillManager skillManager;
    public ExperiencePopUp expPopUp;

    public void LevelUp(float remainder = 0)
    {
        if(Level != GlobalValues.max_level)
        {
            Level++;

            /*
             *  START HERE, 150 XP DOESNT WORK
             */

            if(remainder + experience >= ExpNeededToNextLevel(Level))
            {
                LevelUp(remainder);
            }
            //Level = Mathf.Round(Mathf.Sqrt(experience / 50));
            Debug.Log("Level: " + Level.ToString() + " EXP: " + experience.ToString());
            skillManager.LevelUp();
        }
    }

    public void GainExperience(float xp, bool isRemainder = false)
    {
        if(Level < GlobalValues.max_level)
        {
            float neededPrevious = ExpNeededToNextLevel(Level - 1);
            float needed = ExpNeededToNextLevel(Level);
            expPopUp.GainExp(experience - neededPrevious, experience + xp - neededPrevious, needed - neededPrevious);

            experience += xp;

            float remainder = experience - needed;
            Debug.Log("remainder: " + remainder.ToString());

            if (experience >= needed)
            {
                LevelUp(remainder);
                neededPrevious = ExpNeededToNextLevel(Level - 1);
                needed = ExpNeededToNextLevel(Level);
                Debug.Log("Previously needed: " + neededPrevious.ToString() + "Needed: " + needed.ToString()) ;
                Debug.Log("Remainder/Target: " + remainder.ToString() + " Max: " + (needed - neededPrevious).ToString());
                expPopUp.LevelUp(0, remainder, needed - neededPrevious, Level);
            }
        }
    }

    private float ExpNeededToNextLevel(float x)
    {
        return 50 * Mathf.Pow(x, 2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        skillManager = transform.parent.gameObject.GetComponentInChildren<SkillManager>();
        //expPopUp = gameObject.AddComponent<ExperiencePopUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
