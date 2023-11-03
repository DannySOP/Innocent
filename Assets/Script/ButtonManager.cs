using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Color normalColor;
    private Color hoverColor;

    public List<ButtonOnHover> posButton = new List<ButtonOnHover>();

    private void Start()
    {
        ButtonOnHover[] buttonOnHovers = Resources.FindObjectsOfTypeAll<ButtonOnHover>();
        
        foreach (ButtonOnHover buttonOnHover in buttonOnHovers)
        {
            posButton.Add(buttonOnHover);
        }
    }


    public void BottonOnClick()
    {
        foreach (ButtonOnHover buttonOnHover in posButton)
        {
            buttonOnHover.RevertColorToNormal();
        }
    }
}
