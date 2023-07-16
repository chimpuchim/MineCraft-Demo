using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<GameObject> poolObjs;
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

    public virtual void DeSpawn(GameObject obj)
    {
        poolObjs.Add(obj);
        obj.SetActive(false);
    }

    public virtual GameObject Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = GetPrefabByName(prefabName).gameObject;
        if(prefab == null)
        {
            return null;
        }

        GameObject newPrefab = GetObjectFromPool(prefab);
        newPrefab.transform.SetPositionAndRotation(position, rotation);
        newPrefab.transform.SetParent(holder.transform);
        newPrefab.SetActive(true);
        
        return newPrefab;
    }

    protected virtual GameObject GetObjectFromPool(GameObject prefab)
    {
        foreach(GameObject poolObject in this.poolObjs)
        {
            if(poolObject.name == prefab.name)
            {
                this.poolObjs.Remove(poolObject);
                return poolObject;
            }
        }

        GameObject newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;

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
