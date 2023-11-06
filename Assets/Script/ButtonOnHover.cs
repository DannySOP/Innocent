using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color normalColor;
    private Color hoverColor;
    private Image buttonImage;
    private Button posButton;

    private ButtonManager buttonManager;

    private void Start()
    {
        buttonManager = FindAnyObjectByType<ButtonManager>();
        buttonImage = GetComponent<Image>();
        posButton = GetComponent<Button>();

        normalColor = buttonImage.color;
        hoverColor = new Color(128f / 255f, 255f / 255f, 255f / 255f, 1f);

        /*posButton.onClick.AddListener(OnButtonClick);*/

    }

    private void Update()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            buttonImage.color = hoverColor;
        }*/
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            buttonImage.color = normalColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = normalColor;
    }

    public void RevertColorToNormal()
    {
        buttonImage.color = normalColor;
    }

    public void OnButtonClick()
    {
        buttonManager.BottonOnClick();
        Debug.Log("pencet");
    }
}
