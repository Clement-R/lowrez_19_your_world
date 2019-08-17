using UnityEngine;

public class PaintBrush : Item
{
    [SerializeField] private PaintBall m_paintball;
    [SerializeField] private Transform m_spawnPosition;
    [SerializeField] private Vector2 m_baseForce;

    public override void Use()
    {
        PaintBall ball = Instantiate(m_paintball, m_spawnPosition.position, Quaternion.identity);
        Rigidbody2D rb2d = ball.GetComponent<Rigidbody2D>();

        Vector2 rand = new Vector2(Random.Range(-1f, 1f), 1);
        rb2d.AddForce(m_baseForce * rand, ForceMode2D.Impulse);
    }
}