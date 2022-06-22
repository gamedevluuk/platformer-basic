using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInventory inventory = collision.transform.parent.GetComponent<PlayerInventory>();
            if (inventory.ConsumeKey())
            {
                OpenLock();
            }
        }
    }
    void OpenLock()
    {
        gameObject.SetActive(false);
    }
}
    