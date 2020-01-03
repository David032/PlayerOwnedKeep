using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorldAction : MonoBehaviour
{
    public GameObject dialogueWindow;
    public GameObject dialogueSpot;
    public string message = "";
    public float accessRange;

    public string EventName = "";
    public List<categories> EventCategories;
    public bool IsEventUnforgetabble = false;
    [Range(0f, 1f)]
    public float EventWeight = 0.75f;

    GameObject spawnedDialogue;
    EventManager Manager;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        print(distanceBetween);
        if (distanceBetween < accessRange)
        {
            player.GetComponent<NavMeshAgent>().enabled = false;
            spawnedDialogue = Instantiate(dialogueWindow, dialogueSpot.transform);
            spawnedDialogue.GetComponent<RectTransform>().localPosition.Set(0, 0, 0);
            spawnedDialogue.GetComponent<DialogueInstance>().NewDialogueInstance(false, false, message, player);
            spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.RemoveAllListeners();
            spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.AddListener(OnDialogueEnd);   
        }
        else
        {      
        }
    }

    public void OnDialogueEnd() 
    {
        player.GetComponent<NavMeshAgent>().enabled = true;
        Event thisEventEntry = Manager.gameObject.AddComponent<Event>();
        thisEventEntry.CreateEvent(EventName, EventCategories, EventWeight, IsEventUnforgetabble);
        Manager.Events.Add(thisEventEntry);
        EventObject thisEvent = this.gameObject.AddComponent<EventObject>();
        thisEvent.EventId = EventName;
        thisEvent.EventObjectType = ObjectType.Visual;
        thisEvent.LinkedEvent = thisEventEntry;
        Destroy(spawnedDialogue);
    }
}
