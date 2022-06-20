using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private EndingSO endingSO;
    private float needKill = 10f;
    private void Start()
    {
        InvokeRepeating("CheckEndingProgress", 5f, 0f); 
    }
    private void CheckEndingProgress()
    {
        Debug.Log("CheckEndig");
        if (endingSO.killMonster >= needKill)
        {
            endingSO.endingProgress++;
            needKill *= 1.2f;
        }
    }
    private void EndingProgressOne()
    {

    }
    private void EndingProgressTwo()
    {

    }
    private void EndingProgressThree()
    {

    }
    private void EndingProgressFour()
    {

    }
    private void EndingProgressFinal()
    {

    }

}
