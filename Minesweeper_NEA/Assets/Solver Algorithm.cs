using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int[,] MineMatrix;
    public bool[,] ClearMatrix;
    bool[,] CheckMatrix;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Creating SeenMatrix[,] and refining
        int[,] SeenMatrix = MineMatrix;

        for (int i = 0; i < 21; i++){for (int j = 0; j < 8; j++)
            {
                if (!ClearMatrix[i, j]) { SeenMatrix[i, j] = -1; } // This matrix is what the player can see

                CheckMatrix[i, j] = false;

                //Making a matrix showing only the useful tiles
                if (SeenMatrix[i, j] >= 1 && SeenMatrix[i, j] <= 8) 
                {
                    for (int x = -1; x < 1; i++){
                        for (int y = -1; y < 1; i++){
                            try{if(SeenMatrix[i + x, j + y] == -1){CheckMatrix[i, j] = true;}}
                            catch{}}}}}}

        // 
        for (int i = 0; i < 21; i++) { for (int j = 0; j < 8; j++)
            {
                


            }}
    }
}