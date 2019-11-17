using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public TextMesh text;
    public void SetText(string inputText) 
    {
        text.text = inputText;
    }
}
