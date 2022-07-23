
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _distance;
   [SerializeField] private Transform player;
    private Vector3 _pos;

    private void Start()
    {
        _pos = transform.position;
        _distance = -_pos.z + player.position.z;
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(_pos.x, _pos.y, player.position.z - _distance);

    }
}
