using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] Greyscale person;
    private SpriteRenderer sr;
    [SerializeField] Sprite newSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(person.isHappy)
        {
           sr.sprite = newSprite;
        }
    }
}
