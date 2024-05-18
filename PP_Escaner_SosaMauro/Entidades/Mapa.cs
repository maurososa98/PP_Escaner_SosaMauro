﻿using System;
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

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        #region Propiedades
        public int Alto
        {
            get => alto;
        }
        public int Ancho
        {
            get => ancho;
        }
        public int Superficie
        {
            get => this.alto * this.ancho;
        }
        #endregion

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return (m1.Barcode == m2.Barcode) ||
                   ((m1.Titulo == m2.Titulo) && (m1.Autor == m2.Autor) && (m1.Anio == m2.Anio) && (m1.Superficie == m2.Superficie));
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine(base.ToString());
            texto.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.Superficie} cm2");

            return texto.ToString();
        }
    }
}
