using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.GameFoundation;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    bool amMoving = false;

    void Start()
    {       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        anim.SetInteger("WeaponType_int", 0);
        anim.SetInteger("MeleeType_int", 0);

        GameFoundation.Initialize();
        TestInventory();
    }

    void TestInventory() 
    {
        InventoryItem coinItem = Wallet.GetItem("coin");
        coinItem.quantity -= 25;
    }

    void Update()
    {
        if (agent.velocity != Vector3.zero)
        {
            amMoving = true;
            anim.SetFloat("Speed_f", agent.speed);
        }
        else
        {
            amMoving = false;
            anim.SetFloat("Speed_f", 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            agent.destination = hit.point;
        }
    }

}
