using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DialogMrg : MonoBehaviour
{
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private GameObject ojb;
    public void Start()
    {
        SetDialog("이런... 여긴 어디지");
    }
    private void Update()
    {
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
            ojb.SetActive(false);
            dialogText.gameObject.SetActive(false);
        }
    }
    public void SetDialog(string s)
    {
        dialogText.gameObject.SetActive(true);
        ojb.SetActive(true);
        dialogText.text = "";
        dialogText.DOText("- " + s, s.Length * 0.3f);

    }
}
