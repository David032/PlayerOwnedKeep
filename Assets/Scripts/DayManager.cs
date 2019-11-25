using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DayManager : MonoBehaviour
{
    public Material dayBox;
    public Material nightBox;

    TimeManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.timePassage == Passage.AM)
        {
            RenderSettings.skybox = dayBox;
        }
        else
        {
            RenderSettings.skybox = nightBox;
        }
    }
}
