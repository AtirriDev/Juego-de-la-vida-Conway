
using System;
using System.ComponentModel.Design;
Console.WriteLine("");



//VARIABLES DE COMIENZO

string[,] Matriz = new string[16, 16];
int fila = 0;
int columna = 0;

// Hay un minimo de 10 celulas vivas a elegir , por eso usaremos esta variable como contador 
var celuvasVivas = 0;

//Bandera repetitiva central del programa 
Boolean Reiniciar = true;



// bandera para controla la carga de datos 

Boolean controlador = false;

// Matriz para mostrar un mini ejemplo de las relaciones de la celula

string[,] ejemplo = new string[3, 3];

// llenado
for (int f = 0; f < 3; f++)
{
    for (int c = 0; c < 3; c++)
    {
        Matriz[f, c] = "R";

        if (Matriz[f, c] == Matriz[1 , 1])
        {
            Matriz[f, c] = "V";
        }
    }
}











Console.ForegroundColor = ConsoleColor.Red;
Console.Write("   Bienvenido al juego de la vida");
Console.ResetColor();
Console.Write(" by Atirri dev. Pablo Caboni Burgos");
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine(" Este juego fue creado por el matemático Horton Conway en 1970 ," +
    " el mismo consta de una dinámica de juego autómata donde desde ");
Console.WriteLine(" un estado de células (celdas) vivas o muertas, " +
    "el sistema se va desarrollando automaticamente segun reglas establecidas que te detallare mas adelante junto a un explicativo.");


Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" Consideraciones Generales :  ");
Console.ResetColor();
Console.WriteLine("");
Console.WriteLine(" - El juego se desarrolla en una cuadricula de 2 dimensiones , en este caso va a ser de 16 x 16.");
Console.WriteLine("");
Console.WriteLine(" - Las relaciones que tiene cada célula se dan con 8 vecinos a su alrededor.");
Console.WriteLine("");
Console.WriteLine(" - Las células vivas o muertas al inicio del juego deberán ser elegidas por el jugador junto al numero de turnos que quiera establecer (minimo 5 turno , maximo 20) , luego el juego" +
                    " se desarrollara de forma automata. ");
Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Ejemplo de relaciones de una celula");
Console.ResetColor();

Console.WriteLine("");
MostrarMatrizEjemplo();
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(" - [R] representa una celda relacionada (viva o muerta).\r\n - [V] representa la celda viva que se está analizando.");
Console.ResetColor();
Console.WriteLine("");
Console.WriteLine("");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(" Presione enter para conocer las reglas del juego ");
Console.ResetColor();
Console.ReadLine();


Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" REGLAS DEL JUEGO ");
Console.ResetColor();
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write(" NÚMERO 1 :");
Console.ResetColor();
Console.Write(" Toda célula viva con menos de 2 vecinos vivos morirá en el próximo turno, ya que no podrá asegurar su descendencia.  ");
Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write(" NÚMERO 2 :");
Console.ResetColor();
Console.Write(" Toda célula viva con 2 o 3 vecinos vivos a su alrededor seguirá viva en el próximo turno, porque son células sociales.");
Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write(" NÚMERO 3 :");
Console.ResetColor();
Console.Write(" Toda célula viva con más de 3 vecinos vivos a su alrededor morirá por sobrepoblación en el próximo turno, ya que la comida no alcanza para todos.");
Console.WriteLine("");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write(" NÚMERO 4 :");
Console.ResetColor();
Console.Write(" Toda célula muerta puede revivir si tiene exactamente 3 vecinos vivos a su alrededor , y si hay que ponerle un poco de fantasia zombie al sistema.");
Console.WriteLine("");
Console.WriteLine("");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(" Presione enter para comenzar el juego ");
Console.ResetColor();

Console.ReadLine();
Console.WriteLine("");

//Aca le damos comienzo a toda la ejecucion del programa 
while (Reiniciar == true )
{
    //Llenar la cuadricula para inicio , con todas las posiciones sin celulas vivas 
    CargarMatrizComienzo();

    try
    {
        while (controlador != true)
        {
            Console.WriteLine("");
            Console.WriteLine(" Por favor indique el numero de turnos que desea jugar ?");
            Console.WriteLine(" Recuerde que el mínimo es de 5 turnos y el mínimo de 20 ?");

            var entrada= Console.ReadLine();

            if (string.IsNullOrEmpty(entrada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Por favor ingrese solo numeros para asignar el numero de turnos ");
                Console.ResetColor();
            }
            else
            {
                // pasamos la entrada a int y le asignamos como nombre la variable turnos 
                if (int.TryParse(entrada, out int turnos))
                {
                    if (turnos < 5 || turnos > 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine(" Turnos fuera del rango por favor vuelva a elegir");
                        Console.ResetColor();
                    }
                    else
                    {
                        controlador = true;
                        Console.WriteLine(" Ahora toca elegir las celulas vivas que tendra el sistema ");
                        //Mostar la grilla y el metodo para seleccionar celulas vivas 
                        Console.WriteLine("");
                        Console.WriteLine(" Pero primero le voy a mostrar la cuadricula , [M] simbolizara células muertas , [V] células vivas ");
                        Console.WriteLine(" Las posiciones van del 0 al 15 a nivel horizontal como vertical , siendo su interseccion la celda elegida  ");
                        Console.WriteLine("");
                        Console.WriteLine("");


                        //Metodo para mostrar la cuadricula
                        MostrarCuadricula();
                        
                        Console.WriteLine("");
                        Console.WriteLine("Ahora si vamos a elegir las células vivas ");

                        //metodo para la eleccion de celulas vivas 
                        EleccionCelulasVivas(celuvasVivas);

                        // Aqui ya mostrariamos la cuadricula y dsp empezaria la simulacion 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Asi ha quedado conformado el sistema inicial ");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        MostrarCuadricula();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("¿ Preparado para ver el juego de la vida en funcionamiento ? , Presiona enter si es asi");
                        Console.ResetColor();
                        int contadorTurnos = 1;
                        
                        while (contadorTurnos <= turnos)
                        {
                           
                            Console.ReadLine(); 

                            Console.WriteLine($"TURNO NUMERO : {contadorTurnos} ");


                            //Aca va a tener que ir le metodo que muestre nuevamente la cuadricula actualizada

                           

                            Matriz = ProcesarMatriz(Matriz);

                            //Mostrar 
                            MostrarCuadriculaAUX(Matriz);
                           
                            if (contadorTurnos < turnos)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;  
                                Console.WriteLine("Presione una tecla para ver el proximo turno");
                                Console.ResetColor();
                            }
                            else
                            {


                                Console.ForegroundColor = ConsoleColor.Green;   
                                Console.WriteLine("Hemos llegando al final del juego , gracias por dejar jugar a este sistema automata");

                                //Preguntar si quiere volver a jugar y ver la forma de reiniciar la cuadricula 
                                Reiniciar = false;
                                
                                
                                return;
                            }

                            contadorTurnos++;


                        }


                    }
                }
                else
                {
                    // si no lo puede convertir es por que mandaron letras o simbolos entonces avisamos que lo arregle

                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor ingresar solo numeros para asignar los turnos a jugar ");
                    Console.ResetColor();
                }

                
            }
               

           





        }

        
    }
    catch (Exception)
    {

        throw;
    }
    // Empezamos con la asignacion de turnos a jugar 
   
   
    
    
}

void CargarMatrizComienzo() 
{
    for (int f = 0; f < 16; f++) // Filas
    {

        for (int c = 0; c < 16; c++) // columnas
        {
            Matriz[f, c] = "M";

        }
        

    }
    


}


void MostrarCuadricula() 
{
    
    Console.WriteLine("");
   
    Console.ForegroundColor = ConsoleColor.Red;

    for (int f = 0; f < 16 ; f++) // Filas
    {
        
        for (int c = 0; c < 16; c++) // columnas
        {
            if (Matriz[f,c] == "M")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + Matriz[f, c] + "]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[" + Matriz[f, c] + "]");
                Console.ResetColor();
            }
          
            
        }
        Console.WriteLine();

    }


   

}

void MostrarCuadriculaAUX(string[,] MatrizAux)
{
    string[,] cuadricula = new string[16, 16];

    cuadricula = MatrizAux;
   
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Red;

    for (int f = 0; f < 16; f++) // Filas
    {

        for (int c = 0; c < 16; c++) // columnas
        {
            if (cuadricula[f, c] == "M")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + cuadricula[f, c] + "]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[" + cuadricula[f, c] + "]");
                Console.ResetColor();
            }


        }
        Console.WriteLine();

    }




}

void EleccionCelulasVivas(int ContadorCelulas) 
{
   

    //Bandera para la eleccion de celdas
    Boolean EleccionCeldasVivas =false;

    // Mientras la bandera sea false y el numero de celulas vivas elegidas sea menor de 10 estaremos en la repetitiva
    while (EleccionCeldasVivas != true)
    {
        if (ContadorCelulas >= 5) // si la celulas vivas superan el minimo debemos preguntar si quiere seguir agregando
        {
            Console.WriteLine("Ya ha llegado al limite minimo de células vivas -¿ Desea seguir agregando ? ");
            Console.WriteLine("Si en caso afirmativo , Cualquier tecla para comenzar con el juego ");

            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                EleccionCeldasVivas = false;
            }
            else
            {
               
                EleccionCeldasVivas = true;
                return;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Eliga la ubicacion de la célula viva ");

       


        Console.WriteLine("Para ello primero indique el numero de fila (0 a 15 ) ");


        string? entradaFila = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Ahora indique el numero de columna(0 a 15 ) ");
        string? entradaColumna = Console.ReadLine();
       
        if (string.IsNullOrEmpty(entradaFila) || string.IsNullOrEmpty(entradaColumna))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe completar correctamente el campo fila y columna");
           
            Console.ResetColor();
           
        }

        if (int.TryParse(entradaFila , out int f) && (int.TryParse(entradaColumna, out int c)))
        {
            fila = f;
            columna = c;




            if (fila >= 0 && fila <= 15)
            {
                if (columna >= 0 && columna <= 15)
                {
                    //Aca quiere decir que todo esta bien entonces seguimos 
                    // Asignar la celula viva a la cuadricula 

                    if (AsignarCeldaViva())
                    {
                        ContadorCelulas++;
                    }
                        

                       
                        
                        MostrarCuadricula();
                    Console.WriteLine("");
                    Console.WriteLine($"Lleva {ContadorCelulas} células vivas elegidas , recuende que el minimo es 5 celulas para el sistema");



                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Celda no valida , revise y vuelva a intentar");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Numero de fila no es valido, revise y vuelva a intentar");
                Console.ResetColor();
                Console.WriteLine("");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por favor debe ingreasar solo numeros ");
            Console.WriteLine("");
            Console.ResetColor();
        }



















    }






   
}


bool AsignarCeldaViva() 
{

    if (Matriz[fila, columna] == "M") // si el lugar en la matriz elegido es igual a [M] , ocea que es una celula muerta 
    {
        // La pasamos a celula Viva 
        Console.ForegroundColor = ConsoleColor.White;
        Matriz[fila, columna] = "V";

        
      
        Console.ResetColor();
        return true;
       
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("La celda seleccionada ya contiene una célula viva , por favor elija nuevamente ");
        Console.ResetColor();
        Console.WriteLine("");
        return false;
        
    }

   




    return true;

}


string[,] ProcesarMatriz(string[,] Matriz)

{
    string[,] nuevaMatriz = new string[16, 16];

    // Copiar los valores de la matriz original a la nueva
    for (int f = 0; f < 16; f++)
    {
        for (int c = 0; c < 16; c++)
        {
            nuevaMatriz[f, c] = Matriz[f, c];
        }
    }

    for (int f = 0; f < 16; f++) // recorrer fila 
    {
        for (int c = 0; c < 16; c++) // recorrer columna
        {
           
           
            int vecinosVivos = ContarVecinosVivos(Matriz, f, c); // Metodos de fijarnos cuantos vecinos tiene 
            // lo hacemos con la matriz que recibimos por parametro ya que esta no la modificamos 
           
           
            if (Matriz[f, c] == "V")
            {
                // Regla 1 y 3
                if (vecinosVivos < 2 || vecinosVivos > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    nuevaMatriz[f, c] = "M"; // Muere

                    Console.ResetColor();
                }
                else /* (regla 2  x deducccion) */
                {   
                    nuevaMatriz[f, c] = "V"; // Sobrevive
                }
            }
            else
            {
                // Regla 4
                if (vecinosVivos == 3)
                {
                    nuevaMatriz[f, c] = "V"; // Revive
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    nuevaMatriz[f, c] = "M"; // Permanece muerta
                    Console.ResetColor();
                }
            }
        }
    }

    return nuevaMatriz;
}

int ContarVecinosVivos(string[,] matriz, int fila, int columna)
{
    int[] direcciones = { -1, 0, 1 };
    int contador = 0;

    foreach (int df in direcciones) // Desplazamiento en fila
    {
        foreach (int dc in direcciones) // desplazamiento columna
        {
            if (df == 0 && dc == 0) continue; // Ignorar la celda seleccionada (el vecino no puede ser el mismo)

            int nuevaFila = fila + df;
            int nuevaColumna = columna + dc;

            // Verificar que la celda este dentro de los limites de la matriz
            if (nuevaFila >= 0 && nuevaFila < 16 && nuevaColumna >= 0 && nuevaColumna < 16)
            {
                if (matriz[nuevaFila, nuevaColumna] == "V")
                {
                    contador++;
                }
            }
        }
    }

    return contador;
}


void MostrarMatrizEjemplo() 
{
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.Red;

    for (int f = 0; f < 3; f++) // Filas
    {

        for (int c = 0; c < 3; c++) // columnas
        {
            if (Matriz[f, c] == "M")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + Matriz[f, c] + "]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[" + Matriz[f, c] + "]");
                Console.ResetColor();
            }


        }
        Console.WriteLine();

    }



}
;

    // Patrón de prueba: Glider , para hacer la prueba 
   

    //  matrizInicial[1, 2] = "V";
    //  matrizInicial[2, 3] = "V";
    //  matrizInicial[3, 1] = "V";
    //  matrizInicial[3, 2] = "V";
    //  matrizInicial[3, 3] = "V";



