using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tools
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Tilemap))]
    public class CompressTilemap : MonoBehaviour
    {
        [ExposeMethodInEditor]
        public void Compress()
        {
            GetComponent<Tilemap>().CompressBounds();
        }
    }
}
