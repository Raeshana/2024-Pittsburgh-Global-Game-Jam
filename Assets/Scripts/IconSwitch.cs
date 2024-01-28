using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwitch : MonoBehaviour
{
    [SerializeField] Greyscale person;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(person.isHappy)
        {
            image.color = Color.white;
        }
    }
}
