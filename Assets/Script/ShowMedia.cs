using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowMedia : MonoBehaviour
{
    public RawImage imageTarget;
    public int dataNumber;
    public int cNumber;

    private void Start()
    {
        imageTarget = GetComponentInChildren<RawImage>();

        StartCoroutine(SetImageCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].C[cNumber].image.formats.large.url, imageTarget));
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
