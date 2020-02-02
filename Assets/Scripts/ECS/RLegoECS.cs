using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class RLegoECS : MonoBehaviour
{
    public Lego lego;
    public float rspeed = 60f;

}

public class RLegoSystem : ComponentSystem
{
    struct Components
    {
        public Transform transform;
        public MeshRenderer renderer;

    }

    protected override void OnUpdate()
    {
        Entities.WithAll<RLegoECS, MeshRenderer>().ForEach((Entity entity, RLegoECS rLegoECS, Transform transform) =>
        {
            transform.Rotate(Vector3.up * rLegoECS.rspeed * Time.DeltaTime);
        });
    }
}