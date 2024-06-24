using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMoreMode : MonoBehaviour
{
    [Header("Game Object Parameters")]
    public GameObject MoreModeMultiPlayer;
    public GameObject MultiPlayerButton;
    public GameObject MoreModeSinglePlayer;
    public GameObject SinglePlayerButton;

    private bool checkActiveMulti = false;
    private bool checkActiveSingle = false;

    public void LoadMoreMulti()
    {
        MoreModeMultiPlayer.SetActive(true);
        checkActiveMulti = true;
        MultiPlayerButton.SetActive(false);
        if(checkActiveSingle)
        {
            MoreModeSinglePlayer.SetActive(false);
            SinglePlayerButton.SetActive(true);
        }
    }

    public void LoadMoreSingle()
    {
        SinglePlayerButton.SetActive(false);
        MoreModeSinglePlayer.SetActive(true);
        checkActiveSingle = true;
        if(checkActiveMulti)
        {
            MoreModeMultiPlayer.SetActive(false);
            MultiPlayerButton.SetActive(true);
        }
    }
}
