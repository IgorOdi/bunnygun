using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public GameObject canvas;
    public Text points;

    public static int Points = 0;

    public void ShowGameOver () {

        canvas.SetActive (true);
        points.text = Points.ToString ();
        Points = 0;
        Time.timeScale = 0;
    }

    public void TryAgain () {

        Time.timeScale = 1;
        SceneManager.LoadScene ("Prototype");
    }
}