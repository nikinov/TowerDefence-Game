using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int Material;
    int night;
    int PlayerHelth;
    public int ZombieStartWithHelth;
    int Zombies;
    int NumOfZombInNight;
    int EnLeft;

    GameObject Store;
    GameObject TurretStore;
    GameObject NotEnoughCash;
    GameObject PauseMenu;
    GameObject gamePanel;
    public GameObject TurretOpenButton;
    public GameObject TurretCloseButton;
    GameObject[] Enemy;
    public ZSpawner spawner;

    bool Day;

    private void Start()
    {
        Material = 30;
        Store = GameObject.FindGameObjectWithTag("Store");
        TurretStore = GameObject.FindGameObjectWithTag("TurretStore");
        NotEnoughCash = GameObject.FindGameObjectWithTag("NotEnoughCash");
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        NotEnoughCash.SetActive(false);
        PauseMenu.SetActive(false);
        TurretStore.SetActive(false);
        TurretCloseButton.SetActive(false);
        StartCoroutine(SetDay());
    }
    private void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject en in Enemy)
        {
            EnLeft = 0;
            EnLeft += 1;
        }
        Spawn2();
    }
    public void SetNight ()
    {
        ZombieStartWithHelth = night * 10;
    }
    public void addMat()
    {
        
    }
    public void PressOK ()
    {
        Time.timeScale = 1f;
        NotEnoughCash.SetActive(false);
    }
    public void OpenTurretMenu()
    {
        TurretStore.SetActive(true);
        TurretCloseButton.SetActive(true);
        TurretOpenButton.SetActive(false);
    }
    public void CloseTurretMenu ()
    {
        TurretStore.SetActive(false);
        TurretOpenButton.SetActive(true);
        TurretCloseButton.SetActive(false);
    }
    public void PauseGame ()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
    public void BuyTurret1()
    {
        if (Material - 10 >= 0)
        {
            Material -= 10;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTurret2()
    {
        if (Material - 20 >= 0)
        {
            Material -= 20;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTurret3()
    {
        if (Material - 50 >= 0)
        {
            Material -= 50;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTurret4()
    {
        if (Material - 100 >= 0)
        {
            Material -= 100;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTurret5()
    {
        if (Material - 200 >= 0)
        {
            Material -= 200;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTurret6()
    {
        if (Material - 500 >= 0)
        {
            Material -= 500;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyTrap()
    {
        if (Material - 50 >= 0)
        {
            Material -= 50;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void BuyBarrier()
    {
        if (Material - 10 >= 0)
        {
            Material -= 10;
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void Spawn2 ()
    {
        if (EnLeft == 0)
        {
            Day = true;
        }
    }
    IEnumerator SetDay()
    {
        Day = true;
        night = 1;
        yield return new WaitForSeconds(5);
        Day = false;
        spawner.Spawn();
        yield return new WaitForEndOfFrame();
        Day = false;
        yield return new WaitForSeconds((2^night + 1) * 10);
        if (Day)
        {
            StartCoroutine(SetDay());
        }
    }
}