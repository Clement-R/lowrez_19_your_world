using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HandsController : MonoBehaviour
{
    public static HandsController Instance;

    [SerializeField] private Transform m_leftHand;
    [SerializeField] private GameObject m_leftArm;
    [SerializeField] private Transform m_rightHand;
    [SerializeField] private GameObject m_rightArm;

    private Item m_rightItem = null;
    private Item m_leftItem = null;

    private EHand m_last = EHand.NONE;

    private enum EHand
    {
        NONE = 0,
        LEFT = 1,
        RIGHT = 2
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (m_leftItem != null)
                m_leftItem.Use();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_rightItem != null)
                m_rightItem.Use();
        }
    }

    public void GrabNewItem(Item p_item)
    {
        Transform hand = GetNextHand();
        if (!IsHandFree(hand))
        {
            // Throw object
            GameObject go = hand.GetChild(0).gameObject;
            go.transform.parent = null;
            go.AddComponent(typeof(ThrowEffect));
        }

        // Grab new object
        p_item.transform.parent = hand;
        p_item.transform.localPosition = Vector2.zero;

        // Set item
        if (m_last == EHand.LEFT)
            m_leftItem = p_item;
        else
            m_rightItem = p_item;

        UpdateArms();
    }

    private bool IsHandFree(Transform p_hand)
    {
        return p_hand.childCount == 0;
    }

    private Transform GetNextHand()
    {
        if (m_last == EHand.NONE)
        {
            m_last = EHand.LEFT;
            return m_leftHand;
        }
        else if (m_last == EHand.LEFT)
        {
            m_last = EHand.RIGHT;
            return m_rightHand;
        }
        else
        {
            m_last = EHand.LEFT;
            return m_leftHand;
        }
    }

    private void UpdateArms()
    {
        m_leftArm.SetActive(!IsHandFree(m_leftHand));
        m_rightArm.SetActive(!IsHandFree(m_rightHand));
    }
}