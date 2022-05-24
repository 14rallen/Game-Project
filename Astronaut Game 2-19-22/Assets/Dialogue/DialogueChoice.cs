using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class DialogueChoice
{
    [XmlAttribute("id")]
    public string ID;

    [XmlText]
    public string PlayerText;

    [XmlAttribute("selected")]
    public bool Selected;

    [XmlElement("Conditions")]
    public DialogueConditions Conditions = new DialogueConditions();
}
