using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Dialogue
{
    [XmlAttribute("id")]
    public string ID;

    //[XmlElement("Text")]
    //public string NPCText;

    [XmlElement("Text")]
    public DialogueNPCText NPC;

    [XmlElement("Choice")]
    public List<DialogueChoice> Choices;
}