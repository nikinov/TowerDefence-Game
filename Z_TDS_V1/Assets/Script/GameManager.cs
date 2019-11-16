using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int Material;
    int night;
    int PlayerHelth;
    int ZombieStartWithHelth;
    int Zombies;

    GameObject Store;
    GameObject TurretStore;
    GameObject NotEnoughCash;
    GameObject PauseMenu;
    GameObject gamePanel;
    public GameObject TurretOpenButton;
    public GameObject TurretCloseButton;

    private BuildSystem buildSystem;
    [SerializeField] private GameObject wall;

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
        night = 1;
        TurretCloseButton.SetActive(false);

        buildSystem = GetComponent<BuildSystem>();
    }

    public void SetNight ()
    {
        ZombieStartWithHelth = night;
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
            buildSystem.Select(Instantiate(wall));
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
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            buildSystem.Select(Instantiate(wall,pos,Quaternion.identity));
        }
        else
        {
            Time.timeScale = 0f;
            NotEnoughCash.SetActive(true);
        }
    }
    public void Spawn ()
    {

    }
    IEnumerator SetDay()
    {
        Day = true;
        night += 1;
        yield return new WaitForSeconds(60);
        Day = false;
        Spawn();
    }
}