using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCode : MonoBehaviour
{

    public GameObject tile;
    public int CursorHeight, CursorWidth;
    public int[,] MineMatrix;
    public bool[,] ClearMatrix;
    public int numMines;
    public int remainingMines;
    public bool won;
    public bool lost;



    // Start is called before the first frame update
    void Start()
    {
        CursorHeight = 7; // Setting the cursor to start position
        numMines = 20;
        remainingMines = 0;

        //------------------------SETTING TILE MATRIX------------------------//
        MineMatrix = new int[21, 8];
        ClearMatrix = new bool[21, 8];
        numMines = 20;
        won = false;
        lost = false;


            //=========    Setting Random Minefield
        int n = 0;
        while (n < numMines)
        {   int RandX = Mathf.RoundToInt(Random.Range(0f, 20f));
            int RandY = Mathf.RoundToInt(Random.Range(0f, 7f));
            if (MineMatrix[RandX, RandY] != 9)
            {
                MineMatrix[RandX, RandY] = 9;
                n++;
            }
        }
            //==========


            //==========    Setting Minefield Matrix
        int tileNum;

        for (int i = 0; i < 21; i++) // i is horizontal
        {
            for (int j = 0; j < 8; j++) // j is vertical
            {
                if (MineMatrix[i, j] != 9)
                {
                    bool upcheck = true;
                    bool downcheck = true;
                    bool leftcheck = true;
                    bool rightcheck = true;
                    tileNum = 0;
                    if (j == 7) { upcheck = false; }
                    if (j == 0) { downcheck = false; }
                    if (i == 0) { leftcheck = false; }
                    if (i == 20) { rightcheck = false; }

                    if (upcheck & leftcheck) { if (MineMatrix[i - 1, j + 1] == 9) { tileNum++; } }
                    if (upcheck) { if (MineMatrix[i, j + 1] == 9) { tileNum++; } }
                    if (upcheck & rightcheck) { if (MineMatrix[i + 1, j + 1] == 9) { tileNum++; } }
                    if (rightcheck) { if (MineMatrix[i + 1, j] == 9) { tileNum++; } }
                    if (downcheck & rightcheck) { if (MineMatrix[i + 1, j - 1] == 9) { tileNum++; } }
                    if (downcheck) { if (MineMatrix[i, j - 1] == 9) { tileNum++; } }
                    if (downcheck & leftcheck) { if (MineMatrix[i - 1, j - 1] == 9) { tileNum++; } }
                    if (leftcheck) { if (MineMatrix[i - 1, j] == 9) { tileNum++; } }
                    MineMatrix[i, j] = tileNum;
                }
            }
        }
            //==========

        //-------------------------------------------------------------------//



        //---------------------------INSTANTIATING---------------------------//
        for (int i = 0; i < 21; i++)
        {

            for (int j = 0; j < 8; j++)
            {
                GameObject sprite = Instantiate(tile, new Vector3(i * 0.07F, j * 0.085F, 0), Quaternion.identity);
                sprite.name = "tile (" + i + ", " + j + ")";
                sprite.GetComponent<SpriteCode>().gamecode = this;
            }
        }
        //-------------------------------------------------------------------//
    }



    // Update is called once per frame
    void Update()
    {
        //---------------MOVEMENT-------------------//
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CursorHeight++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CursorWidth++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CursorHeight--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CursorWidth--;
        }

        if (CursorHeight > 7) { CursorHeight = 0; }
        if (CursorHeight < 0) { CursorHeight = 7; }

        if (CursorWidth > 20) { CursorWidth = 0; }
        if (CursorWidth < 0) { CursorWidth = 20; }
        //--------------------------------------------//


        //--------------VICTORY OR LOSS---------------//
        if (remainingMines == 168 - numMines)
        {
            won = true;
        }
        //--------------------------------------------//

        //-----------------RESTARTING-----------------//
        if (Input.GetKeyDown("6"))
        {
            SceneManager.LoadScene("Minesweeper");
        }
        //--------------------------------------------//
    }
}
