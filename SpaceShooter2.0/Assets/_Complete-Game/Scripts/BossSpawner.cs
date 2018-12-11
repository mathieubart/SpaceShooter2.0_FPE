using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BossSpawn
{
    public string m_Name;
    public int m_Wave;
    public GameObject m_Boss;
}

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    private Done_GameController m_Game;
    [SerializeField]
    private List<BossSpawn> m_BossList = new List<BossSpawn>();

    private int m_WaveCount = 0;

    private void Start()
    {
        m_Game.m_WaveChange += OnWaveChanged;
    }

    private void OnWaveChanged()
    {
        m_WaveCount++;
        foreach (BossSpawn boss in m_BossList)
        {
            if (boss.m_Wave == m_WaveCount)
            {
                Instantiate(boss.m_Boss);
            }
        }
    }
}
