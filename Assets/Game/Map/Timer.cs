using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject GameOverPanel;
    public float TimeRemaining;
    public bool IsOver;

	// Use this for initialization
	void Start () {
        IsOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsEnded())
        {
            End();
        }
        else
        {
            TimeRemaining -= Time.deltaTime;
            GetRemainingTime();
        }
	}

    public void GetRemainingTime()
    {
        string minutes = Mathf.Floor(TimeRemaining / 60).ToString("00");
        string seconds = (TimeRemaining % 60).ToString("00");
        GetComponent<Text>().text = string.Format("{0}:{1}", minutes, seconds);
    }

    public bool IsEnded()
    {
        if (TimeRemaining <= 0.0f)
        {
            IsOver = true;
            return true;
        }
        if( GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerStats>().IsDead())
        {
            return true;
        }

        return false;
    }

    public void End()
    {
        GameOverPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadSceneAsync("Game/Menu/Menu");
    }
}
