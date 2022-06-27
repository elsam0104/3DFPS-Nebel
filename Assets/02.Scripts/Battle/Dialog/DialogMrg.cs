using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DialogMrg : MonoBehaviour
{
    [SerializeField]
    private Text dialogText;
    public void Start()
    {
        SetDialog("�̷�... ���� �����");
        NextDialog("�ϴ� ��������");
        EndDialog();
    }
    public void NextDialog(string s)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDialog(s);
        }
    }
    public void EndDialog()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogText.gameObject.SetActive(false);
        }
    }
    public void SetDialog(string s)
    {
        dialogText.text = "";
        dialogText.DOText("- " + s, s.Length * 0.3f);
    }
}
