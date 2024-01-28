using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    [SerializeField] GameObject colored;
    private SpriteRenderer renderer;

    private float currAlpha = 0f;
    private float maxAlpha = 1f;

    //private HappinessBar happinessBar;

    [HideInInspector]
    public bool isHappy = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = colored.GetComponent<SpriteRenderer>();

        //happinessBar = GetComponentInChildren<HappinessBar>();
        //happinessBar.SetMax(maxAlpha);

        renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
    }

    [ContextMenu("If player is in a room and is laughing, the person gets less greyscale")]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().isLaughing)
        {
            if (!isHappy)
            {
                currAlpha += 0.1f;
                renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
                //happinessBar.UpdateBar(currAlpha);
            }

            if(currAlpha >= maxAlpha)
            {
                isHappy = true;
            }
        }
    }
}
