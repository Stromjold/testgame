#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AutomatizadorRecursos
{
    [MenuItem("Herramientas/Arreglar Escala de Recursos")]
    public static void ArreglarEscalas()
    {
        // Busca todos los prefabs específicamente en tu carpeta de Elementos
        string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Prefabs/Cap1/Elementos" });
        
        int contador = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            if (prefab != null)
            {
                // 1. Aplicar la escala matemáticamente exacta a 150
                prefab.transform.localScale = new Vector3(150f, 150f, 1f);

                // 2. Buscar el Sprite y subirlo a la capa 10
                SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingOrder = 10;
                }

                // Obligar a Unity a registrar que este archivo cambió
                EditorUtility.SetDirty(prefab);
                contador++;
            }
        }

        // Guardar todos los archivos modificados en el disco duro de golpe
        AssetDatabase.SaveAssets();
        
        // Imprimir el reporte en la consola de Unity
        Debug.Log($"[AUTOMATIZACIÓN] ¡Trabajo terminado! Se actualizaron {contador} recursos a escala 150 y capa 10.");
    }
}
#endif