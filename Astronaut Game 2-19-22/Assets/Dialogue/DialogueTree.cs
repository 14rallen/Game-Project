﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class DialogueTree
{
    [XmlElement("Dialogue")]
    public List<Dialogue> Dialogues;
}
