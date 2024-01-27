using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tickle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("Player tickle")]
    public void TickleFn()
    {
        Debug.Log("tickling");
    }
}
