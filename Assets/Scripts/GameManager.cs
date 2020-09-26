using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [Header("UI")]
    public GameObject nextScenePan;
    public GameObject gameOverPan;
    public GameObject eventSystem;
    public List<GameObject> inputs;

    [Space]
    [Header("Altele")]
    public string nextLevel = "";

    // Start is called before the first frame update
    void Awake()
    {
        manager = this;
        gameOverPan.SetActive(false);


        foreach (GameObject input in inputs)
        {
            input.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        FindObjectOfType<Personaj>().over = true;
        gameOverPan.SetActive(true);
        eventSystem.SetActive(true);

        foreach (GameObject input in inputs)
        {
            input.SetActive(false);
        }
    }

    public void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }


    public void NextLevel()
    {
        nextScenePan.SetActive(true);
        eventSystem.SetActive(true);

        foreach (GameObject input in inputs)
        {
            input.SetActive(false);
        }
    }

    public void NextScene()
    {
        Personaj p = FindObjectOfType<Personaj>();

        if (p.over)
            return;

        if (nextLevel.Trim() != "")
        {
            Application.LoadLevel(nextLevel);
        }
        else
        {
            string sceneName = Application.loadedLevelName;
            int sceneNumber = int.Parse(sceneName.ToCharArray()[sceneName.Length - 1].ToString()) + 1;
            string levelName = "Level" + sceneNumber.ToString();
            p.salveaza_scor();
            Application.LoadLevel(levelName);
        }
    }

}
