using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{

    private Movement playerMove;
    [SerializeField] private AudioSource footstepSound;
    private Rigidbody2D rb;

    private float directionX;
    private float directionY;

    private Laugh playerLaugh;
    public bool isLaughing = false;
    public bool isMoving = false;
    public int laughter_count;

    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<Movement>();
        playerLaugh = GetComponent<Laugh>();
        laughter_count = -1;
    }

    void Update()
    {
        PlayerMove();
        PlayerFlip();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            footstepSound.Play();
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    [ContextMenu("Takes input for player movement")]
    private void PlayerMove()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        playerMove.MoveFn(directionX, directionY);
    }

    [ContextMenu("Detects if player is laughing")]
    public void IsPlayerLaughing(string recordedText)
    {
        laughter_count = Regex.Matches(recordedText.ToLower(), "ha").Count;

        if (laughter_count > 0)
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
