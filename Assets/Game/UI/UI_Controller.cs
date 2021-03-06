﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extensions;

public class UI_Controller: MonoBehaviour
{
    //Stage Transistion
    [SerializeField]
    private float _transistionSpeed = 0.05f;

    //Stage and Score
    [SerializeField]
    private GameObject _stageGO;
    private int _currentStage = 1;

    //Text Objects
    [SerializeField]
    private Text _scoreTxt;
    [SerializeField]
    private Text _scoreMultiTxt;
    [SerializeField]
    private Text _stageValTxt;
    [SerializeField]
    private Text _stageTxt;
    [SerializeField]
    private Image _stagePlate;

    bool isFirstTime = true;

    // Use this for initialization
    void Start ()
    {        
        
    }
	
	// Update is called once per frame
	void OnGUI ()
    {
        if (isFirstTime)
        {
            DisplayStage(false);
            isFirstTime = false;
        }              
	}

    public void UpdateScore(int score, int scoreMultiplier)
    {
        _scoreTxt.text = score.ToString("D14");
        _scoreMultiTxt.text = scoreMultiplier.ToString();
    }

    public void NewGame()
    {
        _currentStage = 1;
    }

    public void DisplayStage(bool nextStage)
    {
        if (nextStage)
            _currentStage++;

        _stageValTxt.text = _currentStage.ToString();
        StartCoroutine(FadeINColourImage(_transistionSpeed, _stagePlate));
        StartCoroutine(FadeINColourText(_transistionSpeed, _stageTxt));
        StartCoroutine(FadeINColourText(_transistionSpeed, _stageValTxt));

        StartCoroutine(Wait(2));
    }

    private IEnumerator FadeINColourText(float t,Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while(i.color.a < 1)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeINColourImage(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while (i.color.a < 1)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    private IEnumerator FadeOUTColourText(float t,Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while (i.color.a > 0)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeOUTColourImage(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a);
        while (i.color.a >0)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }


    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);


        StartCoroutine(FadeOUTColourImage(_transistionSpeed, _stagePlate));
        StartCoroutine(FadeOUTColourText(_transistionSpeed, _stageTxt));
        StartCoroutine(FadeOUTColourText(_transistionSpeed, _stageValTxt));
    }
}
