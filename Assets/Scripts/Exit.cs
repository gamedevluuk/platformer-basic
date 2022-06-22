using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        Application.LoadLevel(0);
    }
}
