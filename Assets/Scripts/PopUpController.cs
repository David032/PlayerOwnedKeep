using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Transform player;
    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SetText(string inputText) 
    {
        text.text = inputText;
        transform.LookAt(player);
    }
}
