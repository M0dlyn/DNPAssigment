using CLI.UI.ManageSubForum;
using Entities;

namespace CLI.UI;

using FileRepositories;
using RepositoryContracts;

public class CliApp
{
    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    private readonly IPostRepository postRepository;
    private readonly ISubForumRepository subForumRepository;

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository,
        ISubForumRepository subForumRepository)
    {
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
        this.postRepository = postRepository;
        this.subForumRepository = subForumRepository;
    }

    public async Task StartAsync()
    {
        Console.WriteLine("CLI App started...");

        Console.WriteLine("Options:");
        Console.WriteLine("1. Add Post");
        Console.WriteLine("2. Delete Post");
        Console.WriteLine("3. Update Post");
        Console.WriteLine("4. Get Single Post");
        Console.WriteLine("5. List Posts");
        Console.WriteLine("6. Add User");
        Console.WriteLine("7. Delete User");
        Console.WriteLine("8. Update User");
        Console.WriteLine("9. Get Single User");
        Console.WriteLine("10. List Users");
        Console.WriteLine("11. Exit");

        var option = Console.ReadLine();

        User? user;
        switch (option)
        {
            case "1":
                Console.WriteLine("Enter post title:");
                var title = Console.ReadLine();
                Console.WriteLine("Enter post body:");
                var body = Console.ReadLine();
                Console.WriteLine("Enter user ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid userId))
                {
                    var post = new Post(title, body, userId);
                    await postRepository.AddAsync(post);
                    Console.WriteLine("Post added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid user ID.");
                }
                await StartAsync();
                break;
            case "2":
                Console.WriteLine("Enter post ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid postId))
                {
                    var post = await postRepository.GetSingleAsync(postId);
                    if (post != null)
                    {
                        await postRepository.DeleteAsync(postId);
                        Console.WriteLine("Post deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Post not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid post ID.");
                }
                await StartAsync();
                break;
            case "3":
                Console.WriteLine("Enter post ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid Id))
                {
                    var post = await postRepository.GetSingleAsync(Id);
                    if (post != null)
                    {
                        Console.WriteLine("Enter new title:");
                        var newTitle = Console.ReadLine();
                        Console.WriteLine("Enter new body:");
                        var newBody = Console.ReadLine();
                        post.Title = newTitle;
                        post.Body = newBody;
                        await postRepository.UpdateAsync(post);
                        Console.WriteLine("Post updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Post not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid post ID.");
                }
                await StartAsync();
                break;
            case "4":
                Console.WriteLine("Enter post ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    var post = await postRepository.GetSingleAsync(id);
                    if (post != null)
                    {
                        Console.WriteLine($"Post ID: {post.Id}");
                        Console.WriteLine($"Post Title: {post.Title}");
                        Console.WriteLine($"Post Body: {post.Body}");
                        Console.WriteLine($"Post User ID: {post.UserId}");

                        Console.WriteLine("Options:");
                        Console.WriteLine("a. Add Comment");
                        Console.WriteLine("b. Delete Comment");
                        Console.WriteLine("c. Update Comment");
                        Console.WriteLine("d. List Comments");
                        Console.WriteLine("e. Exit");
                        var choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "a":
                                Console.WriteLine("Enter comment body:");
                                var commentBody = Console.ReadLine();
                                Console.WriteLine("Enter user ID:");
                                if (Guid.TryParse(Console.ReadLine(), out Guid commentUserId))
                                {
                                    var comment = new Comment();
                                    await commentRepository.AddAsync(comment);
                                    Console.WriteLine("Comment added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid user ID.");
                                }
                                break;
                            case "b":
                                Console.WriteLine("Enter comment ID:");
                                if (Guid.TryParse(Console.ReadLine(), out Guid deleteCommentId))
                                {
                                    var comment = await commentRepository.GetSingleAsync(deleteCommentId);
                                    if (comment != null)
                                    {
                                        await commentRepository.DeleteAsync(deleteCommentId);
                                        Console.WriteLine("Comment deleted successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Comment not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid comment ID.");
                                }
                                break;
                            case "c":
                                Console.WriteLine("Enter comment ID:");
                                if (Guid.TryParse(Console.ReadLine(), out Guid updateCommentId))
                                {
                                    var comment = await commentRepository.GetSingleAsync(updateCommentId);
                                    if (comment != null)
                                    {
                                        Console.WriteLine("Enter new comment body:");
                                        var newCommentBody = Console.ReadLine();
                                        comment.Body = newCommentBody;
                                        await commentRepository.UpdateAsync(comment);
                                        Console.WriteLine("Comment updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Comment not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid comment ID.");
                                }
                                break;
                            case "d":
                                Console.WriteLine("Listing comments...");
                                foreach (var comment in await commentRepository.GetAllAsync())
                                {
                                    Console.WriteLine($"Comment ID: {comment.Id}");
                                    Console.WriteLine($"Comment Body: {comment.Body}");
                                    Console.WriteLine($"Comment User ID: {comment.UserId}");
                                    Console.WriteLine();
                                }
                                break;
                            case "e":
                                Console.WriteLine("Exiting...");
                                return;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Post not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid post ID.");
                }
                await StartAsync();
                break;
            case "5":
                Console.WriteLine("Listing posts...");
                foreach (var post in await postRepository.GetAllAsync())
                {
                    Console.WriteLine($"Post ID: {post.Id}");
                    Console.WriteLine($"Post Title: {post.Title}");
                    Console.WriteLine($"Post Body: {post.Body}");
                    Console.WriteLine($"Post User ID: {post.UserId}");
                    Console.WriteLine();
                }
                await StartAsync();
                break;
            case "6":
                Console.WriteLine("Enter username:");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                var password = Console.ReadLine();
                user = new User();
                await userRepository.AddAsync(user);
                Console.WriteLine("User added successfully.");
                await StartAsync();
                break;
            case "7":
                Console.WriteLine("Enter user ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid deleteUserId))
                {
                    user = await userRepository.GetSingleAsync(deleteUserId);
                    if (user != null)
                    {
                        await userRepository.DeleteAsync(deleteUserId);
                        Console.WriteLine("User deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid user ID.");
                }
                await StartAsync();
                break;
            case "8":
                Console.WriteLine("Enter user ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid updateUserId))
                {
                    user = await userRepository.GetSingleAsync(updateUserId);
                    if (user != null)
                    {
                        Console.WriteLine("Enter new username:");
                        var newUsername = Console.ReadLine();
                        Console.WriteLine("Enter new password:");
                        var newPassword = Console.ReadLine();
                        user.Name = newUsername;
                        user.Password = newPassword;
                        await userRepository.UpdateAsync(updateUserId, user);
                        Console.WriteLine("User updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid user ID.");
                }
                await StartAsync();
                break;
            case "9":
                Console.WriteLine("Enter user ID:");
                if (Guid.TryParse(Console.ReadLine(), out Guid getUserId))
                {
                    user = await userRepository.GetSingleAsync(getUserId);
                    if (user != null)
                    {
                        Console.WriteLine($"User ID: {user.Id}");
                        Console.WriteLine($"Username: {user.Name}");
                        Console.WriteLine($"Password: {user.Password}");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid user ID.");
                }
                await StartAsync();
                break;
            case "10":
                Console.WriteLine("Listing users...");
                foreach (var u in await userRepository.GetAllAsync())
                {
                    Console.WriteLine($"User ID: {u.Id}");
                    Console.WriteLine($"Username: {u.Name}");
                    Console.WriteLine();
                }
                await StartAsync();
                break;
            case "11":
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}