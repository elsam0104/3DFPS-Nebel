using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameMgr : MonoBehaviour
{
    public TMP_Text scoreText;
    private int totalScore = 0;

    public GameObject monster;
    public float creatTime = 1f;

    public List<Transform> points = new List<Transform>();
    public List<GameObject> monsterPool = new List<GameObject>();

    public int maxMonster = 10;
    private bool isGameOver;
    public bool IsGameOver
    {
        get => isGameOver;
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                CancelInvoke("CreatMonster");
            }
        }
    }

    private static GameMgr instance;
    public static GameMgr GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameMgr>();
            if (instance == null)
            {
                GameObject container = new GameObject("GameMgr");
                instance = container.AddComponent<GameMgr>();
            }
        }
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        DisplayScore(0);
        CreatMonsterPool();
        Transform spawnPointGroup = GameObject.Find("SpawnPointGrop")?.transform;
        //같은 역할
        //spawnPointGroup?.GetComponentsInChildren<Transform>(points);
        //Transform[] pointArry = spawnPointGroup.GetComponentsInChildren<Transform>(true);
        foreach (Transform item in spawnPointGroup)
        {
            points.Add(item);
        }
        InvokeRepeating("CreatMonster", 2f, creatTime);
    }

    void CreatMonster()
    {
        int idx = Random.Range(0, points.Count);
        //Instantiate(monster, points[idx].position, points[idx].rotation);

        GameObject _monster = GetMonsterInPool();
        _monster?.transform.SetPositionAndRotation(points[idx].position, points[idx].rotation);
        _monster.SetActive(true);
    }
    void CreatMonsterPool()
    {
        for (int i = 0; i < maxMonster; i++)
        {
            var _monster = Instantiate<GameObject>(monster);
            _monster.name = $"Monster_{i:00}";
            _monster.SetActive(false);
            monsterPool.Add(_monster);
        }
    }

    public GameObject GetMonsterInPool()
    {
        foreach (var _monster in monsterPool)
        {
            if (_monster.activeSelf == false)
                return _monster;
        }
        return null;
    }
    public void DisplayScore(int score)
    {
        totalScore += score;
        scoreText.text = $"<color=#00ff00>Score :</color> <color=#92F9FF>{totalScore:#,##0} </color>";
    }
}
