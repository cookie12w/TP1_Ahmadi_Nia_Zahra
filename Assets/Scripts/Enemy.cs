using System.Collections;
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
        if (Vector3.Distance(Ball.position, EndPos.position) < 2)
        {
            _End = true;
            _Start = false;
        }

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
        Ball.position = StartPos.position;
        print("Reset");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Points"))
        {
            Time.timeScale = 0;
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        SceneManager.LoadScene("Jeu terminé", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(2);
        GameOver_UiMainMenu.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Jeu terminé");
        SceneManager.UnloadSceneAsync("Niveau_Jeu");
        SceneManager.LoadScene("Niveau_Jeu", LoadSceneMode.Additive);

    }
}
