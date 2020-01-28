using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = .707f;

    private int roadCount = 0;

    // Start is called before the first frame update
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, .5f); //Call the function
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CreateNewRoadPart();
        //}
    }

    public void CreateNewRoadPart() 
    {
        Debug.Log("Create new road part!");

        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);

        if(chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
            Debug.Log(spawnPos);
        }
        else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        Debug.Log(spawnPos);

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = g.transform.position;

        roadCount++;

        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true); //Set the childs position at 0 and set it to active
        }
    }
}
