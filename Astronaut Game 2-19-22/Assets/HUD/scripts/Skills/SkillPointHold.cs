using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Timers;
using UnityEngine.UI;

public class SkillPointHold : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    /*
     * assigned in hierarchy
     */
    public SkillType skillType;
    public bool isIncrease;

    private Player player;
    private SkillManager playerSkillManager;
    private Skill skill;
    private float tempSkill;
    private bool arrowEnabled = true;
    private Timer startTimer = new Timer();
    private Timer continuousTimer = new Timer();
    ElapsedEventHandler eventHandlerDelay;
    ElapsedEventHandler eventHandler;
    private bool delayed = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerSkillManager = player.GetComponentInChildren<SkillManager>();
        skill = playerSkillManager.FindSkill(skillType);
        tempSkill = skill.Level;
        eventHandlerDelay = new ElapsedEventHandler(CountDelay);
        eventHandler = new ElapsedEventHandler(Count);
    }

    public void Save()
    {
        tempSkill = skill.Level;
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillSaveButton.Saved)
        {
            Save();
        }

        if (!isIncrease)
        {
            if (tempSkill == skill.Level)
            {
                arrowEnabled = false;
            }
            else
            {
                arrowEnabled = true;
            }
        }
        else
        {
            if (GlobalValues.max_skill_level == skill.Level)
            {
                arrowEnabled = false;
            }
            else
            {
                if (playerSkillManager.CurrentSkillPoints == 0)
                {
                    arrowEnabled = false;
                }
                else
                {
                    arrowEnabled = true;
                }
            }
        }

        this.GetComponent<Image>().enabled = arrowEnabled;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isIncrease)
            {
                IncreasePoint(1);
            }
            else
            {
                IncreasePoint(-1f);
            }
            delayed = true;

            startTimer = new Timer();
            startTimer.Interval = GlobalValues.global_UI_arrow_delay;
            startTimer.Enabled = true;
            startTimer.Elapsed += eventHandlerDelay;

            continuousTimer = new Timer();
            continuousTimer.Interval = GlobalValues.global_UI_arrow_speed;
            continuousTimer.Enabled = true;
            continuousTimer.Elapsed += eventHandler;
        }
    }

    private void Count(object sender, ElapsedEventArgs e)
    {
        if (!delayed)
        {
            if (isIncrease)
            {
                IncreasePoint(1);
            }
            else
            {
                IncreasePoint(-1f); 
            }
        }
    }

    private void CountDelay(object sender, ElapsedEventArgs e)
    {
        delayed = false;
    }
    private void IncreasePoint(float i = 1)
    {
        if(arrowEnabled)
        {
            skill.IncreaseSkillOnLevelUp(tempSkill, i);

            if (isIncrease)
            {
                playerSkillManager.IncrementSkillPoints(-1);
            }
            else
            {
                playerSkillManager.IncrementSkillPoints(1);
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            startTimer.Dispose();
            continuousTimer.Dispose();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("exit called");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("click called");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("enter called");
    }
}