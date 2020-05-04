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

    void Start () {

        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

        if (Input.GetMouseButton (0)) {
            side = Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x ? 1 : -1;;
        } else {
            side = 0;
        }

        rb.velocity = new Vector2 (side * speed, rb.velocity.y);
        transform.eulerAngles = platform.eulerAngles;

        runningTime += Time.deltaTime;
        if (runningTime >= projectTime) {

            Instantiate (projectile, transform.position, Quaternion.identity);
            runningTime = 0;
        }
    }

    public void OnHit () {

        Time.timeScale = 0;
        FindObjectOfType<GameOverController> ().ShowGameOver ();
    }
}