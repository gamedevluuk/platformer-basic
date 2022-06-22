using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField]
    List<Image> HUDKeys;

    [SerializeField]
    Sprite filledKeySprite;

    [SerializeField]
    Sprite emptyKeySprite;

    int hasKey = 0;
    public void AddKey()
    {
        hasKey++;
        FillKeyInHUD();
    }

    public void RemoveKey()
    {
        hasKey--;
        UnfillKeyInHUD();
    }

    public bool ConsumeKey()
    {
        if (hasKey > 0)
        {
            RemoveKey();
            return true;
        }

        return false;
    }

    void FillKeyInHUD()
    {
        HUDKeys[hasKey - 1].sprite = filledKeySprite;
    }

    void UnfillKeyInHUD()
    {
        HUDKeys[hasKey].sprite = emptyKeySprite;

    }
}
