**Requisitos:**
- Unity 2020.x.
- Visual Studio.

**Descripción:**

![](https://raw.githubusercontent.com/chloroplastgames/Unity-07Scripting-08Arquitecture-01FunctionalSystems-02DesignProgrammingPatterns-Exercise05/master/readme_resources/screenshot.png "Mock up")

Desarrollo de un videojuego infinito por turnos para un jugador en el que el jugador se enfrenta a un enemigo por combate y cada combate supone un nivel del juego.

Para ello el jugador debe establecer tres acciones en cada turno: Disparar (daña al enemigo), defender (reduce el daño recibido al 50%) o curar (aumenta sus puntos de vida).

Las acciones se establecen pulsando cada uno de los tres botones de la parte inferior, el jugador puede determinar el orden de las acciones. Cada acción supone un consumo de puntos de acción (barra roja de la parte inferior). Las acciones establecidas para el turno no puede superar el límite de puntos de acción del jugador.
Una vez se han establecido las acciones del turno el jugador debe pulsar el botón “OK” para iniciar el turno. Al iniciarse el turno se establecen de manera aleatoria y automática las acciones del enemigo y posteriormente se resuelven las acciones del turno. El orden de resolución de acciones es el siguiente: 1ª acción del enemigo, 1ª acción del jugador, 2ª acción del enemigo, 2ª acción del jugador, 3ª acción del enemigo, 3ª acción del jugador.

Una vez se resuelve el turno se comprueba si el jugador o el enemigo han muerto:
* Si el enemigo no ha muerto se realizará otro turno en el combate hasta que uno de los dos muera
* Si el enemigo ha muerto se avanza de nivel (aumenta en 1 la etiqueta de texto que hay encima del enemigo) y aparece otro enemigo
* Si el jugador muere se reinicia el juego.


**Objetivos:**
1. Crear los siguientes sistemas e implementar el patrón factory:
* Sistema de gestión de la instanciación de enemigos.
2. Estructurar y comentar el código correctamente.
3. Compilar el proyecto de Unity para Windows.


**Procedimientos:**
1. Crear un sistema de gestión de la instanciación de los enemigos teniendo en cuenta diferentes tipos de enemigos aplicando el patrón factory.
2. Finalizar los sistemas auxiliares para cumplir con los requisitos de diseño del juego.
3. Estructurar y comentar el código utilizando las regiones adecuadas y comentarios.
4. El proyecto se debe compilar para ser ejecutado en Windows. La compilación del proyecto se debe guardar en una carpeta llamada "build" en la raíz del proyecto de Unity.