using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenManager : MonoBehaviour
{
    public GameObject FightUI;
    bool A;
    float timerBecauseACorutineDoesNotWorkHere;
    public int Levell;
    public GameManager gameManager;

    private void Awake()
    {
        FightUI.SetActive(false);
        timerBecauseACorutineDoesNotWorkHere = 0;
        A = false;
        GetPre();
    }
    private void Update()
    {
        if (A)
        {
            Go();
            FightUI.SetActive(true);
        }
    }
    public void Normal()
    {
        PlayerPrefs.SetInt("Level", 1);
        A = true;
    }
    public void Super()
    {
        PlayerPrefs.SetInt("Level", 2);
        A = true;
    }
    public void UltimateSuper()
    {
        PlayerPrefs.SetInt("Level", 3);
        A = true;
    }
    void Load()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void Load2()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    void Go()
    {
        if (timerBecauseACorutineDoesNotWorkHere < 2)
        {
            timerBecauseACorutineDoesNotWorkHere += 1 * Time.deltaTime;
        }
        if (timerBecauseACorutineDoesNotWorkHere >= 1)
        {
            Load();
        }
    }
    public void GetPre()
    {
        Levell = PlayerPrefs.GetInt("Level");
        gameManager.Lev = Levell;
    }
}
