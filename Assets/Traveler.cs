using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveler : MonoBehaviour
{

    public string LastSpawnPointName
    {
        get;
        set;
    } = "";
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        DestroySelfIfNotOrigin();
#endif
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoadAction;

        
    }
    private void DestroySelfIfNotOrigin()
    {
        if(SpawnPoint.Player != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoadAction(Scene scene, LoadSceneMode loadMode)
    {
        if (LastSpawnPointName != "")
        {
            SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                if (spawnPoint.name == LastSpawnPointName)
                {
                    transform.position = spawnPoint.transform.position;
                }
            }
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoadAction;
        Debug.Log("Oh the tragedy");
    }

}
