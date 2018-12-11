using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectionButton : MonoBehaviour
{
    [SerializeField]
    private int m_shipIndex = 1;

    [SerializeField]
    private bool m_IsLocked = false;
    public bool IsLocked
    {
        get
        {
            return m_IsLocked;
        }
        set
        {
            m_IsLocked = value;
            if (m_LockedFeedback)
            {
                m_LockedFeedback.SetActive(false);
            }
        }
    }
    [SerializeField]
    private GameObject m_LockedFeedback;

    private Button m_Button;

    private void Start()
    {
        m_Button = GetComponent<Button>();

        if(m_LockedFeedback)
        {
            m_LockedFeedback.SetActive(m_IsLocked);
        }

        if(PlayerManager.Instance && m_Button)
        {
            m_Button.onClick.AddListener(() => PlayerManager.Instance.SetPlayerShip(m_shipIndex));
        }
    }
}
