using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEffect : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if(rb2d == null)
        {
            rb2d = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        }

        PlanetObjectController poc = GetComponent<PlanetObjectController>();
        if(poc != null)
            Destroy(poc);

        rb2d.AddForce(new Vector2(Random.Range(-25f, 25f), 55f), ForceMode2D.Impulse);
        rb2d.gravityScale = 5f;

        Destroy(gameObject, 3.5f);
    }
}
