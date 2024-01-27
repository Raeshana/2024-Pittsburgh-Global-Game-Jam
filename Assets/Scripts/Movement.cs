using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [ContextMenu("Moves player")]
    public void MoveFn(float directionX, float directionY)
    {
        rb.velocity = new Vector2(directionX * moveSpeed, directionY * moveSpeed);
    }
}
