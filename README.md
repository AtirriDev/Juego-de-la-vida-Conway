   Bienvenido al juego de la vida by Atirri dev. Pablo Caboni Burgos

 Este juego fue creado por el matemático Horton Conway en 1970 , el mismo consta de una dinámica de juego autómata donde desde
 un estado de células (celdas) vivas o muertas, el sistema se va desarrollando automaticamente segun reglas establecidas que te detallare mas adelante junto a un explicativo.


 Consideraciones Generales :

 - El juego se desarrolla en una cuadricula de 2 dimensiones , en este caso va a ser de 16 x 16.

 - Las relaciones que tiene cada célula se dan con 8 vecinos a su alrededor.

 - Las células vivas o muertas al inicio del juego deberán ser elegidas por el jugador junto al numero de turnos que quiera establecer (minimo 5 turno , maximo 20) , luego el juego se desarrollara de forma automata.


Ejemplo de relaciones de una celula


            [R][R][R]
            [R][V][R]
            [R][R][R]

 - [R] representa una celda relacionada (viva o muerta).
 - [V] representa la celda viva que se está analizando.






 REGLAS DEL JUEGO

 NÚMERO 1 : Toda célula viva con menos de 2 vecinos vivos morirá en el próximo turno, ya que no podrá asegurar su descendencia.

 NÚMERO 2 : Toda célula viva con 2 o 3 vecinos vivos a su alrededor seguirá viva en el próximo turno, porque son células sociales.

 NÚMERO 3 : Toda célula viva con más de 3 vecinos vivos a su alrededor morirá por sobrepoblación en el próximo turno, ya que la comida no alcanza para todos.

 NÚMERO 4 : Toda célula muerta puede revivir si tiene exactamente 3 vecinos vivos a su alrededor , y si hay que ponerle un poco de fantasia zombie al sistema.


 **Consideracion importante el juego esta desarrolado con  C# en .net 8.0 , para probarlo usar la version de visual studio 2022**
