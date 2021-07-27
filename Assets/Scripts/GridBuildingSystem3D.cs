using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem3D : MonoBehaviour
{
    [SerializeField] private Transform testTransform;
    private GridXZ<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, new Vector3(200, 0, 200), (GridXZ<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    public class GridObject
    {

        private GridXZ<GridObject> grid;
        private int x;
        private int y;

        public GridObject(GridXZ<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            //placedObject = null;
        }

        public override string ToString()
        {
            return x + ", " + y;
        }
    }

   /* private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(testTransform, Mouse3D.GetMouseWorldPosition(), Quaternion.identity);
        }
    }*/
}

