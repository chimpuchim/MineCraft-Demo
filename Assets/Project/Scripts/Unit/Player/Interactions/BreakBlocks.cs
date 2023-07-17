using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlocks : GameManager
{
    private Camera mainCamera;


    protected override void Start()
    {
        mainCamera = GameController.Instance.CameraMain.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BreakBlock();
        }
    }

    private void BreakBlock()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Block block = hit.collider.GetComponent<Block>();

            if (block != null)
            {
                StartCoroutine(BreakBlockCoroutine(block, block.TimeBreakBlock));
            }
        }
    }

    private IEnumerator BreakBlockCoroutine(Block block, float breakTime)
    {
        yield return new WaitForSeconds(breakTime);

        block.gameObject.SetActive(false);
        Destroy(block.gameObject);
    }
}
