using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CarteleraCine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FuncionRepositorio repo = new FuncionRepositorio();
            string opcion;

            do
            {
                opcion = LeerOpcionMenu();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            RegistrarFuncion(repo);
                            break;
                        case "2":
                            ListarFunciones(repo);
                            break;
                        case "3":
                            BuscarFuncionPorId(repo);
                            break;
                        case "4":
                            ActualizarPrecio(repo);
                            break;
                        case "5":
                            EliminarFuncion(repo);
                            break;
                        case "6":
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error de base de datos: {ex.Message}");
                }

            } while (opcion != "6");
        }

        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== CARTELERA DE CINE ===");
            Console.WriteLine("1. Registrar función");
            Console.WriteLine("2. Listar funciones");
            Console.WriteLine("3. Buscar función por Id");
            Console.WriteLine("4. Actualizar precio");
            Console.WriteLine("5. Eliminar función");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine() ?? "";
   