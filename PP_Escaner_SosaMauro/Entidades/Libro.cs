﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        #region Propiedades
        public string ISBN { get => this.NumNormalizado; }
        public int NumPaginas { get => numPaginas; }
        #endregion

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        public static bool operator ==(Libro l1, Libro l2)
        {
            return (l1.Barcode == l2.Barcode) ||
                   (l1.ISBN == l2.ISBN) ||
                   ((l1.Titulo == l2.Titulo) && (l1.Autor == l2.Autor));
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine(base.ToString());
            texto.AppendLine($"Número de páginas: {this.numPaginas}");

            return texto.ToString();
        }
    }
}
