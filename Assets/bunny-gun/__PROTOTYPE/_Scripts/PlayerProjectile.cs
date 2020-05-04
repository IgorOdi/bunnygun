using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public float speed;

    void Update () {

        transform.Translate (0, speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D (Collider2D other) {

        if (other.transform.CompareTag ("Enemy")) {

            other.GetComponent<EnemyController> ().Damage ();
            GameOverController.Points += 1;
            Destroy (gameObject);
        }
    }
}