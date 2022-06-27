using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndigLoad : MonoBehaviour
{
    [SerializeField]
    private DialogMrg dialogMrg;
    private void OnEnable()
    {
        dialogMrg.SetDialog("...이제 그만 일어나야 해.");
    }
    private void OnCollisionEnter(Collision collision)
    {   
        dialogMrg.SetDialog("일어나자.");
        dialogMrg.NextDialog("안개에서 벗어나서.");
        SceneManager.LoadScene("Ending");
    }
}
