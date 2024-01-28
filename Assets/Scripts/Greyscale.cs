using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greyscale : MonoBehaviour
{
    [SerializeField] GameObject room;

    public GameObject player;
    private SpriteRenderer this_renderer;
    private PlayerController pc;

    public float currTime = 0f;
    public float maxTime = 1f;

    public int alpha_increase_speed = 10;

    [HideInInspector]
    public bool isHappy = false;
    public bool isInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        this_renderer = room.GetComponent<SpriteRenderer>();
        pc = player.GetComponent<PlayerController>();
        //rb = GetComponent<Rigidbody2D>();

        this_renderer.color = Color.black;
    }

    private void Update()
    {
        if (isInRange)
        {
            if (pc.isLaughing)
            {
                if (!isHappy)
                {
                    currTime += 0.01f * pc.laughter_count * alpha_increase_speed;
                    this_renderer.color = Color.Lerp(Color.black, Color.white, currTime);
                    pc.isLaughing = false;
                    pc.laughter_count = 0;
                }

                if (currTime >= maxTime)
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
