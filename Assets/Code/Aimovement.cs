using System.Collections;
using UnityEngine;

namespace Code
{
    public class Aimovement : MonoBehaviour
    {
        public static float movespeed = 1f;

        public Rigidbody2D rb;

        private readonly float countdownTimer = 1f;
        private float currentTime;
        private float up, down, left, right;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            currentTime = countdownTimer;

            #region dont look at this bitch

            left = GameObject.Find("WallLeft").transform.position.x;
            right = GameObject.Find("WallRight").transform.position.x;
            up = GameObject.Find("WallUp").transform.position.y;
            down = GameObject.Find("Floor").transform.position.y;

            #endregion
        }

        public void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= countdownTimer)
            {
                StartCoroutine(Move(new Vector3(Random.Range(left, right), Random.Range(down, up), 0)));
                currentTime = 0;
            }
        }

        public IEnumerator Move(Vector3 newpos)
        {
            var timeSinceStart = 0f;
            while (true)
            {
                timeSinceStart += Time.deltaTime;
                transform.transform.position = Vector3.Lerp(transform.position, newpos, timeSinceStart / 2 * movespeed);
                if (transform.position == newpos)
                    yield break;
                yield return null;
            }
        }
    }
}