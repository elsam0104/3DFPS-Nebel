using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private EndingSO endingSO;
    private float needKill = 10f;
    [SerializeField]
    private GameObject endPoint;
    [SerializeField]
    private GameObject oneObj;
    [SerializeField]
    private GameObject twoObj;
    private void Start()
    {
        InvokeRepeating("CheckEndingProgress", 5f, 0f);
        switch (endingSO.endingProgress)
        {
            case 1:
                EndingProgressOne();
                break;
            case 2:
                EndingProgressTwo();
                break;
             case 3:
                EndingProgressFinal();
                break;
        }

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
        oneObj.SetActive(true);
    }
    private void EndingProgressTwo()
    {
        twoObj.SetActive(true);
    }
    private void EndingProgressFinal()
    {
        endPoint.SetActive(true);
    }

}
