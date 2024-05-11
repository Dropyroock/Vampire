using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetInstance().gameObject;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var pos = player.transform.position;
        pos.z =-10;
        transform.position = pos;
    }
}
