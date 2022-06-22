using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 80.0f;

    private Animation playerAnim;
    //초기 hp
    private readonly float initHp = 100.0f;
    //현재 hp
    private float currentHp;
    public float CurrentHp { get { return currentHp; } set { currentHp = value; } }
    private Image hpBar;


    IEnumerator Start()
    {
        playerAnim = GetComponent<Animation>();
        currentHp = initHp;
        hpBar = GameObject.FindGameObjectWithTag("HPBAR").GetComponent<Image>();
        playerAnim.Play("Idle");

        rotationSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        rotationSpeed = 80.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        moveDir.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float fastMove = moveSpeed+5f;
            transform.Translate(moveDir * fastMove * Time.deltaTime);
        }
        else
        {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }

        transform.Rotate(Vector3.up * r * rotationSpeed * Time.deltaTime);

        PlayerAnimation(h, v);
    }

    void PlayerAnimation(float h, float v)
    {
        if (h <= -0.1f)
            playerAnim.CrossFade("RunL", 0.25f);
        else if (h >= 0.1f)
            playerAnim.CrossFade("RunR", 0.25f);
        else if (v <= -0.1f)
            playerAnim.CrossFade("RunB", 0.25f);
        else if (v >= 0.1f)
            playerAnim.CrossFade("RunF", 0.25f);
        else
            playerAnim.CrossFade("Idle", 0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PUNCH") && currentHp > 0f)
        {
            currentHp -= 10f;
            Debug.Log($"Player HP = {currentHp}");
            DisplayHP();
            if (currentHp <= 0.0f)
            {
                PlayerDie();
            }
            else if (currentHp <= 30f)
            {

            }
        }
    }

    private void BloodScreen()
    {

    }
    private void PlayerDie()
    {
        Debug.Log("YOU DIE");
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
        foreach (GameObject monster in monsters)
        {
            monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        }
        //game over
        GameMgr.GetInstance().IsGameOver = true;
    }
    private void DisplayHP()
    {
        hpBar.fillAmount = currentHp / initHp;
    }
}
