using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawnProperties : ISpawnProperties
{
    public Vector3 SpawnPosition()
    {
        return new Vector3(0,0,0);
    }
}
