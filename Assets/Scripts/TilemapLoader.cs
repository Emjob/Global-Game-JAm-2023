using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapLoader : MonoBehaviour
{
    public int Xnum;
    public int Ynum;
    private float GriddyX;
    private float GriddyY;
    private float Xpos = 1;
    private float Ypos = 1;
    [SerializeField] private GameObject earthtile;
    public GameObject Origin;
    private float SPX;
    private float SPY;
    

    
    void Start()
    {
        SPX = Origin.transform.position.x;
        SPY = Origin.transform.position.y;
        for(int i = 0; i < Xnum; i++)
        {
            GriddyX = SPX + (Xpos * i);
            Instantiate(earthtile, new Vector2(GriddyX,0), Quaternion.identity);
            for(int j = 0; j < Ynum; j++)
            {
                GriddyY = SPY + (Ypos * -j);
                Instantiate(earthtile, new Vector2(GriddyX,GriddyY), Quaternion.identity);
            
            }
        }
    }
}
