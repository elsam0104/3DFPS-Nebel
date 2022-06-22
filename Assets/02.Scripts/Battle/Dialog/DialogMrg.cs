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
        SetDialog("이런... 여긴 어디지");
    }
    private void Update()
    {
        NextDialog("일단 움직이자");
        
    }
    public void NextDialog(string s)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDialog(s);
        }
    }
    public void SetDialog(string s)
    {
        dialogText.text = "";
        dialogText.DOText("- " + s, s.Length * 0.3f);
    }
}
