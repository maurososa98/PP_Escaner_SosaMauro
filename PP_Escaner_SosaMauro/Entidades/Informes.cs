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

            foreach (Documento documento in e.ListaDocumentos)
            {
                if (documento.Estado == estado)
                {
                    cantidad += 1;
                    resumen += documento.ToString();
                    if (documento is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                    }
                    else if (documento is Libro libro)
                    {
                        extension += libro.NumPaginas;
                    }
                }
            }

            string textoExtencion = e.Tipo == TipoDoc.mapa ? $"Extensión: {extension} cm2" : $"Extensión: {extension} páginas";
            string textoCantidad = e.Tipo == TipoDoc.mapa ? $"Cantidad: {cantidad} mapas" : $"Cantidad: {cantidad} libros";

            texto.AppendLine(textoExtencion);
            texto.AppendLine(textoCantidad);
            texto.AppendLine(resumen);
            
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
