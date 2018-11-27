using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{


	private void Start ()
    {
		if(LevelManager.Instance)
        {
            LevelManager.Instance.ChangeLevel(EScene.MainMenu);
        }
	}

}
