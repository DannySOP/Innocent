using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// test 3
[System.Serializable]
public class GetMedia
{
    public photoData data;

    [System.Serializable]
    public class photoData
    {
        public int id;
        public photoAttributes attributes;
    }


    [System.Serializable]
    public class photoAttributes
    {
        public string name;
        public string alternativeText;
        public string url;
    }
}
