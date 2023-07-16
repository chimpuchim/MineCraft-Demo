using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChunkSpawn : SpawnManager
{
    public static BlockChunkSpawn Instance;
    public static string grassBlockName = "Grass";
    public static string dirtBlockName = "Dirt";
    public static string stoneBlockName = "Stone";

    public Block[,,] blocks = new Block[4, 4, 4];


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

    public void GenerateChunk()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    BlockType blockType = GetBlockType(y);
                    Block block = InstantiateBlock(blockType, new Vector3(x, y, z));
                    blocks[x, y, z] = block;
                }
            }
        }
    }
    
    private BlockType GetBlockType(int y)
    {
        if (y == 3)
            return BlockType.Grass;
        else if (y == 2)
            return BlockType.Dirt;
        else
            return BlockType.Stone;
    }
    
    private Block InstantiateBlock(BlockType blockType, Vector3 position)
    {
        string blockPrefabName;
        switch (blockType)
        {
            case BlockType.Grass:
                blockPrefabName = grassBlockName;
                break;
            case BlockType.Dirt:
                blockPrefabName = dirtBlockName;
                break;
            case BlockType.Stone:
                blockPrefabName = stoneBlockName;
                break;
            default:
                blockPrefabName = null;
                break;
        }
        
        Block block = Spawn(blockPrefabName, position, Quaternion.identity).GetComponent<Block>();
        return block;
    }

}
