using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private SceneController sc;
    //private int count = 0;

    [SerializeField] Greyscale[] person;

    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SceneController>();
    }

    public bool canExit()
    {
        int i = 0;
        while(i<5 && person[i].isHappy)
        {
            i++;
        }
        if (i==5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && (canExit() == true))
        {
            sc.GoToWinScreen();
        }
    }
}
