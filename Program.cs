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
        }

        private static void RegistrarFuncion(FuncionRepositorio repo)
        {
            Console.Write("Película: ");
            string pelicula = (Console.ReadLine() ?? "").Trim();

            Console.Write("Sala: ");
            string sala = (Console.ReadLine() ?? "").Trim();

            Console.Write("Precio: ");
            bool precioOk = decimal.TryParse(Console.ReadLine(), out decimal precio);

            if (string.IsNullOrWhiteSpace(pelicula) || string.IsNullOrWhiteSpace(sala) || !precioOk || precio <= 0)
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            Funcion nueva = new Funcion
            {
                Pelicula = pelicula,
                Sala = sala,
                Precio = precio
            };

            repo.Insertar(nueva);
            Console.WriteLine("Función registrada.");
        }

        private static void ListarFunciones(FuncionRepositorio repo)
        {
            List<Funcion> funciones = repo.ListarTodos();

            if (funciones.Count == 0)
            {
                Console.WriteLine("No hay funciones registradas.");
                return;
            }

            decimal totalPrecios = 0;
            foreach (Funcion f in funciones)
            {
                Console.WriteLine(f);
                totalPrecios += f.Precio;
            }

            Console.WriteLine($"TOTAL DE PRECIOS: Q {totalPrecios:N2}");
        }

        private static void BuscarFuncionPorId(FuncionRepositorio repo)
        {
            Console.Write("Id de la función: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Funcion? encontrada = repo.BuscarPorId(id);
            if (encontrada == null)
            {
                Console.WriteLine("No existe ese Id.");
            }
            else
            {
                Console.WriteLine(encontrada);
            }
        }

        private static void ActualizarPrecio(FuncionRepositorio repo)
        {
            Console.Write("Id de la función: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Funcion? existente = repo.BuscarPorId(id);
            if (existente == null)
            {
                Console.WriteLine("No existe ese Id.");
                return;
            }

            Console.Write("Nuevo precio: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) || nuevoPrecio <= 0)
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            existente.Precio = nuevoPrecio;
            if (repo.Actualizar(existente))
            {
                Console.WriteLine("Función actualizada.");
            }
        }

        private static void EliminarFuncion(FuncionRepositorio repo)
        {
            Console.Write("Id de la función: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            if (repo.Eliminar(id))
            {
                Console.WriteLine("Función eliminada.");
            }
            else
            {
                Console.WriteLine("No existe ese Id.");
            }
        }
    }
}