using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    public bool amMoving = false;
    Vector3 oldPos;
    Vector3 currentPos;
    Vector3 targetPos;
    void Start()
    {       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


        anim.SetInteger("WeaponType_int", 0);
        anim.SetInteger("MeleeType_int", 0);

    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if (currentPos == targetPos)
        {
            amMoving = false;           
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        oldPos = transform.position;
        amMoving = true;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
            targetPos = agent.destination;
        }
    }

}
