using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static GetAPI;

public class WebRequest : MonoBehaviour
{
    public static WebRequest Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public string apiURL = "http://localhost:1337/api/landing-pages";
    public DataWrapper dataWrapper;

    [System.Serializable]
    public class DataWrapper
    {
        public List<DataMap> data;
    }


    [System.Serializable]
    public class DataMap
    {
        public int id;
        public Attributes attributes;
    }

    [System.Serializable]
    public class Attributes
    {
        public string title;
        public string description;  
        public string slug;
        public DateTime createdAt;
        public DateTime updatedAt;
        public DateTime publishedAt;
        public List<Block> blocks;
        public string name;
        public object alternativeText;
        public string url;
    }

    [System.Serializable]
    public class Block
    {
        public int id;
        public string __component;
        public string heading;
        public string text;
        public Link link;
        public string description;
        public GetMedia image;
        public List<Card> card;
        public string name;
        public List<Plan> plan;
        public string title;
    }


    [System.Serializable]
    public class LandingPageLink
    {
        public int id;
        public string title;
        public string link;
        public bool isExternal;
        public string type;
    }

    [System.Serializable]
    public class LandingPage
    {
        public int id;
        public string __component;
        public string heading;
        public string text;
        public LandingPageLink link;
    }

    [System.Serializable]
    public class LandingPagesResponse
    {
        public List<LandingPage> data;
    }

    void Start()
    {
        StartCoroutine(FetchDataFromAPI());
    }

    /*public void InterplayButtonPressed(int order)
    {
        StartCoroutine(FetchDataFromAPI(order));
    }*/

    IEnumerator FetchDataFromAPI(/*int order*/)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(apiURL);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.LogError("Error: " + webRequest.error);
        }
        else
        {
            // Parse JSON response
            string jsonResponse = webRequest.downloadHandler.text;
            // LandingPagesResponse response = JsonUtility.FromJson<LandingPagesResponse>(jsonResponse);
            DataWrapper response = JsonUtility.FromJson<DataWrapper>(jsonResponse);
            dataWrapper = response;

            if (response != null && response.data != null && response.data.Count > 0)
            {
                // Access the specific part of JSON you mentioned
                var firstLandingPage = response.data[0];

                Debug.Log("ID: " + firstLandingPage.id);
                Debug.Log("Title: " + firstLandingPage.attributes.title);
                Debug.Log("Desc: " + firstLandingPage.attributes.description);
                Debug.Log("Desc: " + firstLandingPage.attributes.blocks[3].id);
                Debug.Log("Desc: " + firstLandingPage.attributes.blocks[3].__component);
                Debug.Log("Desc: " + firstLandingPage.attributes.blocks[3].heading);
                Debug.Log("Desc: " + firstLandingPage.attributes.blocks[3].text);

                Debug.Log("Img" + firstLandingPage.attributes.blocks[3].image.data.attributes.url);
                /*Debug.Log("Component: " + firstLandingPage.text);
                Debug.Log("Heading: " + firstLandingPage.heading);
                Debug.Log("Text: " + firstLandingPage.text);

                LandingPageLink link = firstLandingPage.link;
                Debug.Log("Link ID: " + link.id);
                Debug.Log("Link Title: " + link.title);
                Debug.Log("Link URL: " + link.link);
                Debug.Log("Is External: " + link.isExternal);
                Debug.Log("Link Type: " + link.type);*/
            }
            else
            {
                Debug.LogError("Failed to parse JSON response.");
            }
        }
    }
}
