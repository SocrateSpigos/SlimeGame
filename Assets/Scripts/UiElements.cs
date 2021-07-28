using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiElements : MonoBehaviour
{
    public Transform WinScreen;
    public Transform LoseScreen;
    public Text RedGoal;
    public Text GreenGoal;
    public Text BlueGoal;
    public int Nextpoints;
    public Text Points;
    public Transform GoalParent;
    public Transform GoalText;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Nextpoints < Crossroad.score)
        { Nextpoints += 1; }
           
        Points.text = Nextpoints.ToString();

        RedGoal.text = Crossroad.goal.goal[0].ToString();
        GreenGoal.text = Crossroad.goal.goal[1].ToString();
        BlueGoal.text = Crossroad.goal.goal[2].ToString();

        if (Crossroad.goal.goal[0] ==0)
        {
            RedGoal.GetComponent<Text>().enabled = false;
            RedGoal.GetComponentInChildren<Image>().enabled = true;

        }

        if (Crossroad.goal.goal[1] == 0)
        {
            GreenGoal.GetComponent<Text>().enabled = false;
            GreenGoal.GetComponentInChildren<Image>().enabled = true;

        }
        if (Crossroad.goal.goal[2] == 0)
        {
            BlueGoal.GetComponent<Text>().enabled = false;
            BlueGoal.GetComponentInChildren<Image>().enabled = true;

        }


        if ( WinScreen.gameObject.active)
        {
            GoalText.gameObject.SetActive(false);
            GoalParent.gameObject.SetActive(false);
            Points.rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2 +200);
           
        }
    }

    public void Reset()
    {
        Crossroad.score = 0;

        if (Application.loadedLevel == Application.levelCount - 1)
        {
            Application.LoadLevel(Application.levelCount - Application.loadedLevel - 1);

        }
        else
        {
            Application.LoadLevel(Application.loadedLevel + 1);

        }

    }

}
