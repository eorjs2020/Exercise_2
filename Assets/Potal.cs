using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    [SerializeField]
    private string destinationSpawn = "";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("AA");
        Traveler traveler = collision.GetComponent<Traveler>();
        if(traveler != null)
        {
            traveler.LastSpawnPointName = destinationSpawn;
            SceneManager.LoadScene(gameObject.tag, LoadSceneMode.Single);
        }
    }
}
