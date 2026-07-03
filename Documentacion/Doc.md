<img src="media/image1.png" style="width:1.55in;height:0.82119in" />

Documentación de Desarrollo

Tierra de nadie

<img src="media/image2.png" style="width:0.83in;height:0.52377in" />

Colaboradores: Derek Philip Lemus Sepúlveda – Luis Alberto González
Toledo- Martín Matías Díaz coloma - Vicente Fernando Cossío Gallardo\
Docente a cargo: Francisco Villarroel\
Fecha de modificaciones: 25-06-2026\
Fecha de entrega: 11/07/2026

# Índice

- [Preproducción del Proyecto](#preproducción-del-proyecto)
  - [Idea Inicial](#idea-inicial)
  - [Investigación y Referencias](#investigación-y-referencias)
  - [Definición de Objetivos](#definición-de-objetivos)
  - [Diseño de la Historia](#diseño-de-la-historia)
  - [Diseño de Personajes](#diseño-de-personajes)
  - [Diseño de Escenarios](#diseño-de-escenarios)
  - [Planificación de Niveles](#planificación-de-niveles)
  - [Selección de Herramientas](#selección-de-herramientas)
  - [Planificación del Desarrollo](#planificación-del-desarrollo)

- [Etapa de Planificación y Diseño](#etapa-de-planificación-y-diseño)
  - [Desarrollo de la Base del Proyecto](#desarrollo-de-la-base-del-proyecto)
  - [Implementación de Mecánicas Básicas](#implementación-de-mecánicas-básicas)

- [Creación del Proyecto](#creación-del-proyecto)

- [Capítulo 1 – Nivel 1](#capítulo-1--nivel-1)
  - [Stack Tecnológico](#stack-tecnológico)

- [Estructura de Archivos del Proyecto](#estructura-de-archivos-del-proyecto)

- [Funcionamiento General](#funcionamiento-general)

- [Descripción de Componentes](#descripción-de-componentes)

- [Prefabs](#prefabs)
  - [Escenas](#escenas)

- [Configuración del Proyecto](#configuración-del-proyecto)

- [Recursos Visuales](#recursos-visuales)

1\. Preproducción del Proyecto

## 1.1 Idea Inicial

El proyecto "Tierra de Nadie" surge con el objetivo de desarrollar un
videojuego que se orientara en estrategia y supervivencia ambientado en
un mundo postapocalíptico como el destino del reactor 4 de la planta
nuclear Scratovish el siglo 20 y siendo uno de los peores casos de
desastres naturales en la historia, permitiendo que el jugador pueda
vivir una experiencia progresiva a través de distintos capítulos que
muestran la evolución de la catástrofe.

La idea principal es en que el jugador controle diferentes unidades
encargadas de enfrentar criaturas mutadas y sobrevivir en entornos
contaminados, mientras descubre los acontecimientos que llevaron al
colapso de la zona afectada.

## 1.2 Investigación y Referencias

Antes del comienzo de la creación del proyecto, se investigó de que se
trataría y como se haría, se estudió una gran variedad de historias y
distintas jugabilidades en distintos juegos en línea que se adecuaran a
nuestra idea de juego. Se investigo juegos como Clash of Clan, Call of
duty, League of legends, Word of warcraf, que es de los que más se sabía
en el momento, se investigó en distintas partes en juegos no tan
conocidos como los que ofrece la plataforma de Poki (Poki - Juegos
Gratis Online - ¡Juega Ahora!), encontramos una variedad enorme de
juegos a el cual nos llamó la atención es el Stick Defenders, el cual
consiste en defender un frente de unos enemigos que tratan de derivar
sus fuerzas y poder conquistar su espacio

Se investigo el tipo de juego que era, con los colaboradores del juego
se llegó a la conclusión de que el juego a crear sería un tower defence.

## 1.3 Definición de Objetivos

Durante la etapa de planificación se establecieron los siguientes
objetivos:

Crear un videojuego funcional utilizando Unity.

El juego deberá tener la funcionalidad de poder seleccionar a sus
jugadores en la partida lo cual se deberán agregar instancias en las
cuales se puedan agregar los personajes del juego, con botones y
pantallas emergentes

Diseñar una historia dividida en capítulos.

La historia será contada desde el comienzo como un epilogo para dar la
información al jugador el contexto de la historia y de lo que ocurrirá
en ella, esta será dividida en varias partes del juego dando información
de los hechos ocurridos en cada partida del juego

Implementar distintos niveles de dificultad.

Los niveles en el juego serán organizados en 3 niveles distintos por
capitulo, los cuales desde el nivel 1 al 3 irán aumentando su dificulta
según lo programado por el equipo de desarrollo

Incorporar enemigos con comportamientos automáticos.

Los enemigos tendrán caminos señalados por el programador que deberán
seguir hasta llegar a si meta, estos no podrán llegar solo si el jugador
los elimina antes de llegar a su destino

Desarrollar un sistema de combate entre soldados y enemigos.

El sistema consiste en que los enemigos pasen el perímetro de los
aleados que hay en la partida que en total serán 5 soldados los cuales
su misión será atacar a los monstruos que se encuentra y evitar que se
llegue a su destino, estos disparan distintos tipos de municiones para
poder evitar que los monstruos avancen

Generar una experiencia visual coherente con la temática
postapocalíptica.

El juego mostrara un diseño según la historia planteada por el equipo
mismo de producción del juego, se enfocarán de crear los escenarios para
dar a entender y dar la sensación de que la historia que se está
intentando contar a través del juego sea más vivida para poder atraer la
atención del consumidor en cuestión

## 1.4 Diseño de la Historia

Se definió una narrativa compuesta por cinco capítulos que relatan los
acontecimientos ocurridos desde el desastre nuclear hasta una segunda
explosión en el reactor número 4.

Cada capítulo representa una etapa diferente de la historia y permite al
jugador conocer nuevos escenarios, personajes y desafíos. Para facilitar
la comprensión de la trama, se decidió incorporar Comic Strips al inicio
de cada nivel.

## 1.5 Diseño de Personajes

Se planificaron distintos tipos de personajes para el juego:

Soldados

Representan a las fuerzas encargadas de contener la amenaza. Que Poseen
capacidad de ataque a distancia mediante proyectiles.

Enemigos Mutantes

Son criaturas afectadas por la radiación que avanzan por rutas definidas
intentando superar las defensas del jugador.

Personajes Secundarios

Se contempló la inclusión de personajes narrativos para apoyar el
desarrollo de la historia mediante escenas ilustradas.

## 

## 1.6 Diseño de Escenarios

Los escenarios fueron diseñados considerando ambientes inspirados en
zonas contaminadas por radiación, instalaciones abandonadas y áreas
afectadas por mutaciones biológicas.

Se definieron cinco grandes escenarios principales, uno por cada
capítulo de la historia.

Los escenarios son en total tres por capitulo los cuales distintos
escenarios tendrán distintos monstruos los cuales tendrán una dificulta
diferente a la anterior dando al jugador la sensación de que el panorama
está cambiando

##  1.7 Planificación de Niveles

El juego fue organizado en cinco capítulos.

Cada capítulo contempla tres niveles de dificultad:

- Fácil

- Medio

- Difícil

Las dificultades serán puestas al principio del juego, al seleccionar
las variables de éxito cambiarán acorde a la dificultad que se elija

Esta estructura permite aumentar progresivamente la complejidad del
juego y ofrecer una experiencia más desafiante para el jugador.

En total se planificaron quince niveles distribuidos de la siguiente
manera:

- Capítulo 1: 3 niveles

- Capítulo 2: 3 niveles

- Capítulo 3: 3 niveles

- Capítulo 4: 3 niveles

- Capítulo 5: 3 niveles

## 1.8 Selección de Herramientas

Para el desarrollo del proyecto se seleccionaron las siguientes
herramientas tecnológicas:

- Unity 6.5 como motor de desarrollo.

- Lenguaje de programación C#.

- Universal Render Pipeline (URP) para gráficos 2D.

- Sistema de control de recursos mediante la estructura de carpetas del
  proyecto

La elección de estas herramientas se realizó considerando su facilidad
de uso,compatibilidad con proyectos 2D y disponibilidad para los
integrantes del equipo.

## 

## 1.9 Planificación del Desarrollo

Se estableció una metodología de trabajo basada en etapas secuenciales:

1.  Planificación y diseño.

2.  Configuración del proyecto.

3.  Implementación de mecánicas básicas.

4.  Desarrollo de niveles.

5.  Integración de recursos visuales.

6.  Pruebas y corrección de errores.

7.  Optimización y documentación final.

Esta planificación permitió organizar el trabajo y facilitar el
seguimiento del avance del proyecto.

# 2 etapa de Planificación y Diseño

Se realiza la guía de planificación general del videojuego Tierra de
Nadie que se necesitara para ir trabajando día a día, definiendo la
historia principal, la cantidad de capítulos y los objetivos de cada
nivel.

Actividades realizadas:

- Definición de la narrativa principal del juego.

- Estructuración de 5 capítulos completos en formato de viñetas.

- Definición de 3 niveles por capítulo fácil, medio, difícil.

- Diseño preliminar de personajes, enemigos y escenarios.

- Elaboración de la estructura general del proyecto.

Resultados:

Historia principal definida, desde el desastre en Chernóbil hasta el
colapso del subsuelo y segunda explosión en el reactor 4.

Organización completa de capítulos y niveles, por ejemplo, capítulo 1
dificultad fácil , media, difícil según preferencia del usuario

Identificación de recursos gráficos necesarios para el desarrollo.

## 2.11 Desarrollo de la Base del Proyecto

Se procede a la configuración inicial del entorno de trabajo utilizando
Unity 6.5 y el pipeline Universal Render Pipeline (URP) para desarrollo
2D.

Actividades realizadas:

- Creación del proyecto con nombre test3.

- Configuración del motor gráfico URP.

- Instalación de dependencias necesarias.

- Organización de carpetas y recursos.

- Configuración de escenas iniciales.

<!-- -->

- Resultados:

- Proyecto operativo y preparado para el desarrollo.

- Estructura organizada para facilitar el trabajo colaborativo.

## 2.12 Implementación de Mecánicas Básicas

Se desarrolla la lógica principal del sistema de juego, permitiendo la
interacción entre enemigos, soldados y proyectiles.

Actividades realizadas:

- Programación de Spawner.cs.

- Programación de Enemy.cs.

- Programación de Soldier.cs.

- Programación de Bullet.cs.

- Programación de Waypoints.cs.

Resultados:

• Generación automática de enemigos.

• Movimiento funcional mediante rutas.

• Sistema de detección y ataque implementado.

• Sistema de daño operativo.

# 3.Creación del Proyecto 

Se procede a la creación del proyecto inicial con el nombre **test3**,
como referencia a las pruebas anteriores. En este proyecto se desarrolla
el juego **Tierra de Nadie**.

Para la creación del juego se utiliza la herramienta **Unity versión
6.5**, instalada en uno de los dispositivos de los dos estudiantes
responsables del proyecto.

El juego consta de **5 capítulos** que narran toda la historia desde su
inicio hasta el final.\
Cada capítulo incluye **Comic Strips** al comienzo de cada nivel,
mostrando el progreso de la historia y brindando información al jugador
sobre la parte de la trama en la que se encuentra.

Cada capítulo contiene **3 niveles** con distintos desafíos que el
jugador debe superar.

# 4 Capítulo 1 – Nivel 1 

## 4.1 Stack Tecnológico 

**Lenguaje:** C#\
**Framework / Runtime:** Unity 6000.5.0f1 + Universal Render Pipeline
(URP) + 2D

**Librerías Notables:**

- com.unity.render-pipelines.universal

- com.unity.inputsystem

- com.unity.ugui

- com.unity.timeline

- com.unity.2d.sprite/com.unity.3d.tilemap/com.unity.2d.animation

# 5 estructura de Archivos del Proyecto 

| Carpeta | Descripción |
|----|----|
| **Scripts/** | Lógica jugable: enemigo, bala, soldado, spawner, rutas |
| **Prefabs/** | Enemigos y proyectiles reutilizables |
| **Scenes/** | Escena principal y subcarpeta de niveles |
| **Settings/** | Configuración de render, escenas y pipeline |
| **Sprites/** | Recursos visuales 2D organizados por capítulos |
| **img/** | Imágenes sueltas y assets visuales |
| **Packages/** | Dependencias del proyecto Unity |
| **ProjectSettings/** | Configuración global del editor y del proyecto |

# 6 funcionamiento General 

- Spawner.cs instancia enemigos repetidamente.

- Enemy.cs usa Waypoints.points para moverse por una ruta y se destruye
  al llegar al final o al perder toda la vida.

- Soldier.cs busca el enemigo más cercano dentro de su rango, rota hacia
  él y crea un prefab Bullet.

- Bullet.cs persigue al objetivo y lo destruye al impactar.

# 7 Descripción de Componentes 

7.1 Scripts

Assets/Scripts/Spawner.cs

- Arranca una corrutina en Start().

- Genera enemigos de forma infinita cada tiempoEntreEnemigos.

- Usa enemigoPrefab como prefab de aparición.

Assets/Scripts/Enemy.cs

- Lee la primera posición de Waypoints.points en Start().

- Se mueve hacia el waypoint actual en Update().

- Avanza al siguiente waypoint al acercarse.

- Tiene vida (health) y recibe daño con TakeDamage(int damage).

- Se destruye al llegar al final o al morir.

Assets/Scripts/Waypoints.cs

- Construye un arreglo estático points con los hijos del objeto que lo
  contiene.

- Sirve como ruta compartida para los enemigos.

Assets/Scripts/Soldier.cs

- Busca enemigos con tag "Enemy".

- Elige el más cercano dentro de range.

- Rota el soldado hacia el objetivo.

- Instancia bulletPrefab y le pasa el objetivo con Seek().

- Dibuja el rango en el editor con gizmos.

Assets/Scripts/Bullet.cs

- Guarda un target asignado por Seek().

- Se mueve hacia el objetivo cada frame.

- Si el enemigo desaparece, la bala se destruye.

- Al impactar, destruye al enemigo y a sí misma.

# 8. Prefabs 

| Archivo | Descripción |
|:---|:---|
| **Assets/Prefabs/Bala.prefab** | Prefab de proyectil para el sistema de disparo. |
| **Assets/Prefabs/EnemigoPrueba.prefab** | Prefab de enemigo usado por el spawner. |

## 8.1 Escenas 

**Assets/Scenes/SampleScene.unity**

- Escena principal detectada.

- Contiene al menos:

  - Main Camera

  - Global Light 2D

  - Objeto sprite de fondo/escenario

- No se detectó un sistema de gameplay completo, pero sí la base visual
  y de iluminación.

**Assets/Scenes/niveles/**

- Subcarpeta de niveles (sin escenas internas listadas aún).

# 9. Configuración del Proyecto 

| Archivo | Descripción |
|:---|:---|
| **Assets/Settings/Renderer2D.asset** | Configuración del renderer 2D. |
| **Assets/Settings/UniversalRP.asset** | Asset del pipeline URP del proyecto. |
| **Assets/Settings/Lit2DSceneTemplate.scenetemplate** | Plantilla de escena 2D lit. |

# 10. Recursos Visuales 

**Assets/img/**

Imágenes de personajes, enemigos y otros recursos:

- Soldado1.png

- soldado.png

- Monstruo_acuatico.png

- Monstruo_acuatico1.png

- 1.jpeg

- 2.png

- Carpeta adicional: **Municiones/**

**Assets/Sprites/**

Organización por capítulos:

- capitulo 1/

- capitulo 2/

- capitulo 3/

- capitulo 4/

- capitulo 5/
