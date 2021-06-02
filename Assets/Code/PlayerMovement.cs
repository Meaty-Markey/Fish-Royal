using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class PlayerMovement : MonoBehaviour
    {
        public static float moveSpeed;

        public Rigidbody2D rb;

        public TMP_Text Coin;

        public GameObject go;

        private int Coins;

        private Vector2 moveDirection;

        private SpriteRenderer sr;

        private float time;

        private void Start()
        {
            Coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            Coins = PlayerPrefs.GetInt("TotalCoins");
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            moveSpeed = Kyanshouse.MainPlayer.movespeed;
            gameObject.GetComponent<SpriteRenderer>().sprite = Kyanshouse.MainPlayer._PlayerSprite;
        }


        private void Update()
        {
            ProcessInputs();

            time -= Time.deltaTime;

            if (time < 0)
            {
                Instantiate(go);
                go.transform.position = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
                time = Random.Range(0, 10);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(200, 0, 0);
                    Debug.Log("This works");
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-200, 0, 0);
                    Debug.Log("This works");
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(0, 0, 200);
                    Debug.Log("This works");
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.position += new Vector3(0, 0, -200);
                    Debug.Log("This works");
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
                moveDirection = new Vector2(MoveLeft, MoveUp).normalized;

                if (MoveLeft > 0)
                    sr.flipX = true;
                else if (MoveLeft < 0)
                    sr.flipX = false;

                if (Input.GetKeyDown(KeyCode.Space) && MoveLeft < 0)
                    transform.position += new Vector3(-100, 0, 0);
                else if (Input.GetKeyDown(KeyCode.Space) && MoveUp > 0)
                    transform.position += new Vector3(100, 0, 0);

                if (Input.GetKeyDown(KeyCode.Space) && MoveLeft < 0)
                    transform.position += new Vector3(0, 0, -100);
                else if (Input.GetKeyDown(KeyCode.Space) && MoveUp > 0)
                    transform.position += new Vector3(0, 0, -100);
            }

            void Move()
            {
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                Coins += 1;
                Coin.text = $"Coins: {Coins}";
                Destroy(col.gameObject);
            }

            if (col.gameObject.tag == "Plant")
            {
                Coins += 1;
                Coin.text = $"Coins: {Coins}";
                Destroy(col.gameObject);
            }

            if (col.gameObject.tag == "Enemy")
            {
                Coins -= 1;
                Coin.text = $"Coins: {Coins}";
                Destroy(col.gameObject);
                PlayerPrefs.SetInt("Coin", Coins);
                SceneManager.LoadScene("Menu");
            }

            if (col.gameObject.tag == "Finish") SceneManager.LoadScene("Menu");
        }
    }
}