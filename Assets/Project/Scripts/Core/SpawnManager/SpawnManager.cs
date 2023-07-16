using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] public Transform holder;

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        HidePrefabs();
    }

    protected virtual void LoadHolder()
    {
        if(holder != null) return;

        Transform holderObj = transform.Find("Holder");
        holder = holderObj;
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform obj in this.prefabs)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public virtual GameObject Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = GetPrefabByName(prefabName).gameObject;
        if(prefab == null)
        {
            return null;
        }

        GameObject newPrefab = Instantiate(prefab);
        newPrefab.transform.SetPositionAndRotation(position, rotation);
        newPrefab.transform.SetParent(holder.transform);
        newPrefab.SetActive(true);
        
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in prefabs)
        {
            if(prefab.name == prefabName)
            {
                return prefab;
            }
        }

        return null;
    }
}
