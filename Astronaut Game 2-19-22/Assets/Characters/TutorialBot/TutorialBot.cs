using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutorialBot : MonoBehaviour, ICharacter, IDialoguable
{
    public string CharacterName;
    public GameObject DialogueCloud;
    public DialogueTree Tree = new DialogueTree();

    private string dialogueFilePath;
    private bool alive;
    private bool dialogueActive;

    public bool IsAlive()
    {
        return alive;
    }

    public void Die()
    {
        alive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        dialogueActive = false;
        dialogueFilePath = "Assets/Characters/TutorialBot/Dialogue/TutorialBotDialogue.xml";
        LoadDialogue();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialoguePrompt(bool active)
    {
        DialogueCloud.SetActive(active);
        dialogueActive = active;
    }

    public bool GetDialogueActive()
    {
        return dialogueActive;
    }

    public void BeginDialogue()
    {
        Debug.Log("Hello, my name is " + CharacterName);
        GameManager.dialogueWindow.BeginDialogue(Tree);
        //dialogueWindow.ShowDialogue(dialogueManager);
    }

    public void LoadDialogue()
    {
        Tree = DialogueLoader.Load(dialogueFilePath);
    }
}
