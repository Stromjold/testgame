"""
unir_logs.py

Une todos los archivos .log que estén en la misma carpeta que este script
en un único archivo de texto, respetando el nombre de cada archivo como
título/separador y sin omitir ni una sola línea de contenido.

Uso:
    Coloca este archivo en la misma carpeta que tus .log y ejecútalo:
        python unir_logs.py

    El archivo resultante ("logs_unidos.txt") se generará en esa misma carpeta.
"""

import os
import sys
from datetime import datetime

# Nombre del archivo de salida (se genera en la misma carpeta que este script)
NOMBRE_SALIDA = "logs_unidos.txt"


def obtener_carpeta_script():
    """Devuelve la carpeta donde está ubicado este script."""
    return os.path.dirname(os.path.abspath(__file__))


def encontrar_logs(carpeta):
    """Busca todos los .log en la carpeta (sin entrar a subcarpetas),
    ordenados alfabéticamente para un resultado predecible."""
    archivos = [
        f for f in os.listdir(carpeta)
        if f.lower().endswith(".log") and os.path.isfile(os.path.join(carpeta, f))
    ]
    archivos.sort()
    return archivos


def leer_contenido(ruta_archivo):
    """Lee el contenido completo de un archivo intentando varias codificaciones
    para no perder información si el .log no está en UTF-8 puro."""
    codificaciones = ["utf-8", "utf-8-sig", "latin-1"]
    for codificacion in codificaciones:
        try:
            with open(ruta_archivo, "r", encoding=codificacion) as f:
                return f.read()
        except UnicodeDecodeError:
            continue
    # Última opción: leer ignorando errores de decodificación, para no fallar
    with open(ruta_archivo, "r", encoding="utf-8", errors="replace") as f:
        return f.read()


def main():
    carpeta = obtener_carpeta_script()
    archivos_log = encontrar_logs(carpeta)

    if not archivos_log:
        print("No se encontraron archivos .log en esta carpeta.")
        sys.exit(0)

    ruta_salida = os.path.join(carpeta, NOMBRE_SALIDA)

    with open(ruta_salida, "w", encoding="utf-8") as salida:
        salida.write("ARCHIVO GENERADO AUTOMÁTICAMENTE POR unir_logs.py\n")
        salida.write(f"Fecha de generación: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        salida.write(f"Total de archivos .log encontrados: {len(archivos_log)}\n")
        salida.write("=" * 80 + "\n\n")

        for nombre_archivo in archivos_log:
            ruta_completa = os.path.join(carpeta, nombre_archivo)
            contenido = leer_contenido(ruta_completa)

            # Título/separador claro por cada archivo, sin tocar su contenido original
            salida.write("=" * 80 + "\n")
            salida.write(f"ARCHIVO: {nombre_archivo}\n")
            salida.write("=" * 80 + "\n")
            salida.write(contenido)

            # Asegura un salto de línea limpio entre archivos aunque el .log
            # no termine con salto de línea
            if not contenido.endswith("\n"):
                salida.write("\n")
            salida.write("\n")

            print(f"Añadido: {nombre_archivo}")

    print(f"\nListo. Archivo generado en: {ruta_salida}")


if __name__ == "__main__":
    main()