﻿// CreateCommentDto.cs
namespace ApiContracts
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}