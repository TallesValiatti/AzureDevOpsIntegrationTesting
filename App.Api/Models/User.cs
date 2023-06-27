namespace App.Api.Models;
public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }
}