using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        public enum TipoDoc { libro, mapa }

        /// <summary>
        /// Constructor de la clase <c>Escaner</c>.
        /// </summary>
        /// <param name="marca">Corresponde a la marca del escane.</param>
        /// <param name="tipo">Corresponde al tipo del escane.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            var mapeo = new Dictionary<TipoDoc, Departamento>
            {
                {TipoDoc.libro, Departamento.procesosTecnicos},
                {TipoDoc.mapa, Departamento.mapoteca}
            };

            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            this.locacion = mapeo.TryGetValue(tipo, out Departamento departamento) ? departamento : Departamento.nulo;
        }

        #region Propiedades
        /// <value> Propiedad ListaDocumentos corresponde a la lista de documentos contenidos en un escaner.</value>
        public List<Documento> ListaDocumentos { get => listaDocumentos; }

        /// <value> Propiedad Locacion corresponde a la locacion de un escaner (nulo, mapoteca, procesosTecnicos).</value>
        public Departamento Locacion { get => locacion; }

        /// <value> Propiedad Marca corresponde a la marca de un escaner.</value>
        public string Marca { get => marca; }

        /// <value> Propiedad Tipo corresponde al tipo de documento que puede escanear un escaner (libro, mapa).</value>
        public TipoDoc Tipo { get => tipo; }
        #endregion

        /// <summary>
        /// Cambia el estado del documento pasado por parametro.
        /// </summary>
        /// <param name="d">Corresponde a un documento, que se requiere cambiar de estado</param>
        /// <returns>True si se logra cambiar el estado del documento, False si no se logra</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            if (this == d && d.AvanzarEstado())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador <c>!=</c> que comprueba si no hay un documento igual en escaner.
        /// </summary>
        /// <param name="e">Escaner analizado</param>
        /// <param name="d">Documento analizado</param>
        /// <returns>True si no se logra encontrar el documento, False si se logra</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /// <summary>
        /// Sobrecarga del operador <c>+</c> que añade un documento al escaner.
        /// </summary>
        /// <param name="e">Escaner al cual se le va agregar un documento</param>
        /// <param name="d">Documento a ser agregado</param>
        /// <returns>True si se logra añadir el documento, False si no se logra</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            if ((e.tipo == TipoDoc.libro && (d is Libro) || (e.tipo == TipoDoc.mapa && (d is Mapa))) &&
                !(e == d) &&
                d.Estado == Paso.Inicio &&
                d.AvanzarEstado())
            {
                e.listaDocumentos.Add(d);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador <c>==</c> que comprueba si hay un documento igual en escaner.
        /// </summary>
        /// <param name="e">Escaner analizado</param>
        /// <param name="d">Documento analizado</param>
        /// <returns>True si se logra encontrar el documento, False si no se logra</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            foreach (Documento documento in e.listaDocumentos)
            {
                if ((documento is Libro libro && d is Libro libroD && libro == libroD) ||
                    (documento is Mapa mapa && d is Mapa mapaD && mapa == mapaD))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
    }
}
