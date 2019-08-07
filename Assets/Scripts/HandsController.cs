using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HandsController : MonoBehaviour
{
    [SerializeField] private Transform m_leftHand;
    [SerializeField] private Transform m_rightHand;

    private EHand m_last = EHand.NONE;

    private enum EHand
    {
        NONE = 0,
        LEFT = 1,
        RIGHT = 2
    }

    [SerializeField] private GameObject[] m_objects;
    private void DebugGrab()
    {
        GameObject go = Instantiate(m_objects[Random.Range(0, m_objects.Length)]);
        GrabNewItem(go);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            DebugGrab();
        }
    }

    public void GrabNewItem(GameObject p_item)
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

        //TODO: Show arms if objects
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
}