using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHUDEnabler : MonoBehaviour
{

    [SerializeField]
    Transform KeyHUDContainer;

    Key[] keysInLevel;

    // Start is called before the first frame update
    void Start()
    {
        keysInLevel = FindObjectsOfType<Key>();

        for (int i = 0; i < keysInLevel.Length; i++)
        {
            KeyHUDContainer.GetChild(i).gameObject.SetActive(true);
        }


    }
    
}
