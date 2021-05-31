using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed;

    public Rigidbody2D rb;

    SpriteRenderer sr;

    private Vector2 moveDirection;

    int Coins = 0;

    public TMP_Text Coin;

    public GameObject go;

    float time = 0; 
 
    void Start()
    {
        Coin.text = ($"Coins: {PlayerPrefs.GetInt("TotalCoins")}");
        Coins = PlayerPrefs.GetInt("TotalCoins");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        moveSpeed = Kyanshouse.MainPlayer.movespeed;
        gameObject.GetComponent<SpriteRenderer>().sprite = Kyanshouse.MainPlayer._PlayerSprite;
    }


    void Update()
    {
        ProcessInputs();

        time -= Time.deltaTime;

        if(time < 0 )
        {
            Instantiate(go);
            go.transform.position = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
            time = (Random.Range(0,10)); 
        }




    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {

        var MoveUp = Input.GetAxisRaw("Vertical");
        var MoveLeft = Input.GetAxisRaw("Horizontal");
        moveDirection = new UnityEngine.Vector2(MoveLeft, MoveUp).normalized;

        if (MoveLeft > 0)
            sr.flipX = true;
        else if (MoveLeft < 0)
            sr.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) && MoveLeft < 0 )
            transform.position += new Vector3(-100, 0, 0);
        else if (Input.GetKeyDown(KeyCode.Space) && MoveUp > 0)
            transform.position += new Vector3(100, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && MoveLeft < 0)
            transform.position += new Vector3(0, -100, 0);
        else if (Input.GetKeyDown(KeyCode.Space) && MoveUp > 0)
            transform.position += new Vector3(0, 100, 0);

    }

   void Move()
    {
        rb.velocity = new UnityEngine.Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            Coins += 1;
            Coin.text = ($"Coins: {Coins}");
             Destroy(col.gameObject);
        }

        if (col.gameObject.tag == ("Plant"))
        {
            Coins += 1;
            Coin.text = ($"Coins: {Coins}");
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == ("Enemy"))
        {
            Coins -= 1;
            Coin.text = ($"Coins: {Coins}");
            Destroy(col.gameObject);
            PlayerPrefs.SetInt("Coin", Coins);
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Menu");
        }

    



    }
}




