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
        dialogMrg.SetDialog("...���� �׸� �Ͼ�� ��.");
    }
    private void OnCollisionEnter(Collision collision)
    {   
        dialogMrg.SetDialog("�Ͼ��.");
        dialogMrg.NextDialog("�Ȱ����� �����.");
        SceneManager.LoadScene("Ending");
    }
}
