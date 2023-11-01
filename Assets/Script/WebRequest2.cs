using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest2 : MonoBehaviour
{
    public static WebRequest2 webInstance { get; private set; }

    private void Awake()
    {
        if (webInstance == null)
        {
            webInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public string urlAPI = "https://api-v2.svcc.io/booth-b-20-s";
    public DataWrapper dataWrapper;


    [Serializable]
    public class DataWrapper
    {
        public List<Data> data;
    }

    [Serializable]
    public class Data
    {
        public int id;
        public string name;
        public string published_at;
        public string created_at;
        public string updated_at;
        public List<A> A;
        public List<C> C;
        public List<E> E;
    }

    [Serializable]
    public class A
    {
        public int id;
        public string name;
        public string type;
        public string video_url;
        public string thumbnail_url;
    }

    [Serializable]
    public class C
    {
        public int id;
        public string name;
        public string type;
        public string url_file;
        public Image image;
    }

    [Serializable]
    public class Image
    {
        public int id;
        public string name;
        public string alternativeText;
        public string caption;
        public float width;
        public float height;
        public Formats formats;
        public string hash;
        public string ext;
        public float size;
        public string url;
        public string previewUrl;
        public string provider;
        public string provider_metadata;
        public string created_at;
        public string updated_at;
    }

    [Serializable]
    public class Formats
    {
        public Thumbnail thumbnail;
        public Large large;
        public Medium medium;
        public Small small;
    }

    [Serializable]
    public class Thumbnail
    {
        public string name;
        public string hash;
        public string ext;
        public string mime;
        public float width;
        public float height;
        public float size;
        public string path;
        public string url;
    }

    [Serializable]
    public class Large
    {
        public string name;
        public string hash;
        public string ext;
        public string mime;
        public float width;
        public float height;
        public float size;
        public string path;
        public string url;
    }

    [Serializable]
    public class Medium
    {
        public string name;
        public string hash;
        public string ext;
        public string mime;
        public float width;
        public float height;
        public float size;
        public string path;
        public string url;
    }

    [Serializable]
    public class Small
    {
        public string name;
        public string hash;
        public string ext;
        public string mime;
        public float width;
        public float height;
        public float size;
        public string path;
        public string url;
    }

    [Serializable]
    public class E
    {

    }


    public static string WrapToClass(string source, string topClass)
    {
        return string.Format("{{ \"{0}\": {1}}}", topClass, source);
    }

    public List<ShowVideo> showVideo = new List<ShowVideo>();
    void Start()
    {
        StartCoroutine(FetchDataFromAPI());

        FindShowVideoComponents();
    }   

    IEnumerator FetchDataFromAPI()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(urlAPI);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.LogError("Error: " + webRequest.error);
        }
        else
        {
            string jsonResponse = webRequest.downloadHandler.text;
            string jsonWrap = WrapToClass(jsonResponse, "data");
            DataWrapper response = JsonUtility.FromJson<DataWrapper>(jsonWrap);
            /*Debug.Log(jsonResponse);*/
            dataWrapper = response;
        }
    }

    public void FindShowVideoComponents()
    {
        showVideo.Clear(); // Clear the list to avoid duplicates

        // Find all ShowVideo components in the entire scene, including inactive ones
        ShowVideo[] foundVideos = Resources.FindObjectsOfTypeAll<ShowVideo>();

        // Add them to the showVideo list
        showVideo.AddRange(foundVideos);
    }

    public void GetAllVideo()
    {
        /*foreach (ShowVideo showVideo in showVideo)
        {
            showVideo.GetVideo();
        }*/
    }
}
