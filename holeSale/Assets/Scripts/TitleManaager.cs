using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

[XmlRoot("TitleManager")]
public class TitleManaager : MonoBehaviour {
    [XmlArray("Titles")]
    [XmlArrayItem("Title")]
    public List<Title> Titles = new List<Title>();
   // public Title[] Titles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Save(string path) {
        var serializer = new XmlSerializer(typeof(TitleManaager));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    
    }

    public static TitleManaager Load(string path)
    {
        
    }
}
