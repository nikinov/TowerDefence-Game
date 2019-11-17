using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int Material;
    int night;
    public int PlayerHelth;
    public int ZombieStartWithHelth;
    int Zombies;
    int EnLeft;

    GameObject Store;
    GameObject TurretStore;
    GameObject NotEnoughCash;
    GameObject PauseMenu;
    GameObject gamePanel;
    GameObject player;
    public GameObject TurretOpenButton;
    public GameObject TurretCloseButton;
    GameObject[] Enemy;
    public ZSpawner spawner;
    public GameObject Spawnerr;
    public GameObject Nightt;
    GameObject DethPanel;

    private BuildSystem buildSystem;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject turet1;

    public Text mat;

    public bool Day;

    private void Start()
    {
        PlayerHelth = 10;
        Material = 70;
        Store = GameObject.FindGameObjectWithTag("Store");
        TurretStore = GameObject.FindGameObjectWithTag("TurretStore");
        NotEnoughCash = GameObject.FindGameObjectWithTag("NotEnoughCash");
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        player = GameObject.FindGameObjectWithTag("Player");
        DethPanel = GameObject.FindGameObjectWithTag("DethPanel");

        NotEnoughCash.SetActive(false);
        PauseMenu.SetActive(false);
        TurretStore.SetActive(false);
        TurretCloseButton.SetActive(false);
		buildSystem = GetComponent<BuildSystem>();
        StartCoroutine(SetDay());
        DethPanel.SetActive(false);
    }

    private void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        EnLeft = 0;
        foreach (GameObject en in Enemy)
        {
            EnLeft += 1;
        }
        if (Day)
        {
            Nightt.SetActive(false);
        }
        if (!Day)
        {
            Nightt.SetActive(true);
            spawner.isSpawning = true;
        }
        SetNight();
        //mat = Material.ToString("");
    }
    public void SetNight ()
    {
        ZombieStartWithHelth = night * 10;
    }
    public void addMat()
    {
        if (night < 4)
        {
            Material += 2;
        }
        if (night < 10)
        {
            if (night >= 4)
            {
                Material += 5;
            }
        }
        if (night < 20)
        {
            if (night >= 10)
            {
                Material += 10;
            }
        }
    }
    public void  TakePlayerHelth ()
    {
        if (PlayerHelth > 0)
        {
            PlayerHelth -= 1;
        }
        if (PlayerHelth <= 0)
        {
            DethPanel.SetActive(true);
            Destroy(player);
            Time.timeScale = 0f;
        }
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
            buildSystem.Select(Instantiate(turet1));
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
            buildSystem.Select(Instantiate(trap));
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
        night += 1;
        spawner.enabled = false;
        yield return new WaitForSeconds(5);
        Day = false;
        SetNight();
        spawner.enabled = true;
        spawner.isSpawning = true;
        yield return new WaitForSeconds(night * 20);
        spawner.enabled = false;
        StartCoroutine(Check());
    }
    IEnumerator Check()
    {
        yield return new WaitForSeconds(.1f);
        if (!Day)
        {
            Spawn2();
            StartCoroutine(Check());
        }
        if (Day)
        {
            StartCoroutine(SetDay());
        }
    }
}