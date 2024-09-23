// See https://aka.ms/new-console-template for more information
using CLI.UI;
using FileRepositories;
using RepositoryContracts;


Console.WriteLine("Starting CLI app....");
IUserRepository userRepository = new UserFileRepository();
ICommentRepository commentRepository = new CommentFileRepository();
IPostRepository postRepository = new PostFileRepository();
ISubForumRepository subForumRepository = new SubForumFileRepository();

CliApp cliApp = new CliApp( userRepository, commentRepository, postRepository, subForumRepository );
await cliApp.StartAsync();