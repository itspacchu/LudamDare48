using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniTerrain : MonoBehaviour
{
    public float maxViewDistance = 50;
    public static float maxViewDst;
    public Transform viewer;
    public static Vector2 viewerPosition;
    public int chunksize;
    int chunkVisibleInViewDst;
    public GameObject ToInstaniate;
    static GameObject Treefab;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    void Start()
    {
        maxViewDst = maxViewDistance;
        Treefab = ToInstaniate;             
        chunkVisibleInViewDst = Mathf.RoundToInt(maxViewDst/chunksize);
    }

    private void Update() {
        viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
        UpdateVisibleChunks();
    }

    // Update is called once per frame
    void UpdateVisibleChunks()
    {
        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x/chunksize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunksize);
        
        for(int yOffset = -chunkVisibleInViewDst; yOffset <= chunkVisibleInViewDst ; yOffset++){
            for (int xOffset = -chunkVisibleInViewDst; xOffset <= chunkVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2 (currentChunkCoordX + xOffset , currentChunkCoordY + yOffset);
                if(terrainChunkDictionary.ContainsKey(viewedChunkCoord)){
                    terrainChunkDictionary[viewedChunkCoord].Update();
                    //
                }else{
                    terrainChunkDictionary.Add(viewedChunkCoord , new TerrainChunk(viewedChunkCoord,chunksize));
                }
            }
        }
    }

    public class TerrainChunk {
        GameObject meshObject;
        Vector2 position;

        Bounds bounds;
        public TerrainChunk(Vector2 coord , int size){
            position = coord * size;
            bounds = new Bounds(position,Vector2.one*size);
            Vector3 positionV3 = new Vector3(position.x,0,position.y);
            meshObject = Instantiate(Treefab);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size / 10f;
            SetVisible(false);
        }

        public void Update(){
            float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
            bool visible = viewerDstFromNearestEdge <= maxViewDst;
            SetVisible(visible);
        }

        public void SetVisible(bool visible){
            meshObject.SetActive(visible);
        }

    }
}
