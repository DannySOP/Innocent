using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowThumbnail : MonoBehaviour
{
    public RawImage imageTarget;
    public Image thisPanel;
    public int dataNumber;
    public int aNumber;

    private void Start()
    {
        imageTarget = GetComponentInChildren<RawImage>();
        thisPanel = GetComponent<Image>();

        PanelTransparency();

        StartCoroutine(SetImageCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].thumbnail_url, imageTarget));
    }

    private IEnumerator SetImageCoroutine(string url, RawImage img/*, AspectRatioFitter ratio = null*/)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(url);
            Debug.Log(www.error);
            StartCoroutine(SetImageCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].thumbnail_url, imageTarget));
        }
        else
        {
            Texture tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
            img.texture = tex;
            /*ratio.aspectRatio = (float)tex.width / (float)tex.height;*/
        }
    }

    public void PanelTransparency()
    {
        Color panelColor = thisPanel.color;
        panelColor.a = 0f;
        thisPanel.color = panelColor;
    }
}
