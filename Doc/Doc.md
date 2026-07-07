<img src="media/image1.png" style="width:1.55in;height:0.82119in" />

Documentación de Desarrollo

Tierra de nadie

<img src="media/image2.png" style="width:0.83in;height:0.52377in" />

Colaboradores: Derek Philip Lemus Sepúlveda – Luis Alberto González Toledo - Martín Matías Díaz Coloma - Vicente Fernando Cossío Gallardo\
Docente a cargo: Francisco Villarroel\
Fecha de modificaciones: 07-07-2026\
Fecha de entrega: 17/07/2026

# Índice

- [Preproducción del Proyecto](#1-preproducción-del-proyecto)
  - [Idea Inicial](#11-idea-inicial)
  - [Investigación y Referencias](#12-investigación-y-referencias)
  - [Definición de Objetivos](#13-definición-de-objetivos)
  - [Diseño de la Historia](#14-diseño-de-la-historia)
  - [Diseño de Personajes](#15-diseño-de-personajes)
  - [Diseño de Escenarios](#16-diseño-de-escenarios)
  - [Planificación de Niveles](#17-planificación-de-niveles)
  - [Selección de Herramientas](#18-selección-de-herramientas)
  - [Planificación del Desarrollo](#19-planificación-del-desarrollo)
- [Etapa de Planificación y Diseño](#2-etapa-de-planificación-y-diseño)
  - [Desarrollo de la Base del Proyecto](#211-desarrollo-de-la-base-del-proyecto)
  - [Implementación de Mecánicas Básicas](#212-implementación-de-mecánicas-básicas)
- [Creación del Proyecto](#3-creación-del-proyecto)
- [Capítulo 1 – Nivel 1](#4-capítulo-1--nivel-1)
  - [Stack Tecnológico](#41-stack-tecnológico)
  - [Cambios recientes en la escena de carga](#42-cambios-recientes-en-la-escena-de-carga)
- [Estructura de Archivos del Proyecto](#5-estructura-de-archivos-del-proyecto)
- [Funcionamiento General](#6-funcionamiento-general)
- [Descripción de Componentes](#7-descripción-de-componentes)
- [Prefabs](#8-prefabs)
  - [Escenas](#81-escenas)
- [Configuración del Proyecto](#9-configuración-del-proyecto)
- [Recursos Visuales](#10-recursos-visuales)
- [Cambios Recientes](#11-cambios-recientes)
- [Historial de Cambios en GitHub](#12-historial-de-cambios-en-github)

# 1. Preproducción del Proyecto

## 1.1 Idea Inicial

El proyecto **Tierra de Nadie** surge con el objetivo de desarrollar un videojuego orientado a estrategia y supervivencia, ambientado en un mundo postapocalíptico inspirado en un desastre nuclear.

La idea principal es que el jugador controle diferentes unidades para enfrentar criaturas mutadas y sobrevivir en entornos contaminados, mientras descubre los hechos que llevaron al colapso de la zona afectada.

## 1.2 Investigación y Referencias

Antes de comenzar la creación del proyecto, se investigaron referencias narrativas y mecánicas de juego en títulos de estrategia y defensa, incluyendo ejemplos de juegos populares y alternativas de plataformas web.

Como resultado del análisis realizado por el equipo, se definió que el género base para el desarrollo sería **tower defense**.

## 1.3 Definición de Objetivos

Durante la etapa de planificación se establecieron los siguientes objetivos:

- Crear un videojuego funcional utilizando Unity.
- Permitir la selección de personajes/unidades para la partida.
- Diseñar una historia dividida en capítulos.
- Implementar distintos niveles de dificultad.
- Incorporar enemigos con comportamientos automáticos.
- Desarrollar un sistema de combate entre soldados y enemigos.
- Generar una experiencia visual coherente con la temática postapocalíptica.

## 1.4 Diseño de la Historia

Se definió una narrativa compuesta por cinco capítulos que relatan acontecimientos desde el desastre inicial hasta una segunda explosión en el reactor número 4.

Cada capítulo representa una etapa distinta y permite al jugador conocer nuevos escenarios, personajes y desafíos. Para facilitar la comprensión de la trama, se incorporan **Comic Strips** al inicio de cada nivel.

## 1.5 Diseño de Personajes

Se planificaron tres categorías principales:

- **Soldados:** fuerzas defensivas con capacidad de ataque a distancia.
- **Enemigos mutantes:** criaturas afectadas por radiación que avanzan por rutas definidas.
- **Personajes secundarios:** apoyo narrativo para el desarrollo de la historia.

## 1.6 Diseño de Escenarios

Los escenarios fueron diseñados en ambientes inspirados en zonas contaminadas, instalaciones abandonadas y áreas afectadas por mutaciones biológicas.

Se definieron cinco escenarios principales (uno por capítulo), cada uno con variaciones de dificultad y progresión visual.

## 1.7 Planificación de Niveles

El juego fue organizado en cinco capítulos.

Cada capítulo contempla tres niveles de dificultad:

- Fácil
- Medio
- Difícil

En total, se planificaron **15 niveles** distribuidos de la siguiente manera:

- Capítulo 1: 3 niveles
- Capítulo 2: 3 niveles
- Capítulo 3: 3 niveles
- Capítulo 4: 3 niveles
- Capítulo 5: 3 niveles

## 1.8 Selección de Herramientas

Para el desarrollo se seleccionaron las siguientes herramientas:

- **Unity 6000.5.0f1** como motor de desarrollo.
- **C#** como lenguaje principal.
- **Universal Render Pipeline (URP)** para gráficos 2D.
- Estructura de carpetas para control y organización de recursos.

## 1.9 Planificación del Desarrollo

Se estableció una metodología de trabajo basada en etapas:

1. Planificación y diseño.
2. Configuración del proyecto.
3. Implementación de mecánicas básicas.
4. Desarrollo de niveles.
5. Integración de recursos visuales.
6. Pruebas y corrección de errores.
7. Optimización y documentación final.

# 2. Etapa de Planificación y Diseño

Se elaboró la guía de planificación general del videojuego **Tierra de Nadie**, definiendo historia principal, capítulos y objetivos por nivel.

Actividades realizadas:

- Definición de la narrativa principal.
- Estructuración de 5 capítulos en formato de viñetas.
- Definición de 3 niveles por capítulo (fácil, medio, difícil).
- Diseño preliminar de personajes, enemigos y escenarios.
- Elaboración de la estructura general del proyecto.

Resultados:

- Historia principal definida.
- Organización de capítulos y niveles completa.
- Identificación de recursos gráficos necesarios.

## 2.11 Desarrollo de la Base del Proyecto

Se realizó la configuración inicial del entorno de trabajo con Unity y URP para desarrollo 2D.

Actividades realizadas:

- Creación del proyecto **test3**.
- Configuración del motor gráfico URP.
- Instalación de dependencias.
- Organización de carpetas y recursos.
- Configuración de escenas iniciales.

Resultados:

- Proyecto operativo y preparado para desarrollo.
- Estructura ordenada para trabajo colaborativo.

## 2.12 Implementación de Mecánicas Básicas

Se desarrolló la lógica principal de interacción entre enemigos, soldados y proyectiles.

Actividades realizadas:

- Programación de `Spawner.cs`.
- Programación de `Enemy.cs`.
- Programación de `Soldier.cs`.
- Programación de `Bullet.cs`.
- Programación de `Waypoints.cs`.

Resultados:

- Generación automática de enemigos.
- Movimiento funcional mediante rutas.
- Sistema de detección y ataque implementado.
- Sistema de daño operativo.

# 3. Creación del Proyecto

Se creó el proyecto inicial con nombre **test3**, como continuidad de pruebas anteriores.

El juego consta de **5 capítulos** que narran la historia desde su inicio hasta su cierre. Cada capítulo incluye **Comic Strips** al comienzo de cada nivel para entregar contexto narrativo al jugador.

Cada capítulo contiene **3 niveles** con distintos desafíos.

# 4. Capítulo 1 – Nivel 1

## 4.1 Stack Tecnológico

**Lenguaje:** C#\
**Framework / Runtime:** Unity 6000.5.0f1 + Universal Render Pipeline (URP) + 2D

**Paquetes y librerías destacadas:**

- `com.unity.render-pipelines.universal`: renderizado URP para fondos, luces y efectos.
- `com.unity.inputsystem`: sistema de entrada moderno.
- `com.unity.ugui`: interfaz gráfica (HUD, menús, textos).
- `TextMeshPro`: texto de alta calidad en UI.
- `com.unity.2d.sprite`: soporte para sprites 2D.
- `com.unity.2d.tilemap`: soporte para mapas y superficies 2D.
- `com.unity.2d.animation`: animación 2D.
- `com.unity.timeline`: secuencias narrativas y cinemáticas.
- `com.unity.visualscripting`: soporte de prototipado visual.
- `com.unity.test-framework`: pruebas de validación.

## 4.2 Cambios recientes en la escena de carga

La escena `Assets/Scenes/niveles/cap1/pantallacarga.unity` recibió ajustes visuales y de jerarquía para mejorar claridad y presentación.

Cambios principales:

- Se añadió un objeto UI llamado **LogoCarga**.
- Se incorporó un texto TMP para mensajes o títulos del nivel.
- Se ajustó posición y escala de elementos principales para centrar la interfaz.
- Se mejoró la coherencia visual general de la pantalla de carga.

# 5. Estructura de Archivos del Proyecto

| Carpeta | Descripción |
|---|---|
| **Scripts/** | Lógica jugable: enemigo, bala, soldado, spawner, rutas |
| **Prefabs/** | Enemigos y proyectiles reutilizables |
| **Scenes/** | Escena principal y subcarpetas de niveles |
| **Settings/** | Configuración de render, escenas y pipeline |
| **Sprites/** | Recursos visuales 2D organizados por capítulos |
| **img/** | Imágenes sueltas y assets visuales |
| **Packages/** | Dependencias del proyecto Unity |
| **ProjectSettings/** | Configuración global del editor y del proyecto |

# 6. Funcionamiento General

- `Spawner.cs` instancia enemigos repetidamente.
- `Enemy.cs` usa `Waypoints.points` para moverse por la ruta y se destruye al llegar al final o al perder toda la vida.
- `Soldier.cs` busca el enemigo más cercano dentro de su rango, rota hacia él y crea un prefab `Bullet`.
- `Bullet.cs` persigue al objetivo, aplica daño al impactar y se destruye.

# 7. Descripción de Componentes

## 7.1 Scripts

`Assets/Scripts/capitulo1/Nivel1/GameManager.cs`

- Controla el estado central de la partida con patrón singleton.
- Lleva la cuenta de enemigos eliminados, recursos y puntos.
- Actualiza textos UI con TextMeshProUGUI e imagen de progreso.
- `RegistrarMuerte()` suma puntos, incrementa meta y evalúa victoria.
- `RecogerRecurso()` centraliza la suma de Cristal, Artefacto, Oscura y Orbe.

`Assets/Scripts/capitulo1/Nivel1/Spawner.cs`

- Inicia corrutina en `Start()`.
- Genera enemigos de forma continua según `tiempoEntreEnemigos`.
- Instancia `enemigoPrefab` en la posición del spawner.

`Assets/Scripts/capitulo1/Nivel1/Enemy.cs`

- Lee la primera posición de `Waypoints.points` en `Start()`.
- Se mueve hacia el waypoint actual en `Update()`.
- Avanza al siguiente waypoint y se destruye al finalizar ruta.
- Gestiona vida (`health`) con `TakeDamage(int damage)`.
- Al morir llama a `GameManager.instance.RegistrarMuerte()`.

`Assets/Scripts/capitulo1/Nivel1/Waypoints.cs`

- Construye arreglo estático `points` con hijos del objeto contenedor.
- Define la ruta compartida para los enemigos.
- Inicializa en `Awake()`.

`Assets/Scripts/capitulo1/Nivel1/Soldier.cs`

- Busca enemigos con tag `Enemy`.
- Selecciona el más cercano dentro del rango.
- Rota hacia el objetivo antes de disparar.
- Instancia `bulletPrefab` y asigna objetivo con `Seek()`.
- Usa `OnDrawGizmosSelected()` para visualizar rango en editor.

`Assets/Scripts/capitulo1/Nivel1/Bullet.cs`

- Guarda un objetivo asignado por `Seek()`.
- Se mueve hacia el objetivo cada frame.
- Si el objetivo desaparece, la bala se autodestruye.
- Al impactar llama a `Enemy.TakeDamage(1)` y se destruye.

`Assets/Scripts/capitulo1/Nivel1/MenuInteractivo.cs`

- Mantiene el menú oculto al iniciar.
- Usa `OnMouseDown()` para alternar visibilidad de `menuCanvas`.
- Funciona como control interactivo simple para paneles UI.

`Assets/Scripts/capitulo1/Nivel1/ControladorSlideshow.cs`

- Cambia imágenes de fondo mediante arreglo de `Sprite`.
- Usa `Image` (UGUI) para mostrar cada escena visual.
- Controla tiempo entre imágenes con temporizador.
- Reinicia el ciclo al finalizar el arreglo.

`Assets/Scripts/capitulo1/Nivel1/movimiento/RecursoDrop.cs`

- Detecta colisiones con `Collider2D` en modo trigger.
- Si colisiona un objeto con tag `Player`, suma recurso al `GameManager`.
- Soporta tipos: Cristal, Artefacto, Oscura y Orbe.
- Destruye el objeto tras ser recogido.

# 8. Prefabs

| Archivo | Descripción |
|:---|:---|
| **Assets/Prefabs/Bala.prefab** | Prefab de proyectil del sistema de disparo. |
| **Assets/Prefabs/EnemigoPrueba.prefab** | Prefab de enemigo usado por el spawner. |

## 8.1 Escenas

**Assets/Scenes/SampleScene.unity**

- Escena principal detectada.
- Incluye al menos: Main Camera, Global Light 2D y fondo/escenario.

**Assets/Scenes/niveles/**

- Subcarpeta de niveles por capítulo.
- La escena `Assets/Scenes/niveles/cap1/pantallacarga.unity` se utiliza como pantalla de carga del capítulo 1.

# 9. Configuración del Proyecto

| Archivo | Descripción |
|:---|:---|
| **Assets/Settings/Renderer2D.asset** | Configuración del renderer 2D. |
| **Assets/Settings/UniversalRP.asset** | Asset del pipeline URP del proyecto. |
| **Assets/Settings/Lit2DSceneTemplate.scenetemplate** | Plantilla de escena 2D lit. |

# 10. Recursos Visuales

**Assets/img/**

Imágenes de personajes, enemigos y otros recursos:

- `Soldado1.png`
- `soldado.png`
- `Monstruo_acuatico.png`
- `Monstruo_acuatico1.png`
- `1.jpeg`
- `2.png`
- Carpeta adicional: **Municiones/**

**Assets/Sprites/**

Organización por capítulos:

- `capitulo 1/`
- `capitulo 2/`
- `capitulo 3/`
- `capitulo 4/`
- `capitulo 5/`

# 11. Cambios Recientes

- Se actualizó la documentación para reflejar scripts reales presentes en `Assets/Scripts`.
- Se amplió la descripción de la lógica del nivel 1 con `GameManager`, `MenuInteractivo`, `ControladorSlideshow` y `RecursoDrop`.
- Se documentaron paquetes principales del proyecto y su función en el flujo de trabajo.
- Se registraron cambios visuales de la escena de carga del capítulo 1.

# 12. Historial de Cambios en GitHub

> Resumen general de mejoras y avances registrados en el repositorio hasta el **07-07-2026**.

- Integración progresiva de la base jugable del capítulo 1.
- Incorporación de scripts de combate, movimiento por rutas y generación de enemigos.
- Ajustes visuales y de interfaz en escenas de niveles, especialmente pantalla de carga.
- Actualización y organización de recursos gráficos (Sprites e imágenes de apoyo).
- Mejoras en documentación técnica y descripción del funcionamiento del proyecto.
- Consolidación de estructura de carpetas para trabajo colaborativo en Unity.

**Commits considerados en la actualización (rama `main`):**

- `415cfea21b5c68ee1ae3f13087473ea1403e68da`
- `5aa3b39704f6f2d3e931d7122b06930a44f09f06`
- `7ed3fcc9d23b6606307318a723534cd55dc50b88`
- `e53eff4a467f7400851226699ad20afe1c22aa5d`
- `b20407692e6f96f9572f86ab8d2f97401763a0b5`
- `2dd0aac6fac3dc98c3ab456134f7917e74820b09`
- `1570500e00b6f5015cffc46d9f0d458d7966fa32`
- `41c51c264dccd2d04c9ed9e2cd96664b8ac1bb51`
- `ebf77ea1e95f1661644b5a95bcddaaf44df2edd2`
- `9de12e590adddd76057dbc74bfee2366e13ba3f2`
- `895449518b25b42b296278a2492d7fdd91fc9cd4`
- `ca70774f5991c6405f14c4ce4eae675025d70b78`
- `9b45bd077987fec3d75bc207995346b0742effd6`
- `d296fb46c0bd1eb1b3a94474a1214a156b77c4e1`
- `8b2cacaed2064a37cf82b07a3ce0245eab5fa591`
- `da5fe226e9738d9a893284b83ff41382b5579693`
- `24d3b83c4da54d25735fbd1334b7a579c2310ada`
- `16d6bc8c00e4f1b39e5bdad0b7f0feb6c8f5527e`
- `58c6245e281d162097afc7c34b0096a21ae017a7`
- `590b49720b543b82d03ee3e25a810136166b7132`
- `a98507d7f1a4edb395401d54d8d4221eaa25f3c5`
- `ce6528031b28276d4f408f6e46f5fceb28539b62`
- `cb5a576cbf3aa66ff7abbff0014ec57e4a7efd18`
- `198866c536df7357fd92d8adaf4762247c2c100e`
- `99f5c993a916b5485a7cad03a54754f28d186d46`
- `2b2ef4bbea4fe6bafaccc6e60a15ce3672a8274a`
- `fc5ece549b2d75bbcbaef4c15c419f2764db513e`
- `713ee8b7128168df222469b5260795fb509e4c31`
- `2e92258fef12ccf8ca2de37f492b075358daa1d4`
- `a828d54e4ff18380933b79b6c8e7869215d3d11e`
- `43decd777a1b5abb2d59efc80bfeae92b5a5aeac`
- `5c446446cdc4cea6d9b6041d59990f014593e304`
- `f701ad5dfdd08c4c281aac093bc2c816d8a2118e`
- `873dd0faef4ea7df91d14e4c543e9769e2b07a3f`
- `d468343a8cffe1f503a64b36a31951b8c88c6e37`
- `2c9849f20b7641ebe23a984b8ee9703807344618`
- `67d5dd1f328b2a1596eee8fdc856530094c46c65`
- `03fbae7ee223d554619b92b219c6d852f5908983`
- `0849eff37e920142bc187ddd570289b62e337a86`
- `58ca0617b9ad3e7a94309958522ec26e43b20865`
