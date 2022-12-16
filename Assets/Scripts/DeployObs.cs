using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObs : MonoBehaviour
{
    public GameObject ObsPrefab;
    public float respawnTime;
    public float EnergyTime;
    private Vector2 screenBounds;
    public GameObject EnergyPrfab;
    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(ObsWave());
        StartCoroutine(EnergyWave());
    }

    // Update is called once per frame
    private void spawnObs()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject O = Instantiate(ObsPrefab) as GameObject;
        O.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y+6);
    }


    private void Energyspawn()
    {
        GameObject E = Instantiate(EnergyPrfab) as GameObject;
        E.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 6);
    }
    

    IEnumerator ObsWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObs(); ;
        }    
    }
    IEnumerator EnergyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(EnergyTime);
            Energyspawn();
        }
    }
}
