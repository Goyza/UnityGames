using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else {
            Debug.Log("Couldn't find GameController script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log (other.gameObject.name);
        //if (other.tag == "Boundary") return;
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion!= null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddNewScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
