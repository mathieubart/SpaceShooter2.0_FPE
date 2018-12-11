using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovment : MonoBehaviour
{
    [SerializeField]
    private float m_MoveTime = 1.5f;
    [SerializeField]
    private List<Transform> m_ShieldTargetsPos = new List<Transform>();
    [SerializeField]
    private Transform m_TransformToRotateAround;
    [SerializeField]
    private int m_CurrentTarget;

    private bool m_Ready = true;


    private void Update()
    {
        transform.Rotate(m_TransformToRotateAround.position,30);
        
        if (m_Ready)
        {
            m_Ready = false;
            StartCoroutine(ShieldMove(m_ShieldTargetsPos[m_CurrentTarget].position));
            /*
            if (transform.position.x == m_TransformToRotateAround.position.x)
            {
                if (transform.position.z > m_TransformToRotateAround.position.z)
                {
                    StartCoroutine(ShieldMove(m_ShieldTargetsPos[1].position));
                }
                else
                {
                    StartCoroutine(ShieldMove(m_ShieldTargetsPos[3].position));
                }
            }
            else
            {
                if (transform.position.x > m_TransformToRotateAround.position.x)
                {
                    StartCoroutine(ShieldMove(m_ShieldTargetsPos[2].position));
                }
                else
                {
                    StartCoroutine(ShieldMove(m_ShieldTargetsPos[0].position));
                }
            }
            */
        }
        
    }

    private IEnumerator ShieldMove(Vector3 i_EndPos)
    {
        Vector3 startPos = transform.position;

        float value = 0.0f;
        float currentTime = 0.0f;

        while (currentTime != m_MoveTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime > m_MoveTime)
            {
                currentTime = m_MoveTime;
            }

            value = currentTime / m_MoveTime;
            transform.position = Vector3.Lerp(startPos, i_EndPos, value);
            yield return new WaitForEndOfFrame();
        }
        if (m_CurrentTarget < m_ShieldTargetsPos.Count - 1)
        {
            m_CurrentTarget++;
        }
        else
        {
            m_CurrentTarget = 0;
        }


        m_Ready = true;
    }

}
