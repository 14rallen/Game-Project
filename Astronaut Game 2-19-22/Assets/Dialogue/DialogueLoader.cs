using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DialogueTree")]
public class DialogueLoader
{
    //[XmlArray("DialogueTree")]
    //[XmlArrayItem("Dialogue")]
    //public List<Dialogue> DialogueList = new List<Dialogue>();

    public static DialogueTree Load(string path)
    {
        if(File.Exists(path))
        {
            string xmlText = File.ReadAllText(path);
            XmlSerializer serializer = new XmlSerializer(typeof(DialogueTree));
            using (StringReader reader = new StringReader(xmlText))
            {
                return (DialogueTree)(serializer.Deserialize(reader)) as DialogueTree;
            }
        }
        Debug.Log("dialogue tree path does not exist");
        return null;
    }
}
