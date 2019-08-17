using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool m_clicked = false;

    [SerializeField] private AudioClip m_startClip;

    void Update()
    {
        if (Input.anyKey && !m_clicked)
        {
            m_clicked = true;
            StartCoroutine(_MoveToWorld());
        }
    }

    private IEnumerator _MoveToWorld()
    {
        SFXManager.Instance.PlaySound(m_startClip);

        yield return new WaitForSeconds(1f);

        while (Camera.main.transform.position.y != 0)
        {
            yield return null;
            Camera.main.transform.position =
                new Vector3(
                    Camera.main.transform.position.x,
                    Camera.main.transform.position.y - 1,
                    Camera.main.transform.position.z
                );
        }
    }
}