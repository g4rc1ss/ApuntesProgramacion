﻿using Singleton;

var patron1 = PatronSingleton.GetInstance();
patron1.Nombre = "Prueba1";
Console.WriteLine(patron1.Nombre);

var patron2 = PatronSingleton.GetInstance();
Console.WriteLine(patron2.Nombre);

patron2.Nombre = "Modificando nombre";

Console.WriteLine(patron1.Nombre);
Console.WriteLine(patron2.Nombre);
