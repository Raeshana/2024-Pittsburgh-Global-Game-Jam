using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] Material material1; 
    [SerializeField] Material material2; 
    private float time = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            time += 0.05f;
            renderer.material.Lerp(material1, material2, time);
        }
    }
}
