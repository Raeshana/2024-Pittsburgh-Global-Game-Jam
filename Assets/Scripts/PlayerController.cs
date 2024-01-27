using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement playerMove;
    private float directionX;
    private float directionY;

    private Tickle playerTickle;

    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Movement>();
        playerTickle = GetComponent<Tickle>();
    }

    void Update()
    {
        PlayerMove();
        PlayerTickle();
        PlayerFlip();
    }

    [ContextMenu("Takes input for player movement")]
    private void PlayerMove()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        //Debug.Log(directionX);
        playerMove.MoveFn(directionX, directionY);
    }

    [ContextMenu("Takes input for player tickle")]
    private void PlayerTickle()
    {
        if(Input.GetButton("Fire1"))
        {
            playerTickle.TickleFn();
        }
    }

    [ContextMenu("Flips the direction that the player faces")]
    private void PlayerFlip()
    {
        if (isFacingRight && directionX < 0f || !isFacingRight && directionX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
