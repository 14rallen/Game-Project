using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager
{
    private DialogueTree tree;
    public string NPCText = "";

    public void SetDialogueTree(DialogueTree t)
    {
        tree = t;
    }

    public DialogueTree GetDialogueTree()
    {
        return tree;
    }
    public Dialogue GetNextDialogue(string id)
    {
        Dialogue d = tree.Dialogues.Find(item => item.ID == id);
        return d;
    }

    public void ChoiceSelected(DialogueChoice c)
    {
        c.Selected = true;
    }
}
