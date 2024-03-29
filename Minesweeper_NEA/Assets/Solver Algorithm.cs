﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int[,] MineMatrix;
    public bool[,] ClearMatrix;
    public bool[,] CheckMatrix;

    // Link Arrays from 2 to 4

    public int[,][,] Link_1_2;
    public int[,][,][,] Link_1_3;
    public int[,][,][,] Link_2_3;
    public int[,][,][,][,] Link_1_4;
    public int[,][,][,][,] Link_2_4;
    public int[,][,][,][,] Link_3_4;

    // Start is called before the first frame update
    void Start()
    {
        // Resetting Link Arrays
        int[,][,] Link_1_2 = default(int[,][,]);
        int[,][,][,] Link_1_3 = default(int[,][,][,]);
        int[,][,][,] Link_2_3 = default(int[,][,][,]);
        int[,][,][,][,] Link_1_4 = default(int[,][,][,][,]);
        int[,][,][,][,] Link_2_4 = default(int[,][,][,][,]);
        int[,][,][,][,] Link_3_4 = default(int[,][,][,][,]);
    }

    // Update is called once per frame
    void Update()
    {
        // Creating SeenMatrix[,]
        int[,] SeenMatrix = MineMatrix;

        //Filling in SeenMatrix[], Defining aand filling CheckMatrix[]
        for (int i = 0; i < 21; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!ClearMatrix[i, j])
                {
                    SeenMatrix[i, j] = -1;
                } // This matrix is what the player can see

                CheckMatrix[i, j] = false;

                //Making a matrix showing only the tiles bordering a covered mine
                if (SeenMatrix[i, j] >= 1 && SeenMatrix[i, j] <= 8) 
                {
                    for (int x = -1; x < 1; x++){
                        for (int y = -1; y < 1; y++)
                        {
                            try
                            {
                                if (SeenMatrix[i + x, j + y] == -1)
                                {
                                    CheckMatrix[i, j] = true;
                                }
                            }
                            catch{}
                        }
                    }
                }
            }
        }

        /*   PLAN
        
         - Scan each number bordering a covered mine
         - Check if each covered mine is in the link arrays
         - In situations where a link is under causational dispute, simply calculate probabilities.
         - select one with the highest probability that is closest to the cursor.
         - If one depends on another outcome, where probability is affected again by another, leave it. A better, less risky angle will reveal itself
         - Select each one in ascending order of uncertain mines around it.
        */

        //Only allows the code counting up from 1
        for (int MineCount = 1; MineCount < 8; MineCount++)
        {





            // Scanning Iteration
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    //Finding all Mines Around it 
                    int NumAvailableMines = MineMatrix[i, j];
                    for (int x = -1; x < 1; x++)
                    {
                        for (int y = -1; y < 1; y++)
                        {
                            try
                            {
                                //Scans all surrounding mines for 100% Probability
                                //FILL IN LATER------------------------------------------------------//
                            }
                            catch { }
                        }
                    }
                    //New variable gets slotted into if statement

                    if (NumAvailableMines == MineCount)
                    {
                        if (CheckMatrix[i, j]) // Cycles through each tile bordering an uncovered mine
                        {


                            // Setting actual number of mines the program needs to consider
                            int NumUncertainMines = MineMatrix[i, j];



                            //Scanning all mines around it for being linked
                            for (int x = -1; x < 1; x++)
                            {
                                for (int y = -1; y < 1; y++)
                                {
                                    try
                                    {
                                        //Trying to find if mines around are linked

                                    }
                                    catch { }
                                }
                            }




                        }
                    }
                }
            }




        //Finishes Iteration
        }
    }
}