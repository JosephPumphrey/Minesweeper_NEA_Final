using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCode : MonoBehaviour
{
    public GameCode gamecode;
    public int CursorHeight;
    public int CursorWidth;
    public int Height;
    public int Width;

    public int[,] MineMatrix;
    public bool[,] ClearMatrix;
    public int remainingMines;
    public bool won;
    public bool lost;

    bool selected = false;
    bool cursorhere = false;
    bool marked = false;
    bool scoreadded = false;

    // SPRITE IMPORTS
    public Sprite Cursor_Default;
    public Sprite Tile_Default;

    public Sprite Tile_0; public Sprite Cursor_0;
    public Sprite Tile_1; public Sprite Cursor_1;
    public Sprite Tile_2; public Sprite Cursor_2;
    public Sprite Tile_3; public Sprite Cursor_3;
    public Sprite Tile_4; public Sprite Cursor_4;
    public Sprite Tile_5; public Sprite Cursor_5;
    public Sprite Tile_6; public Sprite Cursor_6;
    public Sprite Tile_7; public Sprite Cursor_7;
    public Sprite Tile_8; public Sprite Cursor_8;

    public Sprite Cursor_Mark;
    public Sprite Tile_Mark;
    public Sprite Tile_Mine;
    public Sprite Tile_DeadMark;
    public Sprite Tile_DeadMine;
    public Sprite Win_Star;

    Sprite Cursor_My;
    Sprite Tile_My;


    // Start is called before the first frame update
    void Start()
    {
        Height = Mathf.RoundToInt((transform.position.y) / 0.085f);
        Width = Mathf.RoundToInt((transform.position.x) / 0.07f);
        MineMatrix = gamecode.MineMatrix;
        int MyTile = MineMatrix[Width, Height];
        if (MyTile == 0) { Tile_My = Tile_0; Cursor_My = Cursor_0; }
        if (MyTile == 1) { Tile_My = Tile_1; Cursor_My = Cursor_1; }
        if (MyTile == 2) { Tile_My = Tile_2; Cursor_My = Cursor_2; }
        if (MyTile == 3) { Tile_My = Tile_3; Cursor_My = Cursor_3; }
        if (MyTile == 4) { Tile_My = Tile_4; Cursor_My = Cursor_4; }
        if (MyTile == 5) { Tile_My = Tile_5; Cursor_My = Cursor_5; }
        if (MyTile == 6) { Tile_My = Tile_6; Cursor_My = Cursor_6; }
        if (MyTile == 7) { Tile_My = Tile_7; Cursor_My = Cursor_7; }
        if (MyTile == 8) { Tile_My = Tile_8; Cursor_My = Cursor_8; }
        if (MyTile == 9) { Tile_My = Tile_Mine; Cursor_My = Cursor_Default; }

        selected = false;
        cursorhere = false;
        marked = false;
    }

    // Update is called once per frame
    void Update()
    {
        CursorHeight = gamecode.CursorHeight;
        CursorWidth = gamecode.CursorWidth;
        MineMatrix = gamecode.MineMatrix;
        ClearMatrix = gamecode.ClearMatrix;
        won = gamecode.won;
        lost = gamecode.lost;


        if (Height == CursorHeight & Width == CursorWidth) { cursorhere = true; }
        else { cursorhere = false; }

        if (Input.GetKeyDown("1") & cursorhere & marked == false) {selected = true;}


        // Clears area of 0s
        if (!ClearMatrix[Width, Height] | MineMatrix[Width, Height] != 0)
        {
        }
        else
        {
            bool upcheck = true;
            bool downcheck = true;
            bool leftcheck = true;
            bool rightcheck = true;
            if (Height == 7) { upcheck = false; }
            if (Height == 0) { downcheck = false; }
            if (Width == 0) { leftcheck = false; }
            if (Width == 20) { rightcheck = false; }

            if (upcheck & leftcheck) { ClearMatrix[Width - 1, Height + 1] = true; }
            if (upcheck) { ClearMatrix[Width, Height + 1] = true; }
            if (upcheck & rightcheck) { ClearMatrix[Width + 1, Height + 1] = true; }
            if (rightcheck) { ClearMatrix[Width + 1, Height] = true; }
            if (downcheck & rightcheck) { ClearMatrix[Width + 1, Height - 1] = true; }
            if (downcheck) { ClearMatrix[Width, Height - 1] = true; }
            if (downcheck & leftcheck) { ClearMatrix[Width - 1, Height - 1] = true; }
            if (leftcheck) { ClearMatrix[Width - 1, Height] = true; }

        }
        //----------------


        // Cursor Movement
        if (cursorhere & selected == false & marked == false & !won & !lost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Cursor_Default;
        }
        else if (cursorhere & selected == false & marked & !won & !lost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Cursor_Mark;
        }
        else if (marked & !won & !lost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Tile_Mark;
        }
        else if (!marked & !won & !lost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Tile_Default;
        }

        //-----------------


        // Cursor Selection
        if (cursorhere & selected & !marked & !won & !lost)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Cursor_My;
        }
        else if (selected &  !marked)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Tile_My;
        }
        //-----------------


        // If Tile Value Is 0
        if (selected & MineMatrix[Width, Height] == 0) { ClearMatrix[Width, Height] = true; }
        if (ClearMatrix[Width, Height]) { selected = true; }
        // -----------------

        //Marking Tiles
        if (Input.GetKeyDown("2") & cursorhere & marked == false & selected == false) { marked = true; }
        else if (Input.GetKeyDown("2") & cursorhere & marked == true & selected == false) { marked = false; }
        //-------------------


        // Winning
        if (selected & !scoreadded & MineMatrix[Width, Height] != 9 & !lost)
        {
            gamecode.remainingMines++;
            scoreadded = true;
        }

        if (won & MineMatrix[Width, Height] != 9) { selected = true; }
        if (won & MineMatrix[Width, Height] == 9)
        {
            marked = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = Win_Star; }
        //-------------------

        // Losing
        if (selected & MineMatrix[Width, Height] == 9)
        {
            gamecode.lost = true;
        }
        if (lost)
        {
            if (MineMatrix[Width, Height] == 9)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Tile_Mine;
            }
            else if (marked)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Tile_DeadMark;
            }

            if (marked & MineMatrix[Width, Height] == 9)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Tile_DeadMine;
            }
        }
        //-------------------

    }//
}