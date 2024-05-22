using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;

        /// <summary>
        /// Constructor de la clase <c>Mapa</c>.
        /// </summary>
        /// <param name="titulo">Corresponde al titulo del mapa</param>
        /// <param name="autor">Corresponde al autor del mapa</param>
        /// <param name="anio">Corresponde al año del documento</param>
        /// <param name="numNormalizado">Corresponde al numeronormalizado del mapa</param>
        /// <param name="codebar">Corresponde al codigo de barras del mapa</param>
        /// <param name="ancho">Corresponde al ancho del mapa</param>
        /// <param name="alto">Corresponde al alto del mapa</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        #region Propiedades

        /// <value> Propiedad Alto corresponde al alto del mapa</value>
        public int Alto { get => alto; }

        /// <value> Propiedad Ancho corresponde al ancho del mapa</value>
        public int Ancho { get => ancho; }

        /// <value> Propiedad Superficie corresponde a la superficie del mapa</value>
        public int Superficie { get => this.alto * this.ancho; }
        #endregion

        /// <summary>
        /// Sobrecarga del operador <c>!=</c> que comprueba que dos mapas no son iguales.
        /// </summary>
        /// <param name="m1">Primer mapa a analizar </param>
        /// <param name="m2">Segundo mapa a analizar</param>
        /// <returns>True si los mapas no tienen el mismo barcode o no tienen el mismo título y el mismo autor y el mismo año y la misma superficie, de lo contrario False </returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Sobrecarga del operador <c>==</c> que comprueba que dos mapas son iguales.
        /// </summary>
        /// <param name="m1">Primer mapa a analizar </param>
        /// <param name="m2">Segundo mapa a analizar</param>
        /// <returns>True si los mapas tienen el mismo barcode o tienen el mismo título y el mismo autor y el mismo año y la misma superficie, de lo contrario False </returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return (m1.Barcode == m2.Barcode) ||
                   ((m1.Titulo == m2.Titulo) && (m1.Autor == m2.Autor) && (m1.Anio == m2.Anio) && (m1.Superficie == m2.Superficie));
        }

        /// <summary>
        /// Guarda en una cadena todos los datos del mapa.
        /// </summary>
        /// <returns> Un string con los datos correspondientes al mapa.</returns>
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine(base.ToString());
            texto.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.Superficie} cm2");

            return texto.ToString();
        }
    }
}
