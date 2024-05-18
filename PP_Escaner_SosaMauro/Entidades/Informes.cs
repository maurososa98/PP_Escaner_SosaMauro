using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;
using static Entidades.Escaner;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDistribuidosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        private static void MostrarDistribuidosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"\t Informe Documentos (tipo {e.Tipo}): Estado {estado}");
            switch (e.Tipo)
            {
                case TipoDoc.mapa:
                    foreach (Mapa mapa in e.ListaDocumentos)
                    {
                        if (mapa.Estado == estado)
                        {
                            extension += mapa.Superficie;
                            cantidad += 1;
                            resumen += mapa.ToString();
                        }
                    }
                    texto.AppendLine(resumen);
                    texto.AppendLine($"Extensión: {extension} cm2");
                    texto.AppendLine($"Cantidad: {cantidad} mapas");
                    break;

                case TipoDoc.libro:
                    foreach (Libro libro in e.ListaDocumentos)
                    {
                        if (libro.Estado == estado)
                        {
                            extension += libro.NumPaginas;
                            cantidad += 1;
                            resumen += libro.ToString();
                        }
                    }
                    texto.AppendLine(resumen);
                    texto.AppendLine($"Extensión: {extension} páginas");
                    texto.AppendLine($"Cantidad: {cantidad} libros");
                    break;
            }
            Console.WriteLine(texto.ToString());
        }
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDistribuidosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDistribuidosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDistribuidosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
