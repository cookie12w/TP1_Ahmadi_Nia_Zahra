using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Transform StartPosition;
    [SerializeField] Transform EndPosition;

    [SerializeField] Transform Car;
    private void Awake()
    {
        SceneManager.LoadScene("Niveau_Jeu", LoadSceneMode.Additive);
    }
    void Start()
    {
       // Car = GameObject.FindGameObjectWithTag("Player").transform;
       // StartPosition = GameObject.FindGameObjectWithTag("StartPosition").transform;
       // EndPosition = GameObject.FindGameObjectWithTag("EndPosition").transform;

        Time.timeScale = 0;
    }

    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
    public void Reset_Position_Of_Car()
    {
        Car = GameObject.FindGameObjectWithTag("Player").transform;
        StartPosition = GameObject.FindGameObjectWithTag("StartPosition").transform;
        EndPosition = GameObject.FindGameObjectWithTag("EndPosition").transform;

        Car.SetPositionAndRotation(StartPosition.position, StartPosition.rotation);
    }
    public void ResetNumberOfPoint()
    {
        PointManager.Point = 0;
    }
}
