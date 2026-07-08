Documentación de Desarrollo: Tierra de Nadie

Fecha de modificaciones: 07-07-2026 | Fecha de entrega: 17/07/2026
Docente a cargo: Francisco Villarroel
Colaboradores: Derek Philip Lemus Sepúlveda, Luis Alberto González Toledo, Martín Matías Díaz Coloma, Vicente Fernando Cossío Gallardo.
1. Estándar de Juego y Metodología de Documentación

El proyecto se documenta siguiendo una estructura modular que permite el crecimiento y la iteración.

    Estándar / Género Base: Estrategia, Supervivencia y Tower Defense.

    Forma de documentar: Se utiliza un formato iterativo donde la lógica, arquitectura y diseño están centralizados, permitiendo que cualquier desarrollador que ingrese al proyecto entienda el flujo, los componentes técnicos y la narrativa sin fricciones.

2. Metodología y Libertad Creativa

Se ha establecido una metodología de trabajo basada en etapas (ágil) que permite iterar rápidamente sobre mecánicas comprobables.

    Fases del flujo de trabajo: Planificación/Diseño -> Configuración -> Mecánicas Básicas -> Desarrollo de Niveles -> Integración Visual -> Pruebas -> Optimización.

    Libertad Creativa: Esta metodología permite cierta flexibilidad en la narrativa. Aunque las rutas de los enemigos están definidas de forma estricta (Tower Defense), la libertad creativa brilla en la narrativa episódica: el uso de Comic Strips introductorios al inicio de cada nivel brinda al equipo de arte y guion un lienzo para explorar el drama postapocalíptico sin afectar el código base.

3. Concepción y Diseño
Temática

El juego está ambientado en un mundo postapocalíptico inspirado en un desastre nuclear (específicamente hasta una segunda explosión en el reactor número 4). La estética visual refleja zonas contaminadas, instalaciones abandonadas y criaturas mutadas por la radiación.
Reglas Core del Juego

    Condición de Victoria: El jugador debe sobrevivir a las oleadas de enemigos, eliminando mutantes para sumar puntos y alcanzar una meta en el GameManager.

    Condición de Derrota: Permitir que los enemigos recorran la ruta completa y dañen la base (o perder las unidades defensivas).

    Economía y Recursos: Los enemigos derrotados sueltan recursos (RecursoDrop.cs en tipos: Cristal, Artefacto, Oscura y Orbe) que el jugador recoge interactuando con ellos para mejorar su estado.

    Combate Automático: Los soldados (Soldier.cs) detectan automáticamente al enemigo más cercano dentro de su rango, rotan y disparan (Bullet.cs).

4. Arquitectura de Software del Videojuego

El juego utiliza el motor Unity (6000.5.0f1) con C# y se basa en el patrón de Diseño Basado en Componentes clásico de Unity, apoyado por un patrón Singleton para la gestión global.

    Renderizado: Universal Render Pipeline (URP) para gráficos 2D, iluminación global y efectos visuales (Renderer2D.asset).

    Patrones de Diseño: * GameManager.cs: Utiliza un Singleton (GameManager.instance) para centralizar el estado de la partida, puntajes, UI y la evaluación de victoria/derrota.

    Estructura de Comportamientos (Scripts):

        Spawner.cs: Rutina (Corrutina) de instanciación continua de Prefabs enemigos.

        Enemy.cs: Lógica de navegación consumiendo un arreglo estático de Waypoints.cs. Gestiona su propia salud.

        Soldier.cs: Lógica de Targeting. Usa funciones matemáticas para medir distancia, identificar el tag "Enemy" más cercano, y dispara proyectiles.

        Bullet.cs: Lógica de rastreo iterativo (persigue al objetivo asignado frame a frame mediante Seek()).

5. Preproducción
Equipo de Trabajo y Orden de Labores

Aunque todos son colaboradores integrales, para este estándar el equipo asume responsabilidades cruzadas:

    Dirección de Proyecto / Game Design: Definición de capítulos, progresión de dificultad (Fácil, Medio, Difícil).

    Programación: Creación del Stack Tecnológico (Mecánicas de Spawner, Combate, Waypoints, Interfaz de Usuario UI/HUD).

    Arte y Narrativa: Creación de sprites (soldados, monstruos acuáticos), Comic Strips y diseño de interfaz (pantallacarga.unity).

Costo de Juego

Al ser un proyecto de ámbito académico/independiente, el costo monetario directo es bajo o nulo, subsidiado por el uso de licencias gratuitas de Unity y repositorios gratuitos (GitHub). El "costo" real recae en las horas-hombre invertidas por los 4 desarrolladores en investigación, programación y diseño de assets, además del costo de hardware personal utilizado.
6. Producción

Fase de ejecución principal. Actualmente, el proyecto ya cuenta con un proyecto base operativo llamado test3.

    Logros de Producción: Creación del Capítulo 1 (Nivel 1). Se integró el entorno, las rutas de movimiento de los enemigos, la jerarquía de la UI (Textos TMP, Menú Interactivo) y el ciclo central de gameplay (aparecer -> caminar -> disparar -> morir -> soltar recurso).

    Stack Integrado: Uso activo del Input System moderno, UGUI, com.unity.2d.animation y Tilemaps.

7. Corrección (Pruebas y QA)

Las rondas de corrección se reflejan en el Historial de GitHub:

    Ajustes visuales y de jerarquía en la pantalla de carga del Capítulo 1 (centrado, adaptación de resoluciones).

    Corrección de las colisiones en el script RecursoDrop.cs (uso de Collider2D en modo trigger).

    Organización profunda de carpetas (Assets/Scripts/, Assets/Prefabs/, etc.) para evitar conflictos en el control de versiones.

8. Expansiones y Nuevas Funcionalidades

La arquitectura del juego ya está diseñada de forma escalable para recibir expansiones directas:

    Capítulos 2 al 5: Planeados estructuralmente con 3 niveles cada uno (15 niveles en total).

    Nuevas mecánicas proyectadas: Introducción de nuevos tipos de soldados, enemigos mutantes con comportamientos complejos (no solo avanzar por una ruta), y mayor profundidad en el uso de los recursos (Cristal, Artefacto, etc.) para aplicar mejoras (upgrades).
