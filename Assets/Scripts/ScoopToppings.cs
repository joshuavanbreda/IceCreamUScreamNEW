using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopToppings : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public PlayerMovement playerMovement;
    public Stack stack;
    public GameObject obiEmitter;
    public GameObject origChocSauce;

    public Transform iceCreamCarryPoint;
    public bool isEnd = false;

    private bool chocSpawn = false;

    public GameObject confetti;
    public GameObject confettiPoint;
    public GameObject gameManager1;

    //public Transform charcterAnimated;
    public Animator animChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SprinkleTrigger")
        {
            Debug.Log("Sprinkle Trigger");
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                stack.stackObjects[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            //GetComponent<Collider>().enabled = false;
        }

        if (other.tag == "ChocSprinkleTrigger")
        {
            Debug.Log("Choc Sprinkle Trigger");
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                stack.stackObjects[i].transform.GetChild(1).gameObject.SetActive(true);
                //stack.stackObjects[i].transform.GetChild(1).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
            }
            //GetComponent<Collider>().enabled = false;
        }

        if (other.tag == "SauceTrigger")
        {
            obiEmitter.SetActive(true);
            Debug.Log("Sauce Trigger");
            StartCoroutine(chocSauceWait());
            
            //GetComponent<Collider>().enabled = false;
        }

        //if (other.tag == "MellowTrigger")
        //{
        //    Debug.Log("Marshmellow Trigger");
        //    for (int i = 0; i < stack.stackObjects.Count; i++)
        //    {
        //        stack.stackObjects[i].transform.GetChild(3).gameObject.SetActive(true);
        //        stack.stackObjects[i].transform.GetChild(3).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
        //    }
        //    //GetComponent<Collider>().enabled = false;
        //}

        if (other.tag == "EndTrigger")
        {
            isEnd = true;
            playerMovement.initialized = false;
            //Camera.main.transform.position += new Vector3(0, 5f, 0);
            stack.player.transform.parent = iceCreamCarryPoint;
            stack.player.transform.localPosition = new Vector3(0,0,0);
            cameraFollow.camTarget.transform.parent = gameManager1.transform;
            Camera.main.transform.parent = gameManager1.transform;

            cameraFollow.offset += new Vector3(5f, 10f, -20f);

            // modify Main camera properties :
            Camera.main.nearClipPlane = 0.05f;
            Camera.main.farClipPlane = 1500f;
            // Confetti particle
            //confetti.SetActive(true);

            //Animator animator = charcterAnimated.gameObject.GetComponent<Animator>();
            //animator.runtimeAnimatorController = Resources.Load("Assets/Animations/Idle 2.controller") as RuntimeAnimatorController;

            animChar.SetBool("isWaiting", false);
        }

        IEnumerator chocSauceWait()
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < stack.stackObjects.Count - 1; i++)
            {
                obiEmitter.SetActive(true);
                stack.stackObjects[i].transform.GetChild(2).gameObject.SetActive(true);
                stack.stackObjects[i].transform.GetChild(2).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
                origChocSauce.SetActive(true);
            }
        }
    }
}
