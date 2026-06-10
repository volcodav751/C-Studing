using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Services;

namespace AsyncDataLibraryForm;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        var serializer = new JsonDataSerializer();
        var storageProvider = new FileStorageProvider(dataPath);

        var userRepository = new JsonRepository<User>(storageProvider, serializer);
        var bookRepository = new JsonRepository<Book>(storageProvider, serializer);
        var orderRepository = new JsonRepository<Order>(storageProvider, serializer);

        var userService = new UserService(userRepository);
        var bookService = new BookService(bookRepository);
        var orderService = new OrderService(orderRepository);

        Application.Run(new Form1(userService, bookService, orderService));
    }
}
