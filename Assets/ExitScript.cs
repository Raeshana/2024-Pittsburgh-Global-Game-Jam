using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private SceneController sc;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SceneController>();
    }

    public void AddCount()
    {
        count++;
        Debug.Log(count);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && count == 5)
        {
            sc.GoToWinScreen();
        }
    }
}
