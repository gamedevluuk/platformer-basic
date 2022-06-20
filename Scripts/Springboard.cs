using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 20;

    [SerializeField]
    float cooldown = 1;

    float currentCooldown;

    bool isActive = true;
    
    [SerializeField]
    Sprite activeSprite;
    [SerializeField]
    Sprite inactiveSprite;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = activeSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0)
            {
                isActive = true;
                renderer.sprite = activeSprite;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive && collision.transform.tag == "Player")
        {
            isActive = false;
            renderer.sprite = inactiveSprite;

            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            currentCooldown = cooldown;
        }
    }
}
