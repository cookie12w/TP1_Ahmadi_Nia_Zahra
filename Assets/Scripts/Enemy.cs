using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform StartPos;
    [SerializeField] Transform EndPos;


    [SerializeField] float Speed;
    [SerializeField] float Lenght;

    [SerializeField] Transform Ball;

    bool _Start = true;
    bool _End;

    [SerializeField] GameObject GameOver_UiPanel;
    [SerializeField] GameObject GameOver_UiMainMenu;
    private void Start()
    {
        GameOver_UiPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        GameOver_UiMainMenu = GameObject.FindGameObjectWithTag("MainMenuPanel");
    }
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, Mathf.PingPong(Speed *Time.deltaTime *2, Lenght), transform.position.z);

        //if (Vector3.Distance(Ball.position, StartPos.position) < 1) // this method calculate distance between ball and strat position
        //{
        //    _End = true;
        //    _Start = false;
        //}
        //else
        //{
        if (Vector3.Distance(Ball.position, EndPos.position) < 2)
        {
            _End = true;
            _Start = false;
        }
        //}

        if (_Start == true)
        {
            ToStart();
        }
        if (_End == true)
        {
            Reset();
            _Start = true;
            _End = false;
        }
    }
    void ToStart()
    {
        Ball.position = Vector3.MoveTowards(Ball.position, EndPos.position, Speed * Time.deltaTime);
    }
    void Reset()
    {
        Ball.position = StartPos.position; /*Vector3.Lerp(Ball.position, EndPos.position, Speed * Time.deltaTime);*/
        print("Reset");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Time.timeScale = 0;
            // GameOver_UiPanel.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        //GameOver_UiPanel.transform.GetChild(0).gameObject.SetActive(false);

        SceneManager.LoadScene("Jeu terminé", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(2);
        GameOver_UiMainMenu.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Jeu terminé");
        SceneManager.UnloadSceneAsync("Niveau_Jeu");
        SceneManager.LoadScene("Niveau_Jeu", LoadSceneMode.Additive);

    }
}
