# PEC 1 - Un juego de aventuras

## Normas de juego

Ayuda a Robert René-Robert Cavelier a dejar descolocada a la pesada de Morgan le Fay. Para conseguirlo hay que ganar un reto de insultos.

Para ganar hay que responder correctamente a los insultos que nos lanzará Morgan.

### Como jugar
La acción principal del juego se desarrolla en el cuadro de selección de insultos y respuestas. Cuando sea Morgana quien te insulte, escoge del cuadro de selección la respuesta apropiada para el insulto lanzado. Cuando seas tu quien vaya a lanzar un insulto, realiza el mismo proceso.

No te preocupes, estarás informado en todo momento si tienes que lanzar un insulto o una respuesta. Pero vigila!, quien falle la respuesta dará un punto a su oponente, y sólo se permite fallar 3 veces. De la misma forma, si la respuesta es correcta, el punto es para tí!

## Estructura de los Assets
Se compone de cuatro carpetas, Prefabs, Resources, Scenes y Scripts.
* Prefabs: Contiene botones y elementos que se usan múltiples veces.
* Resources: Todas las imágenes, sonidos y JSON están aquí recogidos.
* Scenes: Contiene las tres escenas del juego.
* Scripts: Contiene todos los scripts que definen el funcionamiento del juego.

Los puntos principales del desarrollo se pueden definir en: Hay una clase principal *GamePlayerManager* que gestiona el funcionamiento principal del juego. Desde esta clase se resuelvo el flujo de los turnos, se carga toda la información y se determina si las respuestas son correctas y quien es el ganador del juego.
Por otro lado hay una serie de clases secundarias que se encargan de tareas más concretas. Como por ejemplo:
* **GameNavigation**: Dirige el juego a la vista correspondiente
* **CrossData**: Contiene datos que son requeridos desde cualquier escena.
* **Insult / Insults**: Son las clases que definen la estructura de los datos recogidos en el JSON.
* **LoadResources**: Se encarda de obtener los datos JSON
* **Machine**: Tiene toda la lógica de la computadora como jugador.
* **PointsCounter**: Maneja el control de puntos y define cuando hay un ganador
* **TurnManager**: Tiene el control de quin dispone de la posesión del turno. Se encarga de mostrar esa información en pantalla.


## Preview
[Ver archivo en mp4](https://gitlab.com/Somo86/albertsomoza-pec1/-/blob/master/un_juego_de_aventuras.mp4)
## Repositorio
[AlbertSomoza-PEC1](https://gitlab.com/Somo86/albertsomoza-pec1)