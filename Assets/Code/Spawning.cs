
using UnityEngine;
using UnityEngine.Serialization;

public class Spawning : MonoBehaviour
{
    public float time;
    public int I; 

    [FormerlySerializedAs("EmanyPrefab")] public GameObject emanyPrefab;
    [FormerlySerializedAs("Bigboy")] public GameObject bigboyPrefab;


    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Spawnfish();
            time = Random.Range(0, 10);
            I += 1; 
        }

        else if (time < 0 && I > 1 )
        {
            Spawnbigboy();
            time = Random.Range(0, 10);
            I = 0;
        }
    }


    private void Spawnfish()
    {
        Instantiate(emanyPrefab);
        emanyPrefab.transform.position = new Vector2(Random.Range(-2000, 4000), Random.Range(540, -1200));
    }

    private void Spawnbigboy()
    {
        Instantiate(bigboyPrefab);
        emanyPrefab.transform.position = new Vector2(Random.Range(-2000, 4000), Random.Range(540, -1200));
    }
}
