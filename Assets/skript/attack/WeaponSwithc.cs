using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwithc : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bow.activeInHierarchy == true)
            {
                bow.SetActive(false);
                sword.SetActive (true);
            }
            else if (sword.activeInHierarchy == true){
                sword.SetActive(false);
                bow.SetActive (true);
            }
        }
    }
}
