using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillsSelect : MonoBehaviour
{
    public Text scienceLevelText;
    public Text speechLevelText;
    public Text cheeseMakingLevelText;
    public Text skillPointsText;

    private Player player;
    private SkillManager playerSkillManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerSkillManager = player.GetComponentInChildren<SkillManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scienceLevelText.text = playerSkillManager.Science.Level.ToString();
        speechLevelText.text = playerSkillManager.Speech.Level.ToString();
        cheeseMakingLevelText.text = playerSkillManager.CheeseMaking.Level.ToString();
        skillPointsText.text = playerSkillManager.CurrentSkillPoints.ToString();
    }
}
