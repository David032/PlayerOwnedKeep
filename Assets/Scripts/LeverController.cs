using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject door;

    private void OnMouseDown()
    {
        door.SetActive(!door.activeSelf);
    }
}
