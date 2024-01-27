using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] Material material1; 
    [SerializeField] Material material2; 

    private float currTime = 0f; 
    private float maxTime = 1f;

    private HappinessBar happinessBar;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        happinessBar = GetComponentInChildren<HappinessBar>();
        happinessBar.SetMax(maxTime);
    }

    [ContextMenu("If player is in a room and is laughing, the person gets less greyscale")]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().isLaughing)
        {
            currTime += 0.1f;
            happinessBar.UpdateBar(currTime);
            renderer.material.Lerp(material1, material2, currTime);
        }
    }
}
