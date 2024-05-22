using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        /// <summary>
        /// Constructor de la clase <c>Libro</c>.
        /// </summary>
        /// <param name="titulo">Corresponde al titulo del libro</param>
        /// <param name="autor">Corresponde al autor del libro</param>
        /// <param name="anio">Corresponde al año del libro</param>
        /// <param name="numNormalizado">Corresponde al numeronormalizado del libro</param>
        /// <param name="codebar">Corresponde al codigo de barras del libro</param>
        /// <param name="numPaginas">Corresponde al numero de paginas del libro</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        #region Propiedades

        /// <value> Propiedad ISBN corresponde al numero normalizado del libro</value>
        public string ISBN { get => this.NumNormalizado; }

        /// <value> Propiedad NumPaginas corresponde al numero de paginas del libro</value>
        public int NumPaginas { get => numPaginas; }
        #endregion

        /// <summary>
        /// Sobrecarga del operador <c>!=</c> que comprueba que dos libros no son iguales.
        /// </summary>
        /// <param name="l1">Primer libro a analizar</param>
        /// <param name="l2">Segundo libro a analizar</param>
        /// <returns>True si los libros no tienen el mismo barcode o no tienen el mismo ISBN o no tienen el mismo título y el mismo autor, de lo contrario False </returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        /// <summary>
        /// Sobrecarga del operador <c>==</c> que comprueba que dos libros son iguales.
        /// </summary>
        /// <param name="l1">Primer libro a analizar</param>
        /// <param name="l2">Segundo libro a analizar</param>
        /// <returns>True si los libros tienen el mismo barcode o tienen el mismo ISBN o tienen el mismo título y el mismo autor, de lo contrario False </returns>
        public static bool operator ==(Libro l1, Libro l2)
        {
            return (l1.Barcode == l2.Barcode) ||
                   (l1.ISBN == l2.ISBN) ||
                   ((l1.Titulo == l2.Titulo) && (l1.Autor == l2.Autor));
        }

        /// <summary>
        /// Guarda en una cadena todos los datos del libro.
        /// </summary>
        /// <returns> Un string con los datos correspondientes al libro.</returns>
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine(base.ToString());
            texto.AppendLine($"Número de páginas: {this.numPaginas}");

            return texto.ToString();
        }
    }
}
