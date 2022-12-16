using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforming : MonoBehaviour
{
    private const float Player_Dist_Level = 200f;
    [SerializeField] private Transform Level_Part_Start;
    [SerializeField] private List<Transform> LevelParts;
    [SerializeField] private Player player;
    
    private Vector3 lastEndPosition;
    // Start is called before the first frame update
    void Awake()
    {
        lastEndPosition = Level_Part_Start.Find("EndPosition").position;

        int StartingLevelParts = 5;
        for(int i =0;i<StartingLevelParts;i++)
        {
            SpawnLevel();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < Player_Dist_Level)
        {
            SpawnLevel();
        }
    }
    private void SpawnLevel()
    {
        Transform chosenLevel = LevelParts[Random.Range(0, LevelParts.Count)];
        Transform lastLevel = SpawnLevel( chosenLevel , lastEndPosition);
        lastEndPosition = lastLevel.Find("EndPosition").position;
    }
    private Transform SpawnLevel(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
