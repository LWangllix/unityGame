using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class move : MonoBehaviour
{

    private Rigidbody2D playerBody;
    public TMP_Text score;
    public TMP_Text high;
    public GameObject rightSide;
    public GameObject leftSide;
    public GameObject ground;
    private int maxScore = 0;

    private GameObject platform;
    private GameObject platform1;
    private GameObject platform2;



    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            new GameObject("platfrom" + i, typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(PlatformEffector2D), typeof(platformScript));

        }
        platform = GameObject.Find("platform");
        platform1 = GameObject.Find("platfrom0");
        platform2 = GameObject.Find("platfrom1");


        platform1.transform.position = new Vector2(-0.5f, 3f);
        platform1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        platform1.GetComponent<BoxCollider2D>().usedByEffector = true;
        platform1.GetComponent<BoxCollider2D>().size = new Vector2(1.86f, 0.49f);
        platform1.GetComponent<PlatformEffector2D>().useColliderMask = true;
        platform1.GetComponent<SpriteRenderer>().sprite = platform.GetComponent<SpriteRenderer>().sprite;


        platform2.transform.position = new Vector2(1f, 5f);
        platform2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        platform2.GetComponent<BoxCollider2D>().usedByEffector = true;
        platform2.GetComponent<BoxCollider2D>().size = new Vector2(1.86f, 0.49f);
        platform2.GetComponent<PlatformEffector2D>().useColliderMask = true;
        platform2.GetComponent<SpriteRenderer>().sprite = platform.GetComponent<SpriteRenderer>().sprite;




    }


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        score = GameObject.Find("score").GetComponent<TMP_Text>();
        high = GameObject.Find("high").GetComponent<TMP_Text>();
        rightSide = GameObject.Find("rightSide");
        leftSide = GameObject.Find("leftSide");
        ground = GameObject.Find("Ground");
        high.SetText("High score: {0}", PlayerPrefs.GetInt("high"));
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBody.position.y > maxScore)
        {
            maxScore = (int)playerBody.position.y;
            if (score != null)
                score.SetText("Score {0}", maxScore);

            ground.transform.position = new Vector2(ground.transform.position.x, playerBody.position.y - 2.5f);
            PlayerPrefs.SetInt("score", maxScore);
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("high"))
            {
                PlayerPrefs.SetInt("high", PlayerPrefs.GetInt("score"));
                high.SetText("High score: {0}", PlayerPrefs.GetInt("high"));

            }


        }


    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") <= 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }


        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * 10f, playerBody.velocity.y);
        leftSide.transform.position = new Vector2(leftSide.transform.position.x, playerBody.position.y);
        rightSide.transform.position = new Vector2(leftSide.transform.position.x, playerBody.position.y);

    }
}
