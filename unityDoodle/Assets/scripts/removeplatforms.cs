using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class removeplatforms : MonoBehaviour
{

    public float test;
    public GameObject myplat;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            Instantiate(myplat, new Vector2(Random.Range(-1.5f, 1.5f), other.gameObject.transform.position.y + (12 + Random.Range(3f, 4f))), Quaternion.identity);
        }
        else
            SceneManager.LoadScene("GameOver");
    }
}
