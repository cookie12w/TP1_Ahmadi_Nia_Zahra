using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject MainMenu_UiPanel;
    private void Start()
    {
        MainMenu_UiPanel = GameObject.FindGameObjectWithTag("GameOverPanel");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            if (PointManager.Point <= 5)
            {

                StartCoroutine(WinDelay());
            }
            else
            {
                StartCoroutine(LoseDelay());
            }

        }
    }

    IEnumerator WinDelay()
    {
        SceneManager.LoadSceneAsync("Scene_Final", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.UnloadSceneAsync("Scene_Final");
        MainMenu_UiPanel.transform.GetChild(0).gameObject.SetActive(true);
        //GameOver_UiPanel.transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator LoseDelay()
    {
        SceneManager.LoadSceneAsync("Jeu terminé", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.UnloadSceneAsync("Jeu terminé");
        MainMenu_UiPanel.transform.GetChild(0).gameObject.SetActive(true);
        //GameOver_UiPanel.transform.GetChild(0).gameObject.SetActive(false);
    }
}
