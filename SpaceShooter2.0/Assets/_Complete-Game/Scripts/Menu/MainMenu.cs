using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (PlayerManager.Instance)
        {
            PlayerManager.Instance.ResetChoices();
        }
    }

    public void LoadShipSelection(bool a_TwoPlayerMode)
    {
        if(a_TwoPlayerMode)
        {
            if(PlayerManager.Instance)
            {
                PlayerManager.Instance.TwoPlayerMode = true;
            }
        }

        if(LevelManager.Instance)
        {
            LevelManager.Instance.ChangeLevel(EScene.ShipSelection);
        }
    }
}
