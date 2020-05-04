using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private float checkTime = 2;
    private float runningTime;

    [SerializeField]
    private GameObject enemyPrefab;

    void Update () {

        runningTime += Time.deltaTime;
        if (runningTime > checkTime) {

            runningTime = 0;
            SpawnEnemy ();
        }
    }

    void SpawnEnemy () {

        bool hasEnemyOnScreen = FindObjectOfType<EnemyController> () != null;

        if (!hasEnemyOnScreen) {

            Instantiate (enemyPrefab, new Vector2 (0, 4.15f), Quaternion.identity);
        } else {

            if (FindObjectsOfType<EnemyController> ().Length <= 1) {

                Vector3 newPosition = Vector3.zero;
                if (FindObjectOfType<EnemyController> ().transform.position.y > 4f) {

                    newPosition = new Vector2 (0, 2.75f);
                } else {

                    newPosition = new Vector2 (0, 4.15f);
                }

                Instantiate (enemyPrefab, newPosition, Quaternion.identity);
            }
        }
    }
}