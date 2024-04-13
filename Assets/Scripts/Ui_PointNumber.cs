using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui_PointNumber : MonoBehaviour
{
    [SerializeField] TMP_Text Text;
    void Update()
    {
        Text.text = PointManager.Point.ToString();
    }
}
