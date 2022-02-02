using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public CameraFollow cameraFollow;

    public GameObject previousTile;
    public GameObject currentTile;

    public GameObject tilePrefab;
    public GameObject scoop1;
    public GameObject scoop2;
    public GameObject scoop3;
    public GameObject scoop4;
    public GameObject scoop5;
    public GameObject scoop6;
    public GameObject scoop7;
    public GameObject cherryTopping;

    public GameObject player;
    [Range(0,50)]
    public float stackFallDistance;

    private GameObject[] stackList;
    public List<GameObject> stackObjects = new List<GameObject>();

    public float camDistanceZ = 10;

    private GameObject currentScoopHit;
    private GameObject newCaughtScoop;

    // Start is called before the first frame update
    void Start()
    {
        //List<GameObject> stackObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scoop")
        {
            Debug.Log("yeseseses");
            other.gameObject.SetActive(false);

            if (currentTile == null)
            {
                if (other.name == "Scoop 1")
                {
                    currentTile = Instantiate(scoop1, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 2")
                {
                    currentTile = Instantiate(scoop2, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 3")
                {
                    currentTile = Instantiate(scoop3, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 4")
                {
                    currentTile = Instantiate(scoop4, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 5")
                {
                    currentTile = Instantiate(scoop5, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 6")
                {
                    currentTile = Instantiate(scoop6, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 7")
                {
                    currentTile = Instantiate(scoop7, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                //currentTile = Instantiate(tilePrefab, previousTile.transform.position + Vector3.up, previousTile.transform.rotation);
                stackObjects.Add(currentTile);
                currentTile.transform.parent = player.transform;
                cherryTopping.transform.position += new Vector3(0, 1.5f, 0);
            }
            else
            {
                previousTile = currentTile;

                if (other.name == "Scoop 1")
                {
                    currentTile = Instantiate(scoop1, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 2")
                {
                    currentTile = Instantiate(scoop2, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 3")
                {
                    currentTile = Instantiate(scoop3, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 4")
                {
                    currentTile = Instantiate(scoop4, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 5")
                {
                    currentTile = Instantiate(scoop5, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 6")
                {
                    currentTile = Instantiate(scoop6, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }
                if (other.name == "Scoop 7")
                {
                    currentTile = Instantiate(scoop7, previousTile.transform.position + new Vector3(0, 1.5f, 0), previousTile.transform.rotation);
                }

                //currentTile = Instantiate(tilePrefab, previousTile.transform.position + Vector3.up, previousTile.transform.rotation);
                stackObjects.Add(currentTile);
                currentTile.transform.parent = player.transform;

                //Camera.main.transform.position += new Vector3(0, 1.5f, 0);
                camDistanceZ += 1.5f;
                cameraFollow.offset -= new Vector3(0, 0, 1.5f);
                //Camera.main.transform.position -= new Vector3(0,0,5);
                cherryTopping.transform.position += new Vector3(0, 1.5f, 0);
                cameraFollow.camTarget.transform.position += new Vector3(0, 1.5f, 0);
            }
        }
    }

    public void GetObjects(GameObject cube,int startPoint)
    {
        cameraFollow.camTarget.transform.position -= new Vector3(0, 1.5f, 0);
        for (int i = startPoint; i < stackObjects.Count; i++)
        {
            float value = stackObjects[i].transform.localPosition.y - stackFallDistance;
            Vector3 newPosition = new Vector3(0, value, 0);

            //stackObjects[i].GetComponent<MeshRenderer>().material.color = Color.red;
            stackObjects[i].transform.localPosition = newPosition;
        }

        //Destroy(cube);
        //stackObjects.RemoveAt(startPoint);
        cameraFollow.offset += new Vector3(0, 0, 1.5f);
    }

}
