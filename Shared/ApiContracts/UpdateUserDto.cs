﻿namespace ApiContracts;

public class UpdateUserDto
{
    public  string Username { get; set; }
    public  string Password { get; set; }

    public string Name { get; set; }
    public int Id { get; set; }
}