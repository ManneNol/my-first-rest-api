var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<User> users = new();
users.add(new("User 1"));
users.add(new("User 2"));
users.add(new("User 3"));

app.MapGet("/users", GetUsers);
app.MapGet("/users/{index}", GetUser);
app.MapPost("/users", PostUser);

app.Run();

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

async Task<User>
GetUser(int index)
{
    User user = users[index];
    return user; // return select * from users where id == userId
}

public record User(string Name);

async Task<string>
UserPage(int userId)
{
    User user = QueryUser(userId);

    return $"""
            <p>Welcome, {user.name}!</p>
        """
}
