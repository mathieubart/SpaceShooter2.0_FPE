using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager m_Instance;
    public static PlayerManager Instance
    {
        get { return m_Instance; }
    }

    private bool m_TwoPlayerMode = false;
    public bool TwoPlayerMode
    {
        get { return m_TwoPlayerMode; }
        set
        {
            m_TwoPlayerMode = value;
        }
    }

    [SerializeField]
    private GameObject[] m_SpaceShipPrefabs = new GameObject[3]; //The three prefab players can choose.
    private GameObject[] m_PlayerShips = new GameObject[2]; //The two prefab that players will have in the game.

    private void Awake()
    {
        if(PlayerManager.Instance != null)
        {
            Destroy(gameObject);
        }

        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerShip(int a_Choice)
    {
        if(a_Choice >= 3)
        {
            Debug.LogError("PlayerManager doesnt have " + a_Choice + " choices of spaceships. Mathf");
            return;
        }

        if(m_PlayerShips[0] == null)
        {
            m_PlayerShips[0] = m_SpaceShipPrefabs[a_Choice];
        }
        else
        {
            m_PlayerShips[1] = m_SpaceShipPrefabs[a_Choice];
        }

        
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (LevelManager.Instance != null)
        {
            if (m_TwoPlayerMode && m_PlayerShips[1] == null)
            {
                LevelManager.Instance.ChangeLevel(EScene.ShipSelection);
            }
            else
            {
                LevelManager.Instance.ChangeLevel(EScene.Done_Main);
            }
        }
    }

    public GameObject GetPlayerShip(int a_PlayerID)
    {
        return m_PlayerShips[a_PlayerID];
    }

    public void ResetChoices()
    {
        for(int i = 0; i < m_PlayerShips.Length; i++)
        {
            m_PlayerShips[i] = null;
        }

        m_TwoPlayerMode = false;
    }
}
