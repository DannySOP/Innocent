using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowMedia : MonoBehaviour
{
    public RawImage imageTarget;
    public int blockNumber;
    public int cardNumber;

    private void Start()
    {
        imageTarget = GetComponent<RawImage>();
        
        StartCoroutine(SetImageCoroutine("http://localhost:1337" + WebRequest.Instance.dataWrapper.data[0].attributes.blocks[blockNumber].card[cardNumber].image.data.attributes.url, imageTarget));
    }

    public void ShowImageOnScreen()
    {
        StartCoroutine(SetImageCoroutine("http://localhost:1337" + WebRequest.Instance.dataWrapper.data[0].attributes.blocks[blockNumber].card[cardNumber].image.data.attributes.url, imageTarget));
    }

    private IEnumerator SetImageCoroutine(string url, RawImage img, AspectRatioFitter ratio = null)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(url);
            Debug.Log(www.error);
        }
        else
        {
            Texture tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
            img.texture = tex;
            ratio.aspectRatio = (float)tex.width / (float)tex.height;
        }
    }
}
