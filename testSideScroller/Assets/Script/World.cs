using UnityEngine;

public class World : SceneController
{

    public Transform player;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        if (prevScene == "level_2")
        {
            player.position = new Vector3(11111f, -733f, -10f);
          //  Camera.main.transform.position = new Vector3(111f, -733f, -10f);
        }
    }

}