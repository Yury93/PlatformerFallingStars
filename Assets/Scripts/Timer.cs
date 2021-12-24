using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private Text textTimer;
    [SerializeField] private float generalTimer;
    [SerializeField] private Text GeneralTimer;

    void Update()
    {
        timer -= Time.deltaTime;
        textTimer.text = "Time: " + Convert.ToInt32( timer).ToString();
        if(timer < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void TimeUpdate(float time)
    {
        timer = time;
    }
}
