namespace ApiContracts
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
   
        public string Password { get; set; }

        public UserDto(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
        public UserDto()
        {
        }
    }
}