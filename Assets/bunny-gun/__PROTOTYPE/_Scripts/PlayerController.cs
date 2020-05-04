using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform platform;

    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    [SerializeField]
    private float projectTime;
    private float runningTime;

    [SerializeField]
    private GameObject projectile;

    private int side = 0;
    private bool calledHit;

    void Start () {

        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

#if UNITY_EDITOR

        rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);
#else

        if (Input.GetMouseButton (0)) {
            side = Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x ? 1 : -1;;
        } else {
            side = 0;
        }

        rb.velocity = new Vector2 (side * speed, rb.velocity.y);
#endif
        transform.eulerAngles = platform.eulerAngles;

        runningTime += Time.deltaTime;
        if (runningTime >= projectTime) {

            Instantiate (projectile, transform.position, Quaternion.identity);
            runningTime = 0;
        }

        if (transform.position.y <= -6 && !calledHit) {

            calledHit = true;
            OnHit ();
        }
    }

    public void OnHit () {

        FindObjectOfType<GameOverController> ().ShowGameOver ();
    }
}