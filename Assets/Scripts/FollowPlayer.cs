using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    public GameObject slingshot;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayers();
    }

    public void ChangeTarget()
    {
        slingshot = GameObject.Find("SlingshotCam");
        target = slingshot.transform;
    }

    void FollowPlayers()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    void SlingshotView()
    {
        Vector3 slingshotPos = slingshot.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, slingshotPos, ref velocity, smoothTime);
    }
}
