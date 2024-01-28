using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private SceneController sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SceneController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            sc.GoToWinScreen();
        }
    }
}
