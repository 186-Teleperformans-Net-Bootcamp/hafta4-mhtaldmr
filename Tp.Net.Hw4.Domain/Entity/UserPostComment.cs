﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Net.Hw4.Domain.Entity
{
    public class UserPostComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int CommentTypeId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserPostId { get; set; }
        [ForeignKey("UserPostId")]
        public UserPost UserPost { get; set; }
    }
}