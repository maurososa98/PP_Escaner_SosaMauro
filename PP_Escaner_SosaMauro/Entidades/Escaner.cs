﻿using System;
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

        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos,
        }
        public enum TipoDoc
        {
            libro,
            mapa
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            switch (tipo)
            {
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;
                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;
            }
        }

        #region Propiedades
        public List<Documento> ListaDocumentos
        {
            get => listaDocumentos;
        }
        public Departamento Locacion
        {
            get => locacion;
        }
        public string Marca
        {
            get => marca;
        }
        public TipoDoc Tipo
        {
            get => tipo;
        }
        #endregion

        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            if ((e.tipo == TipoDoc.libro && (d is Libro) || (e.tipo == TipoDoc.mapa && (d is Mapa))) &&
                !(e == d) &&
                d.Estado == Paso.Inicio &&
                e.CambiarEstadoDocumento(d))
            {
                e.listaDocumentos.Add(d);
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            foreach (Documento documento in e.listaDocumentos)
            {
                if (documento is Libro libro && d is Libro libroD && libro == libroD)
                {
                    retorno = true;
                    break;
                }
                else if (documento is Mapa mapa && d is Mapa mapaD && mapa == mapaD)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
    }
}