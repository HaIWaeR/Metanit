using DelegatesPractice.Models;

public static class SeedData
{
    public static readonly IReadOnlyList<Client> Clients;
    public static readonly IReadOnlyList<Order> Orders;

    static SeedData()
    {
        var ivanov = new Client    { Id = 1, Name = "Иванов Алексей",  City = "Москва",       RegisteredAt = new DateTime(2021, 3, 14), IsConstant = true };
        var petrova = new Client   { Id = 2, Name = "Петрова Мария",   City = "Казань",       RegisteredAt = new DateTime(2025, 11, 2), IsConstant = false };
        var sidorov = new Client   { Id = 3, Name = "Сидоров Дмитрий", City = "Москва",       RegisteredAt = new DateTime(2024, 6, 21), IsConstant = true };
        var kuznecova = new Client { Id = 4, Name = "Кузнецова Ольга", City = "Новосибирск",  RegisteredAt = new DateTime(2019, 9, 8),  IsConstant = false };
        var egorov = new Client    { Id = 5, Name = "Егоров Павел",    City = "Казань",       RegisteredAt = new DateTime(2026, 2, 17), IsConstant = true };
        var nikolaeva = new Client { Id = 6, Name = "Николаева Анна",  City = "Екатеринбург", RegisteredAt = new DateTime(2022, 12, 1), IsConstant = false };

        Clients = [ivanov, petrova, sidorov, kuznecova, egorov, nikolaeva];

        Orders =
        [
            new Order { Id = 1,  Client = ivanov,    Amount =  4500m, CreatedAt = new DateTime(2026, 1, 12),  Status = OrderStatus.Paid     },
            new Order { Id = 1,  Client = ivanov,    Amount = 10000m, CreatedAt = new DateTime(2026, 3, 5),   Status = OrderStatus.Paid     },
            new Order { Id = 1,  Client = ivanov,    Amount = 25400m, CreatedAt = new DateTime(2026, 5, 19),  Status = OrderStatus.New      },
            new Order { Id = 1,  Client = ivanov,    Amount =   990m, CreatedAt = new DateTime(2026, 8, 30),  Status = OrderStatus.Canceled },
            new Order { Id = 2,  Client = petrova,   Amount = 15750m, CreatedAt = new DateTime(2026, 2, 8),   Status = OrderStatus.Paid     },
            new Order { Id = 2,  Client = petrova,   Amount =  3200m, CreatedAt = new DateTime(2026, 4, 23),  Status = OrderStatus.New      },
            new Order { Id = 2,  Client = petrova,   Amount =   560m, CreatedAt = new DateTime(2026, 9, 1),   Status = OrderStatus.Canceled },
            new Order { Id = 3,  Client = sidorov,   Amount = 10000m, CreatedAt = new DateTime(2026, 6, 11),  Status = OrderStatus.New      },
            new Order { Id = 3,  Client = sidorov,   Amount =  7800m, CreatedAt = new DateTime(2026, 7, 2),   Status = OrderStatus.Canceled },
            new Order { Id = 4,  Client = kuznecova, Amount = 42000m, CreatedAt = new DateTime(2025, 12, 15), Status = OrderStatus.Paid     },
            new Order { Id = 4,  Client = kuznecova, Amount =  1250m, CreatedAt = new DateTime(2026, 3, 28),  Status = OrderStatus.Paid     },
            new Order { Id = 5,  Client = egorov,    Amount =  9999m, CreatedAt = new DateTime(2026, 5, 6),   Status = OrderStatus.New      },
            new Order { Id = 5,  Client = egorov,    Amount = 18300m, CreatedAt = new DateTime(2026, 8, 14),  Status = OrderStatus.Paid     },
        ];
    }
}