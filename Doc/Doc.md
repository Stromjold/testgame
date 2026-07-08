Documentación de Desarrollo: Tierra de Nadie

Fecha de modificaciones: 07-07-2026 | Fecha de entrega: 17/07/2026

Docente a cargo: Francisco Villarroel

Colaboradores: Derek Philip Lemus Sepúlveda – Luis Alberto González Toledo - Martín Matías Díaz Coloma - Vicente Fernando Cossío Gallardo
Índice

    Estándar de Juego y Metodología de Documentación

    Metodología y Libertad Creativa

    Concepción y Diseño

        3.1 Temática

        3.2 Reglas Core del Juego (Mecánicas)

    Preproducción

        4.1 Idea Inicial

        4.2 Investigación y Referencias

        4.3 Definición de Objetivos

        4.4 Diseño de la Historia

        4.5 Diseño de Personajes

        4.6 Diseño de Escenarios

        4.7 Planificación de Niveles

        4.8 Selección de Herramientas

        4.9 Planificación del Desarrollo (Hitos)

        4.10 Equipo de Trabajo y Orden de Labores

        4.11 Costo de Juego

    Arquitectura de Software del Videojuego

        5.1 Estructura del Proyecto

        5.2 Scripts y Funcionamiento General

    Producción (Capítulo 1 – Nivel 1)

        6.1 Stack Tecnológico

        6.2 Componentes de Escena e Interfaz

    Corrección (Pruebas y QA)

    Expansiones y Nuevas Funcionalidades

    Sección de Estudio: Conceptos Técnicos y de la Industria

1. Estándar de Juego y Metodología de Documentación

Este documento sigue un formato modular estándar para la industria del videojuego, el cual centraliza los aspectos narrativos, técnicos y de gestión.

El estándar y género base seleccionado para el proyecto corresponde a una combinación de Estrategia, Supervivencia y Tower Defense.

La forma de documentar se rige bajo una estructura de carácter iterativo. Esta metodología vincula directamente la preproducción técnica con la lógica de código activa en los repositorios, permitiendo una escalabilidad limpia a medida que se agregan los nuevos capítulos de juego.
2. Metodología y Libertad Creativa

Respecto a la Metodología de Trabajo, se implementó un modelo ágil basado en hitos incrementales establecidos de la siguiente manera: Planificación -> Configuración Base -> Mecánicas Clave -> Integración de Contenido -> QA y Optimización.

La Libertad Creativa del equipo se equilibra mediante la rigidez matemática del sistema de juego (el cual exige rutas fijas de Tower Defense) y la flexibilidad de la narrativa. El uso de Comic Strips al inicio de cada nivel permite al equipo de guion y arte explorar subtramas complejas sobre el colapso biológico sin alterar de ninguna forma la arquitectura del código base.

3. Concepción y Diseño

3.1 Temática
La temática se desenvuelve en un ambiente postapocalíptico desolado tras un desastre nuclear severo. La progresión dramática de la trama culmina con una segunda explosión catastrófica ocurrida en el reactor número 4. Los escenarios exudan radiación, mutación biológica de las especies e instalaciones industriales abandonadas.

3.2 Reglas Core del Juego (Mecánicas)

La mecánica de Gestión de Defensa establece que el jugador debe posicionar soldados fijos de forma estratégica dentro del mapa para repeler las oleadas entrantes.

La regla de Navegación determina que los enemigos aparecen en puntos de origen preestablecidos (spawners) y se desplazan de manera automática por rutas marcadas que son inalterables.

El Loop de Combate dicta que los soldados automatizados atacan al objetivo en rango más cercano, lo que inflige daño a la criatura hasta que el enemigo muere, provocando que el GameManager procese la puntuación correspondiente y evalúe las condiciones de victoria o derrota del nivel.

La Economía de Drops define que los enemigos derrotados liberan ítems interactivos gestionados por el script RecursoDrop.cs. Estos se clasifican en: Cristal, Artefacto, Oscura y Orbe. El jugador debe recolectarlos mediante interacciones físicas utilizando el tag Player para sumar dicho capital al estado global de la partida.
4. Preproducción del Proyecto

4.1 Idea Inicial
El proyecto Tierra de Nadie surge con el objetivo de desarrollar un videojuego orientado a estrategia y supervivencia, ambientado en un mundo postapocalíptico inspirado en un desastre nuclear. La idea principal es que el jugador controle diferentes unidades para enfrentar criaturas mutadas y sobrevivir en entornos contaminados, mientras descubre los hechos que llevaron al colapso de la zona afectada.

4.2 Investigación y Referencias
Antes de comenzar la creación del proyecto, se investigaron referencias narrativas y mecánicas de juego en títulos de estrategia y defensa, incluyendo ejemplos de juegos populares y alternativas de plataformas web. Como resultado del análisis realizado por el equipo, se definió que el género base para el desarrollo sería tower defense.

4.3 Definición de Objetivos
Durante la etapa de planificación se establecieron los siguientes objetivos esenciales: crear un videojuego funcional utilizando Unity, permitir la selección de personajes/unidades para la partida y diseñar una historia dividida formalmente en capítulos. Aunado a esto, se busca implementar distintos niveles de dificultad, incorporar enemigos con comportamientos automáticos, desarrollar un sistema de combate fluido entre soldados y enemigos, y generar una experiencia visual coherente con la temática postapocalíptica.

4.4 Diseño de la Historia
Se definió una narrativa compuesta por cinco capítulos que relatan acontecimientos cronológicos desde el desastre inicial hasta una segunda explosión en el reactor número 4. Cada capítulo representa una etapa distinta y permite al jugador conocer nuevos escenarios, personajes y desafíos. Para facilitar la comprensión de la trama, se incorporan Comic Strips al inicio de cada nivel.

4.5 Diseño de Personajes
Se planificaron tres categorías principales de entidades para el entorno de juego: los Soldados, que actúan como fuerzas defensivas con capacidad de ataque a distancia; los Enemigos mutantes, que corresponden a criaturas afectadas por la radiación que avanzan por rutas fijas; y los Personajes secundarios, que sirven como apoyo narrativo para el desarrollo de la historia.

4.6 Diseño de Escenarios
Los escenarios fueron diseñados en ambientes inspirados en zonas contaminadas, instalaciones abandonadas y áreas afectadas por mutaciones biológicas. Se definieron cinco escenarios principales (uno por capítulo), cada uno con variaciones de dificultad y progresión visual.

4.7 Planificación de Niveles
El juego fue organizado en cinco capítulos bien estructurados. Cada capítulo contempla tres niveles de dificultad: Fácil, Medio y Difícil. En total, se planificaron 15 niveles distribuidos equitativamente de la siguiente manera: Capítulo 1 cuenta con 3 niveles, Capítulo 2 posee 3 niveles, Capítulo 3 integra 3 niveles, Capítulo 4 añade 3 niveles y el Capítulo 5 concluye con 3 niveles.

4.8 Selección de Herramientas
Para el desarrollo técnico se seleccionaron las siguientes herramientas profesionales: Unity 6000.5.0f1 como motor de desarrollo principal, C# como lenguaje de programación, Universal Render Pipeline (URP) para los gráficos 2D, y una estructura estricta de carpetas para el control y organización de recursos.

4.9 Planificación del Desarrollo (Hitos)
Se estableció una metodología de trabajo basada en etapas ordenadas y secuenciales. La primera es Planificación y diseño (Definición de narrativa, estructuración de capítulos en formato de viñetas, diseño preliminar de personajes y escenarios). La segunda es la Configuración del proyecto base (Creación del proyecto test3, setup de URP 2D, organización inicial de carpetas). La tercera corresponde a la Implementación de mecánicas básicas (Desarrollo de la lógica principal: Spawner, Enemy, Soldier, Bullet, Waypoints). Las fases finales comprenden el Desarrollo de niveles individuales, la Integración de recursos visuales finales, las Pruebas y corrección de errores (QA), y la Optimización junto a la documentación final.

4.10 Equipo de Trabajo y Orden de Labores
Las labores se dividieron de forma organizada por roles específicos. La labor de Coordinación y Game Design se encarga de la distribución de tareas, balance de dificultades por nivel y estructuración de flujos de juego. El rol de Programación y Arquitectura asume la escritura de los componentes C# (GameManager, lógicas de combate y recolección) e integración de paquetes del motor. El área de Arte y Animación realiza el diseño de sprites de personajes (Soldado1.png), enemigos (Monstruo_acuatico.png) y desarrollo visual de las viñetas narrativas (Comic Strips). Por último, QA y Documentación realiza el control de versiones en GitHub, testeo de colisiones e interfaces de usuario, y la redacción técnica de los manuales de desarrollo.

4.11 Costo de Juego
Al ser un proyecto de carácter académico e independiente, los costos financieros directos son mínimos ($0 USD en presupuesto de licencias gracias a las versiones Personal de Unity y repositorios públicos de GitHub). El costo real se evalúa en horas de trabajo invertidas por los cuatro colaboradores a lo largo del ciclo de desarrollo, sumado al desgaste y amortización del hardware y equipos de cómputo personales empleados para las sesiones de programación y diseño.

5. Arquitectura de Software del Videojuego
5.1 Estructura de Archivos del Proyecto
La raíz de Assets/ se encuentra estructurada formalmente para permitir el trabajo colaborativo sin conflictos de fusión (merge conflicts):
    Scripts/: Contiene la lógica pura del juego, tales como la IA de enemigos, proyectiles, comportamiento de soldados, spawners y el manejo de rutas.
    Prefabs/: Almacena las plantillas de objetos reutilizables en juego (ej: Bala.prefab, EnemigoPrueba.prefab).
    Scenes/: Aloja la escena de juego general (SampleScene.unity) y las jerarquías ordenadas por capítulos (ej: niveles/cap1/pantallacarga.unity).
    Settings/: Guarda las configuraciones del motor gráfico, incluyendo Renderer2D.asset, UniversalRP.asset y las plantillas de escenas lit.
    Sprites/: Contiene los recursos visuales 2D organizados de forma capitular (desde capitulo 1/ hasta capitulo 5/).
    img/: Destinada al almacenamiento de imágenes globales y assets sueltos de personajes y monstruos.
    Packages/: Contiene el manifiesto de dependencias instaladas en el entorno operativo de Unity.
    ProjectSettings/: Guarda las configuraciones globales del editor (físicas, capas de tags, resoluciones base y configuraciones de compilación).
   
5.2 Scripts y Funcionamiento General
El script Spawner.cs inicia una corrutina repetitiva en su método Start(), la cual instancia de forma continua el prefab EnemigoPrueba.prefab basándose en la tasa de tiempo asignada en la variable tiempoEntreEnemigos.

El componente Waypoints.cs se ejecuta en la fase temprana Awake(), recopilando de forma automática la lista de hijos del objeto contenedor para construir un arreglo estático de vectores denominado points que servirá de ruta global.

El script Enemy.cs, al ser instanciado, lee el primer índice del arreglo Waypoints.points y traslada su Transform frame a frame dentro de la función Update(). Al alcanzar el destino intermedio, muta al siguiente índice, y si su vida (health) cae a 0 mediante la función TakeDamage(int damage), notifica la baja al GameManager y se destruye.

El componente Soldier.cs escanea constantemente el entorno buscando GameObjects que porten el tag "Enemy". Filtra mediante cálculos de distancia al enemigo más cercano dentro de su radio, ejecuta una rotación suave hacia el objetivo y dispara instanciando un proyectil.

El script Bullet.cs recibe la referencia del enemigo a través de una función dedicada llamada Seek(Transform target). Se desplaza directamente hacia él en cada frame; si el objetivo se destruye antes del impacto, la bala se autodestruye de la memoria, pero si impacta con éxito, invoca al método TakeDamage() en la entidad enemiga.

El GameManager.cs actúa como el administrador centralizado del estado del juego estructurado bajo el patrón de diseño Singleton (GameManager.instance). Mantiene en memoria las variables críticas de la partida, tales como los recursos acumulados, enemigos eliminados y los disparadores de actualización de la UI.

El script MenuInteractivo.cs implementa la interfaz física OnMouseDown() sobre colisionadores específicos con el fin de conmutar de manera directa la visibilidad de los elementos en el componente menuCanvas.

El componente ControladorSlideshow.cs lee arreglos de datos de tipo Sprite y los renderiza de forma secuencial en un componente Image de la UI (UGUI) para dar vida a las cinemáticas introductorias tipo cómic mediante el uso de un temporizador.

El script RecursoDrop.cs utiliza el evento nativo del motor OnTriggerEnter2D para comprobar si un elemento con la etiqueta "Player" intercepta el volumen del objeto. En caso afirmativo, añade el tipo de recurso (Cristal, Artefacto, Oscura u Orbe) directamente a las arcas del GameManager y se elimina de la escena.
6. Production (Capítulo 1 – Nivel 1)
6.1 Stack Tecnológico

El motor de ejecución seleccionado es Unity 6000.5.0f1 asistido por la canalización de renderizado URP (Universal Render Pipeline) optimizada para entornos bidimensionales. Los paquetes integrados críticos son:

    com.unity.render-pipelines.universal: Renderizado de luces 2D, materiales lit y fondos ambientales de zonas nucleares.

    com.unity.inputsystem: Arquitectura moderna para la detección de periféricos y clicks del ratón.

    com.unity.ugui & TextMeshPro: Renderizado de fuentes vectoriales de alta definición en interfaces HUD y contadores de recursos.

    com.unity.2d.sprite, com.unity.2d.tilemap & com.unity.2d.animation: Control de mapas de rejilla, capas de ordenado en profundidad y máquinas de estado para animaciones de mutantes y soldados.

    com.unity.timeline: Automatización de las secuencias narrativas.

6.2 Componentes de Escena e Interfaz

La escena inicial de carga (pantallacarga.unity) correspondiente al Capítulo 1 se ha refinado recientemente con las siguientes adiciones:

Se incluyó el objeto UI LogoCarga estructurado de forma jerárquica limpia. Se agregaron textos dinámicos enlazados con TextMeshPro para presentar el nombre del nivel y consejos narrativos contextuales. Por último, se aplicó un escalado adaptativo centrado en pantalla para mantener la uniformidad en múltiples resoluciones de monitor.
7. Corrección (Pruebas y QA)

Las actividades críticas de control de errores registradas formalmente en el sistema de versiones comprenden los siguientes puntos:

En primer lugar, la Verificación de Colisiones con la corrección en las detecciones de recolección de los recursos mutantes (cambio a triggers en RecursoDrop.cs). En segundo lugar, la Depuración de UI aplicando ajustes de anclajes de interfaz gráficos en paneles interactivos y slideshows cinemáticos. Finalmente, el Control de Excepciones de Referencia Nula (NullReferenceException) para asegurar que la destrucción premature de enemigos en ruta no congele las rutinas de persecución de proyectiles (Bullet.cs) mediante condicionales de control de nulos.
8. Expansiones y Nuevas Funcionalidades

La arquitectura del código basada en managers y prefabs modulares garantiza la inyección directa de nuevo contenido:

Por un lado, la Escalabilidad de Capítulos demuestra que el sistema está preparado para recibir la configuración de los capítulos del 2 al 5 de forma nativa mediante la creación de escenas estructuradas con la misma lógica de Waypoints. Por otro lado, los Nuevos Árboles de Habilidades abren la posibilidad de usar los recursos acumulados (Oscura, Orbes) recopilados por el GameManager para implementar una tienda de mejoras en tiempo real para las fuerzas de defensa (Soldados).
9. Sección de Estudio: Conceptos Técnicos y de la Industria
Motores Gráficos: Qué son y cómo funcionan

Un motor gráfico es un entorno de desarrollo de software (framework) diseñado específicamente para la creación y ejecución de videojuegos. En lugar de obligar al programador a escribir instrucciones de bajo nivel para comunicarse con el hardware (tarjeta de video, tarjeta de sonido), el motor actúa como un orquestador que unifica diferentes subsistemas dentro de un bucle infinito llamado Game Loop (que corre idealmente a 60 cuadros por segundo o más).

Sus engranajes clave operan de la siguiente forma:

El Motor de Renderizado (Render Engine) realiza los cálculos matemáticos matriciales para proyectar los objetos geométricos, imágenes (sprites), luces y texturas bidimensionales o tridimensionales en los píxeles finales que despliega tu monitor.

El Motor de Físicas (Physics Engine) calcula las colisiones cinemáticas, la gravedad, la fricción y las fuerzas de los cuerpos en base a geometrías delimitadoras (Colliders).

El Subsistema de Scripting/Lógica compila los archivos de código escrito por el desarrollador (como vuestros scripts de C# en Unity) y los traduce a lenguaje binario comprensible para el procesador (CPU), dándole comportamiento a las entidades físicas creadas.
