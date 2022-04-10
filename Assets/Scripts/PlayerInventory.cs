using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    bool hasKey = false;
    public void AddKey()
    {
        hasKey = true;
    }

    public void RemoveKey()
    {
        hasKey = false;
    }

    public bool ConsumeKey()
    {
        if (hasKey)
        {
            RemoveKey();
            return true;
        }

        return false;
    }
}