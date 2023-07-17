using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlocks : GameManager
{
    private Camera mainCamera;
    private bool isBreakingBlock;


    protected override void Start()
    {
        mainCamera = GameController.Instance.CameraMain.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBreakingBlock = true;
            StartCoroutine(BreakBlockCoroutine());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isBreakingBlock = false;
        }
    }

    
    private IEnumerator BreakBlockCoroutine()
    {
        float startTime = Time.time;

        while (isBreakingBlock)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Block block = hit.collider.GetComponent<Block>();

                if (block != null)
                {
                    float breakTime = block.TimeBreakBlock;
                    float elapsedTime = Time.time - startTime;

                    if (elapsedTime >= breakTime)
                    {
                        block.gameObject.SetActive(false);
                        Destroy(block.gameObject);
                        startTime = Time.time;
                    }
                }
            }

            yield return null;
        }
    }
}
