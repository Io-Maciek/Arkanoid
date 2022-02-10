using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public abstract class Serialization
{
    public static void Save<T>(string filename,T item)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));

        StreamWriter sw = new StreamWriter(filename);

        xml.Serialize(sw, item);

        sw.Close();
    }

    public static T Read<T>(string filename)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));

        StreamReader sr = new StreamReader(filename);

        T item = (T)xml.Deserialize(sr);

        sr.Close();

        return item;
    }
}
