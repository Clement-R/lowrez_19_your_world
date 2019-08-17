using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private PaintBall m_paint;
    [SerializeField] private AudioClip[] m_walkSounds;
    [SerializeField] private AudioClip m_interact;

    private Interactable m_currentInteractable = null;
    private int m_walkIndex = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                m_animator.Play("Walk");
        }
        else
        {
            if (!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                m_animator.Play("Idle");
                m_walkIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (m_currentInteractable != null)
            {
                m_currentInteractable.Interact();
                SFXManager.Instance.PlaySound(m_interact);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D p_collider)
    {
        Interactable interactable = p_collider.GetComponent<Interactable>();
        if (interactable != null && m_currentInteractable == null)
        {
            m_currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D p_collider)
    {
        Interactable interactable = p_collider.GetComponent<Interactable>();
        if (interactable != null && interactable == m_currentInteractable)
        {
            m_currentInteractable = null;
        }
    }

    public void PlayWalkSound()
    {
        SFXManager.Instance.PlaySound(m_walkSounds[m_walkIndex]);
        m_walkIndex++;

        if (m_walkIndex > m_walkSounds.Length - 1)
            m_walkIndex = 0;
    }
}