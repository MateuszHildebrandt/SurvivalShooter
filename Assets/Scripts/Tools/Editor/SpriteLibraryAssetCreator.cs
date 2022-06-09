using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Tools
{
    public class SpriteLibraryAssetCreator : EditorWindow
    {
        [MenuItem("Window/Create SpriteLibraryAsset")]
        public static void CreateSpriteLibraryAsset()
        {
            if (Selection.objects.Length == 0)
                Debug.Log("No textures selected!");

            string categorylabel = "Movement";
            SpriteLibraryAsset spriteLib;

            foreach (Object o in Selection.objects)
            {
                if (o.GetType() != typeof(Texture2D))
                    return;

                spriteLib = CreateInstance<SpriteLibraryAsset>();
                string spriteSheet = AssetDatabase.GetAssetPath(o);

                Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet)
                    .OfType<Sprite>().ToArray();

                for (int i = 0; i < sprites.Length; i++)
                {
                    spriteLib.AddCategoryLabel(sprites[i], categorylabel, i.ToString());
                }

                AssetDatabase.CreateAsset(spriteLib, RemoveExtensionFromPath(spriteSheet) + ".asset");
            }
        }

        private static string RemoveExtensionFromPath(string path)
        {
            if (!path.Contains("."))
                return path;

            return path.Substring(0, path.IndexOf('.'));
        }
    }
}