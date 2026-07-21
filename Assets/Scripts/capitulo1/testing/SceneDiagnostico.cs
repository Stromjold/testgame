using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;

public class SceneDiagnostico : MonoBehaviour
{
    void Start()
    {
        GenerarReporte();
    }

    public void GenerarReporte()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== REPORTE DE DIAGNÓSTICO DE ESCENA: " + SceneManager.GetActiveScene().name + " ===");
        
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject go in rootObjects)
        {
            AnalizarGameObject(go, sb, 0);
        }

        string path = Application.dataPath + "/ReporteEscena_Nivel1.txt";
        File.WriteAllText(path, sb.ToString());
        Debug.Log("¡[TESTING] Reporte generado con éxito! Revisa el archivo en: " + path);
    }

    void AnalizarGameObject(GameObject go, StringBuilder sb, int nivel)
    {
        string sangria = new string('-', nivel * 2);
        
        sb.AppendLine($"{sangria}> Objeto: {go.name} | Activo: {go.activeInHierarchy}");
        sb.AppendLine($"{sangria}  PosMundial: {go.transform.position} | PosLocal: {go.transform.localPosition} | Escala: {go.transform.localScale}");
        
        Component[] componentes = go.GetComponents<Component>();
        sb.Append($"{sangria}  Componentes: ");
        foreach (Component comp in componentes)
        {
            if (comp != null) sb.Append(comp.GetType().Name + ", ");
        }
        sb.AppendLine();
        sb.AppendLine();

        foreach (Transform child in go.transform)
        {
            AnalizarGameObject(child.gameObject, sb, nivel + 1);
        }
    }
}