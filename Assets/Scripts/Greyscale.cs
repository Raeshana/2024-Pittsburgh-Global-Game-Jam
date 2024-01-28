using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    [SerializeField] GameObject colored;
    //[SerializeField] GameObject player;
    private SpriteRenderer this_renderer;
    //private Rigidbody2D rb;

    public float currAlpha = 0f;
    public float maxAlpha = 1f;

    public int alpha_increase_speed = 5;

    //private HappinessBar happinessBar;

    [HideInInspector]
    public bool isHappy = false;

    // Start is called before the first frame update
    void Start()
    {
        this_renderer = colored.GetComponent<SpriteRenderer>();
        //rb = GetComponent<Rigidbody2D>();

        //happinessBar = GetComponentInChildren<HappinessBar>();
        //happinessBar.SetMax(maxAlpha);

        this_renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerController>().isLaughing)
        {
            if (!isHappy)
            {
                currAlpha += 0.1f * collision.gameObject.GetComponent<PlayerController>().laughter_count * alpha_increase_speed;
                this_renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
                //happinessBar.UpdateBar(currAlpha);
            }

            if (currAlpha >= maxAlpha)
            {
                isHappy = true;
            }
        }
    }
}
