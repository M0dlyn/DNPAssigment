﻿namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }

    public Post(String title, String body, int userId)
    {
        this.Title = title;
        this.Body = body;
        this.UserId = userId;
    }
    
    public void Update(string title, string body)
    {
        this.Title = title;
        this.Body = body;
    }
}