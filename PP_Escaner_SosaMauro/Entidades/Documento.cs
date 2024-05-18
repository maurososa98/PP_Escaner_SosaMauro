﻿using System;
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
        public int Anio
        {
            get => anio;
        }
        public string Autor
        {
            get => autor;
        }
        public string Barcode
        {
            get => barcode;
        }
        public Paso Estado
        {
            get => estado;
        }
        protected string NumNormalizado
        {
            get => numNormalizado;
        }
        public string Titulo
        {
            get => titulo;
        }
        #endregion

        public bool AvanzarEstado()
        {

            if (this.estado == Paso.Terminado)
            {
                return false;
            }

            this.estado += 1;

            return true;

            //bool retorno = true;
            //switch (this.estado)
            //{
            //    case Paso.Inicio:
            //        this.estado = Paso.Distribuido;
            //        break;
            //    case Paso.Distribuido:
            //        this.estado = Paso.EnEscaner;
            //        break;
            //    case Paso.EnEscaner:
            //        this.estado = Paso.EnRevision;
            //        break;
            //    case Paso.EnRevision:
            //        this.estado = Paso.Terminado;
            //        break;
            //    default:
            //        retorno = false;
            //        break;
            //}
            //return retorno;
        }
        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"\nTitulo: {this.titulo}");
            texto.AppendLine($"Autor: {this.autor}");
            texto.AppendLine($"Año: {this.anio}");
            if (this.numNormalizado != "")
            {
                texto.AppendLine($"ISBN: {this.numNormalizado}");
            }
            texto.Append($"Cód. de barras: {this.Barcode}");

            return texto.ToString();
        }
    }
}