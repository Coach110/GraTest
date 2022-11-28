using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public int levelNumber;
    public Vector2 playerPosition;
    public PozycjaPostaci playerStorage;
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetSceneName;

    [SerializeField]
    private Transform _spawnPoint;

    public void Start()
    {
        if(_connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<DontDestroy>().transform.position = _spawnPoint.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(9));
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger){
            Debug.Log("kurwa");
            //playerStorage.initialValue = playerPosition;
            LevelConnection.ActiveConnection = _connection;
            StartCoroutine(LoadLevelbyName(_targetSceneName));
        }
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevelbyName(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
