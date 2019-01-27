using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{

    enum Menu { Default, HowTo };

    public string sceneName;

    public GameObject[] menus = new GameObject[2];

    [SerializeField]
    Menu currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == Menu.Default)
        {
            menus[0].SetActive(true);
            menus[1].SetActive(false);
        }
        else if (currentState == Menu.HowTo) {
            menus[0].SetActive(false);
            menus[1].SetActive(true);
        }
    }

    public void SwitchMode()
    {
        if (currentState == Menu.Default)
        {
            currentState = Menu.HowTo;
        }
        else if (currentState == Menu.HowTo) {
            currentState = Menu.Default;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(sceneName);
    }

    public void EndGame() {
        if (!Application.isEditor) {
            Application.Quit();
        }
    }
}
