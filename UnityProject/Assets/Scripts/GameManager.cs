using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject prefab;
    public GameObject playArea;

    public float spawnDelayS = 5;
    public readonly float spawnHeight = 10;

    private float nextSpawnTime;

    private List<GameObject> managedObjects;

    void Start()
    {
        nextSpawnTime = Time.time;   
        managedObjects = new List<GameObject>{};     
    }

    void Update()
    {
        if (ShouldSpawn()){
            Spawn();
        }
        DeleteFallenObjects();
    }

    private bool ShouldSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Spawn(){
        nextSpawnTime += spawnDelayS;
        
        Vector3 position = playArea.transform.position;
        position.x += Random.Range(-5,5);
        position.y += spawnHeight;
        position.z += Random.Range(-5,5);

        Quaternion rotation =  Random.rotationUniform;

        var newGameObject = Instantiate(prefab, position, rotation);
        var size = Random.Range(0.0f, 1.0f);
        newGameObject.GetComponent<Transform>().localScale = new Vector3(size, size, size);
        newGameObject.GetComponent<Rigidbody>().mass = size * 100;

        managedObjects.Add(newGameObject);
    }

    private void DeleteFallenObjects(){
        for(int i = managedObjects.Count - 1; i >= 0; i--){
            var obj = managedObjects[i];
            if(obj.transform.position.y < -10){
                managedObjects.RemoveAt(i);
                Destroy(obj, 3);
            }
        }
    }

}
