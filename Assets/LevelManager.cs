using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CameraScript cs;
    // odleg�o�� spawnowania w pionie i poziomie od �rodka gry
    float verticalDistance, horizontalDistance;
    //licznik do nast�pnego spawnu
    float spawnTimer = 0;
    //co ile ma nast�powa� spawn
    public float spawnInterval = 5;
    //prefab kamulca
    public GameObject asteroidPrefab;


    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<CameraScript>();
;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnInterval)
        {
            //spawnujemy kamie�
            Vector3 spawnPosition = getRandomSpawnPosition();
            //Debug.Log("Spawnuje kamulec na wsp�rz�dnych: " + spawnPosition.ToString());
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            //resetujemy timer
            spawnTimer = 0;
        }
    }
    Vector3 getRandomSpawnPosition()
    {
        //policz odleg�o�� spawnowania
        verticalDistance = 0.55f * cs.gameHeight;
        horizontalDistance = 0.55f * cs.gameWidth;
        //losowanie liczby cakowitej <1;4>
        int randomSpawnLine = Random.Range(1, 5);
        Vector3 randomSpawnLocation = Vector3.zero;
        switch (randomSpawnLine)
        {
            case 1:
                //g�rna linia
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                verticalDistance);
                break;
            case 2:
                //prawa linia
                randomSpawnLocation = new Vector3(horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
            case 3:
                //dolna linia
                randomSpawnLocation = new Vector3(Random.Range(-horizontalDistance, horizontalDistance),
                                                                0,
                                                                -verticalDistance);
                break;
            case 4:
                //lewa linia
                randomSpawnLocation = new Vector3(-horizontalDistance,
                                                  0,
                                                  Random.Range(-verticalDistance, verticalDistance));
                break;
        }
        return randomSpawnLocation;
    }
}
