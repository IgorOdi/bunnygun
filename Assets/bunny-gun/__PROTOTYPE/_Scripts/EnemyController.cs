using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float speed;
    private int side = 1;
    [SerializeField]
    private float eggDropTime;
    private float eggDropTimeVariation;
    private float runningTime;

    [SerializeField]
    private GameObject egg;

    private int health = 1;

    void Update () {

        if (transform.position.x > 2.5f)
            side = -1;
        else if (transform.position.x < -2.5f)
            side = 1;

        transform.Translate (speed * side * Time.deltaTime, 0, 0);

        runningTime += Time.deltaTime;

        if (runningTime >= eggDropTime + eggDropTimeVariation) {

            Instantiate (egg, transform.position, Quaternion.identity);
            eggDropTimeVariation = Random.Range (-0.5f, 1f);
            runningTime = 0;
        }
    }

    public void Damage () {

        health -= 1;
        if (health <= 0) {

            Destroy (gameObject);
        }
    }
}