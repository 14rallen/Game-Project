using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialoguable
{
    void TriggerDialoguePrompt(bool active);
    bool GetDialogueActive();

    void BeginDialogue();

    void LoadDialogue();
}
