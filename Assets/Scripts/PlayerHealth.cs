using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer playerGfx;

    PlayerInput playerInput;
    PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInventory = GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer()
    {
        if (playerInput.isDead)
            return; 

        playerInput.DisableControls();
        playerGfx.color = Color.red;
        GameManager.instance.PlayerDied();
    }

    void RevivePlayer()
    {
        if (!playerInput.isDead)
            return;

        playerInput.EnableControls();
        playerGfx.color = Color.white;
        GameManager.instance.PlayerRevived();
    }
}
