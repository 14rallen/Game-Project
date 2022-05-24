using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeff : MonoBehaviour, ICharacter, IDialoguable
{
    public string CharacterName;
    public GameObject DialogueCloud;
    public DialogueTree Tree = new DialogueTree();

    private string dialogueFilePath;
    private bool alive;
    private bool dialogueActive;
    public void BeginDialogue()
    {
        GameManager.dialogueWindow.BeginDialogue(Tree);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public bool GetDialogueActive()
    {
        return dialogueActive;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void LoadDialogue()
    {
        Tree = DialogueLoader.Load(dialogueFilePath);
    }

    public void TriggerDialoguePrompt(bool active)
    {
        DialogueCloud.SetActive(active);
        dialogueActive = active;
    }

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        dialogueActive = false;
        dialogueFilePath = "Assets/Characters/Jeff/Dialogue/JeffDialogue.xml";
        LoadDialogue();
        //Debug.Log(Tree.Dialogues[2].Choices[0].Conditions.ConditionsMet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
