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


    protected override void Start()
    {
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

    private void PlaceBlocks()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = Mathf.Round(targetPosition.y);

            if (CanPlaceBlock(targetPosition))
            {
                GameObject blockObject = Spawn(selectedBlockName, new Vector3(targetPosition.x, targetPosition.y - 1f, targetPosition.z), Quaternion.identity);
                Block block = blockObject.GetComponent<Block>();
                block.Type = (BlockType)selectedBlockType;
                block.TimeBreakBlock = selectedBlockTimeBreak;

                Vector3 blockOffset = Vector3.Scale(hit.normal, blockObject.transform.localScale);
                blockObject.transform.position += blockOffset;
            }
        }
    }

    private bool CanPlaceBlock(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapBox(position, Vector3.one * 0.4f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Block"))
            {
                return false;
            }
        }
        return true;
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
