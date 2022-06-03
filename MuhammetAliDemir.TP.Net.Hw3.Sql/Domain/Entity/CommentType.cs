﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity
{
    public class CommentType
    {
        public int Id { get; set; }
        public int CommentTypeId { get; set; }

        [ForeignKey("CommentTypeId")]
        public UserPostComment UserPostComment { get; set; }

        public string CommentTypeName { get; set; }
    }
}
