using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HandsController : MonoBehaviour
{
    [SerializeField] private Transform m_leftHand;
    [SerializeField] private Transform m_rightHand;

    public void GrabNewItem(GameObject p_item)
    {

    }

    private bool IsLeftHandAvailable()
    {
        return m_leftHand.childCount == 0;
    }

    private bool IsRightHandAvailable()
    {
        return m_rightHand.childCount == 0;
    }
}