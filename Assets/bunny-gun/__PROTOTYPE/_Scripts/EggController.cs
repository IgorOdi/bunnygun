using UnityEngine;

public class EggController : MonoBehaviour {

    public static bool destroyEgg = true;

    void OnEnable () {

        Destroy (gameObject, 8f);
    }

    void OnCollisionEnter2D (Collision2D other) {

        if (other.transform.CompareTag ("Player")) {

            other.transform.GetComponent<PlayerController> ().OnHit ();
        }

        if (destroyEgg) {

            DestroyOnPlatform ();
        } else {

            StayOnPlatform ();
        }
    }

    private void StayOnPlatform () {

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
        spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.3f);
        Physics2D.IgnoreCollision (GetComponent<Collider2D> (), FindObjectOfType<PlayerController> ().GetComponent<Collider2D> ());
    }

    private void DestroyOnPlatform () {

        Destroy (gameObject, 0.1f);
    }
}