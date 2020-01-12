using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Base components required for event creation
/// </summary>

public class BaseEvent : MonoBehaviour
{
    protected EventManager Manager;
    protected GameObject player;
    protected GameObject dialogueWindow;
    protected GameObject dialogueSpot;

    public string EventName = "";
    public List<categories> EventCategories;
    public bool IsEventUnforgetabble = false;
    [Range(0f, 1f)]
    public float EventWeight = 0.75f;
    public int refremceId = 0;

    protected GameObject spawnedDialogue;

    public float accessRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEvent() 
    {
        if (!gameObject.GetComponent<EventObject>())
        {
            Event thisEventEntry = Manager.gameObject.AddComponent<Event>();
            if (refremceId != 0)
            {
                thisEventEntry.CreateEvent(EventName, EventCategories, EventWeight, IsEventUnforgetabble,refremceId);

            }
            else
            {
                thisEventEntry.CreateEvent(EventName, EventCategories, EventWeight, IsEventUnforgetabble);
            }

            Manager.Events.Add(thisEventEntry);
            EventObject thisEvent = this.gameObject.AddComponent<EventObject>();
            thisEvent.EventId = EventName;
            thisEvent.EventObjectType = ObjectType.Visual;
            thisEvent.LinkedEvent = thisEventEntry;
        }
    }

    public void AssignElements() 
    {
        Manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueSpot = GameObject.FindGameObjectWithTag("dialogueSpot");
        dialogueWindow = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableController>().dialogueWindow;
    }

    public void spawnDialogue(string message) 
    {
        player.GetComponent<NavMeshAgent>().enabled = false;
        spawnedDialogue = Instantiate(dialogueWindow, dialogueSpot.transform);
        spawnedDialogue.GetComponent<RectTransform>().localPosition.Set(0, 0, 0);
        spawnedDialogue.GetComponent<DialogueInstance>().NewDialogueInstance(false, true, message, player);
        spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.RemoveAllListeners();
        spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.AddListener(OnDialogueEnd);
    }

    public void spawnDialogue(string message, bool createEvent) 
    {
        player.GetComponent<NavMeshAgent>().enabled = false;
        spawnedDialogue = Instantiate(dialogueWindow, dialogueSpot.transform);
        spawnedDialogue.GetComponent<RectTransform>().localPosition.Set(0, 0, 0);
        spawnedDialogue.GetComponent<DialogueInstance>().NewDialogueInstance(false, true, message, player);
        spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.RemoveAllListeners();
        spawnedDialogue.GetComponent<DialogueInstance>().button.GetComponent<Button>().onClick.AddListener(OnEventEnd);
    }

    public void OnDialogueEnd()
    {
        player.GetComponent<NavMeshAgent>().enabled = true;
        CreateEvent();
        Destroy(spawnedDialogue);
    }

    public void OnEventEnd() 
    {
        player.GetComponent<NavMeshAgent>().enabled = true;
        Destroy(spawnedDialogue);
    }

    public bool CalculateDistance() 
    {
        float distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        print(distanceBetween);
        if (distanceBetween < accessRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
