using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class GetMedia
{
    public photoData data;

    [System.Serializable]
    public class photoData
    {
        public photoAttributes attributes;
    }


    [System.Serializable]
    public class photoAttributes
    {
        public string name;
        public string url;
    }
}
