using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;

            collision.GetComponent<PlayerInventory>().AddKey();

            transform.DOMove(collision.transform.position, .3f);
            transform.DOScale(0, .3f);

        }
    }
}
