var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new();
users.Add(new(1,"User 1"));
users.Add(new(2,"User 2"));
users.Add(new(3,"User 3"));

app.MapGet("/users", GetUsers);
app.MapGet("/users/{id}", GetUser);
app.MapPost("/users", PostUser);
app.MapDelete("/users/{id}", DeleteUser);

app.Run();

async Task
DeleteUser(int id)
{
    users.Remove(users.Find((user)=>user.Id == id));
}

async Task
PostUser(User user)
{
    users.Add(user);
}

async Task<List<User>>
GetUsers()
{
    return users; // return select * from users
}

async Task<User?>
GetUser(int id)
{
    User? user = users.Find((user)=>user.Id==id);

    return user; // return select * from users where id == userId
}


public record User(int Id, string Name);
