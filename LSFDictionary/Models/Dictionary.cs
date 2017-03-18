using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LSFDictionary.Models
{
    [Table("WordsDictionary")]
    public class Dictionary : IComparable<Dictionary>
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Cate { get; set; }
        [Required]
        public int Niveau { get; set; }
        [Required]
        public string FontAwe { get; set; }
        [Required]
        public int Valide { get; set; }

        public int CompareTo(Dictionary other)
        {
            if (other == null) return 1;
            return this.Key.CompareTo(other.Key);

        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
                        
            if ((System.Object)obj == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.Key==(String)obj);
        }

    }
}