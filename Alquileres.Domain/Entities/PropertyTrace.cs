﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquileres.Domain
{
    /// <summary>
    /// Seguimiento Propiedad
    /// </summary>
    public class PropertyTrace
    {
        /// <summary>
        /// Id seguimiento propiedad
        /// </summary>
        [Key]
        public string IdPropertyTrace { get; set; }

        /// <summary>
        /// Fecha Venta
        /// </summary>
        public DateTime DateSale { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Impuesto
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Id Propiedad (FK)
        /// </summary>
        [ForeignKey("Property")]
        public string IdProperty { get; set; }

        public virtual Property Properties { get; set; }
    }
}