using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{

    enum Menu { Default, HowTo };

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

    void SwitchMode()
    {
        if (currentState == Menu.Default)
        {
            currentState = Menu.HowTo;
        }
        else if (currentState == Menu.HowTo) {
            currentState = Menu.Default;
        }
    }
}
