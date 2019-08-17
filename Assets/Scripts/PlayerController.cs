using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private PaintBall m_paint;

    private Interactable m_currentInteractable = null;

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
                m_animator.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.F))
            if (m_currentInteractable != null)
                m_currentInteractable.Interact();

        /*The FontStruction “Minimal Pixels” (https://fontstruct.com/fontstructions/show/1264958) by “josriley” is licensed under a Creative Commons Attribution Share Alike license (http://creativecommons.org/licenses/by-sa/3.0/). */
        /*Particle font by Eeve https://www.patreon.com/somepx */
    }

    private void OnTriggerEnter2D(Collider2D p_collider)
    {
        Debug.Log("Enter trigger " + p_collider.name);

        Interactable interactable = p_collider.GetComponent<Interactable>();
        if (interactable != null && m_currentInteractable == null)
        {
            m_currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D p_collider)
    {
        Debug.Log("Exit trigger " + p_collider.name);

        Interactable interactable = p_collider.GetComponent<Interactable>();
        if (interactable != null && interactable == m_currentInteractable)
        {
            m_currentInteractable = null;
        }
    }
}