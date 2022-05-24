using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class DialogueConditions
{
    private bool _conditionsMet = true;
    public bool ConditionsMet 
    {
        get { return AreConditionsMet(); }  
    }

    [XmlAttribute("science")]
    public float Science = 0;

    private bool AreConditionsMet()
    {
        SkillManager skills = GameManager.player.GetSkillManager();

        if(skills.Science.Level >= Science)
        {
            _conditionsMet = true;
        }
        else
        {
            _conditionsMet = false;
        }
        return _conditionsMet;
    }
}
