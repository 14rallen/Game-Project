using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    public Text NPCTextBox;
    private DialogueTree tree;
    private DialogueManager manager = new DialogueManager();
    private Dialogue currentDialogue;
    private List<GameObject> choiceButtons = new List<GameObject>();
    public GameObject ButtonPrefab;
    public  GameObject DialogueWindowObject;
    private string currentID;
    public void BeginDialogue(DialogueTree t)
    {
        tree = t;
        manager.SetDialogueTree(tree);
        DialogueWindowObject.SetActive(true);
        currentDialogue = tree.Dialogues[0];
        currentID = currentDialogue.ID;
        NextDialogue();
    }

    private void NextDialogue()
    {
        if(!(currentDialogue.NPC.NPCText == null || currentDialogue.NPC.NPCText == ""))
        {
            NPCTextBox.text = currentDialogue.NPC.NPCText;
        }

        if(currentDialogue.Choices.Count == 0)
        {
            currentDialogue = manager.GetNextDialogue(currentID);
        }

        foreach (DialogueChoice c in currentDialogue.Choices)
        {
            GameObject obj = Instantiate(ButtonPrefab, gameObject.transform);

            if (!c.Conditions.ConditionsMet)
            {
                obj.GetComponent<Button>().interactable = false;
            }

            obj.GetComponentInChildren<Text>().text = c.PlayerText;

                obj.GetComponent<Button>().onClick.AddListener(delegate { ChoiceButtonClicked(c); });

                if (c.Selected)
                {
                    obj.GetComponent<Button>().image.color = Color.cyan;
                }

                choiceButtons.Add(obj);
        }
    }

    private void ChoiceButtonClicked(DialogueChoice c)
    {
        manager.ChoiceSelected(c);
        currentID = c.ID;
        currentDialogue = manager.GetNextDialogue(currentID);
        currentID = currentDialogue.NPC.ID;
        foreach(GameObject obj in choiceButtons)
        {
            Destroy(obj);
        }

        if (c.ID == "goodbye")
        {
            CloseDialogue();
        }
        else
        {
            NextDialogue();
        }
    }

    public void CloseDialogue()
    {
        DialogueWindowObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        DialogueWindowObject = GameObject.Find("Dialogue Window");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
