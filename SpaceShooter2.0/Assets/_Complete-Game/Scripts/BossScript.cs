using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : Done_DestroyByContact
{
    [SerializeField]
    private int m_Lives = 5;
    [SerializeField]
    private GameObject m_WholeBossGameobject;

    protected override void OnTriggerEnter(Collider i_Other)
    {
        if (i_Other.tag == "Boundary")
        {
            return;
        }

        if (i_Other.tag == "Enemy")
        {
            Destroy(i_Other);
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (i_Other.tag == "Player")
        {
            Instantiate(playerExplosion, i_Other.transform.position, i_Other.transform.rotation);
            gameController.GameOver();
        }

        Destroy(i_Other.gameObject);

        if (m_Lives > 1)
        {
            m_Lives--;
            Debug.Log(m_Lives);
        }
        else
        {
            gameController.AddScore(scoreValue);
            Destroy(m_WholeBossGameobject);
        }
    }
}
