using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class map_Transition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] private Direction direction;

    [SerializeField] private float transitionDistance = 2f; // Distance to move the player during transition

    enum Direction { Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner2D>();
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += transitionDistance; // Adjust as needed
                break;
            case Direction.Down:
                newPos.y -= transitionDistance; // Adjust as needed
                break;
            case Direction.Left:
                newPos.x -= transitionDistance; // Adjust as needed
                break;
            case Direction.Right:
                newPos.x += transitionDistance; // Adjust as needed
                break;
        }

        player.transform.position = newPos;
    }
}
