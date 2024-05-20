using Entidades;
using static Entidades.Informes;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int extension;
            int cantidad;
            string resumen;

            Console.WriteLine($"\n########################################## LIBROS ###############################################################\n");

            Escaner escaner_libros = new Escaner("Samsung", Escaner.TipoDoc.libro);

            //// Libros iguales -> codebar iguales
            Libro libro_1 = new Libro("luces de bohemia", "hugo", 1995, "4565", "22222", 20);
            Libro libro_2 = new Libro("crimen y castigo", "mateo", 1980, "8468", "22222", 30);
            //bool estado = libro_1 == libro_2;
            //Console.WriteLine($"{estado}");

            //// Libros iguales -> numNormalizado iguales
            Libro libro_3 = new Libro("100 años de Soledad", "Lucas", 1970, "9611", "44444", 40);
            Libro libro_4 = new Libro("La casa de los espíritus", "Leo", 1985, "9611", "55555", 50);
            //bool estado_2 = libro_3 == libro_4;
            //Console.WriteLine($"{estado_2}");

            //// Libros iguales -> titulo y autor iguales
            Libro libro_5 = new Libro("Preludio a la fundación", "Daniel", 1950, "9846", "66666", 60);
            Libro libro_6 = new Libro("Preludio a la fundación", "Daniel", 1951, "9846", "77777", 70);
            //bool estado_3 = libro_5 == libro_6;
            //Console.WriteLine($"{estado_3}");

            // Agregar libros
            bool ingreso_1 = escaner_libros + libro_1;
            bool ingreso_2 = escaner_libros + libro_3;
            bool ingreso_3 = escaner_libros + libro_5;

            // Agregar libros duplicados
            bool ingreso_4 = escaner_libros + libro_2;
            bool ingreso_5 = escaner_libros + libro_4;
            bool ingreso_6 = escaner_libros + libro_6;

            Console.WriteLine($"{ingreso_1}");
            Console.WriteLine($"{ingreso_2}");
            Console.WriteLine($"{ingreso_3}");

            Console.WriteLine($"{ingreso_4}");
            Console.WriteLine($"{ingreso_5}");
            Console.WriteLine($"{ingreso_6}");

            MostrarDistribuidos(escaner_libros, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_1));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_3));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_5));

            MostrarEnEscaner(escaner_libros, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_1));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_3));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_5));

            MostrarEnRevision(escaner_libros, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_1));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_3));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_5));

            MostrarTerminados(escaner_libros, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_1));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_3));
            Console.WriteLine(escaner_libros.CambiarEstadoDocumento(libro_5));




            Console.WriteLine($"\n########################################## MAPAS ###############################################################\n");

            Escaner escaner_mapas = new Escaner("Hp", Escaner.TipoDoc.mapa);

            //// Mapas iguales -> codebar iguales
            Mapa mapa_1 = new Mapa("Mundo", "Instituto de geografia 1", 1995, "", "22222", 20, 70);
            Mapa mapa_2 = new Mapa("Buenos Aires", "Instituto de geografia 2", 1980, "", "22222", 30, 80);
            //bool estado_4 = mapa_1 == mapa_2;
            //Console.WriteLine($"{estado_4}");

            //// Mapas iguales -> titulo, autor, año, superficie iguales
            Mapa mapa_3 = new Mapa("Cordoba", "Instituto de geografia 3", 1970, "", "44444", 40, 90);
            Mapa mapa_4 = new Mapa("Cordoba", "Instituto de geografia 3", 1970, "", "55555", 40, 90);
            //bool estado_5 = mapa_3 == mapa_4;
            //Console.WriteLine($"{estado_5}");

            // Agregar mapas
            bool ingreso_7 = escaner_mapas + mapa_1;
            bool ingreso_8 = escaner_mapas + mapa_3;

            // Agregar mapas duplicados
            bool ingreso_9 = escaner_mapas + mapa_2;
            bool ingreso_10 = escaner_mapas + mapa_4;

            Console.WriteLine($"{ingreso_7}");
            Console.WriteLine($"{ingreso_8}");

            Console.WriteLine($"{ingreso_9}");
            Console.WriteLine($"{ingreso_10}");

            MostrarDistribuidos(escaner_mapas, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_1));
            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_3));

            MostrarEnEscaner(escaner_mapas, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_1));
            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_3));

            MostrarEnRevision(escaner_mapas, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_1));
            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_3));

            MostrarTerminados(escaner_mapas, out extension, out cantidad, out resumen);

            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_1));
            Console.WriteLine(escaner_mapas.CambiarEstadoDocumento(mapa_3));





            Console.WriteLine($"\n#########################################################################################################\n");

            Console.WriteLine(extension);
            Console.WriteLine(cantidad);
            Console.WriteLine(resumen);
            Console.WriteLine($"{escaner_libros.Locacion}");
            Console.WriteLine($"{escaner_mapas.Locacion}");





        }
    }
}
