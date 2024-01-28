using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement playerMove;
    private float directionX;
    private float directionY;

    private Laugh playerLaugh;
    public bool isLaughing = false; 

    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Movement>();
        playerLaugh = GetComponent<Laugh>();
    }

    void Update()
    {
        PlayerMove();
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

    [ContextMenu("Detects if player is laughing")]
    public void IsPlayerLaughing(string recordedText)
    {

        if(recordedText.ToLower().Contains("ha"))
        {
            playerLaugh.LaughFn();
            isLaughing = true;
        }
        else
        {
            isLaughing = false;
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
