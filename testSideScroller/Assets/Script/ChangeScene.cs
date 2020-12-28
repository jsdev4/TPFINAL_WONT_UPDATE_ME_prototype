using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string toScene;
    private SceneController sceneController;
   public GameObject cube;
    void Start()
    {
      
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(cube);
            sceneController.LoadScene(toScene);


            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5f, other.transform.position.z);
            cube.transform.position = other.transform.position;


        }
    }


}
