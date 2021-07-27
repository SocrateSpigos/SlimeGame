/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid<bool> grid;

    public void Start()
    {
         grid = new Grid<bool>(4, 2, 10f, new Vector3(20, 0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          grid.SetValue(UtilsClass.GetMouseWorldPosition(),56);
        }

        if (input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
*/