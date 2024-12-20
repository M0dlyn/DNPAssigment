﻿namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }

        public User() {} // Public constructor for EFC
    }
}