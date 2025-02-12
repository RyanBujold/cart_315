using UnityEngine;

public class FallBrick : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isActive = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {

        // Alter the blocks to fall and change color on collision
        if (other.gameObject.tag == "Ball" && isActive) {
            rb.constraints = RigidbodyConstraints2D.None;
            sr.color = Color.yellow;
            GameManager.S.AddBricksHit();
            isActive = false;
        }
    }
}
