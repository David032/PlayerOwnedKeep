using UnityEngine;
public class Sense : MonoBehaviour
{
    public bool enableDebug = true;
    public float detectionRate = 1.0f;
    protected float elapsedTime = 0.0f;

    protected virtual void Initialize() { }
    protected virtual void UpdateSense() { }

    void Start()
    {
        elapsedTime = 0.0f;
        Initialize();
    }

    void Update()
    {
        UpdateSense();
    }
}
