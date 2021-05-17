using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    SpriteRenderer sr;

    private Vector2 moveDirection;

    int Coins = 0;

    public TMP_Text Coin;
    


    void Start()
    {
        Coin.text = ($"Coins: {PlayerPrefs.GetInt("TotalCoins")}");
        Coins = PlayerPrefs.GetInt("TotalCoins");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ProcessInputs();
    }

   

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    { 
        moveDirection = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
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




