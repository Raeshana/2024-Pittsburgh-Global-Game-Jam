using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPerson : MonoBehaviour
{
    private Greyscale person;

    void Start()
    {
        person = GetComponent<Greyscale>();
    }

    void Update()
    {
        if(person.isHappy)
        {
            Destroy(gameObject);
        }
    }
}
