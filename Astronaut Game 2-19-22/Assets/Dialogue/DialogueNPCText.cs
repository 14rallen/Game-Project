﻿using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class DialogueNPCText
{
    [XmlText]
    public string NPCText;

    [XmlAttribute("id")]
    public string ID;
}
