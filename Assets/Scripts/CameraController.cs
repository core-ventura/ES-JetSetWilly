using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("GameObject References")]
    public GameObject followed; 
    public GameObject room;

    [Header("Camera Settings")]
    public float scaleRotation = 3f;
    public float scaleHeight = 1f;
    public float scaleZoom = 0.1f;
    public float maxDistance = 10f;
    public float minDistance = 0.5f;
    public Vector3 relativePosition;

    private PlayerInput controls;

    private float _cameraHeight;
    private float _cameraRotation;
    private float _cameraZoom;
    private float _distance;
    private Bounds _bounds;

    void Awake()
    {
        _cameraHeight = 0f;
        _cameraRotation = 0f;
        _cameraZoom = 0f;

        controls = new PlayerInput();

        controls.Player.CameraVertical.performed += ctx => _cameraHeight = ctx.ReadValue<float>();
        controls.Player.CameraVertical.canceled += ctx => _cameraHeight = 0f;
        controls.Player.CameraHorizontal.performed += ctx => _cameraRotation = ctx.ReadValue<float>();
        controls.Player.CameraHorizontal.canceled += ctx => _cameraRotation = 0f;   
        controls.Player.CameraZoom.performed += ctx => _cameraZoom = ctx.ReadValue<float>();
        controls.Player.CameraZoom.canceled += ctx => _cameraZoom = 0f;     
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Start()
    {
        _distance = relativePosition.magnitude;

        if(followed)
        {
            transform.position = followed.transform.position + relativePosition;
            transform.LookAt(followed.transform.position);
        }
        if(room)
        {
            //_bounds = calculateBounds(room, deltaCameraPosition);
        }
    }

    void Update()
    {
        float newDistance = 0f;
        //Vector3 maxWithMin = new Vector3(0,0,0);
        //Vector3 minWithMax = new Vector3(0,0,0);
        
        transform.position += new Vector3(0f, scaleHeight * _cameraHeight, 0f);
        _distance += scaleZoom*_cameraZoom;
        _distance = Mathf.Clamp(_distance, minDistance, maxDistance);

        if(followed)
        {
            transform.RotateAround(followed.transform.position, new Vector3(0f,1f,0f), scaleRotation*_cameraRotation);
            newDistance = Vector3.Distance(followed.transform.position, transform.position);
            transform.position += transform.TransformDirection(new Vector3(0f,0f,1f)) * (newDistance - _distance);
            //maxWithMin = Vector3.Max(transform.position, _bounds.min);
            //minWithMax = Vector3.Min(maxWithMin, _bounds.max);
            //transform.position = minWithMax;
            transform.LookAt(followed.transform.position);
        }
    }
}
