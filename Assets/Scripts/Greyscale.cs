using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    [SerializeField] GameObject colored;
    public GameObject player;
    private SpriteRenderer this_renderer;
    private PlayerController pc;
    //private Rigidbody2D rb;

    public float currAlpha = 0f;
    public float maxAlpha = 1f;

    public int alpha_increase_speed = 5;

    //private HappinessBar happinessBar;

    [HideInInspector]
    public bool isHappy = false;
    public bool isInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        this_renderer = colored.GetComponent<SpriteRenderer>();
        pc = player.GetComponent<PlayerController>();
        //rb = GetComponent<Rigidbody2D>();

        //happinessBar = GetComponentInChildren<HappinessBar>();
        //happinessBar.SetMax(maxAlpha);

        this_renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
    }

    private void Update()
    {
        if (isInRange)
        {
            if (pc.isLaughing)
            {
                if (!isHappy)
                {
                    currAlpha += 0.01f * pc.laughter_count * alpha_increase_speed;
                    this_renderer.color = new Color(1.0f, 1.0f, 1.0f, currAlpha);
                    //happinessBar.UpdateBar(currAlpha);
                    pc.isLaughing = false;
                    pc.laughter_count = 0;
                }

                if (currAlpha >= maxAlpha)
                {
                    isHappy = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
