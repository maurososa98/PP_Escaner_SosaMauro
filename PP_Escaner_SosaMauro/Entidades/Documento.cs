using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado;
        string numNormalizado;
        string titulo;
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        /// <summary>
        /// Constructor de la clase <c>Documento</c>.
        /// </summary>
        /// <param name="titulo">Corresponde al titulo del documento</param>
        /// <param name="autor">Corresponde al autor del documento</param>
        /// <param name="anio">Corresponde al año del documento</param>
        /// <param name="numNormalizado">Corresponde al numeronormalizado del documento</param>
        /// <param name="barcode">Corresponde al codigo de barras del documento</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        #region Propiedades
        /// <value> Propiedad Anio corresponde al año del documento.</value>
        public int Anio { get => anio; }

        /// <value> Propiedad Autor corresponde al Autor del documento.</value>
        public string Autor { get => autor; }

        /// <value> Propiedad Barcode corresponde al codigo de barras del documento.</value>
        public string Barcode { get => barcode; }

        /// <value> Propiedad Estado corresponde al estado en que puede estar el documento.</value>
        public Paso Estado { get => estado; }

        /// <value> Propiedad NumNormalizado corresponde al numero normalizado del documento.</value>
        protected string NumNormalizado { get => numNormalizado; }

        /// <value> Propiedad Titulo corresponde al titulo del documento.</value>
        public string Titulo { get => titulo; }
        #endregion

        /// <summary>
        /// Avanza el estado del documento, los estados posibles son: Inicio, Distribuido, EnEscaner, EnRevision, Terminado.
        /// </summary>
        /// <returns> True si logro cambiar el estado, False si el documento ya esta Terminado.</returns>
        public bool AvanzarEstado()
        {
            if (this.estado == Paso.Terminado)
            {
                return false;
            }

            this.estado += 1;

            return true;
        }

        /// <summary>
        /// Guarda en una cadena todos los datos del documento.
        /// </summary>
        /// <returns> Un string con los datos correspondientes al ducumento.</returns>
        public override string ToString()
        {
            string numNormalizado = this is Libro ? $"\nISBN: {this.numNormalizado}" : "";

            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"\nTitulo: {this.titulo}");
            texto.AppendLine($"Autor: {this.autor}");
            texto.AppendLine($"Año: {this.anio}{numNormalizado}");
            texto.Append($"Cód. de barras: {this.Barcode}");

            return texto.ToString();
        }
    }
}
