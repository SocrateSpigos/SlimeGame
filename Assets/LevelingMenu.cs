using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelingMenu : MonoBehaviour
{
    public Turret turret;
    public GameObject levelingMenu;
    public GameObject joy;
    //public SphereCollider m_vacuum;
    //public GameObject Vacuum;
   // public Slider m_SliderX, m_SliderY, m_SliderZ;


    void Start()
    {
       // m_vacuum = GetComponent<SphereCollider>();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        levelingMenu.SetActive(false);
       // joy.SetActive(true);
    }

    public void UpgradeVacuum()
    {
       // m_vacuum.size =  new Vector3 (m_SliderX , m_SliderY , m_SliderZ );
    }

    public void UpgradeTurretFireRate()
    {

        turret.fireRate += 1;
        Debug.Log(turret.fireRate);
        turret.range += 1;

        Debug.Log(turret.range);
    }

   
}

