using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlock : SpawnManager
{
    private Camera mainCamera;
    private string selectedBlockName;
    private int selectedBlockType;
    private float selectedBlockTimeBreak;
    private Transform selectedBlockHolder;
    private GameObject holderPlaceBlocks;


    protected override void Start()
    {
        holderPlaceBlocks = new GameObject("Holder");
        mainCamera = GameController.Instance.CameraMain.gameObject.GetComponent<Camera>();
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlaceBlocks();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectBlock(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectBlock(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectBlock(2);
        }
    }

    public override GameObject Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = GetPrefabByName(prefabName).gameObject;
        if(prefab == null)
        {
            return null;
        }

        GameObject newPrefab = Instantiate(prefab);
        newPrefab.transform.SetPositionAndRotation(position, rotation);
        newPrefab.transform.SetParent(holderPlaceBlocks.transform);
        newPrefab.SetActive(true);
        
        return newPrefab;
    }

    private void PlaceBlocks()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.tag == "Block")
            {
                Vector3 spawnPos = new Vector3(Mathf.RoundToInt(hit.point.x + hit.normal.x / 2), Mathf.RoundToInt(hit.point.y + hit.normal.y / 2),Mathf.RoundToInt(hit.point.z + hit.normal.z / 2));
                Block block = Spawn(selectedBlockName, spawnPos, Quaternion.identity).GetComponent<Block>();
                block.TimeBreakBlock = selectedBlockTimeBreak;
                block.Type = (BlockType)selectedBlockType;
            }
        }
    }

    private void SelectBlock(int blockIndex)
    {
        if(blockIndex == 0)
        {
            selectedBlockName = "Grass";
            selectedBlockTimeBreak = 1;
        }
        else if(blockIndex == 1)
        {
            selectedBlockName = "Dirt";
            selectedBlockTimeBreak = 2;
        }
        else if(blockIndex == 2)
        {
            selectedBlockName = "Stone";
            selectedBlockTimeBreak = 3;
        }

        selectedBlockType = blockIndex;
    }
}
