using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	public void ToggleTwoPlayerMode()
    {
        if(PlayerManager.Instance)
        {
            PlayerManager.Instance.TwoPlayerMode = !PlayerManager.Instance.TwoPlayerMode;
        }
    }

    public void LoadShipSelection()
    {
        if(LevelManager.Instance)
        {
            LevelManager.Instance.ChangeLevel(EScene.ShipSelection);
        }
    }
}
