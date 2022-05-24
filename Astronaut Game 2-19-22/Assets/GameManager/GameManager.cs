using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static DialogueWindow dialogueWindow;
    private static IDialoguable dialoguable;
    private static List<IDialoguable> diags;

    //public static SkillManager playerSkillManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Debug.Log(player.GetSkillManager().Science.Level);
        dialogueWindow = GameObject.Find("HUD").GetComponentInChildren<DialogueWindow>();
        diags = new List<IDialoguable>();
        //playerSkillManager = player.GetComponentInChildren<SkillManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IDialoguable GetDialoguable()
    {
        return dialoguable;
    }

    public static void SetDialoguable(IDialoguable d)
    {
        diags.Add(d);
        if (!(dialoguable != null && dialoguable.GetDialogueActive()))
        {
            dialoguable = d;
            dialoguable.TriggerDialoguePrompt(true);
        }
    }

    public static void RemoveDialogable(IDialoguable d)
    {
        diags.Remove(d);
        d.TriggerDialoguePrompt(false);
        if(diags.Count > 0)
        {
            dialoguable = diags[0];
            dialoguable.TriggerDialoguePrompt(true);
        }
        else if(diags.Count == 0)
        {
            dialoguable = null;
        }
    }
}
