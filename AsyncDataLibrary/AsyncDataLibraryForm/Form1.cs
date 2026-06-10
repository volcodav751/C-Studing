using AsyncDataLibrary.Models;
using AsyncDataLibrary.Services;

namespace AsyncDataLibraryForm;

public partial class Form1 : Form
{
    private readonly UserService _userService;
    private readonly BookService _bookService;
    private readonly OrderService _orderService;

    private readonly DataGridView _booksGrid = new();
    private readonly DataGridView _usersGrid = new();
    private readonly DataGridView _ordersGrid = new();

    private readonly TextBox _bookTitleTextBox = new();
    private readonly TextBox _bookAuthorTextBox = new();
    private readonly NumericUpDown _bookYearInput = new();

    private readonly TextBox _userNameTextBox = new();
    private readonly TextBox _userEmailTextBox = new();

    private readonly ComboBox _orderUserComboBox = new();
    private readonly ComboBox _orderBookComboBox = new();
    private readonly ComboBox _orderStatusComboBox = new();

    public Form1(UserService userService, BookService bookService, OrderService orderService)
    {
        _userService = userService;
        _bookService = bookService;
        _orderService = orderService;

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "AsyncDataLibrary UI";
        Width = 1000;
        Height = 650;
        StartPosition = FormStartPosition.CenterScreen;

        var tabs = new TabControl
        {
            Dock = DockStyle.Fill
        };

        tabs.TabPages.Add(CreateBooksTab());
        tabs.TabPages.Add(CreateUsersTab());
        tabs.TabPages.Add(CreateOrdersTab());

        Controls.Add(tabs);
        Load += Form1_Load;
    }

    private TabPage CreateBooksTab()
    {
        var tab = new TabPage("Книги");
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2
        };

        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var inputPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            Padding = new Padding(10)
        };

        _bookTitleTextBox.Width = 180;
        _bookAuthorTextBox.Width = 180;
        _bookYearInput.Width = 90;
        _bookYearInput.Minimum = 0;
        _bookYearInput.Maximum = 3000;
        _bookYearInput.Value = DateTime.Now.Year;

        var addButton = new Button { Text = "Додати книгу", AutoSize = true };
        var deleteButton = new Button { Text = "Видалити вибрану", AutoSize = true };
        var refreshButton = new Button { Text = "Оновити", AutoSize = true };

        addButton.Click += AddBookButton_Click;
        deleteButton.Click += DeleteBookButton_Click;
        refreshButton.Click += RefreshButton_Click;

        inputPanel.Controls.Add(new Label { Text = "Назва:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_bookTitleTextBox);
        inputPanel.Controls.Add(new Label { Text = "Автор:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_bookAuthorTextBox);
        inputPanel.Controls.Add(new Label { Text = "Рік:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_bookYearInput);
        inputPanel.Controls.Add(addButton);
        inputPanel.Controls.Add(deleteButton);
        inputPanel.Controls.Add(refreshButton);

        ConfigureGrid(_booksGrid);

        panel.Controls.Add(inputPanel, 0, 0);
        panel.Controls.Add(_booksGrid, 0, 1);
        tab.Controls.Add(panel);
        return tab;
    }

    private TabPage CreateUsersTab()
    {
        var tab = new TabPage("Користувачі");
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2
        };

        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var inputPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            Padding = new Padding(10)
        };

        _userNameTextBox.Width = 220;
        _userEmailTextBox.Width = 220;

        var addButton = new Button { Text = "Додати користувача", AutoSize = true };
        var deleteButton = new Button { Text = "Видалити вибраного", AutoSize = true };
        var refreshButton = new Button { Text = "Оновити", AutoSize = true };

        addButton.Click += AddUserButton_Click;
        deleteButton.Click += DeleteUserButton_Click;
        refreshButton.Click += RefreshButton_Click;

        inputPanel.Controls.Add(new Label { Text = "ПІБ:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_userNameTextBox);
        inputPanel.Controls.Add(new Label { Text = "Email:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_userEmailTextBox);
        inputPanel.Controls.Add(addButton);
        inputPanel.Controls.Add(deleteButton);
        inputPanel.Controls.Add(refreshButton);

        ConfigureGrid(_usersGrid);

        panel.Controls.Add(inputPanel, 0, 0);
        panel.Controls.Add(_usersGrid, 0, 1);
        tab.Controls.Add(panel);
        return tab;
    }

    private TabPage CreateOrdersTab()
    {
        var tab = new TabPage("Замовлення");
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2
        };

        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var inputPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            Padding = new Padding(10)
        };

        _orderUserComboBox.Width = 180;
        _orderBookComboBox.Width = 220;
        _orderStatusComboBox.Width = 130;
        _orderStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _orderStatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));

        var addButton = new Button { Text = "Створити замовлення", AutoSize = true };
        var statusButton = new Button { Text = "Змінити статус", AutoSize = true };
        var deleteButton = new Button { Text = "Видалити вибране", AutoSize = true };
        var refreshButton = new Button { Text = "Оновити", AutoSize = true };

        addButton.Click += AddOrderButton_Click;
        statusButton.Click += ChangeOrderStatusButton_Click;
        deleteButton.Click += DeleteOrderButton_Click;
        refreshButton.Click += RefreshButton_Click;

        inputPanel.Controls.Add(new Label { Text = "Користувач:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_orderUserComboBox);
        inputPanel.Controls.Add(new Label { Text = "Книга:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_orderBookComboBox);
        inputPanel.Controls.Add(new Label { Text = "Статус:", AutoSize = true, TextAlign = ContentAlignment.MiddleCenter });
        inputPanel.Controls.Add(_orderStatusComboBox);
        inputPanel.Controls.Add(addButton);
        inputPanel.Controls.Add(statusButton);
        inputPanel.Controls.Add(deleteButton);
        inputPanel.Controls.Add(refreshButton);

        ConfigureGrid(_ordersGrid);

        panel.Controls.Add(inputPanel, 0, 0);
        panel.Controls.Add(_ordersGrid, 0, 1);
        tab.Controls.Add(panel);
        return tab;
    }

    private static void ConfigureGrid(DataGridView grid)
    {
        grid.Dock = DockStyle.Fill;
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private async void Form1_Load(object? sender, EventArgs e)
    {
        await RefreshAllAsync();
    }

    private async void RefreshButton_Click(object? sender, EventArgs e)
    {
        await RefreshAllAsync();
    }

    private async void AddBookButton_Click(object? sender, EventArgs e)
    {
        try
        {
            var book = new Book
            {
                Title = _bookTitleTextBox.Text.Trim(),
                Author = _bookAuthorTextBox.Text.Trim(),
                Year = (int)_bookYearInput.Value,
                IsAvailable = true
            };

            await _bookService.AddAsync(book);
            _bookTitleTextBox.Clear();
            _bookAuthorTextBox.Clear();
            await RefreshAllAsync();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private async void DeleteBookButton_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedId(_booksGrid);
        if (id is null)
        {
            ShowError("Виберіть книгу для видалення.");
            return;
        }

        await _bookService.DeleteAsync(id.Value);
        await RefreshAllAsync();
    }

    private async void AddUserButton_Click(object? sender, EventArgs e)
    {
        try
        {
            var user = new User
            {
                FullName = _userNameTextBox.Text.Trim(),
                Email = _userEmailTextBox.Text.Trim()
            };

            await _userService.AddAsync(user);
            _userNameTextBox.Clear();
            _userEmailTextBox.Clear();
            await RefreshAllAsync();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private async void DeleteUserButton_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedId(_usersGrid);
        if (id is null)
        {
            ShowError("Виберіть користувача для видалення.");
            return;
        }

        await _userService.DeleteAsync(id.Value);
        await RefreshAllAsync();
    }

    private async void AddOrderButton_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_orderUserComboBox.SelectedValue is not int userId || _orderBookComboBox.SelectedValue is not int bookId)
            {
                ShowError("Спочатку додайте користувача та книгу.");
                return;
            }

            var order = new Order
            {
                UserId = userId,
                BookId = bookId,
                CreatedAt = DateTime.Now,
                Status = _orderStatusComboBox.SelectedItem is OrderStatus status ? status : OrderStatus.Created
            };

            await _orderService.AddAsync(order);
            await RefreshAllAsync();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private async void ChangeOrderStatusButton_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedId(_ordersGrid);
        if (id is null)
        {
            ShowError("Виберіть замовлення для зміни статусу.");
            return;
        }

        OrderStatus status = _orderStatusComboBox.SelectedItem is OrderStatus selectedStatus
            ? selectedStatus
            : OrderStatus.Created;

        await _orderService.ChangeStatusAsync(id.Value, status);
        await RefreshAllAsync();
    }

    private async void DeleteOrderButton_Click(object? sender, EventArgs e)
    {
        int? id = GetSelectedId(_ordersGrid);
        if (id is null)
        {
            ShowError("Виберіть замовлення для видалення.");
            return;
        }

        await _orderService.DeleteAsync(id.Value);
        await RefreshAllAsync();
    }

    private async Task RefreshAllAsync()
    {
        List<Book> books = await _bookService.GetAllAsync();
        List<User> users = await _userService.GetAllAsync();
        List<Order> orders = await _orderService.GetAllAsync();

        _booksGrid.DataSource = null;
        _booksGrid.DataSource = books;

        _usersGrid.DataSource = null;
        _usersGrid.DataSource = users;

        _ordersGrid.DataSource = null;
        _ordersGrid.DataSource = orders;

        _orderUserComboBox.DataSource = null;
        _orderUserComboBox.DisplayMember = nameof(User.FullName);
        _orderUserComboBox.ValueMember = nameof(User.Id);
        _orderUserComboBox.DataSource = users;

        _orderBookComboBox.DataSource = null;
        _orderBookComboBox.DisplayMember = nameof(Book.Title);
        _orderBookComboBox.ValueMember = nameof(Book.Id);
        _orderBookComboBox.DataSource = books;
    }

    private static int? GetSelectedId(DataGridView grid)
    {
        if (grid.CurrentRow?.DataBoundItem is null)
        {
            return null;
        }

        object? value = grid.CurrentRow.Cells[nameof(Book.Id)]?.Value;
        return value is int id ? id : null;
    }

    private static void ShowError(string message)
    {
        MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
