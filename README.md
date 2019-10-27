# PEC 1 - Un juego de aventuras

## Fecha de entrega

17 de noviembre de 2019.

## Descripción

Siguiendo el hilo del documento *Un juego de aventuras*, os proponemos que implementéis el duelo de insultos que aparece en el juego Monkey Island y del que podéis ver su funcionamiento en [este vídeo](https://www.youtube.com/watch?v=hc-sxN1OnPg).

El duelo se divide en varios asaltos y cada asalto en un insulto y una respuesta. Gana el jugador que consiga ganar tres asaltos.

Al inicio del duelo, se elige de manera aleatoria quién tiene el turno de juego. En nuestro caso, tendremos dos oponentes: el jugador y el ordenador.

En cada asalto, el jugador que tiene el turno grita un insulto. En el caso del ordenador, la frase debe ser aleatoria.

Una vez se ha presentado el insulto, como, por ejemplo: *"¡Luchas como un ganadero! / ¡Ordeñaré hasta la última gota de sangre de tu cuerpo!"*, el otro jugador tiene que responder con la respuesta correcta (en este caso, la respuesta correcta sería: *“Qué apropiado. Tu peleas como una vaca.”*). Quien gane el asalto obtiene el turno y será quien grite el siguiente insulto.

En el juego original, el jugador va aprendiendo los insultos y sus respuestas a medida que va luchando con otros piratas. En nuestro caso, el jugador ya tiene todas las preguntas y respuestas aprendidas y se le presentarán todas cada vez que vaya a insultar. [Aquí](https://es.wikiquote.org/wiki/El_Secreto_de_Monkey_Island) podéis encontrar los insultos del juego original (podéis ignorar los insultos del Sword Master).
   
Los puntos básicos que debéis implementar son:

- Usar tres escenas de juego: menú (con botones de jugar y salir), juego y final de partida.
- Implementar el bucle de juego usando scripts en C#.
- Determinar quién ha ganado e indicarlo en la pantalla final.
- Volver a la primera pantalla y poder jugar más de una partida sin tener que reiniciar el juego.

Los puntos que valoraremos son:

- Definir una buena estructura de datos para guardar la información del juego.
- Claridad y sencillez en el código.
- Buena documentación y explicación del trabajo realizado.

Los puntos optativos que podéis implementar una vez completados los puntos anteriores son:

- Implementar el juego utilizando una máquina de estados.
- Añadir elementos gráficos (background, sprites, animaciones...).
- Añadir sonidos.
- Leer los insultos y respuestas de un fichero de texto o JSON utilizando el directorio [Resources](https://docs.unity3d.com/ScriptReference/Resources.html) de Unity.