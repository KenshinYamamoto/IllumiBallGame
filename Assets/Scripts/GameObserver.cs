using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameObserver : MonoBehaviour
{
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;
    bool isClear;
    int timer = 0;
    int minutes = 0;

    [SerializeField] GameObject gameClearText;
    [SerializeField] Text timeText;

    private void Start()
    {
        gameClearText.SetActive(false);
        timeText.text = minutes.ToString("D2") + ":" + timer.ToString("D2");
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (isClear)
        {
            return;
        }

        if (holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            GameClear();
        }
    }

    void GameClear()
    {
        gameClearText.SetActive(true);
        isClear = true;
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator Timer()
    {
        while (!isClear)
        {
            yield return new WaitForSeconds(1f);
            timer++;
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        if (timer == 60)
        {
            minutes++;
            timer = 0;
        }
        timeText.text = minutes.ToString("D2")  + ":" + timer.ToString("D2");
    }

    /*private void OnGUI()
    {
        GUI.matrix = Matrix4x4.Scale(Vector3.one * 2);
        if(holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        {
            GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
        }
    }*/
}
