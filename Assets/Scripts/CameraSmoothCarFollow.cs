using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothCarFollow : MonoBehaviour
{
    [SerializeField] Transform CameraPlace;
    [SerializeField] Transform Car;

    [SerializeField] float Speed;
    private void Start()
    {
        // Cela déplace la position de la caméra de manière fluide vers la position de CameraPlace.
        CameraPlace = GameObject.FindGameObjectWithTag("CameraFollow").transform;
    }
    void Update()
    {
        //pour un mouvement doux et naturel. La variable Speed contrôle la vitesse du mouvement.  
        transform.position = Vector3.SmoothDamp(transform.position, CameraPlace.position, ref ccurrent, Speed * Time.deltaTime,50);
        // la caméra regarde toujours vers l'objet Car.
        transform.LookAt(Car);
    }
    //C'est une variable pour stocker la vitesse actuelle de déplacement de la caméra,
    //utilisée par Vector3.SmoothDamp. 
    Vector3 ccurrent;
}
