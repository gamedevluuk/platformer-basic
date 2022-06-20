using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int playersDead = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRevived()
    {
        playersDead--;
    }

    public void PlayerDied()
    {
        playersDead++;
        if (playersDead >= 2)
            Application.LoadLevel(0);
    }
}
