using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstanceUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(destroyMe());
    }

    IEnumerator destroyMe() 
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
