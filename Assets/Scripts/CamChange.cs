using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamChange : MonoBehaviour
{
    public GameObject NormalCam;
    public GameObject OpinionCam;

    NavMeshAgent playerAgent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Awake() 
    {
        playerAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
    }

    public void switchCam() 
    {
        NormalCam.SetActive(!NormalCam.activeSelf);
        OpinionCam.SetActive(!OpinionCam.activeSelf);
        playerAgent.isStopped = !playerAgent.isStopped;
    }

    IEnumerator restoreMovementCapability() 
    {
        yield return new WaitForSeconds(0.1f);
        playerAgent.isStopped = false;
    }
}
