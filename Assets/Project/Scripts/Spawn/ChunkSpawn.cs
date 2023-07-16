using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : SpawnManager
{
    public static ChunkSpawn Instance;
    public static string blockChunkName = "BlockChunk";

    [Header("Setup spawn chunk")]
        [SerializeField] private int chunksPerRow = 3;
        [SerializeField] private float chunkSpacing = 4f;


    protected override void Awake()
    {
        base.Awake();
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(this);
        }
    }

    protected override void Start()
    {
        SpawnChunks();
    }

    private void SpawnChunks()
    {
        for (int row = 0; row < chunksPerRow; row++)
        {
            for (int col = 0; col < chunksPerRow; col++)
            {
                Vector3 spawnPosition = new Vector3(col * chunkSpacing, 0f, row * chunkSpacing);
                GameObject chunkObject = Spawn(blockChunkName, spawnPosition, Quaternion.identity);
                BlockChunkSpawn blockChunkSpawn = chunkObject.GetComponent<BlockChunkSpawn>();
                blockChunkSpawn.GenerateChunk();
            }
        }
    }
}
