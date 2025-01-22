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
