using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LSFDictionary.Models
{
    [Table("Jeux")]
    public class Score : IComparable<Score>
    {
        public int Id { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public int Niveau { get; set; }
        [Required]
        public string Cate { get; set; }
        [Required]
        public int Value { get; set; }

        int IComparable<Score>.CompareTo(Score other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);

        }
    }
}