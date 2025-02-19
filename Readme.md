# Roll A Ball Demo
*Esteban Montes* - *2 DAM* - *PMDM*

### Actualmente se encuentra en construcción... Este readme se actualizará a medida que se avance más en el desarrollo.

## SCRIPTS
>[!IMPORTANT]Scripts
Para acceder a la carpeta ```Scripts```, haz click en ```Assets``` y te aparecerá en el penúltimo puesto.

Ahora vamos a ver los scripts que hacen que se mueva el jugador y los distintos tipos de cámaras:

## 1. PlayerController
* [Script del Player](Assets/Scripts/PlayerController.cs) 

### *Descripción básica del Script*
Este código define un controlador para un jugador que puede moverse con las flechas del teclado, recoger objetos, y detectar colisiones. Se emplea un Rigidbody para mover al jugador físicamente y detectar colisiones con objetos etiquetados como "PickUp" o "Enemy". Un contador actualiza y muestra la cantidad de objetos recogidos, activando un mensaje de victoria al alcanzar un límite. Si el jugador colisiona con un enemigo, se destruye el jugador y muestra un mensaje de derrota. El movimiento está restringido a las teclas de flecha.

## 2. CameraController
* [Script de la camara en tercera persona](Assets/Scripts/CameraController.cs)

### *Descripción básica del Script*
Este código crea un controlador para que una cámara siga a un jugador manteniendo una distancia fija (offset). En el método Start, se calcula la distancia inicial entre la cámara y el jugador, y en LateUpdate se actualiza la posición de la cámara para que coincida con la del jugador más el offset, asegurando un seguimiento suave.

## 3. FirstPersonController
* [Script de la camara en primera persona](Assets/Scripts/FirstPersonController.cs)

### *Descripción básica del Script*
Este código implementa un controlador de cámara en primera persona que se mueve y rota según las teclas de flecha presionadas. La dirección del movimiento se calcula con las teclas, y la cámara rota suavemente hacia esa dirección utilizando interpolación (Quaternion.Slerp). Además, la posición de la cámara se actualiza para avanzar en la dirección calculada, creando un movimiento y orientación coherentes.
  
## 4. CameraSwitcher
* [Script para cambiar de camara](Assets/Scripts/CameraSwitcher.cs)

### *Descripción básica del Script*
Este código implementa un sistema para alternar entre múltiples cámaras en una escena. Un arreglo almacena las cámaras configuradas, y solo una está activa al inicio. Al presionar la tecla "C", se desactiva la cámara actual y se activa la siguiente en el arreglo, creando un ciclo circular entre ellas. El método ActivateCamera asegura que solo la cámara seleccionada esté habilitada en cada momento.

## 5. EnemyMovement
* [Script que controla a un enemigo](Assets/Scripts/EnemyMovement.cs)

### *Descripción básica del Script*
Este código permite que un enemigo persiga al jugador utilizando NavMeshAgent en Unity. Primero, obtiene una referencia al jugador y al componente NavMeshAgent. En cada fotograma (Update), el enemigo establece como destino la posición del jugador, lo que hace que lo siga automáticamente por el escenario, evitando obstáculos.

El sistema funciona siempre que el escenario tenga un NavMesh generado y que el enemigo tenga un componente NavMeshAgent configurado.

## 6. Proyectil
* [Script que controla los lanzamientos de los proyectiles enemigos](Assets/Scripts/Proyectil.cs)

### *Descripción básica del Script*
Este código controla el movimiento y las colisiones de un proyectil en Unity. En cada fotograma, el proyectil avanza en línea recta con una velocidad determinada.

Si colisiona con un objeto que tiene el tag "Player" o "Walls", se destruye automáticamente. Esto permite que los proyectiles desaparezcan al impactar al jugador o a una pared, evitando que sigan en la escena innecesariamente.

## 7. RampBoost
* [Script que controla el boost de las rampas](Assets/Scripts/RampBoost.cs)

### *Descripción básica del Script*
Este código proporciona un impulso al jugador cuando entra en contacto con una rampa. Al detectar que un objeto con el tag "Player" colisiona con el trigger, obtiene su Rigidbody y aplica una fuerza en la dirección combinada de la normal de la rampa y la dirección de la rampa.

El impulso se aplica con ForceMode.Impulse para que el efecto sea inmediato. Este sistema permite que el jugador reciba un empuje natural al tocar la rampa, ideal para mecánicas de plataformas o velocidad.

## 8. Torreta
* [Script del enemigo que lanza proyectiles](Assets/Scripts/Torreta.cs)

### *Descripción básica del Script*
Este código controla una torreta que detecta al jugador y dispara proyectiles en su dirección a intervalos regulares.

En Start(), busca al jugador usando el tag "Player".
En Update(), verifica si el jugador existe y, si ha pasado el tiempo necesario, dispara un proyectil.
En Shoot(), se calcula la dirección hacia el jugador y se instancia un proyectil con una rotación que lo haga apuntar correctamente.
La torreta disparará automáticamente mientras el jugador esté en escena, asegurando que cada proyectil se dirija hacia su posición actual.

## 9. Rotator
* [Script que controla la rotación del los Pick ups](Assets/Scripts/Rotator.cs)

### *Descripción básica del Script*
Este código hace que un objeto rote constantemente en los tres ejes (X, Y, Z) en cada fotograma.

En Update(), la función transform.Rotate() aplica una rotación basada en el tiempo (Time.deltaTime), lo que asegura que la velocidad de rotación sea constante e independiente de los FPS.
La rotación se realiza con los valores (15, 30, 45), lo que hace que el objeto gire de manera uniforme en todas las direcciones.
Este script es útil para crear efectos visuales como objetos flotantes, power-ups giratorios o decoraciones dinámicas en la escena. 

## 10. ReiniciarJugador
* [Script que hace reaparecer al jugador al inicio del nivel](Assets/Scripts/ReiniciarJugador.cs)

### *Descripción básica del Script*
Este código detecta cuando el jugador entra en contacto con un trigger y lo teletransporta a un punto de reinicio predefinido.

puntoDeReinicio es un objeto en la escena que define la posición a la que se enviará al jugador.
OnTriggerEnter(Collider other) detecta si el objeto que entra en el trigger tiene el tag "Player".
Si es el jugador, su posición se actualiza a la de puntoDeReinicio.
Este sistema es útil para checkpoints, límites de caída o zonas de reinicio en plataformas y juegos de aventura. 


# FUNCIONAMIENTO DEL JUEGO

* ## CÓMO JUGAR
    * **MOVIMIENTO**: Flechas direccionales
    * **SALTO**: Espacio
    * **CÁMARA**: "C"

* ## OBJETIVO
    El objetivo del juego es recoger todos los Pick Ups. Hay en total 3 Pick Ups, uno en cada zona del mapa. Tendrás que recogerlos sin que te pille el enemigo o sin que te tiren con sus proyectiles

# GAMEPLAY EN DIRECTO

## PRIMER VISTAZO

![Primer Vistazo al juego](videos/giphy.gif)