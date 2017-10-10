using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  RPS gameplay
///  - input R P or S to play
///  - the AI will select the action
///  - we log the result
/// </summary>
/// 
public enum Action
{
    NONE = 0,
    ROCK = 1,
    PAPER = 2,
    SCISSOR = 3
}
public class RockPaperScissor : MonoBehaviour {

    // STATS

    int nGames = 0;
    int nWon = 0;
    int nLost = 0;
    int nDraw = 0;


    public int maxGames;

	

	void Start () {

        // player1 = gameObject.AddComponent<AIRandom>();
        // player2 = gameObject.AddComponent<AIRandom>();
    }

    public AIPlayer player1;
    public AIPlayer player2;



    void Update()
    {
        Action chosenAction = Action.NONE;
        
        
        //if (GetInput(out chosenAction))
        if (nGames < maxGames)
        {

            chosenAction = player1.GetAction();
            // You choose
            Debug.Log("You choose: " + chosenAction);

            // AI chooses

            Action aiAction = player2.GetAction();

            // Check who wins
            int dif = ((int)chosenAction - (int)aiAction);
            if (dif == 1 || dif == -2)
            {
                Debug.Log("YOU WIN!");
                nWon++;
                
            }
            else if (dif == 2 || dif == -1)
            {
                Debug.Log("YOU LOSE!");
                nLost++;
                
            }
            else 
            {
                Debug.Log("DRAW");
                nDraw++;
                
            }
            nGames++;

            float myWinRate = nWon * 100 / (float)nGames;
            float aiWinRate = nLost * 100 / (float)nGames;
            Debug.Log("My winrate:" + myWinRate.ToString("0.00") + " % "
                + "   AI winrate: " + aiWinRate.ToString("0.00") + " % "
                + "\n nGames: " + nGames + " nWon: " + nWon + "nLost: " + nLost + "nDraw: " + nDraw);


        }
        
    }

    bool GetInput(out Action chosenAction)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            chosenAction = Action.ROCK;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            chosenAction = Action.PAPER;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            chosenAction = Action.SCISSOR;
            return true;
        }
        chosenAction = Action.NONE;
        return false;
    }

    Action GetAiAction()
    {

        return (Action)Random.Range(1, 4);
    }
	
}
