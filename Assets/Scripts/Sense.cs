using UnityEngine;
public class Sense : MonoBehaviour
{
    public bool enableDebug = true;
    public float detectionRate = 1.0f;
    protected float elapsedTime = 0.0f;

    protected NPCMentalModel MentalModel;
    protected SpawnableController spawnables;

    protected virtual void Initialize() { }
    protected virtual void UpdateSense() { }

    void Start()
    {
        MentalModel = GetComponent<NPCMentalModel>();
        spawnables = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnableController>();
        elapsedTime = 0.0f;
        Initialize();
    }

    void Update()
    {
        UpdateSense();
    }
}
